using System;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using AuthenticatorProject.Encryption;
using Yubico.YubiKey;
using Yubico.YubiKey.Otp;
using Yubico.YubiKey.Otp.Operations;
using System.Collections.Generic;
using System.IO;
using System.Drawing;

namespace AuthenticatorProject {
    /// <summary>
    /// Interface used to get a vault path and the security parameters.
    /// </summary>
    public partial class FrmVault : Form {
        /// <summary>
        /// Path to the vault file.
        /// </summary>
        public string VaultPath { get;set;}
        /// <summary>
        /// Flag indicating if this is to save a file or to open one.
        /// </summary>
        private bool ForOpen { get; set; }
        /// <summary>
        /// Access control to the file: either setting (save the file) or using to access existing file.
        /// </summary>
        public AccessControl AccessControl { get; set; }
        // Positioning parameters.
        private int PositionLeft { get; set; }
        private int PositionTop { get; set; }
        public object Devices { get; private set; }

        private List<string> currentKeys;

        #region "Form Events"
        /// <summary>
        /// Constructing the interface.
        /// </summary>
        /// <param name="path">The file path that was provided to open.</param>
        /// <param name="forOpen">If true, opening existing file. Otherwise creating a new one.</param>
        /// <param name="left">Positioning parameter.</param>
        /// <param name="top">Positioning parameter.</param>
        public FrmVault(string path, bool forOpen, int left, int top) {
            InitializeComponent();
            // Drop-down of recently opened files.
            CboPath.Text = path;
            if (Properties.Settings.Default.Recent1 != "" && Properties.Settings.Default.Recent1 != path)
                CboPath.Items.Add(Properties.Settings.Default.Recent1);
            if (Properties.Settings.Default.Recent2 != "" && Properties.Settings.Default.Recent2 != path)
                CboPath.Items.Add(Properties.Settings.Default.Recent2);
            if (Properties.Settings.Default.Recent3 != "" && Properties.Settings.Default.Recent3 != path)
                CboPath.Items.Add(Properties.Settings.Default.Recent3);
            if (Properties.Settings.Default.Recent4 != "" && Properties.Settings.Default.Recent4 != path)
                CboPath.Items.Add(Properties.Settings.Default.Recent4);

            this.ForOpen = forOpen;
            this.PositionLeft = left;
            this.PositionTop = top;

            if (ForOpen) {
                this.Text = "Provide path to vault file and security parameters";
                this.CboPath.Text = path;
            }
            else {
                this.Text = "Select path for the new vault and security parameters to apply";
            }
            this.currentKeys = new List<string>();
            RefreshListOfKeys();
        }
        // Positioning the form.
        private void FrmVault_Load(object sender, EventArgs e) {
            this.Left = this.PositionLeft;
            this.Top = this.PositionTop;

        }

        #endregion

