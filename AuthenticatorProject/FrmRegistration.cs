using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using AuthenticatorProject.DigitalSignature;
using AuthenticatorProject.EasyAuthentication;
using Attribute = AuthenticatorProject.EasyAuthentication.Attribute;
using ValueType = AuthenticatorProject.EasyAuthentication.ValueType;

namespace AuthenticatorProject {
    /// <summary>
    /// Interface used to register a new account to a web server.
    /// </summary>
    public partial class FrmRegistration : Form {
        // The message received that triggered this interface to appear.
        private EasyAuthenticationMessage Message { get; set; }
        
        // Positioning parameters.
        private int PositionLeft { get; set; }
        private int PositionTop { get; set; }
        // The authenticator associated where the information will be kept: provides profile definitions and a vault.
        private FrmAuthenticator Authenticator { get; set; }
        
        // For the use of Yubikey: device serial number and the slot used.
        private string YubikeySerial { get; set;}
        private byte YubikeySlot { get; set; }
        //private DigitalSignatureImplementation Implementation { get; set; }
        private string PublicKey { get; set; }

        // For tracking the email address that will go in the account.
        private string EmailAddress { get; set; }
        // When a certificate is used: this is the reference to the certificate.
        private Certificate Certificate { get; set; }

        // The account that the registration is attempting to define.
        public Account Account { get; set; }
        // Track if the changes have been saved or not.
        private bool Changed { get; set; }
        //public Vault Vault { get; set; }
        private EasyAuthenticationMessage Response { get; set; }

        #region "Form Events"

