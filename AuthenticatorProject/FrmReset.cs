using System;
using System.Drawing;
using System.Windows.Forms;
using AuthenticatorProject.DigitalSignature;
using AuthenticatorProject.EasyAuthentication;
using Attribute = AuthenticatorProject.EasyAuthentication.Attribute;

namespace AuthenticatorProject {
    /// <summary>
    /// Interface used to reset an account, or even recover it completely.
    /// </summary>
    public partial class FrmReset : Form {
        private Account Account { get; set; }
        private int PositionLeft { get; set; }
        private int PositionTop { get; set; }

        private Certificate Certificate { get; set; }
        private EasyAuthenticationMessage Message { get; set; }
        private EasyAuthenticationMessage Response { get; set; }
        public bool Changed { get; set; }

        /// <summary>
        /// If true, we are recovering and recreating the account, so it will be a new one added. Otherwise, 
        /// we are resetting the key on an existing one.
        /// </summary>
        public bool NewAccount { get; set; }
        public FrmAuthenticator Authenticator { get; set; }

        #region "Form Events"
        
        /// <summary>
        /// Constructing the interface.
        /// </summary>
        /// <param name="account">The account that we are resetting.</param>
        /// <param name="newAccount">If true, we are recovering and recreating an account to be added. Otherwise, we are resetting the key to an existing account.</param>
        /// <param name="authenticator">The instance of the main interface.</param>
        /// <param name="left">Positioning parameter.</param>
        /// <param name="top">Positioning parameter.</param>
        /// <param name="message">The EasyAuthenticationMessage received from the web server.</param>
        public FrmReset(Account account, bool newAccount, FrmAuthenticator authenticator, int left, int top, EasyAuthenticationMessage message) {
            InitializeComponent();

            this.Message = message;
            Account = new Account();
            Account.Email = account.Email;
            Account.Icon = Utilities.Base64ToImage(Utilities.ImageToBase64(account.Icon));
            Account.LoginURL = account.LoginURL;
            Account.Notes = account.Notes;
            Account.Key = account.Key;  // Might be null if recreated.
            Account.Server = account.Server;
            
            NewAccount = newAccount;
            Authenticator = authenticator;

            this.PositionLeft = left;
            this.PositionTop = top;

            if (Message.ProvidedParameters.GetParametersByAttribute(Attribute.Challenge).Count > 0) {
                switch (this.Message.ValidateChallenge()) {
                    case ChallengeStatus.Expired:
                        MessageBox.Show(this, "The challenge is expired", "Invalid Challenge", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.Close();
                        break;
                    case ChallengeStatus.InTheFuture:
                        MessageBox.Show(this, "The challenge was set in the future", "Invalid Challenge", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.Close();
                        break;
                    case ChallengeStatus.WrongIdentification:
                        MessageBox.Show(this, "The server identification is wrong", "Identification Mismatch", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.Close();
                        break;
                }
            }

            Response = new EasyAuthenticationMessage();
            Response.Action = Message.Action;

            foreach (Parameter _p in Message.RequestedParameters) {
                Parameter _providedParameter = new Parameter(_p);
                
                Response.ProvidedParameters.Parameters.AddLast(_providedParameter);
            }

            string[] algorithms = Utilities.SortAlgorithmByPreference(Message.RequestedParameters.GetFirstParameterByAttribute(Attribute.DigitalSignatureAlgorithm).GetListFromValue());

            CboImplementations.Items.AddRange(algorithms);
            CboImplementations.SelectedIndex = 0;

            if (Message.RequestedParameters.GetParametersByAttribute(Attribute.Certificate).Count == 1) {
                // A certificate is required. We create the control to manage it.
                ParameterTextBox _pCertifcate = new ParameterTextBox(Response.ProvidedParameters.GetFirstParameterByAttribute(Attribute.Certificate));
                _pCertifcate.Text = "Must be signed by: " + _pCertifcate.Parameter.Description;
                _pCertifcate.Left = 45;
                _pCertifcate.Top = 20;
                _pCertifcate.Width = 305;
                _pCertifcate.ReadOnly = true;
                GrpCertificate.Controls.Add(_pCertifcate);
            }

        }
        // Populate the interface with the details of the account.
        private void FrmReset_Load(object sender, EventArgs e) {
            PicAccount.Image = Account.Icon;

            TxtEmail.Text = Account.Email;
            TxtLoginURL.Text = Account.LoginURL;
            TxtServerID.Text = Account.Server;

            this.Left = PositionLeft;
            this.Top = PositionTop;
        }

        #endregion

        #region "Drag and Drop Operation"

        private void PicReset_MouseDown(object sender, MouseEventArgs e) {
            // A new key is always provided during a reset, either from a newly generated one, or from a certificate.
            // Provide digital signature if one is requested.
            if (Response.ProvidedParameters.GetParametersByAttribute(Attribute.Signature).Count == 1) {
                Response.ProvidedParameters.GetFirstParameterByAttribute(Attribute.Signature).Value = Account.Key.Sign(Message.ProvidedParameters.GetFirstParameterByAttribute(Attribute.Challenge).Value);
            }
            else {
                // If no signature is requested, it means a validation code must be provided.
                Response.ProvidedParameters.GetFirstParameterByAttribute(Attribute.ValidationCode).Value =
                    Message.ProvidedParameters.GetFirstParameterByAttribute(Attribute.ValidationCode).Value;
            }

            if (Response.ProvidedParameters.GetParametersByAttribute(Attribute.EmailAddress).Count == 1) {
                Response.ProvidedParameters.GetFirstParameterByAttribute(Attribute.EmailAddress).Value = Account.Email;
            }

            // Specify the digital signature algorithm used.
            if (Response.ProvidedParameters.GetParametersByAttribute(Attribute.DigitalSignatureAlgorithm).Count == 1) {
                Response.ProvidedParameters.GetFirstParameterByAttribute(Attribute.DigitalSignatureAlgorithm).Value = CboImplementations.Text;
            }

            if (ChkCertificate.Checked) {
                // The private key is associated to a certificate, either file or Yubikey.
                if (this.Certificate is YubikeyCertificate) {
                    // The private key is stored in the Yubikey. We have the others parameters acquired.
                    try {
                        this.Account.Key = new Yubikey();
                        YubikeyCertificate _yubikeyCert = (YubikeyCertificate) Certificate;
                        this.Account.Key.Generate(_yubikeyCert.DeviceSerialNumber + "|" + 
                             _yubikeyCert.Slot.ToString("X2") + "|" + _yubikeyCert.PublicKey);
                    }
                    catch {
                        MessageBox.Show(this, "Unsupported public key algorithm: " + CboImplementations.Text, 
                            "Unsupported Algorithm", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                else {
                    // It's a file certificate.
                    try {
                        this.Account.Key = new CertificateKey(DigitalSignatureImplementation.FromName(CboImplementations.Text));
                        this.Account.Key.Generate(Certificate.ToXmlString());
                    }
                    catch {
                        MessageBox.Show(this, "Unsupported public key algorithm: " + CboImplementations.Text,
                            "Unsupported Algorithm", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
            }
            else {
                try {
                    this.Account.Key = new InternalKey(DigitalSignatureImplementation.FromName(CboImplementations.Text));
                    this.Account.Key.Generate();
                }
                catch {
                    MessageBox.Show(this, "Unsupported public key algorithm: " + CboImplementations.Text, "Unsupported Algorithm", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            // The new key was generated. If it is being asked for instead of a certificate, we provided it.
            if (Response.ProvidedParameters.GetParametersByAttribute(Attribute.PublicKey).Count == 1) {
                Response.ProvidedParameters.GetFirstParameterByAttribute(Attribute.PublicKey).Value = Account.Key.Export(false);
            }

            PicReset.DoDragDrop(Response.ToString(), DragDropEffects.Move);
            Changed = true;
        }

        #endregion

        #region "Control Events"

        private void BtnCancel_Click(object sender, EventArgs e) {
            this.Authenticator.Focus();
            this.Close();
        }

        private void BtnOK_Click(object sender, EventArgs e) {
            SaveChanges();
            this.Authenticator.Focus();
            this.Close();
        }

        #endregion

        #region "Data Manipulation"
        /// <summary>
        /// Save the changes to the account.
        /// </summary>
        private void SaveChanges() {
            if (Changed) {
                // Preserve the changes in the authenticator.
                if (NewAccount) {
                    // The account was recreated, so we add to the vault.
                    Authenticator.Vault.Accounts.Add(Account);
                }
                else {
                    // Update the current one with the updated information.

                    Account _accountToUpdate = null;
                    foreach (Account _a in Authenticator.Vault.Accounts) {
                        if (_a.Server == Account.Server && _a.Email == Account.Email) {
                            _accountToUpdate = _a;
                        }
                    }
                    Authenticator.Vault.Accounts.Remove(_accountToUpdate);
                    Authenticator.Vault.Accounts.Add(Account);
                }
                Authenticator.Vault.Changed = true;
                Authenticator.UpdateStatus("Account was updated successfully");
                Authenticator.RefreshList();
                this.Changed = false;
            }
        }

        #endregion

        #region "Certificate Handling"

        private void ChkCertificate_CheckedChanged(object sender, EventArgs e) {
            if (ChkCertificate.Checked == false) {
                // The user provided a certificate but changed his mind.
                TxtEmail.Text = Account.Email;
                this.Certificate = null;
                this.CboImplementations.Enabled = true;
                // If a certificate was requested, it is no longer with a value attached.
                if (Response.ProvidedParameters.GetParametersByAttribute(Attribute.Certificate).Count == 1) {
                    Response.ProvidedParameters.GetFirstParameterByAttribute(Attribute.Certificate).Value = null;
                }

                foreach (Control _c in GrpCertificate.Controls) {
                    if (_c is ParameterTextBox) {
                        ParameterTextBox _p = (ParameterTextBox) _c;
                        if (_p.Parameter.Attribute == Attribute.Certificate) {
                            _p.Parameter.Value = null;
                            _p.Text = _p.Parameter.Description;
                        }
                    }
                }
            }
            else {
                DialogResult result;
                string[] _implementations = new string[CboImplementations.Items.Count];
                for (int i = 0; i < _implementations.Length; i++)
                    _implementations[i] = CboImplementations.Items[i].ToString();

                FrmCertificate _frmCert = new FrmCertificate(this.Left + 25, this.Top + 25, _implementations);

                result = _frmCert.ShowDialog(this);
                if (result == DialogResult.OK) {
                    // A certificate was loaded.
                    //StringBuilder builder = new StringBuilder();
                    this.Certificate = _frmCert.Certificate;
                    this.TxtEmail.Text = Certificate.Subject.EmailAddress;

                    // Set the algorithm to use in the drop-down list and lock it.
                    for (int i = 0; i < CboImplementations.Items.Count; i++) {
                        if (CboImplementations.Items[i].ToString() == Certificate.Implementation.Name) {
                            CboImplementations.SelectedIndex = i;
                            CboImplementations.Enabled = false;
                        }
                    }

                    foreach (Control _c in GrpCertificate.Controls) {
                        if (_c is ParameterTextBox) {
                            ParameterTextBox _p = (ParameterTextBox) _c;

                            if (_p.Parameter.Attribute == Attribute.Certificate) {
                                if (Certificate.Issuer.Name != _p.Parameter.Description) {
                                    MessageBox.Show(this, "The certificate is not signed by the right issuer", "Wrong Issuer",
                                        MessageBoxButtons.OK, MessageBoxIcon.Error);

                                }
                                else if (Certificate.IsExpired) {
                                    MessageBox.Show(this, "The certificate is expired", "Expired Certificate",
                                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                                else if (!Certificate.IsActive) {
                                    MessageBox.Show(this, "The certificate is not yet active", "Wrong Issuer",
                                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                                else {
                                    _p.ForeColor = Color.Black;
                                    _p.Parameter.Value = Utilities.StringToBase64(Certificate.GetCrt());
                                    _p.Text = "Certificate provided";
                                }
                            }
                            else if (_p.Parameter.Attribute == Attribute.EmailAddress) {
                                _p.Text = Certificate.Subject.EmailAddress;
                            }
                        }
                    }
                }
                else
                    ChkCertificate.Checked = false;
            }
        }

        #endregion
    }
}
