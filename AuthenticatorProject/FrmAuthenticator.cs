using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Xml;
using System.Diagnostics;
using AuthenticatorProject.EasyAuthentication;
using AuthenticatorProject.Encryption;
using Attribute = AuthenticatorProject.EasyAuthentication.Attribute;
using System.Reflection;

namespace AuthenticatorProject {
    /// <summary>
    /// Main interface of the application. Everything is run from here.
    /// </summary>
    public partial class FrmAuthenticator : Form {
        /// <summary>
        /// The vault associated to the main form. If null, then no vault is open.
        /// </summary>
        public Vault Vault = null;
        // Recent files used by the app.
        private string Recent1 { get; set; } 
        private string Recent2 { get; set; }
        private string Recent3 { get; set; }
        private string Recent4 { get; set; }
        // Command line arguments: vaults to open.
        private string[] VaultFiles { get; set; }
        
        /// <summary>
        /// The user profiles stored in the application.
        /// </summary>
        public LinkedList<UserProfile> Profiles { get; set; }

        #region "Form Events"
        
        /// <summary>
        /// The constructor for the main interface.
        /// </summary>
        /// <param name="vaultFiles">The list of files that were provided to the application to be opened, from none to several.</param>
        public FrmAuthenticator(string[] vaultFiles) {
            InitializeComponent();
            
            this.VaultFiles = vaultFiles;
            try {
                //this.Profiles = LoadProfiles("user_profiles.xml");
                this.Profiles = LoadProfiles(Properties.Settings.Default.Profiles);
            }
            catch (Exception) {
                MessageBox.Show(this, "Could not load the user profiles", "Unexpected Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
            // Load the recently opened files from the application properties.
            Recent1 = Properties.Settings.Default.Recent1;
            Recent2 = Properties.Settings.Default.Recent2;
            Recent3 = Properties.Settings.Default.Recent3;
            Recent4 = Properties.Settings.Default.Recent4;
        }

        // Set the interface for initial display.
        private void FrmAuthenticator_Load(object sender, EventArgs e) {
            // Remember the size of the application.
            this.Width = Properties.Settings.Default.Width;
            this.Height = Properties.Settings.Default.Height;

            this.TopMost = Properties.Settings.Default.StartOnTop;

            this.Visible = true;
            UpdateStatus("Application loading...");
            if (VaultFiles != null && VaultFiles.Length > 0) {
                // Open the first file name in the current app.
                OpenVault(VaultFiles[0]);
                for (int i = 1; i < VaultFiles.Length; i++)
                    OpenNewWindow(VaultFiles[i]);
                VaultFiles = null;
            }
            else if (Properties.Settings.Default.OpenLast) {
                // Reopen the last vault that was used.
                OpenVault(Recent1);
            }
            UpdateStatus();
        }

        // Run the closing routine from here: make sure to save what is needing saving.
        private void FrmAuthenticator_FormClosing(object sender, FormClosingEventArgs e) {
            // To control the window closing, cancel the events and then proceed manually.
            e.Cancel = true;
            QuitApplication();
        }
        #endregion

        #region "Menu and toolbar event handlers"

        private void MnuClose_Click(object sender, EventArgs e) {
            CloseVault();
        }

        private void MnuSelectAll_Click(object sender, EventArgs e) {
            if (ListAccounts != null) {
                foreach (ListViewItem item in ListAccounts.Items)
                    item.Selected = true;
            }
        }

        private void MnuView_DropDownOpening(object sender, EventArgs e) {
            MnuOnTop.Checked = this.TopMost;
            MnuAccount.Enabled = ListAccounts.SelectedItems.Count > 0;
            MnuRefresh.Enabled = this.Vault != null;
        }

        private void MnuHelpContents_Click(object sender, EventArgs e) {
            ShowHelp();
        }

        private void MnuAbout_Click(object sender, EventArgs e) {
            ShowAbout();
        }
        private void MnuExportAccounts_Click(object sender, EventArgs e) {
            ExportAccounts();
        }

        private void MnuYubikey_Click(object sender, EventArgs e) {
            EditYubikeySettings();
        }

        private void BtnHelp_Click(object sender, EventArgs e) {
            ShowHelp();
        }

        private void MnuQuit_Click(object sender, EventArgs e) {
            QuitApplication();
        }

        private void MnuOnTop_Click(object sender, EventArgs e) {
            this.TopMost = !this.TopMost;
        }

        private void MnuOpen_Click(object sender, EventArgs e) {
            OpenVault("");
        }

        private void BtnOpen_Click(object sender, EventArgs e) {
            OpenVault("");
        }

        private void MnuNew_Click(object sender, EventArgs e) {
            CreateNewVault();
        }

        private void MnuSaveAs_Click(object sender, EventArgs e) {
            SaveVaultAs();
        }

        private void BtnNew_Click(object sender, EventArgs e) {
            CreateNewVault();
        }

        private void MnuSave_Click(object sender, EventArgs e) {
            SaveVault();
        }

        private void BtnSave_Click(object sender, EventArgs e) {
            SaveVault();
        }

        private void MnuProfiles_Click(object sender, EventArgs e) {
            ManageProfiles();
        }

        private void BtnAccounts_Click(object sender, EventArgs e) {
            ManageProfiles();
        }

        private void ListAccounts_KeyUp(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Delete) {
                DeleteAccount();
            }
        }

        private void MnuDeleteAccount_Click(object sender, EventArgs e) {
            DeleteAccount();
        }

        private void CxtMenuAccount_Opening(object sender, System.ComponentModel.CancelEventArgs e) {
            if (ListAccounts.SelectedItems.Count == 0) {
                e.Cancel = true;
            }
        }
        private void CtxMenuDetails_Click(object sender, EventArgs e) {
            ShowAccountDetails();
        }

        private void CtxMenuOpenLogin_Click(object sender, EventArgs e) {
            OpenLoginPages();
        }

        private void CtxMenuDelete_Click(object sender, EventArgs e) {
            DeleteAccount();
        }

        private void MnuAccount_Click(object sender, EventArgs e) {
            ShowAccountDetails();
        }

        private void ListAccounts_ItemActivate(object sender, EventArgs e) {
            ActivateAccount();
        }

        private void MnuLoadAccounts_Click(object sender, EventArgs e) {
            ImportAccounts();
        }

        private void MnuRefresh_Click(object sender, EventArgs e) {
            RefreshList();
        }

        private void MnuSettings_Click(object sender, EventArgs e) {
            ManageSettings();
        }

        private void BtnSettings_Click(object sender, EventArgs e) {
            ManageSettings();
        }

        private void MnuExportCSV_Click(object sender, EventArgs e) {
            ExportVaultToCSV();
        }

        private void MnuExportPlainText_Click(object sender, EventArgs e) {
            ExportVaultToPlainText();
        }

        private void MnuYubikeyCertificates_Click(object sender, EventArgs e) {
            FrmYubikeyPIV frmYubikeyPIV = new FrmYubikeyPIV(this.Left + 25, this.Top + 25);
            frmYubikeyPIV.ShowDialog(this);
        }

        private void MnuUsbSecurityKey_Click(object sender, EventArgs e) {
            ShowUsbSecurityKeyEditor();
        }

        private void MnuCertificateViewer_Click(object sender, EventArgs e) {
            FrmCertificate frmCertificate = new FrmCertificate(this.Left + 25, this.Top + 25);
            frmCertificate.ShowDialog(this);
        }

        // Open interface for profile management with trigger to start importation.
        private void MnuImportProfiles_Click(object sender, EventArgs e) {
            FrmProfiles _frmProfiles = new FrmProfiles(this, this.Left + 25, this.Top + 25, true);
            _frmProfiles.ShowDialog(this);
            _frmProfiles.Dispose();
        }
        // Enable/Disable menu items depending on current status.
        private void MnuFile_DropDownOpening(object sender, EventArgs e) {
            MnuRecents.DropDownItems.Clear();

            if (Recent1 == null || Recent1 == "") {
                MnuRecents.Enabled = false;
            }
            else {
                ToolStripMenuItem _mnuRecent1 = new ToolStripMenuItem(Recent1);
                MnuRecents.DropDownItems.Add(_mnuRecent1);
                _mnuRecent1.Click += new EventHandler(this.OpenRecent);

                if (Recent2 != null && Recent2 != "") {
                    ToolStripMenuItem _mnuRecent2 = new ToolStripMenuItem(Recent2);
                    MnuRecents.DropDownItems.Add(_mnuRecent2);
                    _mnuRecent2.Click += new EventHandler(this.OpenRecent);
                }

                if (Recent3 != null && Recent3 != "") {
                    ToolStripMenuItem _mnuRecent3 = new ToolStripMenuItem(Recent3);
                    MnuRecents.DropDownItems.Add(_mnuRecent3);
                    _mnuRecent3.Click += new EventHandler(this.OpenRecent);
                }

                if (Recent4 != null && Recent4 != "") {
                    ToolStripMenuItem _mnuRecent4 = new ToolStripMenuItem(Recent4);
                    MnuRecents.DropDownItems.Add(_mnuRecent4);
                    _mnuRecent4.Click += new EventHandler(this.OpenRecent);
                }
            }

            MnuClose.Enabled = Vault != null;
            MnuSave.Enabled = Vault != null;
            MnuSaveAs.Enabled = Vault != null;

            MnuExportProfiles.Enabled = this.Profiles.Count > 0;
            MnuExportAccounts.Enabled = this.Vault != null && this.Vault.Accounts.Count > 0;
            
            MnuImportAccounts.Enabled = this.Vault != null;

        }
        #endregion

        #region "Drag and drop management"
        
        // Managing something dropped in the interface.
        private void ListAccounts_DragDrop(object sender, DragEventArgs e) {
            
            // Received a potential EasyAuthenticationMessage from a drag-drop event.
            if (e.Data.GetData(DataFormats.Text) != null) {
                if (Vault == null) {
                    return;  // Cannot interact to create account or login without a vault open.
                }
                // Received some text through a drop operation. See if it is a message that can be actioned.
                string xml = (string) e.Data.GetData(DataFormats.Text);
                try {
                    // If it's not valid text, it will be handled.
                    EasyAuthenticationMessage _message = new EasyAuthenticationMessage(xml);
                    // If we're here, it's a valid message. Act upon the message action.
                    if (_message.Action == MessageAction.Register) {  // Registering a new account.
                        FrmRegistration _frmRegistration = new FrmRegistration(_message, this, this.Left + 25, this.Top + 25);
                        _frmRegistration.Show(this);
                    }
                    else if (_message.Action == MessageAction.ResetKey) {
                        // Resetting the key, or recovering an account.
                        Account _account = GetAccountFromMessage(_message, true, true);
                        bool _newAccount = false;
                        if (_account == null) {
                            // This action is particular: we can recreate the account and reset it completely: it's a recovery action.
                            DialogResult result = MessageBox.Show(this, "No account found for that server using that email. Recover the account?",
                                "Account Not Found", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                            if (result == DialogResult.No)
                                return;

                            // Recover the account with the provided parameters.
                            _account = new Account();
                            _account.Email = _message.ProvidedParameters.GetFirstParameterByAttribute(Attribute.EmailAddress).Value;
                            _account.Server = _message.ProvidedParameters.GetFirstParameterByAttribute(Attribute.Identification).Value; ;
                            if (_message.ProvidedParameters.GetParametersByAttribute(Attribute.URL).Count > 0)
                                _account.LoginURL = _message.ProvidedParameters.GetFirstParameterByAttribute(Attribute.URL).Value;

                            if (_message.ProvidedParameters.GetParametersByAttribute(Attribute.Avatar).Count > 0)
                                _account.Icon = Utilities.Base64ToImage(_message.ProvidedParameters.GetFirstParameterByAttribute(Attribute.Avatar).Value);

                            _newAccount = true;
                        }

                        FrmReset _frmreset = new FrmReset(_account, _newAccount, this, this.Left + 25, this.Top + 25, _message);
                        _frmreset.Show(this);
                    }
                    else if (_message.Action == MessageAction.RenewKey) {  // Renew the key to an account.
                        Account _account = GetAccountFromMessage(_message, true);
                        if (_account == null)
                            return;
                        FrmReset _frmreset = new FrmReset(_account, false, this, this.Left + 25, this.Top + 25, _message);
                        _frmreset.Show(this);
                    }
                    else if (_message.Action == MessageAction.SignIn) {  // Sign in to the service using the private key.
                        Account _account = GetAccountFromMessage(_message, false);
                        if (_account == null) return;

                        if (_message.ProvidedParameters.GetParametersByAttribute(Attribute.Challenge).Count != 1) {
                            MessageBox.Show(this, "The challenge is incorrectly defined for the request", "Challenge Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        FrmSignIn _frmSignIn = new FrmSignIn(this, _account, this.Left + 25, this.Top + 25, _message);
                        _frmSignIn.Show(this);
                    }
                    else if (_message.Action == MessageAction.Sign) {
                        // Already authenticated and signing some transaction.
                        Account _account = GetAccountFromMessage(_message, true);
                        if (_account == null) return;

                        FrmSign _frmSign = new FrmSign(_account, this.Left + 25, this.Top + 25, _message);
                        _frmSign.Show(this);
                    }
                    else if (_message.Action == MessageAction.Terminate) {
                        // Already authenticated and signing a termination request.
                        Account _account = GetAccountFromMessage(_message, true);

                        if (_account == null) return;

                        FrmTerminate _frmTerminate = new FrmTerminate(_account, this, this.Left + 25, this.Top + 25, _message);
                        _frmTerminate.Show(this);
                    }
                    else if (_message.Action == MessageAction.EditAccount) {
                        // Editing the profile on the web service using the authenticator and the stored profiles.
                        Account _account = GetAccountFromMessage(_message, true);
                        if (_account == null) return;

                        if (_message.ProvidedParameters.GetParametersByAttribute(Attribute.Challenge).Count != 1) {
                            MessageBox.Show(this, "The challenge is incorrectly defined for the request", "Challenge Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        FrmModification _frmModification = new FrmModification(_account, _message, this, this.Left + 25, this.Top + 25);
                        _frmModification.Show(this);
                    }
                }

                catch (EasyAuthenticationMessageException ex) {
                    MessageBox.Show(this, ex.Message, "Error Occurred", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (e.Data.GetData(DataFormats.FileDrop) != null) {
                
                // Received one or more files.
                string[] files = (string[]) e.Data.GetData(DataFormats.FileDrop);
                // The first file is opened in the current application. The other ones are
                // opened in additional instances.

                OpenVault(files[0]);
                for (int i = 1; i < files.Length; i++) {
                    OpenNewWindow(files[i]);
                }
            }
        }

        // Visual feedback when entering drop zone.
        private void ListAccounts_DragEnter(object sender, DragEventArgs e) {
            // Information has entered the drop zone.
            if (e.Data.GetDataPresent(DataFormats.FileDrop) && (e.AllowedEffect & DragDropEffects.Move) != 0) {
                // Dropping a file into the app.
                
                e.Effect = DragDropEffects.Move;
            }
            else if (e.Data.GetDataPresent(DataFormats.Text) && (e.AllowedEffect & DragDropEffects.Move) != 0) {
                if (Vault == null) {
                    UpdateStatus("Create or open a vault for interaction", true);
                }
                else
                    // Allow this.
                    e.Effect = DragDropEffects.Move;
            }
            else {
                // Don't allow any other drop.
                e.Effect = DragDropEffects.None;
            }
        }

        #endregion

        #region "File and App Management"

        /// <summary>
        /// Exports the currently loaded accounts to a CSV file.
        /// </summary>
        private void ExportVaultToCSV() {
            if (Vault == null || Vault.Accounts.Count == 0) {
                MessageBox.Show(this, "There are no accounts to export", "No Accounts", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try {
                // There is no protection here: so send a null key to trigger warning, pending preferences.
                if (WarnUnprotected(new Unprotected())) {
                    SaveFileDialog _fileDialog = new SaveFileDialog();
                    _fileDialog.Filter = "CSV Files|*.csv|All Files|*.*";
                    _fileDialog.FilterIndex = 0;
                    _fileDialog.FileName = "";
                    _fileDialog.AddExtension = true;
                    _fileDialog.CheckFileExists = false;
                    _fileDialog.CheckPathExists = true;
                    _fileDialog.DefaultExt = "csv";
                    _fileDialog.Title = "Select file for exportation";
                    _fileDialog.ShowDialog();
                    StringBuilder content = new StringBuilder();
                    if (_fileDialog.FileName != "") {
                        content.AppendLine("Server,EmailAddress,LoginURL,Notes,KeyInfo");
                        foreach (Account account in Vault.Accounts) {
                            content.AppendLine(account.Server + "," + account.Email + "," + account.LoginURL + "," + account.Notes.Replace('\n', ' ').Replace('\r', ' ') + "," +
                                account.Key.Export(true).Replace('\n', ' ').Replace('\r', ' ')); ;
                        }
                    }

                    File.WriteAllText(_fileDialog.FileName, content.ToString());
                }
            }
            catch (Exception ex) {
                MessageBox.Show(this, ex.Message, "Error Occurred", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }
        /// <summary>
        /// Open an interface to manage USB Security Keys to use with the Authenticator.
        /// </summary>
        private void ShowUsbSecurityKeyEditor() {
            FrmUsbSecuritKey frmUsbSecuritKey = new FrmUsbSecuritKey(this.Left + 25, this.Top + 25);
            frmUsbSecuritKey.ShowDialog(this);
        }

        /// <summary>
        /// Exports the currently loaded accounts to a plaintext file.
        /// </summary>
        private void ExportVaultToPlainText() {
            if (Vault == null || Vault.Accounts.Count == 0) {
                MessageBox.Show(this, "There are no accounts to export", "No Accounts", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try {
                // There is no protection here: so send a null key to trigger warning, pending preferences.
                if (WarnUnprotected(new Unprotected())) {
                    SaveFileDialog _fileDialog = new SaveFileDialog();
                    _fileDialog.Filter = "Text Files|*.txt|All Files|*.*";
                    _fileDialog.FilterIndex = 0;
                    _fileDialog.FileName = "";
                    _fileDialog.AddExtension = true;
                    _fileDialog.CheckFileExists = false;
                    _fileDialog.CheckPathExists = true;
                    _fileDialog.DefaultExt = "txt";
                    _fileDialog.Title = "Select file for exportation";
                    _fileDialog.ShowDialog();
                    StringBuilder content = new StringBuilder();
                    if (_fileDialog.FileName != "") {

                        foreach (Account account in Vault.Accounts) {
                            content.AppendLine("======================================================");
                            content.AppendLine("Server:          " + account.Server);
                            content.AppendLine("Email Address:   " + account.Email);
                            content.AppendLine("Login URL:       " + account.LoginURL);
                            content.AppendLine("Notes:\n" + account.Notes);
                            content.AppendLine("Key:\n" + account.Key.Export(true));
                        }
                    }

                    File.WriteAllText(_fileDialog.FileName, content.ToString());
                }
            }
            catch (Exception ex) {
                MessageBox.Show(this, ex.Message, "Error Occurred", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        /// <summary>
        /// Open the interface for application settings.
        /// </summary>
        private void ManageSettings() {
            FrmSettings _settings = new FrmSettings(this.Left + 25, this.Top + 25);
            _settings.ShowDialog(this);

        }
        /// <summary>
        /// Open the interface for Yubikey settings.
        /// </summary>
        private void EditYubikeySettings() {
            FrmYubikey _frmYubikey = new FrmYubikey(this.Left + 25, this.Top + 25);
            _frmYubikey.ShowDialog(this);
        }

        /// <summary>
        /// Display the about interface.
        /// </summary>
        private void ShowAbout() {
            FrmAbout _about = new FrmAbout(this.Left + 25, this.Top + 25);
            _about.ShowDialog(this);
        }

        /// <summary>
        /// Launches the Help pdf file by a system process.
        /// </summary>
        private void ShowHelp() {
            
            byte[] PDF = Properties.Resources.user_manual;
            MemoryStream ms = new MemoryStream(PDF);

            //Create PDF File From Binary of resources folders helpFile.pdf
            FileStream f = new FileStream("help_doc.pdf", FileMode.OpenOrCreate);

            //Write Bytes into Our Created helpFile.pdf
            ms.WriteTo(f);
            f.Close();
            ms.Close();

            // Finally Show the Created PDF from resources 
            Process.Start("help_doc.pdf");
        }

        /// <summary>
        /// Update the message in the status bar.
        /// </summary>
        /// <param name="message">Optional, the message to display. If not set, the application will generate an appropriate message.</param>
        /// <param name="alarm">Optional, false by default. If true the message is displayed in red.</param>
        public void UpdateStatus(string message = null, bool alarm = false) {
            if (message == null) {
                if (Vault == null) {
                    StatusLabel.Text = "Application ready: no vault open";
                }
                else {
                    StatusLabel.Text = "Application ready: " + Vault.Accounts.Count + " account" + (Vault.Accounts.Count > 1 ? "s" : "") + " available";
                }
                return;
            }
            
            StatusLabel.Text = message;
            if (alarm)
                StatusLabel.ForeColor = Color.Red;
            else
                StatusLabel.ForeColor = Color.Black;

            if (Vault == null) {
                this.Text = Properties.Settings.Default.AppTitle;
            }
            else {
                this.Text = (Vault.Changed ? "* " : "") + Vault.Path + " - " + Properties.Settings.Default.AppTitle;
            }
        }

        /// <summary>
        /// Open a vault using the file path to replace the current one.
        /// </summary>
        /// <param name="filePath"></param>
        private void OpenVault(string filePath) {
            FrmVault _frmOpen = new FrmVault(filePath, true, this.Left + 25, this.Top + 25);
            _frmOpen.ShowDialog(this);
            
            if (_frmOpen.VaultPath != null && _frmOpen.VaultPath != "") {
                try {
                    Vault _temp = new Vault(_frmOpen.VaultPath, _frmOpen.AccessControl);
                    _temp.LoadAccounts();
                    
                    if (CloseVault()) {
                        this.Vault = _temp;
                        UpdateRecentFiles();
                        RefreshList();
                        UpdateStatus("Vault opened: " + Vault.Accounts.Count + " account" + (Vault.Accounts.Count > 1 ? "s" : ""));
                    }
                }
                catch (VaultException ex) {
                    MessageBox.Show(this, "An error occurred accessing the vault: " + ex.Message, "Vault Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            _frmOpen.Dispose();
            
        }
        /// <summary>
        /// Create a new vault.
        /// </summary>
        private void CreateNewVault() {
            FrmVault _newVaultDialog = new FrmVault("", false, this.Left + 25, this.Top + 25);
            _newVaultDialog.ShowDialog(this);
            if (_newVaultDialog.VaultPath != null) {
                try {
                    if (WarnUnprotected(_newVaultDialog.AccessControl)) {
                        Vault _temp = new Vault(_newVaultDialog.VaultPath, _newVaultDialog.AccessControl);
                        // We don't load the accounts: it's a new vault so it is overwritten.
                        if (CloseVault()) {
                            this.Vault = _temp;
                            this.Vault.Save();
                            UpdateRecentFiles();
                            RefreshList();
                            UpdateStatus("New Vault Created");
                        }
                    }
                }
                catch (VaultException ex) {
                    MessageBox.Show(this, "An error occurred accessing the vault: " + ex.Message, "Vault Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            _newVaultDialog.Dispose();
        }

        /// <summary>
        /// Save the vault under a new name, and apply specific access controls.
        /// </summary>
        private void SaveVaultAs() {
            FrmVault _frmSaveAs = new FrmVault(this.Vault.Path, false, this.Left + 25, this.Top + 25);
            _frmSaveAs.ShowDialog(this);

            if (_frmSaveAs.VaultPath != null && _frmSaveAs.VaultPath != "") {
                try {
                    if (WarnUnprotected(_frmSaveAs.AccessControl)) {
                        this.Vault.Path = _frmSaveAs.VaultPath;
                        this.Vault.AccessControl = _frmSaveAs.AccessControl;
                        this.Vault.Save();
                        UpdateRecentFiles();
                        UpdateStatus("Vault saved: " + Vault.Accounts.Count + " account" + (Vault.Accounts.Count > 1 ? "s" : ""));
                    }
                }
                catch (VaultException ex) {
                    MessageBox.Show(this, "An error occurred accessing the vault: " + ex.Message, "Vault Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            _frmSaveAs.Dispose();
        }

        /// <summary>
        /// Update the list of the recent files that were opened. 4 potential file paths are maintained.
        /// </summary>
        private void UpdateRecentFiles() {
            string _filePath = this.Vault.Path;

            // We opened a vault successfully. Manage the recent files.
            if (Recent1 != _filePath && Recent2 != _filePath && Recent3 != _filePath && Recent4 != _filePath) {
                // It's a new file, not in the list.
                Recent4 = Recent3;
                Recent3 = Recent2;
                Recent2 = Recent1;
                Recent1 = _filePath;
            }
            else {
                if (Recent2 == _filePath) {
                    Recent2 = Recent1;
                    Recent1 = _filePath;
                }
                else if (Recent3 == _filePath) {
                    Recent3 = Recent2;
                    Recent2 = Recent1;
                    Recent1 = _filePath;
                }
                else if (Recent4 == _filePath) {
                    Recent4 = Recent3;
                    Recent3 = Recent2;
                    Recent2 = Recent1;
                    Recent1 = _filePath;
                }
            }
            Properties.Settings.Default.Recent1 = Recent1;
            Properties.Settings.Default.Recent2 = Recent2;
            Properties.Settings.Default.Recent3 = Recent3;
            Properties.Settings.Default.Recent4 = Recent4;
            Properties.Settings.Default.Save();
        }
        /// <summary>
        /// This is invoked when private data will be stored without adequate or even any protection.
        /// </summary>
        /// <param name="accessControl"></param>
        /// <returns></returns>
        private bool WarnUnprotected(AccessControl accessControl) {
            if (accessControl.IsNull()) {
                if (Properties.Settings.Default.WarnUnprotected) {
                    DialogResult result = MessageBox.Show(this, "This will create a vault where sensitive information is not protected. Continue?", 
                        "Unprotected Vault", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    return result == DialogResult.Yes;
                }
                return true;
            }
            else
                return true;
        }


        /// <summary>
        /// Clear and recreate the contents of the list view depending on the loaded accounts.
        /// </summary>
        public void RefreshList() {
            this.ListAccounts.Clear();
            this.Vault.Sort();
            foreach (Account _account in Vault.Accounts) {
                ListViewGroup _groupOfAccount = null;

                foreach (ListViewGroup _group in ListAccounts.Groups) {
                    if (_group.Header == _account.Email) {    
                        _groupOfAccount = _group;
                    }
                       
                }
                if (_groupOfAccount == null) {
                    _groupOfAccount = new ListViewGroup(_account.Email);
                    ListAccounts.Groups.Add(_groupOfAccount);
                }

                ListViewItem _lvwItem = new ListViewItem {
                    Text = _account.Server,
                    Tag = _account,
                    Group = _groupOfAccount
                };

                Image _image = _account.Icon;
                if (_image == null)
                    _lvwItem.ImageIndex = 0;
                else {
                    string _key = "key" + ImageListAccounts.Images.Count;
                    ImageListAccounts.Images.Add(_key, _account.Icon);
                    _lvwItem.ImageKey = _key;
                }

                this.ListAccounts.Items.Add(_lvwItem);
            }
        }
        /// <summary>
        /// Save the settings and close/dispose the interface.
        /// </summary>
        private void QuitApplication() {
            if (CloseVault()) {
                Properties.Settings.Default.Width = this.Width;
                Properties.Settings.Default.Height = this.Height;
                Properties.Settings.Default.Recent1 = this.Recent1;
                Properties.Settings.Default.Recent2 = this.Recent2;
                Properties.Settings.Default.Recent3 = this.Recent3;
                Properties.Settings.Default.Recent4 = this.Recent4;
                Properties.Settings.Default.Save();

                this.Dispose();

                Utilities.FormsCount--;
                
                if (Utilities.FormsCount <= 0)
                    Application.Exit();
            }
        }
        // When someone calls on an autogenerated recent file menu.
        private void OpenRecent(object sender, EventArgs e) {
            string _path = ((ToolStripMenuItem) sender).Text;
            OpenVault(_path);
        }

        /// <summary>
        /// Save the current contents of the vault with currently defined access controls.
        /// </summary>
        private void SaveVault() {
            if (this.Vault == null)
                return;
            this.Vault.Save();
            this.Vault.Changed = false;
            UpdateStatus("Vault Saved");
        }

        /// <summary>
        /// Close the current vault.
        /// </summary>
        /// <returns>True if close was successful, false otherwise.</returns>
        private bool CloseVault() {
            // Check if the vault needs to be saved.
            // The saving might cancel the operation.
            if (this.Vault == null) {
                return true;  // Closing did not need to occur, so it is successful.
            }

            if (Vault.Changed) {
                DialogResult _result = MessageBox.Show(this, "Save File Before Closing?", "Unsaved Changes", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
                if (_result == DialogResult.Cancel)
                    return false;  // Not saving and not closing.
                if (_result == DialogResult.Yes)
                    SaveVault();
            }
            this.Vault = null;
            ListAccounts.Items.Clear();
            UpdateStatus("Vault closed");
            return true;
        }

        /// <summary>
        /// Instantiate a new main window for the application to view several vaults at once.
        /// </summary>
        /// <param name="path">The path of the vault to open in the new window.</param>
        private void OpenNewWindow(string path) {
            // Open an independent window for another vault.
            FrmAuthenticator auth = new FrmAuthenticator(new string[] { path });
            Utilities.FormsCount++;
            auth.Show();
        }

        #endregion

        #region "Profile Management"

        /// <summary>
        /// Load profiles from external file into the application.
        /// </summary>
        /// <param name="filePath">The path of the file.</param>
        /// <returns>A list of loaded profiles to be saved or not in the application.</returns>
        public LinkedList<UserProfile> LoadProfiles(string profileDefinition) {
            LinkedList<UserProfile> _profiles = new LinkedList<UserProfile>();

            try {
                // Acquire the XML file.
                XmlDocument _xmlDoc = new XmlDocument();
                _xmlDoc.LoadXml(profileDefinition);

                XmlNodeList _xmlProfiles = _xmlDoc.GetElementsByTagName("profile");

                foreach (XmlNode _xmlProfile in _xmlProfiles) {
                    UserProfile _profile = new UserProfile();

                    _profile.Name = _xmlProfile.Attributes.GetNamedItem("name").InnerText;

                    foreach (XmlNode _xmlParameter in _xmlProfile.ChildNodes) {
                        if (_xmlParameter.Name == "email")
                            _profile.Email = _xmlParameter.InnerText;
                        else if (_xmlParameter.Name == "firstName")
                            _profile.FirstName = _xmlParameter.InnerText;
                        else if (_xmlParameter.Name == "lastName")
                            _profile.LastName = _xmlParameter.InnerText;
                        else if (_xmlParameter.Name == "title")
                            _profile.Title = _xmlParameter.InnerText;
                        else if (_xmlParameter.Name == "phoneNumber")
                            _profile.PhoneNumber = _xmlParameter.InnerText;
                        else if (_xmlParameter.Name == "address")
                            _profile.Address = _xmlParameter.InnerText;
                        else if (_xmlParameter.Name == "organization")
                            _profile.Organization = _xmlParameter.InnerText;
                        else if (_xmlParameter.Name == "avatar") {
                            string _base64 = _xmlParameter.InnerText;
                            if (_base64 == "")
                                _profile.Avatar = null;
                            else {
                                _profile.Avatar = Utilities.Base64ToImage(_base64);
                            }
                        }
                    }
                    _profiles.AddLast(_profile);
                }
                return _profiles;
            }
            catch (Exception ex) {
                MessageBox.Show(this, "An error occurred: " + ex.Message, "Unexpected Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            
        }

        /// <summary>
        /// Opens a profile management interface.
        /// </summary>
        private void ManageProfiles() {
            FrmProfiles _frmProfiles = new FrmProfiles(this, this.Left + 25, this.Top + 25, false);
            _frmProfiles.ShowDialog(this);
        }

        /// <summary>
        /// Serializes the profiles to XML and saves them.
        /// </summary>
        public void SaveProfiles() {
            try {
                string _xmlProfiles = SerializeProfiles();
                Properties.Settings.Default.Profiles = _xmlProfiles;
                Properties.Settings.Default.Save();
                //File.WriteAllText("user_profiles.xml", _xmlProfiles);
            }
            catch (Exception ex) {
                MessageBox.Show(this, "Error occurred: " + ex.Message, "Unexpected Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Serializes the profiles to an XML string.
        /// </summary>
        /// <returns>The XML string.</returns>
        private string SerializeProfiles() {
            // Following the use of the management profile UI, we save any potential changes to the XML file.
            StringBuilder _xmlProfiles = new StringBuilder("<?xml version=\"1.0\" encoding=\"utf-8\"?>\n<profiles>\n");

            foreach (UserProfile _profile in Profiles) {
                _xmlProfiles.Append("  <profile name=\"" + _profile.Name + "\">\n");
                _xmlProfiles.Append("    <email>" + _profile.Email + "</email>\n");
                _xmlProfiles.Append("    <firstName>" + _profile.FirstName + "</firstName>\n");
                _xmlProfiles.Append("    <lastName>" + _profile.LastName + "</lastName>\n");
                _xmlProfiles.Append("    <title>" + _profile.Title + "</title>\n");
                _xmlProfiles.Append("    <phoneNumber>" + _profile.PhoneNumber + "</phoneNumber>\n");
                _xmlProfiles.Append("    <organization>" + _profile.Organization + "</organization>\n");
                _xmlProfiles.Append("    <address>" + _profile.Address + "</address>\n");

                if (_profile.Avatar == null) {
                    _xmlProfiles.Append("    <avatar></avatar>\n");
                }
                else {
                    _xmlProfiles.Append("    <avatar>" + Utilities.ImageToBase64(_profile.Avatar) + "</avatar>\n");
                }
                _xmlProfiles.Append("  </profile>\n");
            }
            _xmlProfiles.Append("</profiles>");
            return _xmlProfiles.ToString();
        }

        // Export of profile to XML file.
        private void MnuExportProfiles_Click(object sender, EventArgs e) {
            ExportProfiles();
        }

        public void ExportProfiles() {
            try {
                string _xmlProfiles = SerializeProfiles();
                OpenFileDialog _openDialog = new OpenFileDialog();
                _openDialog.Filter = "XML Files|*.xml|All Files|*.*";
                _openDialog.CheckFileExists = false;
                _openDialog.CheckPathExists = true;
                _openDialog.DefaultExt = "xml";
                _openDialog.FilterIndex = 0;

                if (_openDialog.ShowDialog(this) == DialogResult.OK)
                    File.WriteAllText(_openDialog.FileName, _xmlProfiles);
            }
            catch (Exception ex) {
                MessageBox.Show(this, "An error occurred: " + ex.Message, "Unexpected Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region "Account Management"

        /// <summary>
        /// Manages an activation of one or more accounts in the ListView. The action
        /// depends on application settings.
        /// </summary>
        private void ActivateAccount() {
            // Depending on the setting of the application, either show details or open URL.

            if (Properties.Settings.Default.ActivateAccountShowsDetails) {
                ShowAccountDetails();
            }
            else {
                OpenLoginPages();
            }
        }

        private void OpenLoginPages() {
            foreach (ListViewItem _lv in ListAccounts.SelectedItems) {
                Process.Start(((Account) _lv.Tag).LoginURL);
            }
        }
        
        /// <summary>
        /// Creates an interface to show account details for each currently selected account.
        /// </summary>
        private void ShowAccountDetails() {
            int _top = this.Top + 25;
            int _left = this.Left + 25;
            foreach (ListViewItem _lv in ListAccounts.SelectedItems) {
                FrmAccount _frmAccount = new FrmAccount((Account) _lv.Tag, this, _left, _top);
                _frmAccount.Show(this);
                _top += 25;
                _left += 25;
            }
        }


        /// <summary>
        /// Add a new account to the ones in the vault currently.
        /// </summary>
        /// <param name="account">The reference to the account to add.</param>
        public void AddNewAccount(Account account) {
            this.Vault.Accounts.Add(account);
            this.Vault.Changed = true;
            RefreshList();
            UpdateStatus("New account added to vault");
            
        }
        /// <summary>
        /// Not a server-initiated deletion: the user is deleting the selected accounts directly.
        /// </summary>
        private void DeleteAccount() {
            int _nbAccountsToDelete = ListAccounts.SelectedItems.Count;

            if (_nbAccountsToDelete == 0)
                return;

            if (MessageBox.Show(this, _nbAccountsToDelete + " account" + (_nbAccountsToDelete > 1 ? "s" : "") +
                    " will be deleted from the vault. Deleting the account from the vault does not delete the account " +
                    "with the service provider. Make sure that you first remove the account from the server. Continue?", 
                "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes) {

                foreach (ListViewItem _lv in ListAccounts.SelectedItems) {
                    Account _accountToDelete = (Account) _lv.Tag;
                    Vault.RemoveAccount(_accountToDelete);
                }

                Vault.Changed = true;
                RefreshList();

                UpdateStatus("Deleted " + _nbAccountsToDelete + " account" + " from the vault");
            }
        }
        /// <summary>
        /// Received an easy authentication message, get the account associated.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="expectingEmail">Are we expecting an email address to be specified or not.</param>
        /// <param name="silent">If true, do not raise error message if no account is found.</param>
        /// <returns>An account if one is identified, null otherwise.</returns>
        private Account GetAccountFromMessage(EasyAuthenticationMessage message, bool expectingEmail, bool silent = false) {
            string _emailAddress = null;
            string _serverID = null;

            if (message.ProvidedParameters.GetParametersByAttribute(Attribute.Identification).Count != 1) {
                MessageBox.Show(this, "The server identification is incorrect for the request", "Identification Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            _serverID = message.ProvidedParameters.GetFirstParameterByAttribute(Attribute.Identification).Value;

            if (expectingEmail && message.ProvidedParameters.GetParametersByAttribute(Attribute.EmailAddress).Count != 1) {
                MessageBox.Show(this, "The email address is incorrectly defined for the request", "Email Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            else if (expectingEmail && message.ProvidedParameters.GetParametersByAttribute(Attribute.EmailAddress).Count == 1)
                _emailAddress = message.ProvidedParameters.GetFirstParameterByAttribute(Attribute.EmailAddress).Value;
            
            LinkedList<Account> _allAccounts = new LinkedList<Account>();
            // Get all accounts registered to that server.
            foreach (Account _account in this.Vault.Accounts) {
                if (_account.Server == _serverID && (!expectingEmail || _account.Email == _emailAddress))
                    _allAccounts.AddLast(_account);                    
            }
            // Didn't find any, so unless a silent request was made, give error message and return null;
            if (_allAccounts.Count == 0) {
                if (! silent)
                    MessageBox.Show(this, "You have no registered account in this vault for that server", "Account Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            // Found exactly one, so return it.
            if (_allAccounts.Count == 1)
                return _allAccounts.ElementAt(0);

            // There were several possibilities, so we make the user select the right one.
            string[] _accounts = new string[_allAccounts.Count];
            for (int i = 0; i < _allAccounts.Count; i++)
                 _accounts[i] = _allAccounts.ElementAt(i).Email;

            FrmValueInput _frmValueInput = new FrmValueInput("Select Account", "More than one account is registered to this server. Select the account with which you want to sign in:",
                            "", false, this.Left + 25, this.Top + 25, _accounts);

            bool _onTop = this.TopMost;
            this.TopMost = false;
            _frmValueInput.ShowDialog(this);
            this.TopMost = _onTop;
            // The user did not select: cancelled or something.
            if (_frmValueInput.Value == null)
               return null;
            // One was selected from the list, so we return the selected one.
            foreach (Account _a in _allAccounts) {
                if (_a.Email == _frmValueInput.Value)
                    return _a;
            }
            // Unreachable by design but required.
            return null;
        }

        /// <summary>
        /// Export the selected accounts to new vault.
        /// </summary>
        private void ExportAccounts() {
            // Whatever accounts are selected in the interface we export as requested.
            if (ListAccounts.SelectedItems.Count == 0) {
                MessageBox.Show(this, "Select the accounts that you want to export", "No Accounts Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            FrmVault _frmSaveAs = new FrmVault("", false, this.Left + 25, this.Top + 25);
            _frmSaveAs.ShowDialog(this);

            if (_frmSaveAs.VaultPath != null && _frmSaveAs.VaultPath != "") {
                try {
                    if (WarnUnprotected(_frmSaveAs.AccessControl)) {
                        Vault _temp = new Vault(_frmSaveAs.VaultPath, _frmSaveAs.AccessControl);

                        foreach (ListViewItem _lv in ListAccounts.SelectedItems) {
                            _temp.Accounts.Add((Account) _lv.Tag);
                        }

                        _temp.Save();
                        UpdateStatus("Accounts exported");
                    }
                }
                catch (VaultException ex) {
                    MessageBox.Show(this, "An error occurred accessing the vault: " + ex.Message, "Vault Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// Import accounts from another vault into the current vault.
        /// </summary>
        private void ImportAccounts() {
            FrmVault _frmSaveAs = new FrmVault("", true, this.Left + 25, this.Top + 25);
            _frmSaveAs.ShowDialog(this);

            if (_frmSaveAs.VaultPath != null && _frmSaveAs.VaultPath != "") {
                try {
                    Vault _temp = new Vault(_frmSaveAs.VaultPath, _frmSaveAs.AccessControl);
                    _temp.LoadAccounts();

                    string _skipped = "";
                    foreach (Account _account in _temp.Accounts) {
                        // Cannot import if it already exists in the vault.
                        bool skipping = false;
                        foreach(Account _existing in this.Vault.Accounts) {
                            if (_account == _existing) {
                                skipping = true;
                                _skipped += "\n - " + _account.Email + " on " + _account.Server;
                                break;
                            }
                        }
                        if (! skipping) {
                            this.Vault.Accounts.Add(_account);
                            this.Vault.Changed = true;
                        }
                    }
                    if (_skipped != "")
                        MessageBox.Show(this, "The following accounts were skipped because they already exist in the vault:" + _skipped, "Accounts Skipped", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    UpdateStatus("Import operation completed");
                    this.RefreshList();
                }
                catch (VaultException ex) {
                    MessageBox.Show(this, "An error occurred accessing the vault: " + ex.Message, "Vault Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        #endregion

        
    }
}