        /// <summary>
        /// Constructing the registration interface.
        /// </summary>
        /// <param name="message">The message received by the web server.</param>
        /// <param name="authenticator">The main interface associated.</param>
        /// <param name="left">Positioning parameter.</param>
        /// <param name="top">Positioning parameter.</param>
        public FrmRegistration(EasyAuthenticationMessage message, FrmAuthenticator authenticator, int left, int top) {
            Application.EnableVisualStyles();
            InitializeComponent();
            this.Message = message;
            
            //this.Vault = authenticator.Vault;
            this.Account = new Account();
            this.PositionLeft = left;
            this.PositionTop = top;
            this.Authenticator = authenticator;
            this.Changed = true;
            Response = new EasyAuthenticationMessage();
        }
        // Filling the interface.
        private void FrmRegistration_Load(object sender, EventArgs e) {
            foreach (UserProfile _profile in this.Authenticator.Profiles)
                CboProfiles.Items.Add(_profile.Name);

            // Populate the details received in the invitation.
            this.PicServer.Image = Utilities.Base64ToImage(Message.ProvidedParameters.GetFirstParameterByAttribute(Attribute.Avatar).Value);
            this.TxtServerID.Text = Message.ProvidedParameters.GetFirstParameterByAttribute(Attribute.Identification).Value;
            this.TxtLoginURL.Text = Message.ProvidedParameters.GetFirstParameterByAttribute(Attribute.URL).Value;

            int _top = 15; int _left = 10; int _padding = 10;
            bool _leftColumn = true;

            // Prepare the message for the response. Set up parameters for every requested information.
            foreach (Parameter _p in Message.RequestedParameters) {
                Parameter _providedParameter = new Parameter(_p);
                Response.ProvidedParameters.Parameters.AddLast(_providedParameter);
                if (_p.Visible) {  // Only add parameters marked as visible.
                    Label _lbl = new Label();
                    _lbl.Text = _p.Label + (_p.Mandatory ? "(*):" : ":");
                    ToolTip.SetToolTip(_lbl, _p.Description);
                    _lbl.Size = new Size(100, 20);
                    _lbl.Top = _top;
                    _lbl.Left = _left;
                    if (_p.Attribute != Attribute.DigitalSignatureAlgorithm) {
                        // No label is to be added for the digital signatures: it has it's own control.
                        PanelParameters.Controls.Add(_lbl);
                    }
                    
                    if (_providedParameter.ValueType == ValueType.String || _providedParameter.ValueType == ValueType.Hexadecimal || _providedParameter.ValueType == ValueType.Base64 ||
                        _providedParameter.ValueType == ValueType.Email || _providedParameter.ValueType == ValueType.URL) {

                        ParameterTextBox _txt = new ParameterTextBox(_providedParameter);
                        _txt.Left = _lbl.Left + 100;
                        _txt.Top = _top;
                        _txt.Width = 250;
                        _txt.Height = 20;

                        if (_leftColumn) {
                            // Moving to right column for the next control.
                            _leftColumn = false;
                            _left = _left + 350 + _padding;
                        }
                        else {
                            _leftColumn = true;
                            _top = _top + 20 + 10;
                            _left = 10;
                        }

                        if (_providedParameter.Attribute == Attribute.Certificate) {
                            _txt.ReadOnly = true;  // Can only be set by loading a certificate.
                            _txt.Text = "Must be signed by " + _p.Description;
                        }
                        PanelParameters.Controls.Add(_txt);

                    }
                    else if (_providedParameter.ValueType == ValueType.ClosedList || _providedParameter.ValueType == ValueType.OpenList) {
                        // If this list is for digital signature algorithms, we use the prepared control.
                        if (_providedParameter.Attribute == Attribute.DigitalSignatureAlgorithm) {
                            string[] sorted = Utilities.SortAlgorithmByPreference(_providedParameter.GetListFromValue());
                            CboImplementations.Items.AddRange(sorted);
                            if (CboImplementations.Items.Count > 0)
                                CboImplementations.SelectedIndex = 0;
                        }
                        else {
                            // Dynamic control for the list. Just add it in the panel.
                            ParameterComboBox _cbo = new ParameterComboBox(_providedParameter);
                            _cbo.Left = _lbl.Left + 100;
                            _cbo.Top = _top;
                            _cbo.Width = 250;
                            _cbo.Height = 20;
                            _cbo.Items.AddRange(_providedParameter.GetListFromValue());

                            if (_providedParameter.ValueType == ValueType.ClosedList) {
                                _cbo.DropDownStyle = ComboBoxStyle.DropDownList;
                                _cbo.SelectedIndex = 0;
                                //_cbo.SelectedItem = _providedParameter.Default;
                            }
                            else {
                                _cbo.DropDownStyle = ComboBoxStyle.DropDown;
                            }

                            if (_leftColumn) {
                                // Moving to right column for the next control.
                                _leftColumn = false;
                                _left = _left + 350 + _padding;
                            }
                            else {
                                _leftColumn = true;
                                _top = _top + 20 + 10;
                                _left = 10;
                            }

                            PanelParameters.Controls.Add(_cbo);
                        }
                    }
                    else if (_providedParameter.ValueType == ValueType.Base64Image) {
                        ParameterPictureBox _pic = new ParameterPictureBox(_providedParameter);
                        _pic.SizeMode = PictureBoxSizeMode.StretchImage;
                        _pic.Width = 48;
                        _pic.Height = 48;

                        _pic.Left = _lbl.Left + 100;
                        _pic.Top = _top;
                        
                        _leftColumn = true;
                        _top = _top + 48 + _padding;
                        
                        _pic.Image = PicUnknown.Image;

                        PanelParameters.Controls.Add(_pic);
                    }
                }
            }

            this.Left = PositionLeft;
            this.Top = PositionTop;

            // Load the combo box of profiles, but not select anything.
            if (CboProfiles.Items.Count > 0) {
                //CboProfiles.SelectedIndex = 0;
                CboProfiles.Enabled = true;

                if (CboProfiles.Items.Count > 1) {
                    BtnNext.Enabled = true;
                    BtnPrevious.Enabled = true;
                }
            }

            FillUserForm();
        }
        // Managing changes when the interface closes.
        private void FrmRegistration_FormClosing(object sender, FormClosingEventArgs e) {
            if (Changed) {
                DialogResult result = MessageBox.Show(this, "There are unsaved changes that will be lost if you close the interface. Close?",
                    "Unsaved Changes", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.No)
                    e.Cancel = true;
            }
        }

        #endregion

        #region "Profile Navigation"

        private void CboProfiles_SelectedIndexChanged(object sender, EventArgs e) {
            FillUserForm();
        }

        private void BtnPrevious_Click(object sender, EventArgs e) {
            if (CboProfiles.SelectedIndex > 0)
                CboProfiles.SelectedIndex--;
            else
                CboProfiles.SelectedIndex = CboProfiles.Items.Count - 1;
        }

        private void BtnNext_Click(object sender, EventArgs e) {
            if (CboProfiles.SelectedIndex < CboProfiles.Items.Count - 1)
                CboProfiles.SelectedIndex++;
            else
                CboProfiles.SelectedIndex = 0;
        }

