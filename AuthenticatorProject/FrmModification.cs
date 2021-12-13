using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using AuthenticatorProject.EasyAuthentication;
using Attribute = AuthenticatorProject.EasyAuthentication.Attribute;
using ValueType = AuthenticatorProject.EasyAuthentication.ValueType;

namespace AuthenticatorProject {
    /// <summary>
    /// Interface used to modify an account already existing on the web service.
    /// </summary>
    public partial class FrmModification : Form {
        /// <summary>
        /// Message received that initiated modifications.
        /// </summary>
        private EasyAuthenticationMessage Message { get; set; }
        /// <summary>
        /// Internal list of profiles, including current profile on the web server.
        /// </summary>
        private LinkedList<UserProfile> Profiles { get; set; }
        
        // Positioning parameters.
        private int PositionLeft { get; set; }
        private int PositionTop { get; set; }
        /// <summary>
        /// The current main interface.
        /// </summary>
        private FrmAuthenticator Authenticator { get; set; }
        /// <summary>
        /// The account being modified.
        /// </summary>
        public Account Account { get; set; }
        /// <summary>
        /// Flag for modifications applied.
        /// </summary>
        private bool Changed { get; set; }
        /// <summary>
        /// Reference to the vault being potentially modified.
        /// </summary>
        public Vault Vault { get; set; }
        /// <summary>
        /// The response being constructed for the server.
        /// </summary>
        private EasyAuthenticationMessage Response { get; set; }
        private UserProfile CurrentProfile { get; set; }

        #region "Form Events"

