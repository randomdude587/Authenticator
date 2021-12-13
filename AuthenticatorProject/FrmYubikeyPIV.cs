using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Forms;
using AuthenticatorProject.Yubico;
using AuthenticatorProject.DigitalSignature;
using Yubico.YubiKey;
using Yubico.YubiKey.Piv;

namespace AuthenticatorProject {
    public partial class FrmYubikeyPIV : Form {
        private List<IYubiKeyDevice> Devices { get; set; }
        // Position parameters.
        private int PositionLeft { get; set; }
        private int PositionTop { get; set; }
        private static byte[] SlotNumbers = new byte[] {0x9A, 0x9C, 0x9D, 0x9E, 0x82, 0x83, 0x84, 0x85, 0x86, 0x87, 0x88,
                0x89, 0x8A, 0x8B, 0x8C, 0x8D, 0x8E, 0x8F, 0x90, 0x91, 0x92, 0x93, 0x94, 0x95};

        private YubikeyCertificate _yubikeyCert = null;

        public YubikeyCertificate YubikeyCertificate {
            get { return this._yubikeyCert; }
        }

        #region "Form Events"

        /// <summary>
        /// Construct the interface.
        /// </summary>
        /// <param name="left">Left position.</param>
        /// <param name="top">Top position.</param>
        public FrmYubikeyPIV(int left, int top) {
            InitializeComponent();
            this.PositionLeft = left;
            this.PositionTop = top;
            this.Devices = new List<IYubiKeyDevice>();
        }
        // Fill the interface with current settings.
        private void FrmYubikeyPIV_Load(object sender, EventArgs e) {
            this.Left = PositionLeft;
            this.Top = PositionTop;

            GetDevices();
            RefreshInterface();
        }

        private void FrmYubikeyPIV_FormClosing(object sender, FormClosingEventArgs e) {
            FrmPIN.ClearData();
        }

        #endregion

        #region "Yubikey Management"