        #region "Button Actions"
        private void BtnCancel_Click(object sender, EventArgs e) {
            this.Dispose();
        }
        // Validating the selection.
        private void BtnOK_Click(object sender, EventArgs e) {
            if (CboPath.Text != "") {
                // Acquire the security parameters.
                this.VaultPath = CboPath.Text;
                
                this.AccessControl = new Unprotected();
                if (TxtPasscode.Text != "") {
                    this.AccessControl.Add(new Password(TxtPasscode.Text));
                }

                if (TxtKeyFile.Text != "") {
                    this.AccessControl.Add(new KeyFile(TxtKeyFile.Text));
                }

                if (TxtYubikeyResponse.Text != "") {
                    this.AccessControl.Add(new YubikeyChallengeResponse(TxtYubikeyResponse.Text));
                }

                if (CboUsbSecurityKeys.SelectedIndex >= 0) {
                    this.AccessControl.Add(new UsbSecurityKey(CboUsbSecurityKeys.Text));
                }

                this.Close();
            }
            else {
                MessageBox.Show(this, "Select the path to the vault", "File Not Specified", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        // Browsing for the file to open.
        private void BtnBrowse_Click(object sender, EventArgs e) {
            OpenFileDialog.InitialDirectory = Properties.Settings.Default.VaultDirectory;
            if (ForOpen) {
                if (OpenFileDialog.ShowDialog(this) == DialogResult.OK) {
                    CboPath.Text = OpenFileDialog.FileName;
                }
            }
            else {
                if (NewFileDialog.ShowDialog(this) == DialogResult.OK) {
                    CboPath.Text = NewFileDialog.FileName;
                }
            }
        }
        // Browsing for the key file to use.
        private void BtnKeySelection_Click(object sender, EventArgs e) {
            OpenFileDialog.InitialDirectory = Properties.Settings.Default.VaultDirectory;
            if (OpenKeyDialog.ShowDialog(this) == DialogResult.OK) {
                TxtKeyFile.Text = OpenKeyDialog.FileName;
            }
        }

        // Generating a response to a challenge from a yubikey.
        private void BtnYubikey_Click(object sender, EventArgs e) {
            try {
                int slot = Properties.Settings.Default.YubikeySlot;
                string challenge = Properties.Settings.Default.YubikeyChallenge;

                IYubiKeyDevice key = null;
                foreach (IYubiKeyDevice dev in YubiKeyDevice.FindAll()) {
                    key = dev;
                }
                if (key == null)
                    return;
                OtpSession otpSession = new OtpSession(key);
                CalculateChallengeResponse calc = otpSession.CalculateChallengeResponse(Slot.LongPress);
                calc.UseChallenge(Utilities.HexToByteArray(Properties.Settings.Default.YubikeyChallenge));
                calc.UseYubiOtp(false);
                calc.Execute();

                TxtYubikeyResponse.Text = Utilities.ByteArrayToHex(calc.GetDataBytes().ToArray());
            }
            catch (Exception ex) {
                MessageBox.Show(this, "An error occurred: " + ex.Message, "Unexpected Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region "Drag-Drop for File Names"

        private void CboPath_DragEnter(object sender, DragEventArgs e) {
            if (e.Data.GetDataPresent(DataFormats.FileDrop, false) == true) {
                e.Effect = DragDropEffects.Copy;
            }
        }

        private void CboPath_DragDrop(object sender, DragEventArgs e) {
            string[] files = (string[]) e.Data.GetData(DataFormats.FileDrop);
            if (files != null && files.Length != 0) {
                CboPath.Text = files[0];
            }
        }

        private void TxtKeyFile_DragDrop(object sender, DragEventArgs e) {
            string[] files = (string[]) e.Data.GetData(DataFormats.FileDrop);
            if (files != null && files.Length != 0) {
                TxtKeyFile.Text = files[0];
            }
        }

        private void TxtKeyFile_DragEnter(object sender, DragEventArgs e) {
            if (e.Data.GetDataPresent(DataFormats.FileDrop, false) == true) {
                e.Effect = DragDropEffects.Copy;
            }
        }

        private void TxtPasscode_DragEnter(object sender, DragEventArgs e) {
            if (e.Data.GetDataPresent(DataFormats.Text, false) == true) {
                e.Effect = DragDropEffects.Copy;
            }
        }

        private void TxtPasscode_DragDrop(object sender, DragEventArgs e) {
            string _password = (string) e.Data.GetData(DataFormats.Text);
            if (_password != null && _password.Length != 0) {
                TxtPasscode.Text = _password;
            }
        }

        #endregion

        #region "USB Security Key Handling"
        /// <summary>
        /// Find all the security keys connected to the system.
        /// </summary>
        private void RefreshListOfKeys() {
            List<string> temp = new List<string>();

            foreach (var drive in DriveInfo.GetDrives()) {
                if (File.Exists(drive.Name + UsbSecurityKey.KEY_FILE) && File.Exists(drive.Name + UsbSecurityKey.KEY_ID_FILE)) {
                    // This is a security key device. Get the identifier key.
                    string key_id = File.ReadAllText(drive.Name + UsbSecurityKey.KEY_ID_FILE);
                    temp.Add(key_id);
                }
            }

            // Any changes?
            if (temp.Count != currentKeys.Count) {
                currentKeys = temp;
                CboUsbSecurityKeys.Items.Clear();
                for (int i = 0; i < currentKeys.Count; i++)
                    CboUsbSecurityKeys.Items.Add(currentKeys[i]);
            }
        }
        /// <summary>
        /// Timer-based refresh of the list of keys.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TimerRefreshSecurityKeys_Tick(object sender, EventArgs e) {
            RefreshListOfKeys();
        }
        /// <summary>
        /// When clicked, the first key in order of appearance will be displayed in the list. Quick select.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnUSBKey_Click(object sender, EventArgs e) {
            if (CboUsbSecurityKeys.Items.Count > 0)
                CboUsbSecurityKeys.SelectedIndex = 0;
        }

        #endregion
        /// <summary>
        /// Bring up the password management interface.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnPassword_Click(object sender, EventArgs e) {
            // Someone wants to use the password interface.
            FrmPassword frmPassword = new FrmPassword(this.Left + 25, this.Top + 25, TxtPasscode.Text);
            if (frmPassword.ShowDialog(this) == DialogResult.OK) {
                TxtPasscode.Text = frmPassword.Password;
            }
        }
        /// <summary>
        /// When the password changes, refresh the elements of the interface.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TxtPasscode_TextChanged(object sender, EventArgs e) {
            if (TxtPasscode.Text == "") {
                LblStrength.BackColor = Color.White;
                LblStrength.Text = "";
            }
            else {
                double entropy = PasswordUtilities.CalculateEntropy(TxtPasscode.Text);
                int nb = PasswordUtilities.NbFoundOccurrences(TxtPasscode.Text);

                LblStrength.BackColor = PasswordUtilities.GetColor(entropy, nb);
                LblStrength.Text = PasswordUtilities.GetDescription(entropy, nb);
            }
            
        }
    }
}
