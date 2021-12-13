using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Yubico.YubiKey;
using Yubico.YubiKey.Otp;
using Yubico.YubiKey.Otp.Operations;
using Yubico.Core.Devices.Hid;

namespace AuthenticatorProject {
    /// <summary>
    /// Interface to manage settings to use a yubikey.
    /// </summary>
    public partial class FrmYubikey : Form {
        private List<IYubiKeyDevice> Devices { get; set; }
        // Position parameters.
        private int PositionLeft { get; set; }
        private int PositionTop { get; set; }

        #region "Form Events"

        /// <summary>
        /// Construct the interface.
        /// </summary>
        /// <param name="left">Left position.</param>
        /// <param name="top">Top position.</param>
        public FrmYubikey(int left, int top) {
            InitializeComponent();
            this.PositionLeft = left;
            this.PositionTop = top;
            this.Devices = new List<IYubiKeyDevice>();
        }
        // Fill the interface with current settings.
        private void FrmYubikey_Load(object sender, EventArgs e) {
            this.Left = PositionLeft;
            this.Top = PositionTop;
            CboKeyboard.SelectedIndex = 0;

            // Load Yubikey preferences.
            TxtChallenge.Text = Properties.Settings.Default.YubikeyChallenge;
            CboSlots.SelectedIndex = Properties.Settings.Default.YubikeySlot - 1;
            
            GetDevices();
            RefreshInterface();
        }

        // When closing the form, clear all the data.
        private void FrmYubikey_FormClosing(object sender, FormClosingEventArgs e) {
            FrmPIN.ClearData();
        }

        #endregion

        #region "Yubikey Management"

        private void RefreshInterface() {
            bool deviceSelected = (CboYubikeys.Items.Count > 0 && CboYubikeys.SelectedIndex >= 0);
            
            // A Yubikey was found and selected.
            CboChallengeSlot.Enabled = deviceSelected;
                        
        }

        private void GetDevices() {
            CboYubikeys.Items.Clear();
            // Load the interface.
            foreach (IYubiKeyDevice device in YubiKeyDevice.FindAll()) {
                Devices.Add(device);
                CboYubikeys.Items.Add(device.FormFactor.ToString() + " - Serial: " + device.SerialNumber + " - Version " + device.FirmwareVersion.Major + "." + device.FirmwareVersion.Minor);
            }

            if (CboYubikeys.Items.Count > 0)
                CboYubikeys.SelectedIndex = 0;
        }

