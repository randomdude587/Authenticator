using AuthenticatorProject.Encryption;
using System;
using System.IO;
using System.Windows.Forms;

namespace AuthenticatorProject {
    /// <summary>
    /// Tool for the management of USB Security Keys.
    /// </summary>
    public partial class FrmUsbSecuritKey : Form {
        // Positioning parameters.
        private int PositionLeft;
        private int PositionTop;
        // All the keys currently detected in all the drives.
        private UsbSecurityKey[] allKeys;

        #region "Form Events"

        /// <summary>
        /// Instantiate the interface.
        /// </summary>
        /// <param name="left"></param>
        /// <param name="top"></param>
        public FrmUsbSecuritKey(int left, int top) {
            InitializeComponent();
            this.PositionLeft = left;
            this.PositionTop = top;
            RefreshListOfKeys();
        }

        private void FrmUsbSecuritKey_Load(object sender, EventArgs e) {
            this.Left = PositionLeft;
            this.Top = PositionTop;
        }

        #endregion

        #region "Control Events"

        private void BtnOK_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void BtnRefresh_Click(object sender, EventArgs e) {
            RefreshListOfKeys();
        }

        private void BtnGenerate_Click(object sender, EventArgs e) {
            try {
                if (CboDrives.SelectedIndex >= 0) {
                    if (MessageBox.Show(this, "This will overwrite any existing USB Security Key files on the device. Continue?",
                        "Overwriting Key", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes) {
                        UsbSecurityKey newKey = UsbSecurityKey.GenerateNew(CboDrives.Text.Substring(0, 3), TxtKeyIdentifier.Text, TxtNewVolumeLabel.Text);

                        if (newKey != null) {
                            MessageBox.Show(this, "The USB Security Key was successfully generated", "Successful Operation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
                else {
                    MessageBox.Show(this, "Please select the drive on which to create the USB Security Key", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex) {
                MessageBox.Show(this, "An error occurred: " + ex.Message, "Unexpected Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        // Provide a list of removable drives found on the system.
        private void CboDrives_DropDown(object sender, EventArgs e) {
            // Refresh the list of drives on every drop down.
            CboDrives.Items.Clear();

            foreach (var drive in DriveInfo.GetDrives()) {
                if (drive.DriveType == DriveType.Removable) {
                    double freeSpace = drive.TotalFreeSpace;
                    double totalSpace = drive.TotalSize;
                    double percentFree = (freeSpace / totalSpace) * 100;
                    float num = (float) percentFree;

                    CboDrives.Items.Add(drive.Name + " (" + drive.VolumeLabel + ") " + num.ToString("0.0") + "% remaining");
                }
            }
        }

        #endregion

        #region "USB Key Management"

        // Get the list of all the USB security keys.
        private void RefreshListOfKeys() {
            allKeys = UsbSecurityKey.GetAllDetectedKeys(); ;

            CboSecurityKeys.Items.Clear();
            if (allKeys == null)
                return;

            foreach (UsbSecurityKey key in allKeys) 
                CboSecurityKeys.Items.Add(key.Identifier);
                
            CboSecurityKeys.SelectedIndex = 0;
        }
        // Display the details of the currently selected key in the drop-down list.
        private void CboSecurityKeys_SelectedIndexChanged(object sender, EventArgs e) {
            try {
                UsbSecurityKey key = allKeys[CboSecurityKeys.SelectedIndex];
                TxtDrive.Text = key.DriveName;
                TxtVolumeLabel.Text = key.VolumeLabel;
                TxtContainsKey.Text = key.Identifier;
            }
            catch (Exception ex) {
                MessageBox.Show(this, "An error occurred: " + ex.Message, "Unexpected Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        // If the user is selecting a drive, it is to generate a new key. Provide current details.
        private void CboDrives_SelectedIndexChanged(object sender, EventArgs e) {
            try {
                // Fill with current data.
                foreach (var drive in DriveInfo.GetDrives()) {
                    if (drive.Name == CboDrives.Text.Substring(0, 3)) {
                        TxtNewVolumeLabel.Text = drive.VolumeLabel;
                        if (File.Exists(drive.Name + UsbSecurityKey.KEY_ID_FILE))
                            TxtKeyIdentifier.Text = File.ReadAllText(drive.Name + UsbSecurityKey.KEY_ID_FILE);
                        else
                            TxtKeyIdentifier.Text = drive.VolumeLabel;
                    }
                }
            }
            catch (Exception ex) {
                MessageBox.Show(this, "An error occurred: " + ex.Message, "Unexpected Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion
    }
}