        /// <summary>
        /// Construct the interface
        /// </summary>
        /// <param name="account">The account being modified.</param>
        /// <param name="message">The message received by the web server.</param>
        /// <param name="authenticator">The main interface of the application.</param>
        /// <param name="left">Positional parameter</param>
        /// <param name="top">Positional parameter</param>
        public FrmModification(Account account, EasyAuthenticationMessage message, FrmAuthenticator authenticator, int left, int top) {
            InitializeComponent();
            Account = account;
            Message = message;
            Authenticator = authenticator;
            this.Profiles = Authenticator.Profiles;
            PositionLeft = left;
            PositionTop = top;
            this.Changed = true;
            Response = new EasyAuthenticationMessage();
        }
        // Populate the interface with current information.
        private void FrmModification_Load(object sender, EventArgs e) {
            
            // Populate the details received in the invitation.
            this.PicServer.Image = Utilities.Base64ToImage(Message.ProvidedParameters.GetFirstParameterByAttribute(Attribute.Avatar).Value);
            this.TxtServerID.Text = Message.ProvidedParameters.GetFirstParameterByAttribute(Attribute.Identification).Value;
            this.TxtLoginURL.Text = Message.ProvidedParameters.GetFirstParameterByAttribute(Attribute.URL).Value;

            int _top = 15; int _left = 10; int _padding = 10;
            bool _leftColumn = true;

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

            CurrentProfile = new UserProfile();
            CurrentProfile.Name = "<Current Profile>";

            CurrentProfile.Address = (Message.RequestedParameters.GetParametersByAttribute(Attribute.Address).Count > 0 ? Message.RequestedParameters.GetFirstParameterByAttribute(Attribute.Address).Value : "");
            CurrentProfile.Email = (Message.RequestedParameters.GetParametersByAttribute(Attribute.EmailAddress).Count > 0 ? Message.RequestedParameters.GetFirstParameterByAttribute(Attribute.EmailAddress).Value : "");
            CurrentProfile.FirstName = (Message.RequestedParameters.GetParametersByAttribute(Attribute.FirstName).Count > 0 ? Message.RequestedParameters.GetFirstParameterByAttribute(Attribute.FirstName).Value : "");
            CurrentProfile.LastName = (Message.RequestedParameters.GetParametersByAttribute(Attribute.LastName).Count > 0 ? Message.RequestedParameters.GetFirstParameterByAttribute(Attribute.LastName).Value : "");
            CurrentProfile.Organization = (Message.RequestedParameters.GetParametersByAttribute(Attribute.Organization).Count > 0 ? Message.RequestedParameters.GetFirstParameterByAttribute(Attribute.Organization).Value : "");
            CurrentProfile.PhoneNumber = (Message.RequestedParameters.GetParametersByAttribute(Attribute.PhoneNumber).Count > 0 ? Message.RequestedParameters.GetFirstParameterByAttribute(Attribute.PhoneNumber).Value : "");
            CurrentProfile.Title = (Message.RequestedParameters.GetParametersByAttribute(Attribute.Title).Count > 0 ? Message.RequestedParameters.GetFirstParameterByAttribute(Attribute.Title).Value : "");
            CurrentProfile.Avatar = (Message.RequestedParameters.GetParametersByAttribute(Attribute.Avatar).Count > 0 ? 
                                         Utilities.Base64ToImage(Message.RequestedParameters.GetFirstParameterByAttribute(Attribute.Avatar).Value) : null);

            CboProfiles.Items.Add(CurrentProfile.Name);
            foreach (UserProfile _profile in this.Profiles)
                CboProfiles.Items.Add(_profile.Name);

            // Prepare the message for the response. Set up parameters for every requested information.
            foreach (Parameter _p in Message.RequestedParameters) {
                Parameter _providedParameter = new Parameter(_p);
                Response.ProvidedParameters.Parameters.AddLast(_providedParameter);
                if (_p.Visible) {
                    Label _lbl = new Label();
                    _lbl.Text = _p.Label + (_p.Mandatory ? "(*):" : ":");
                    ToolTip.SetToolTip(_lbl, _p.Description);
                    _lbl.Size = new Size(100, 20);
                    _lbl.Top = _top;
                    _lbl.Left = _left;
                    PanelParameters.Controls.Add(_lbl);

                    //MessageBox.Show(_providedParameter.ToString());

                    if (_providedParameter.ValueType == ValueType.String || _providedParameter.ValueType == ValueType.Hexadecimal || _providedParameter.ValueType == ValueType.Base64 ||
                        _providedParameter.ValueType == ValueType.Email || _providedParameter.ValueType == ValueType.URL) {

                        ParameterTextBox _txt = new ParameterTextBox(_providedParameter);
                        _txt.Text = _providedParameter.Value;
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

                        PanelParameters.Controls.Add(_txt);
                    }
                    else if (_providedParameter.ValueType == ValueType.ClosedList || _providedParameter.ValueType == ValueType.OpenList) {
                        ParameterComboBox _cbo = new ParameterComboBox(_providedParameter);
                        _cbo.Left = _lbl.Left + 100;
                        _cbo.Top = _top;
                        _cbo.Width = 250;
                        _cbo.Height = 20;
                        _cbo.Items.AddRange(_providedParameter.GetListFromValue());

                        if (_providedParameter.ValueType == ValueType.ClosedList) {
                            _cbo.DropDownStyle = ComboBoxStyle.DropDownList;

                            _cbo.SelectedItem = _providedParameter.Default;
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
                    else if (_providedParameter.ValueType == ValueType.Base64Image) {
                        ParameterPictureBox _pic = new ParameterPictureBox(_providedParameter);
                        _pic.SizeMode = PictureBoxSizeMode.StretchImage;
                        _pic.Width = 48;
                        _pic.Height = 48;

                        _pic.Left = _lbl.Left + 100;
                        _pic.Top = _top;

                        _leftColumn = true;
                        _top = _top + 48 + _padding;

                        _pic.Image = _providedParameter.Value == "" ? PicUnknown.Image : CurrentProfile.Avatar;

                        PanelParameters.Controls.Add(_pic);

                    }
                }
            }

            this.Left = PositionLeft;
            this.Top = PositionTop;

            // Load the combo box of profiles, and select the current one.
            CboProfiles.Enabled = true;
            CboProfiles.SelectedIndex = 0;
            FillUserForm();
        }

        // Manage the changes applied when closing the form.
        private void FrmModification_FormClosing(object sender, FormClosingEventArgs e) {
            if (Changed) {
                DialogResult _answer = MessageBox.Show(this, "There are unsaved changes that will be lost if you close the interface. Save?", "Unsaved Changes", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
                if (_answer == DialogResult.Yes) {
                    SaveChanges();
                }
                else if (_answer == DialogResult.Cancel)
                    e.Cancel = true;
            }
        }

        #endregion

        #region "Data Management"

        /// <summary>
        /// Fill the user information from the profiles, current or otherwise.
        /// </summary>
        private void FillUserForm() {
            if (CboProfiles.SelectedIndex >= 0) {
                UserProfile _profile = null;

                if (CboProfiles.SelectedIndex == 0)
                    _profile = CurrentProfile;
                else
                    _profile = Profiles.ElementAt(CboProfiles.SelectedIndex - 1);

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

        /// <summary>
        /// Apply the changes to the pointed account.
        /// </summary>
        private void SaveChanges() {
            if (Response.ProvidedParameters.GetParametersByAttribute(Attribute.EmailAddress).Count == 1)
                this.Account.Email = Response.ProvidedParameters.GetFirstParameterByAttribute(Attribute.EmailAddress).Value;

            this.Account.Icon = PicServer.Image;
            this.Account.Server = TxtServerID.Text;
            this.Account.LoginURL = TxtLoginURL.Text;
            this.Authenticator.Vault.Changed = true;

            Changed = false;
        }
        /// <summary>
        /// Validates the form based on the required parameters.
        /// </summary>
        /// <returns>True if form is valid, false otherwise.</returns>
        private bool ValidateForm() {
            // Check that all the mandatory fields in the response have a value.
            foreach (Parameter _p in Response.ProvidedParameters) {
                if (_p.Mandatory && (_p.Value == null || _p.Value == ""))
                    return false;
            }
            return true;
        }

        #endregion

        #region "Control Events"

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
        // To be compliant with the message, check that all requested parameters have been provided.
        

        private void BtnCancel_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void BtnOK_Click(object sender, EventArgs e) {
            SaveChanges();
            Authenticator.Vault.Changed = true;
            Authenticator.UpdateStatus("Account was updated successfully");
            this.Authenticator.Focus();
            this.Close();
        }

        #endregion

        #region "Drag and Drop"

        private void PicModification_MouseDown(object sender, MouseEventArgs e) {
            // Initiating the message generation for drag-drop operation.
            foreach (Control _c in PanelParameters.Controls) {
                if (_c is ParameterTextBox) {
                    ((ParameterTextBox) _c).Parameter.Value = ((ParameterTextBox) _c).Text;
                }
                else if (_c is ParameterComboBox) {
                    //MessageBox.Show(((ParameterComboBox) _c).Text);
                    ((ParameterComboBox) _c).Parameter.Value = ((ParameterComboBox) _c).Text;
                }
                else if (_c is ParameterPictureBox) {
                    //MessageBox.Show(((ParameterComboBox) _c).Text);
                    ((ParameterPictureBox) _c).Parameter.Value = Utilities.ImageToBase64(((ParameterPictureBox) _c).Image);
                }
            }

            // Was the email up for modification?
            if (Response.ProvidedParameters.GetParametersByAttribute(Attribute.EmailAddress).Count == 1) {
                // Get the provided email for the modified account.
                string _email = Response.ProvidedParameters.GetFirstParameterByAttribute(Attribute.EmailAddress).Value;
                // Was it changed? Or is it the same email?
                if (_email != CurrentProfile.Email) {
                    // Make sure an account with this email does not already exist in the vault.
                    foreach (Account _account in this.Authenticator.Vault.Accounts) {
                        if (_account.Email == _email && _account.Server == TxtServerID.Text) {
                            MessageBox.Show(this, "You have another account with that email address already", "Existing Account",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                }
            }
            
            // Sign the challenge.
            Response.ProvidedParameters.GetFirstParameterByAttribute(Attribute.Signature).Value = this.Account.Key.Sign(Message.ProvidedParameters.GetFirstParameterByAttribute(Attribute.Challenge).Value);

            if (ValidateForm()) {
                // Create the string in XML with the registration information.
                string _xmlString = Response.ToString();
                PicModification.DoDragDrop(_xmlString, DragDropEffects.Move);
            }
            else {
                MessageBox.Show(this, "Some mandatory fields are not provided", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PicModification_QueryContinueDrag(object sender, QueryContinueDragEventArgs e) {
            if (e.Action == DragAction.Drop)
                BtnOK.Enabled = true;
        }

        #endregion
    }
}