        private void BtnApplyPassword_Click(object sender, EventArgs e) {
            if (CboYubikeys.Items.Count == 0) {
                MessageBox.Show(this, "You must select a Yubikey for the operation", "No Yubikey Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (CboPasswordSlot.SelectedIndex == -1) {
                MessageBox.Show(this, "You must select a the slot for the operation", "No Slot Selected", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int slot;
            if (CboPasswordSlot.SelectedIndex == 0) {
                slot = 1;
            }
            else {
                slot = 2;
            }
            string message;
            if (OptNewPassword.Checked)
                message = "This will overwrite the configuration on slot " + slot + " and replace it with a new static password. Continue?";
            else
                message = "This will overwrite the configuration on slot " + slot + " and replace it with the user-defined password. Continue ? ";

            DialogResult result = MessageBox.Show(this, message, "Configuration Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.No)
                return;
            // Apply the configuration.
            OtpSession otpSession = new OtpSession(Devices[CboYubikeys.SelectedIndex]);
            ConfigureStaticPassword password;
            if (slot == 1)
                password = otpSession.ConfigureStaticPassword(Slot.ShortPress);
            else
                password = otpSession.ConfigureStaticPassword(Slot.LongPress);

            password.AppendCarriageReturn(false);
            password.AppendTabToFixed(false);
            password.UseFastTrigger(true);

            if (OptNewPassword.Checked) {
                char[] key = new char[(int) NumPasswordLength.Value];
                password.GeneratePassword(new Memory<char>(key));

                if (CboKeyboard.SelectedIndex == 0)
                    password.WithKeyboard(KeyboardLayout.ModHex);
                else
                    password.WithKeyboard(KeyboardLayout.en_US);
            }
            else {
                char[] key = TxtPassword.Text.ToCharArray();

                password.WithKeyboard(KeyboardLayout.en_US);
                password.SetPassword(key);
            }

            password.Execute();

            MessageBox.Show(this, "The static password was successfully applied in slot " + slot, "Successful Operation", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BtnApplyPrivateKey_Click(object sender, EventArgs e) {
            if (CboYubikeys.Items.Count == 0) {
                MessageBox.Show(this, "You must select a Yubikey for the operation", "No Yubikey Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (CboChallengeSlot.SelectedIndex == -1) {
                MessageBox.Show(this, "You must select a the slot for the operation", "No Slot Selected", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int slot;
            if (CboChallengeSlot.SelectedIndex == 0) {
                slot = 1;
            }
            else {
                slot = 2;
            }
            string message;
            if (OptNewKey.Checked)
                message = "This will overwrite the configuration on slot " + slot + " and replace it with a new private key for challenge-response. Continue?";
            else
                message = "This will overwrite the configuration on slot " + slot + " and replace it with the user-defined private key. Continue ? ";

            DialogResult result = MessageBox.Show(this, message, "Configuration Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.No)
                return;
            // Apply the configuration.
            OtpSession otpSession = new OtpSession(Devices[CboYubikeys.SelectedIndex]);

            ConfigureChallengeResponse challResp;
            if (slot == 1)
                challResp = otpSession.ConfigureChallengeResponse(Slot.ShortPress);
            else
                challResp = otpSession.ConfigureChallengeResponse(Slot.LongPress);

            challResp.UseHmacSha1();
            challResp.UseButton(ChkTouch.Checked);

            if (OptDefinedKey.Checked)
                challResp.UseKey(Utilities.GetSha1(TxtPrivateKey.Text));
            else {
                byte[] key = new byte[20];
                challResp.GenerateKey(new Memory<byte>(key));
            }

            challResp.Execute();

            MessageBox.Show(this, "The challenge-response key was successfully applied in slot " + slot,
                "Successful Operation", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        #endregion

        #region "Control Events"

        private void BtnRefreshDevices_Click(object sender, EventArgs e) {
            GetDevices();
        }

        private void CboYubikeys_SelectedIndexChanged(object sender, EventArgs e) {
            RefreshInterface();
        }

        private void CboActions_SelectedIndexChanged(object sender, EventArgs e) {
            RefreshInterface();
        }

        private void BtnOK_Click(object sender, EventArgs e) {
            this.DialogResult = DialogResult.OK;
            Properties.Settings.Default.YubikeyChallenge = TxtChallenge.Text;
            Properties.Settings.Default.YubikeySlot = CboSlots.SelectedIndex + 1;


            Properties.Settings.Default.Save();
            this.Close();
        }

        private void BtnCancel_Click(object sender, EventArgs e) {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        #endregion

        #region "Yubikey Settings"

        private void OptNewPassword_CheckedChanged(object sender, EventArgs e) {
            NumPasswordLength.Enabled = OptNewPassword.Checked;
            CboKeyboard.Enabled = OptNewPassword.Checked;

            TxtPassword.Enabled = OptDefinedPassword.Checked;
        }

        private void OptNewKey_CheckedChanged(object sender, EventArgs e) {
            TxtPrivateKey.Enabled = OptDefinedKey.Checked;
        }

        private void BtnGenerate_Click(object sender, EventArgs e) {
            string alphabet = "0123456789ABCDEF";
            Random rnd = new Random();
            string newChallenge = "";
            for (int i = 0; i < 24; i++) {
                newChallenge += alphabet[rnd.Next(alphabet.Length)];
            }
            TxtChallenge.Text = newChallenge;
        }

        private void BtnTest_Click(object sender, EventArgs e) {
            try {
                OtpSession otpSession = new OtpSession(Devices[CboYubikeys.SelectedIndex]);
                CalculateChallengeResponse calc = otpSession.CalculateChallengeResponse(CboSlots.SelectedIndex == 0 ? Slot.ShortPress : Slot.LongPress);
                calc.UseChallenge(Utilities.HexToByteArray(TxtChallenge.Text));
                calc.UseYubiOtp(false);
                calc.Execute();

                LblResponse.Text = Utilities.ByteArrayToHex(calc.GetDataBytes().ToArray());
            }
            catch (Exception ex) {
                MessageBox.Show(this, "An error occurred: " + ex.Message, "Unexpected Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion
    }
}
