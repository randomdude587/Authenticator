using AuthenticatorProject.DigitalSignature;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace AuthenticatorProject {
    public partial class FrmCertificate : Form {
        // Positioning parameters.
        private int PositionLeft;
        private int PositionTop;

        // The certificate that we are fetching.
        public Certificate Certificate { get; set; }
        // If we are using the interface to create an account: this is the list of implementations that the provider supports.
        // The selected certificate will have to be compliant.
        private string[] SupportedImplementations { get; set; }

        #region "Form Events"

        public FrmCertificate(int left, int top, string[] supportedImplementations = null) {
            InitializeComponent();
            this.PositionLeft = left;
            this.PositionTop = top;
            this.SupportedImplementations = supportedImplementations;
        }

        private void FrmCertificate_Load(object sender, EventArgs e) {
            this.Left = PositionLeft;
            this.Top = PositionTop;
        }

        #endregion

        #region "Control Events"

        private void BtnFileOpen_Click(object sender, EventArgs e) {
            DialogResult result = OpenCertificateDialog.ShowDialog(this);
            if (result == DialogResult.OK) {
                this.TxtCertificatePath.Text = OpenCertificateDialog.FileName;
            }
        }

        private void BtnLoadFile_Click(object sender, EventArgs e) {
            try {
                Certificate = new Certificate(TxtCertificatePath.Text, TxtPassword.Text);
                DisplayCertificate();
            }
            catch (Exception ex) {
                MessageBox.Show(this, "An error occurred: " + ex.Message, "Unexpected Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnYubikey_Click(object sender, EventArgs e) {
            FrmYubikeyPIV _frm = new FrmYubikeyPIV(this.Left + 25, this.Top + 25);
            DialogResult result = _frm.ShowDialog(this);
            if (result == DialogResult.OK) {
                Certificate = _frm.YubikeyCertificate;
                DisplayCertificate();
            }
        }

        private void BtnOK_Click(object sender, EventArgs e) {
            // If we have restrictions on the supported implementations, we check that we are compliant.
            if (SupportedImplementations != null) {
                bool _supported = false;
                foreach (string _implementation in SupportedImplementations) {
                    if (_implementation == TxtSubjectAlgorithm.Text)
                        _supported = true;
                }
                if (!_supported) {
                    MessageBox.Show(this, "The digital signature algorithm of this certificate is not supported by the service provider", "Unsupported Algorithm",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void BtnCancel_Click(object sender, EventArgs e) {
            this.DialogResult = DialogResult.Cancel;
            this.Certificate = null;
            this.Close();
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

        #region "Certificate Management"

        private void DisplayCertificate() {
            BtnOK.Enabled = true;
            // General Data.
            TxtFormat.Text = Certificate.Format;
            TxtVersion.Text = Certificate.Version;
            TxtSerialNumber.Text = Certificate.SerialNumber;
            TxtFrom.Text = Certificate.NotBefore.ToString();
            TxtTo.Text = Certificate.NotAfter.ToString();
            TxtThumbprint.Text = Certificate.Thumbprint;
            TxtHasPrivate.Text = Certificate.HasPrivateKey ? "YES" : "NO";

            if (Certificate.DaysSinceActivation < 0) {
                TxtExpiration.Text = "Not yet active";
                TxtExpiration.ForeColor = Color.Red;
            }
            else if (Certificate.IsExpired) {
                TxtExpiration.Text = "The certificate has expired";
                TxtExpiration.ForeColor = Color.Red;
            }
            else {
                TxtExpiration.Text = "Expires in " + Certificate.DaysBeforeExpiration + " days";
                TxtExpiration.ForeColor = Color.Black;
            }

            // Issuer information.
            TxtIssuer.Text = Certificate.Issuer.Name;
            TxtIssuerNameCanonical.Text = Certificate.Issuer.ToString();

            TxtSignatureAlgorithm.Text = Certificate.SignatureAlgorithm;

            // Subject Information.
            TxtSubjectName.Text = Certificate.Subject.Name;
            TxtEmail.Text = Certificate.Subject.EmailAddress;

            TxtSubjectCanonical.Text = Certificate.Subject.ToString();

            TxtSubjectAlgorithm.Text = Certificate.Implementation.Name;
        }

        #endregion
    }
}