        /// <summary>
        /// Fill the form with the contents of a profile in the application.
        /// </summary>
        private void FillUserForm() {
            if (CboProfiles.SelectedIndex >= 0) {
                UserProfile _profile = this.Authenticator.Profiles.ElementAt(CboProfiles.SelectedIndex);

                // Fill the form from the profile: each textbox, combobox, pic in the panel gets a value if the parameter of the control fits a standard parameter.
                foreach (Control _c in PanelParameters.Controls) {
                    Parameter _p = null;
                    if (_c is ParameterTextBox) {
                        _p = ((ParameterTextBox) _c).Parameter;
                    }
                    else if (_c is ParameterComboBox) {
                        _p = ((ParameterComboBox) _c).Parameter;
                    }
                    else if (_c is ParameterPictureBox) {
                        _p = ((ParameterPictureBox) _c).Parameter;
                    }
                    else
                        continue;

                    if (_p.Attribute == Attribute.EmailAddress)
                        _c.Text = _profile.Email;
                    if (_p.Attribute == Attribute.Address)
                        _c.Text = _profile.Address;
                    if (_p.Attribute == Attribute.FirstName)
                        _c.Text = _profile.FirstName;
                    if (_p.Attribute == Attribute.LastName)
                        _c.Text = _profile.LastName;
                    if (_p.Attribute == Attribute.Title)
                        _c.Text = _profile.Title;
                    if (_p.Attribute == Attribute.PhoneNumber)
                        _c.Text = _profile.PhoneNumber;
                    if (_p.Attribute == Attribute.Avatar)
                        ((ParameterPictureBox) _c).Image = _profile.Avatar;
                }
            }
        }

        #endregion

        #region "Drag and drop operations"

