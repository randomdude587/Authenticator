using System;
using System.Text;
using System.Windows.Forms;
using Yubico.YubiKey;

namespace AuthenticatorProject {
    public partial class FrmPIN : Form {
        // Implementation of some kind of the singleton design pattern.
        private static FrmPIN instance = null;
        public string PIN { get; set; }
        public string ManagementKey { get; set; }
        public string DefaultValue { get; set; }
        public string Question { get; set; }
        private int Request { get; set; }
        private int PositionLeft { get; set; }
        private int PositionTop { get; set; }
        
        // Static field to keep track of who is calling the interface: for dialog and positioning.
        public static Form Caller { get; set; }

        #region "Form Events"

        // Private constructor, places the location and nullifies the keys.
        private FrmPIN(int left, int top) {
            InitializeComponent();
            this.PositionLeft = left;
            this.PositionTop = top;
            PIN = null;
            ManagementKey = null;
        }
        // Position is established but we don't show the form yet.
        private void FrmPIN_Load(object sender, EventArgs e) {
            this.Left = this.PositionLeft;
            this.Top = this.PositionTop;
            this.Visible = false;
        }
        // Set the provided question on the interface.
        private void FrmPIN_Activated(object sender, EventArgs e) {
            LblQuestion.Text = this.Question;
        }

        #endregion

        #region "Control Events"

        // The input was validated. Update internal value, depending on the request, and hide but do not dispose.
        private void BtnOK_Click(object sender, EventArgs e) {
            this.DialogResult = DialogResult.OK;
            if (Request == 1)
                this.PIN = TxtPasscode.Text;
            else
                this.ManagementKey = TxtPasscode.Text;
            this.Hide();
        }

        // The user cancelled the request: nullify the credential (it's not good anymore) and hide.
        private void BtnCancel_Click(object sender, EventArgs e) {
            this.DialogResult = DialogResult.Cancel;
            if (Request == 1)
                this.PIN = null;
            else
                this.ManagementKey = null;
            this.Hide();
        }

        // Put the default value, either for PIN or for ManagementKey, into the text box.
        private void BtnDefault_Click(object sender, EventArgs e) {
            TxtPasscode.Text = this.DefaultValue;
        }

        #endregion

        #region "Credentials Management"

        // The delegate for the PivSession object.
        public static bool GetCredential(KeyEntryData keyData) {
            // If it's a first call, we instantiate the instance.
            
            if (instance == null)
                instance = new FrmPIN(FrmPIN.Caller.Left + 25, FrmPIN.Caller.Top + 25);
            
            instance.PIN = null;
            if (keyData.Request == KeyEntryRequest.VerifyPivPin) {
                
                instance.Request = 1;  // To flag that a PIN is being requested.
                instance.DefaultValue = "123456";

                if (keyData.IsRetry) {
                    instance.Question = "The PIN provided was incorrect. " + keyData.RetriesRemaining + " attempts remaining.";
                }
                else {
                    if (instance.PIN != null) {
                        // It's not a retry: so the question was asked before and the answer was good, so send it again.
                        keyData.SubmitValue(new ReadOnlySpan<byte>(Encoding.UTF8.GetBytes(instance.PIN)));
                        return true;
                    }
                    instance.Question = "Provide the Yubikey PIN";
                }

                DialogResult result = instance.ShowDialog(FrmPIN.Caller);
                if (result == DialogResult.OK) {
                    // A value was submitted, as a first time or a retry: send it in.
                    keyData.SubmitValue(new ReadOnlySpan<byte>(Encoding.UTF8.GetBytes(instance.PIN)));
                    return true;
                }
                else
                    return false;  // User-cancelled operation.
            }
            else if (keyData.Request == KeyEntryRequest.AuthenticatePivManagementKey) {
                
                instance.Request = 2;  // To flag that a management key is being asked.
                instance.DefaultValue = "0x010203040506070801020304050607080102030405060708";
                                
                if (keyData.IsRetry) {
                    instance.Question = "The management key provided was incorrect. " + keyData.RetriesRemaining + " attempts remaining.";
                }
                else {
                    if (instance.ManagementKey != null) {
                        // It's not a retry: so the question was asked before and the answer was good, so send it again.
                        keyData.SubmitValue(new ReadOnlySpan<byte>(Utilities.HexToByteArray(instance.ManagementKey)));
                        return true;
                    }
                    instance.Question = "Provide the Yubikey Management Key";
                }

                DialogResult result = instance.ShowDialog(FrmPIN.Caller);
                if (result == DialogResult.OK) {
                    // A value was submitted, as a first time or a retry: send it in.
                    keyData.SubmitValue(new ReadOnlySpan<byte>(Utilities.HexToByteArray(instance.ManagementKey)));
                    return true;
                }
                else
                    return false;  // User-cancelled operation.
            }
            
            else if (keyData.Request == KeyEntryRequest.Release) {
                // There is a request for release each time an action is done, forcing to re-enter PIN and management key.
                // We don't release until it's all done, on form closing.
                return true;
            }
            else {
                // No idea what is being asked, and it's not handled by this app!
                return false;
            }
        }
        /// <summary>
        /// Release the collected PIN and ManagementKey if any.
        /// </summary>
        public static void ClearData() {
            if (instance != null)
                instance.Dispose();
            instance = null;
        }

        #endregion

    }
}
