using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace AuthenticatorProject {
    /// <summary>
    /// User interface to import profiles into the application.
    /// </summary>
    public partial class FrmImportProfiles : Form {
        /// <summary>
        /// The profile interface that called this one.
        /// </summary>
        public FrmProfiles FrmProfiles { get; set; }
        /// <summary>
        /// The base Authenticator app that indirectly called this one.
        /// </summary>
        public FrmAuthenticator Authenticator { get; set; }
        private bool Changed { get; set; }
        /// <summary>
        /// The list of profiles defined in this interface.
        /// </summary>
        private LinkedList<UserProfile> Profiles { get; set; }

        #region "Form Events"
        /// <summary>
        /// Creating an instance of the interface.
        /// </summary>
        /// <param name="frmProfiles">A profile management interface that was used to call this one.</param>
        public FrmImportProfiles(FrmProfiles frmProfiles, FrmAuthenticator authenticator) {
            InitializeComponent();
            this.FrmProfiles = frmProfiles;
            this.Changed = false;
            Authenticator = authenticator;
            Profiles = new LinkedList<UserProfile>();
            foreach (UserProfile _profile in FrmProfiles.Profiles) {
                this.Profiles.AddLast(_profile.Clone());
            }
        }
        // Manage the modifications on the form closing.
        private void FrmImportProfiles_FormClosing(object sender, FormClosingEventArgs e) {
            if (Changed) {
                DialogResult _response = MessageBox.Show(this, "There are unsaved changes in the form. Save?", "Unsaved Changes", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);

                if (_response == DialogResult.Cancel) {
                    e.Cancel = true;
                }
                else if (_response == DialogResult.Yes) {
                    SaveChanges();
                }
            }
        }

        #endregion

        #region "Control Events"
        private void BtnProfilesFile_Click(object sender, EventArgs e) {
            if (openProfilesDialog.ShowDialog() == DialogResult.OK) {
                TxtProfileFile.Text = openProfilesDialog.FileName;
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void BtnOK_Click(object sender, EventArgs e) {
            if (TxtProfileFile.Text == "")
                return;

            try {
                // Get the list of user profiles in the file.
                LinkedList<UserProfile> _imported = Authenticator.LoadProfiles(File.ReadAllText(TxtProfileFile.Text));

                // Create an empty list.
                LinkedList<UserProfile> _profiles = new LinkedList<UserProfile>();

                // Merge the two list (imported and existing) into the empty list with the rules in place.
                // For the existing profiles:
                foreach (UserProfile _temp in Profiles) {
                    UserProfile _p = GetProfile(_temp.Name, _imported);
                    if (_p == null) {
                        // The existing profile is not in the imported ones. We can add it.
                        _profiles.AddLast(_temp);
                    }
                    else {
                        // A profile was imported with a name already in use.
                        if (optSkip.Checked) {
                            // We are not importing that profile.
                            _profiles.AddLast(_temp);
                            _imported.Remove(_p);
                        }
                        else if (optReplace.Checked) {
                            // We replace the existing profile with the imported one.
                            _profiles.AddLast(_p);
                            _imported.Remove(_p);
                            Changed = true;
                        }
                        else if (optCopy.Checked) {
                            // We add the imported file with a "different" name.
                            int _index = 1;
                            _profiles.AddLast(_p.Clone());
                            while (GetProfile(_p.Name + " (" + _index + ")", Profiles) != null) {
                                _index++;
                            }
                            _p.Name = _p.Name + " (" + _index + ")";
                            _profiles.AddLast(_p);
                            _imported.Remove(_p);
                            Changed = true;
                        }
                    }
                }
                foreach (UserProfile _p in _imported) {
                    _profiles.AddLast(_p);
                    Changed = true;
                }

                MessageBox.Show(this, _imported.Count + " profile" + (_imported.Count > 1 ? "s" : "") + " successfully imported.",
                    "Import Completed", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.Profiles = _profiles;
                SaveChanges();
                this.Close();
            }
            catch (Exception ex) {
                MessageBox.Show(this, "An error occurred: " + ex.Message, "Unexpected Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TxtProfileFile_DragDrop(object sender, DragEventArgs e) {
            string[] files = (string[]) e.Data.GetData(DataFormats.FileDrop);
            if (files != null && files.Length != 0) {
                TxtProfileFile.Text = files[0];
            }
        }

        private void TxtProfileFile_DragEnter(object sender, DragEventArgs e) {
            if (e.Data.GetDataPresent(DataFormats.FileDrop, false) == true) {
                e.Effect = DragDropEffects.Copy;
            }
        }

        #endregion

        #region "Data Management"

        /// <summary>
        /// Save the changes applied to the profiles.
        /// </summary>
        private void SaveChanges() {
            this.FrmProfiles.Profiles = this.Profiles;
            this.FrmProfiles.Changed = this.Changed;
            Changed = false;
        }

        #endregion

        #region "Utilities"
        
        /// <summary>
        /// Retrieve an instance of profile by its name.
        /// </summary>
        /// <param name="name">The name of the profile.</param>
        /// <param name="profiles">The profiles in which to look.</param>
        /// <returns>The profile or null if not found.</returns>
        private static UserProfile GetProfile(string name, LinkedList<UserProfile> profiles) {
            foreach (UserProfile _profile in profiles) {
                if (_profile.Name == name)
                    return _profile;
            }
            return null;
        }
        #endregion

        
    }
}