        private void RefreshInterface() {
            bool deviceSelected = (CboYubikeys.Items.Count > 0 && CboYubikeys.SelectedIndex >= 0);
            BtnOK.Enabled = false;
            // A Yubikey was found and selected.
            CboCertSlots.Enabled = deviceSelected;

            bool slotSelected = (CboCertSlots.SelectedIndex > 0);
            BtnApplyCert.Enabled = slotSelected;
            BtnImport.Enabled = slotSelected;
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

        private void ShowCertificateStatus() {
            // Get the current status of the slot.

            this._yubikeyCert = new YubikeyCertificate(Devices[CboYubikeys.SelectedIndex].SerialNumber.ToString(), SlotNumbers[CboCertSlots.SelectedIndex]);
            
            if (this._yubikeyCert.InnerCertificate != null) {
                TxtSlotStatus.Text = "Contains certificate: " + _yubikeyCert.Implementation.Name;
                TxtCommonName.Text = _yubikeyCert.Subject.CN;
                BtnOK.Enabled = true;
            }
            else {
                TxtSlotStatus.Text = "Empty slot";
                TxtCommonName.Text = "";
                BtnOK.Enabled = false;
            }
        }

        #endregion

        #region "Control Events"

        private void BtnRefreshDevices_Click(object sender, EventArgs e) {
            GetDevices();
        }

        private void BtnCancel_Click(object sender, EventArgs e) {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void BtnOK_Click(object sender, EventArgs e) {
            this.DialogResult = DialogResult.OK;
        }

        private void TxtCertificatePath_DragEnter(object sender, DragEventArgs e) {
            if (e.Data.GetDataPresent(DataFormats.FileDrop, false) == true) {
                e.Effect = DragDropEffects.Copy;
            }
        }

        private void TxtCertificatePath_DragDrop(object sender, DragEventArgs e) {
            string[] files = (string[]) e.Data.GetData(DataFormats.FileDrop);
            if (files != null && files.Length != 0) {
                TxtCertificatePath.Text = files[0];
            }
        }

        #endregion

        #region "Yubikey Interaction"

        private void CboYubikeys_SelectedIndexChanged(object sender, EventArgs e) {
            RefreshInterface();
        }

        private void CboCertSlots_SelectedIndexChanged(object sender, EventArgs e) {
            RefreshInterface();
            ShowCertificateStatus();
        }

        private void BtnApplyCert_Click(object sender, EventArgs e) {
            if (CboYubikeys.Items.Count == 0) {
                MessageBox.Show(this, "You must select a Yubikey for the operation", "No Yubikey Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (TxtNewCommonName.Text == "") {
                MessageBox.Show(this, "You must provide a common name for the certificate", "No Common Name Provided", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult result = MessageBox.Show(this, "This will overwrite the configuration on slot " + CboCertSlots.Text + " and replace it with a new certificate. Continue?",
                    "Configuration Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.No)
                return;

            // Prepare the configuration.
            FrmPIN.Caller = this;
            PivAlgorithm algo;
            algo = PivAlgorithm.EccP256;
            
            var nameBuilder = new X500NameBuilder();
            nameBuilder.AddNameElement(X500NameElement.CommonName, TxtNewCommonName.Text);
            X500DistinguishedName sampleRootName = nameBuilder.GetDistinguishedName();

            SamplePivSlotContents slotContents = new SamplePivSlotContents();
            slotContents.Algorithm = algo;
            slotContents.SlotNumber = SlotNumbers[CboCertSlots.SelectedIndex];
            slotContents.PinPolicy = ChkCertPIN.Checked ? PivPinPolicy.Always : PivPinPolicy.Never;
            slotContents.TouchPolicy = ChkCertTouch.Checked ? PivTouchPolicy.Always : PivTouchPolicy.Never;

            // Apply the configuration.
            try {
                PivSession pivSession = new PivSession(Devices[CboYubikeys.SelectedIndex]);

                // Tell the key collector interface who is calling: this is for Dialog and positioning purposes.
                pivSession.KeyCollector = FrmPIN.GetCredential;   // Use the delegate.

                // Generate the certificate.
                PivPublicKey pubKey = pivSession.GenerateKeyPair(SlotNumbers[CboCertSlots.SelectedIndex], algo, ChkCertPIN.Checked ? PivPinPolicy.Always : PivPinPolicy.Never,
                    ChkCertTouch.Checked ? PivTouchPolicy.Always : PivTouchPolicy.Never);

                slotContents.PublicKey = pubKey;
                YubiKeySignatureGenerator gen = new YubiKeySignatureGenerator(pivSession, SlotNumbers[CboCertSlots.SelectedIndex], pubKey);

                CertificateOperations.GetCertRequest(Devices[CboYubikeys.SelectedIndex], FrmPIN.GetCredential, sampleRootName, slotContents);

                // Add the BasicConstraints and KeyUsage extensions.
                var basicConstraints = new X509BasicConstraintsExtension(true, true, 2, true);
                var keyUsage = new X509KeyUsageExtension(X509KeyUsageFlags.KeyCertSign, true);

                DateTimeOffset notBefore = DateTimeOffset.Now;
                DateTimeOffset notAfter = notBefore.AddDays(3650);
                byte[] serialNumber = new byte[] { 0x01 };

                var signer = new YubiKeySignatureGenerator(pivSession, slotContents.SlotNumber, slotContents.PublicKey);
                X509Certificate2 selfSignedCert = slotContents.CertRequest.Create(sampleRootName, signer, notBefore, notAfter, serialNumber);

                // Authenticate to the key.
                pivSession.AuthenticateManagementKey();

                // Store the certificate next to the private key in the Yubikey Slot.
                pivSession.ImportCertificate(SlotNumbers[CboCertSlots.SelectedIndex], selfSignedCert);
                // Update the display.
                ShowCertificateStatus();
                pivSession.Connection.Dispose();
                MessageBox.Show(this, "A new certificate was successfully generated in slot " + CboCertSlots.Text,
                    "Successful Operation", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex) {
                MessageBox.Show(this, "Error encountered: " + ex.Message, "Configuration Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnImport_Click(object sender, EventArgs e) {
            // Want to import a PKCS12 file into a slot of the Yubikey.
            try {
                PivSession pivSession = new PivSession(Devices[CboYubikeys.SelectedIndex]);
                FrmPIN.Caller = this;
                // Tell the key collector interface who is calling: this is for Dialog and positioning purposes.
                pivSession.KeyCollector = FrmPIN.GetCredential;   // Use the delegate.

                X509Certificate2 toImport = new X509Certificate2(TxtCertificatePath.Text, TxtPassword.Text);
                Certificate cert = new Certificate(toImport);

                if (cert.Implementation != DigitalSignatureImplementation.ECDSANIST256p) {
                    MessageBox.Show(this, "The Authenticator only supports Yubikey with the Elliptic Curve NIST256p digital signature",
                        "Unsupported Implementation", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                // Store the certificate next to the private key in the Yubikey Slot.
                pivSession.ImportCertificate(SlotNumbers[CboCertSlots.SelectedIndex], toImport);
                // Update the display.
                //ShowCertificateStatus();
                pivSession.Connection.Dispose();
                MessageBox.Show(this, "A new certificate was successfully imported in slot " + SlotNumbers[CboCertSlots.SelectedIndex].ToString("X2"),
                    "Successful Operation", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex) {
                MessageBox.Show(this, "Error encountered: " + ex.Message, "Configuration Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnFileOpen_Click(object sender, EventArgs e) {
            DialogResult result = OpenCertificateDialog.ShowDialog(this);
            if (result == DialogResult.OK) {
                this.TxtCertificatePath.Text = OpenCertificateDialog.FileName;
            }
        }

        #endregion
    }
}