        // Populate the parameters in the response to ask for the registration.
        private void PicRegistration_MouseDown(object sender, MouseEventArgs e) {
            
            // Initiating the message generation for drag-drop operation.
            foreach (Control _c in PanelParameters.Controls) {
                if (_c is ParameterTextBox) {
                    if (((ParameterTextBox) _c).Parameter.Attribute != Attribute.Certificate)
                        ((ParameterTextBox) _c).Parameter.Value = ((ParameterTextBox) _c).Text;
                }
                else if (_c is ParameterComboBox) {
                    ((ParameterComboBox) _c).Parameter.Value = ((ParameterComboBox) _c).Text;
                }
                else if (_c is ParameterPictureBox) {
                    ((ParameterPictureBox) _c).Parameter.Value = Utilities.ImageToBase64(((ParameterPictureBox) _c).Image);
                }
            }

            // Get the provided email for the new account.
            // Either directly provided, or is in a certificate.
            // If in a certificate, it will be already loaded.
            if (Response.ProvidedParameters.GetParametersByAttribute(Attribute.EmailAddress).Count == 1)
                this.EmailAddress = Response.ProvidedParameters.GetFirstParameterByAttribute(Attribute.EmailAddress).Value;
            
            // Make sure an account with this email does not already exist in the vault.
            foreach (Account _account in this.Authenticator.Vault.Accounts) {
                if (_account.Email == this.EmailAddress && _account.Server == TxtServerID.Text) {
                    MessageBox.Show(this, "An account on this server for this email already exists in the vault", "Existing Account",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            string _algo = CboImplementations.Text;
            Response.ProvidedParameters.GetFirstParameterByAttribute(Attribute.DigitalSignatureAlgorithm).Value = _algo;
            
            // Maybe we are generating a new Authenticator-managed key, or we are using an external one.
            if (ChkCertificate.Checked) {
                // A certificate is being used. It is either in a file or a Yubikey.
                if (Certificate is YubikeyCertificate) {
                    // The private key is stored in the Yubikey. We have the others parameters acquired.
                    YubikeyCertificate _cert = (YubikeyCertificate) Certificate;
                    try {
                        this.Account.Key = new Yubikey();
                        this.Account.Key.Generate(_cert.DeviceSerialNumber + "|" + _cert.Slot.ToString("X2") + "|" + _cert.PublicKey);
                    }
                    catch {
                        MessageBox.Show(this, "Unsupported public key algorithm: " + _algo, "Unsupported Algorithm", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                else {
                    // It's a file-based certificate.
                    // We are using a certificate. The private key will be inside, so we can get it and export it into the vault.
                    try {
                        this.Account.Key = new CertificateKey(DigitalSignatureImplementation.FromName(_algo));
                        this.Account.Key.Generate(Certificate.ToXmlString());
                    }
                    catch {
                        MessageBox.Show(this, "Unsupported public key algorithm: " + _algo, "Unsupported Algorithm", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
            }
            else {
                // Not a certificate key, so it is internally generated.
                try {
                    this.Account.Key = new InternalKey(DigitalSignatureImplementation.FromName(_algo));
                    this.Account.Key.Generate();
                }
                catch {
                    MessageBox.Show(this, "Unsupported public key algorithm: " + _algo, "Unsupported Algorithm", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            
            // If a certificate is provided, then no public key will be sent directly: it will be in the certificate.
            if (Response.ProvidedParameters.GetParametersByAttribute(Attribute.PublicKey).Count == 1)
                Response.ProvidedParameters.GetFirstParameterByAttribute(Attribute.PublicKey).Value = this.Account.Key.Export(false);
            //MessageBox.Show(Response.ProvidedParameters.GetFirstParameterByAttribute(Attribute.PublicKey).Value);
            if (ValidateForm()) {
                // Create the string in XML with the registration information.
                string _xmlString = Response.ToString();
                //MessageBox.Show(_xmlString);
                
                PicRegistration.DoDragDrop(_xmlString, DragDropEffects.Move);
            }
            else {
                MessageBox.Show(this, "Some mandatory fields are not provided", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PicRegistration_QueryContinueDrag(object sender, QueryContinueDragEventArgs e) {
            if (e.Action == DragAction.Drop)
                BtnOK.Enabled = true;
        }

        #endregion

        #region "Account Edition"
        // Make sure that we are compliant with the protocol by checking that all requested parameters that are mandatory have values.
        private bool ValidateForm() {
            // Check that all the mandatory fields in the response have a value.
            foreach (Parameter _p in Response.ProvidedParameters) {
                if (_p.Mandatory && (_p.Value == null || _p.Value == "")) {
                    MessageBox.Show(this, _p.Name);
                    return false;
                }
            }
            return true;
        }

        private void BtnCancel_Click(object sender, EventArgs e) {
            this.Close();
            this.Authenticator.Focus();
        }

        private void BtnOK_Click(object sender, EventArgs e) {
            SaveChanges();
            this.Close();
            this.Authenticator.Focus();
        }
        /// <summary>
        /// Save the changes created: i.e. save a new account to the vault.
        /// </summary>
        private void SaveChanges() {
            // The new account is defined and save in the main interface.
            this.Account.Email = this.EmailAddress;
            this.Account.Icon = PicServer.Image;
            this.Account.Server = TxtServerID.Text;
            this.Account.LoginURL = TxtLoginURL.Text;

            Authenticator.AddNewAccount(Account);
            Changed = false;
        }

        private void FetchCertificate(object sender, EventArgs e) {
            if (ChkCertificate.Checked == false) {
                
                this.EmailAddress = null;
                this.Certificate = null;
                this.CboImplementations.Enabled = true;
                if (Response.ProvidedParameters.GetParametersByAttribute(Attribute.Certificate).Count == 1) {
                    Response.ProvidedParameters.GetFirstParameterByAttribute(Attribute.Certificate).Value = null;
                }

                foreach (Control _c in PanelParameters.Controls) {
                    if (_c is ParameterTextBox) {
                        ParameterTextBox _p = (ParameterTextBox) _c;
                        if (_p.Parameter.Attribute == Attribute.Certificate) {
                            _p.Parameter.Value = null;
                            _p.Text = "";
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
                    this.EmailAddress = Certificate.Subject.EmailAddress;

                    // Set the algorithm to use in the drop-down list and lock it.
                    for (int i = 0; i < CboImplementations.Items.Count; i++) {
                        if (CboImplementations.Items[i].ToString() == Certificate.Implementation.Name) {
                            CboImplementations.SelectedIndex = i;
                            CboImplementations.Enabled = false;
                        }
                    }

                    foreach (Control _c in PanelParameters.Controls) {
                        if (_c is ParameterTextBox) {
                            ParameterTextBox _p = (ParameterTextBox) _c;

                            if (_p.Parameter.Attribute == Attribute.Certificate) {
                                if (Certificate.Issuer.Name != _p.Parameter.Description) {
                                    MessageBox.Show(this, "The certificate is not signed by the right issuer", "Wrong Issuer",
                                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    ChkCertificate.Checked = false;
                                    
                                }
                                else if (Certificate.IsExpired) {
                                    MessageBox.Show(this, "The certificate is expired", "Expired Certificate",
                                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    ChkCertificate.Checked = false;
                                }
                                else if (! Certificate.IsActive) {
                                    MessageBox.Show(this, "The certificate is not yet active", "Wrong Issuer",
                                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    ChkCertificate.Checked = false;
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
                            else if (_p.Parameter.Attribute == Attribute.Organization)
                                _p.Text = Certificate.Subject.Organisation;
                            else if (_p.Parameter.Attribute == Attribute.Address)
                                _p.Text = Certificate.Subject.Address;
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