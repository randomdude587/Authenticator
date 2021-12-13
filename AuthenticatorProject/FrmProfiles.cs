using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace AuthenticatorProject {
    /// <summary>
    /// Interface to manage the profiles stored in the application.
    /// </summary>
    public partial class FrmProfiles : Form {
        /// <summary>
        /// Internal list of profiles copied from the authenticator app.
        /// </summary>
        public LinkedList<UserProfile> Profiles = null;
        /// <summary>
        /// Flag to track if changes have been made.
        /// </summary>
        public bool Changed { get; set; }
        /// <summary>
        /// The currently selected profile.
        /// </summary>
        private UserProfile CurrentProfile { get; set; }
        /// <summary>
        /// The authenticator app instance that invoked this form.
        /// </summary>
        private FrmAuthenticator Authenticator { get; set; }
        /// <summary>
        /// A flag indicating if an import of profiles should start automatically.
        /// </summary>
        private bool StartImport { get; set; }
        // Position parameters.
        private int PositionLeft { get; set; }
        private int PositionTop { get; set; }
        /// <summary>
        /// The index of the currently selected profile in the list.
        /// </summary>
        private int CurrentProfileIndex { get; set; }

        #region "Form Events"

        /// <summary>
        /// Construct the interface
        /// </summary>
        /// <param name="authenticator">The instance of the main form associated to this one.</param>
        /// <param name="left">Positioning parameter.</param>
        /// <param name="top">Positioning parameter.</param>
        /// <param name="startImport">If true, initiate an importation, otherwise no action is triggered.</param>
        public FrmProfiles(FrmAuthenticator authenticator, int left, int top, bool startImport) {
            InitializeComponent();
            // Copy the profiles into this interfaces for a potential modification.
            this.Authenticator = authenticator;

            Profiles = new LinkedList<UserProfile>();
            foreach (UserProfile _profile in authenticator.Profiles) {
                this.Profiles.AddLast(_profile.Clone());
            }
            // Position the interface. No changes yet.
            this.PositionLeft = left;
            this.PositionTop = top;
            this.Changed = false;

            CurrentProfile = null;
            CurrentProfileIndex = -1;
            StartImport = startImport;
        }
        // Fill the form with the profiles.
        private void FrmProfiles_Load(object sender, EventArgs e) {
            LoadProfileNames();
            if (Profiles.Count > 0) {
                CurrentProfile = Profiles.First.Value;
                CurrentProfileIndex = 0;
            }
            
            RefreshForm();
            this.Top = this.PositionTop;
            this.Left = this.PositionLeft;
            this.Visible = true;
            if (StartImport)
                ImportProfiles();
        }
        // Manage the changes when closing.
        private void FrmProfiles_FormClosing(object sender, FormClosingEventArgs e) {
            if (Changed) {
                if (MessageBox.Show(this, "There are unsaved changes in the form that will be lost. Save?", "Changes Pending",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes) {
                    // Save the changes.
                    SaveChanges();
                }
            }
        }

        #endregion

        #region "Control Events"

        private void TxtFirstName_TextChanged(object sender, EventArgs e) {
            if (CurrentProfile != null) CurrentProfile.FirstName = TxtFirstName.Text;
        }

        private void TxtLastName_TextChanged(object sender, EventArgs e) {
            if (CurrentProfile != null) CurrentProfile.LastName = TxtLastName.Text;
        }

        private void TxtTitle_TextChanged(object sender, EventArgs e) {
            if (CurrentProfile != null) CurrentProfile.Title = TxtTitle.Text;
        }

        private void TxtPhoneNumber_TextChanged(object sender, EventArgs e) {
            if (CurrentProfile != null) CurrentProfile.PhoneNumber = TxtPhoneNumber.Text;
        }

        private void TxtOrganization_TextChanged(object sender, EventArgs e) {
            if (CurrentProfile != null) CurrentProfile.Organization = TxtOrganization.Text;
        }

        private void TxtAddress_TextChanged(object sender, EventArgs e) {
            if (CurrentProfile != null) CurrentProfile.Address = TxtAddress.Text;
        }

        private void TxtEmail_Validating(object sender, CancelEventArgs e) {
            if (CurrentProfile != null) CurrentProfile.Email = TxtEmail.Text;
        }

        private void BtnPrevious_Click(object sender, EventArgs e) {
            PreviousProfile();
        }

        private void BtnNext_Click(object sender, EventArgs e) {
            NextProfile();
        }

        private void BtnOK_Click(object sender, EventArgs e) {
            SaveChanges();
            this.Dispose();
        }

        private void BtnCancel_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void BtnProfiles_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e) {
            SelectProfileByName(e.ClickedItem.Text);
        }

        private void BtnExport_Click(object sender, EventArgs e) {
            this.Authenticator.ExportProfiles();
        }

        #endregion

        #region "Navigation through profiles"

        /// <summary>
        /// Requesting the previous profile in the list, based on the current one displayed.
        /// </summary>
        private void PreviousProfile() {
            if (Profiles.Count == 0) {
                // No profiles loaded.
                CurrentProfileIndex = -1;
                CurrentProfile = null;
            }
            else if (CurrentProfileIndex == 0) {
                // Circle back to last profile.
                CurrentProfileIndex = Profiles.Count - 1;
                CurrentProfile = Profiles.ElementAt(CurrentProfileIndex);
            }
            else {
                CurrentProfileIndex--;
                CurrentProfile = Profiles.ElementAt(CurrentProfileIndex);
            }
            RefreshForm();
        }

        /// <summary>
        /// Requesting the next profile in the list, based on the current one displayed.
        /// </summary>
        private void NextProfile() {
            if (Profiles.Count == 0) {
                // No profiles loaded.
                CurrentProfileIndex = -1;
                CurrentProfile = null;
            }
            else if (CurrentProfileIndex == Profiles.Count - 1) {
                // Circle back to first profile.
                CurrentProfileIndex = 0;
                CurrentProfile = Profiles.ElementAt(0);
            }
            else {
                CurrentProfileIndex++;
                CurrentProfile = Profiles.ElementAt(CurrentProfileIndex);
            }
            RefreshForm();
        }

        
        /// <summary>
        /// Select a profile from the internal list using its name and display it in the form.
        /// </summary>
        /// <param name="name">The name of the profile.</param>
        private void SelectProfileByName(string name) {
            int _index = 0;
            foreach (UserProfile _profile in Profiles) {
                if (_profile.Name == name) {
                    CurrentProfile = _profile;
                    CurrentProfileIndex = _index;
                    RefreshForm();
                    return;
                }
                _index++;
            }
        }

        #endregion

        #region "Profile Edition"
        
        // Clone the currently selected profile.
        private void BtnClone_Click(object sender, EventArgs e) {
            // Clone the current profile.
            string[] names = new string[Profiles.Count];
            for (int i = 0; i < Profiles.Count; i++) {
                names[i] = Profiles.ElementAt(i).Name;
            }

            FrmValueInput _input = new FrmValueInput("Profile Name", "Copy the profile to: ", TxtProfileName.Text + " (Copy)", false, this.Left + 25, this.Top + 25, null, names);
            _input.ShowDialog();
            // The value is required but if the user cancel the operation, it will come back as null anyway.
            if (_input.Value != null) {
                UserProfile _clone = CurrentProfile.Clone();
                _clone.Name = _input.Value;
                Profiles.AddLast(_clone);
                
                LoadProfileNames();
                CurrentProfileIndex = Profiles.Count - 1;
                CurrentProfile = Profiles.ElementAt(CurrentProfileIndex);
                RefreshForm();
                Changed = true;
            }
        }

        // Add a new empty profile.
        private void BtnAdd_Click(object sender, EventArgs e) {
            string[] names = null;
            if (Profiles.Count > 0) {
                names = new string[Profiles.Count];
                for (int i = 0; i < Profiles.Count; i++) {
                    names[i] = Profiles.ElementAt(i).Name;
                }
            }

            FrmValueInput _input = new FrmValueInput("Profile Name", "Name of new profile:", "", false, this.Left + 25, this.Top + 25, null, names);
            _input.ShowDialog(this);
            // The value is required but if the user cancel the operation, it will come back as null anyway.
            if (_input.Value != null) {
                // Save profile
                UserProfile _profile = new UserProfile();
                _profile.Name = _input.Value;
                _profile.Email = "";
                _profile.FirstName = "";
                _profile.LastName = "";
                _profile.Title = "";
                _profile.PhoneNumber = "";
                _profile.Organization = "";
                _profile.Address = "";
                _profile.Avatar = null;

                Profiles.AddLast(_profile);
                // Load the profiles, including the new one.
                LoadProfileNames();
                // Select the last one of the list, newly added.

                CurrentProfileIndex = Profiles.Count - 1;
                CurrentProfile = Profiles.ElementAt(CurrentProfileIndex);

                Changed = true;
                RefreshForm();
            }
        }

        // Delete the currently selected profile.
        private void BtnDelete_Click(object sender, EventArgs e) {
            if (Profiles.Count == 0) {
                // This won't happen as the button would be disabled.
                MessageBox.Show(this, "No profiles currently selected", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else {
                if (MessageBox.Show(this, "Are you sure you want to delete the profile: " + TxtProfileName.Text + "?", "Confirm Deletion",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK) {

                    Profiles.Remove(CurrentProfile);
                    CurrentProfile = null;

                    Changed = true;
                    LoadProfileNames();

                    if (Profiles.Count > 0) {
                        if (CurrentProfileIndex >= Profiles.Count)
                            CurrentProfileIndex--;
                        CurrentProfile = Profiles.ElementAt(CurrentProfileIndex);
                    }
                    else {
                        CurrentProfileIndex = -1;
                        CurrentProfile = null;
                    }
                    RefreshForm();
                }
            }
        }
        
        // Obtain the path to a picture file to replace the current one in the profile.
        private void PicAvatar_DoubleClick(object sender, EventArgs e) {
            // Select and import an avatar for the current profile.
            if (OpenAvatarDialog.ShowDialog() == DialogResult.OK) {
                try {
                    PicAvatar.Image = Image.FromFile(OpenAvatarDialog.FileName);
                    CurrentProfile.Avatar = PicAvatar.Image;
                    Changed = true;
                    RefreshForm();
                }
                catch (Exception ex) {
                    MessageBox.Show(this, "An error occurred: " + ex.Message, "Unexpected Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Start the profile importation process.
        private void BtnImport_Click(object sender, EventArgs e) {
            ImportProfiles();
        }

        #endregion

        #region "Profile Management"

        /// <summary>
        /// The form is dynamic: it is populated with controls that corresponds to requested parameters from the web server.
        /// This method fills the form with the currently selected profile.
        /// </summary>
        private void RefreshForm() {
            // Determine which controls are active or not.

            bool _profileSelected = CurrentProfile != null;

            BtnAdd.Enabled = true;
            BtnClone.Enabled = _profileSelected;
            BtnDelete.Enabled = _profileSelected;
            BtnCancel.Enabled = true;
            BtnProfiles.Enabled = (Profiles.Count > 0);
            BtnExport.Enabled = (Profiles.Count > 0);
            BtnNext.Enabled = BtnPrevious.Enabled = _profileSelected;
            PicAvatar.Enabled = _profileSelected;

            TxtEmail.Enabled = TxtFirstName.Enabled = TxtLastName.Enabled = TxtTitle.Enabled = TxtPhoneNumber.Enabled = TxtOrganization.Enabled = TxtAddress.Enabled = _profileSelected;

            if (_profileSelected) {
                TxtEmail.Text = CurrentProfile.Email;
                TxtFirstName.Text = CurrentProfile.FirstName;
                TxtLastName.Text = CurrentProfile.LastName;
                TxtTitle.Text = CurrentProfile.Title;
                TxtPhoneNumber.Text = CurrentProfile.PhoneNumber;
                TxtOrganization.Text = CurrentProfile.Organization;
                TxtAddress.Text = CurrentProfile.Address;

                if (CurrentProfile.Avatar == null)
                    PicAvatar.Image = PicUnknown.Image;
                else
                    PicAvatar.Image = CurrentProfile.Avatar;
                TxtProfileName.Text = CurrentProfile.Name;
            }
            else {
                // Currently with an empty form.
                TxtEmail.Text = "";
                TxtFirstName.Text = "";
                TxtLastName.Text = "";
                TxtTitle.Text = "";
                TxtPhoneNumber.Text = "";
                TxtOrganization.Text = "";
                TxtAddress.Text = "";
                PicAvatar.Image = null;
                TxtProfileName.Text = "";
            }
        }
        // Changing the profile name.
        private void TxtProfileName_Validating(object sender, CancelEventArgs e) {
            
            if (TxtProfileName.Text != CurrentProfile.Name) {
                // The profile was renamed.
                foreach (UserProfile _p in Profiles) {
                    if (_p.Name == TxtProfileName.Text) {
                        MessageBox.Show(this, "The name " + TxtProfileName.Text + " is already in use", "Name Used", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        e.Cancel = true;
                        return;
                    }
                }
                CurrentProfile.Name = TxtProfileName.Text;
                LoadProfileNames();
            }
            e.Cancel = false;
            
        }
        /// <summary>
        /// Load or reload the profiles into the dropdown list.
        /// </summary>
        private void LoadProfileNames() {
            BtnProfiles.DropDownItems.Clear();
            
            foreach (UserProfile _profile in Profiles) {
                BtnProfiles.DropDownItems.Add(_profile.Name);
            }
        }

        /// <summary>
        /// Imports profiles from an external XML file.
        /// </summary>
        private void ImportProfiles() {
            FrmImportProfiles _frmImport = new FrmImportProfiles(this, this.Authenticator);
            _frmImport.ShowDialog(this);

            LoadProfileNames();
            if (Profiles.Count > 0)
                CurrentProfile = Profiles.First.Value;
            RefreshForm();
        }

        private void SaveChanges() {
            // Save the changes to the profiles.
            this.Authenticator.Profiles = this.Profiles;
            this.Authenticator.SaveProfiles();
            this.Changed = false;
        }

        #endregion

    }
}
