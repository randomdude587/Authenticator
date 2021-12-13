using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace AuthenticatorProject {
    /// <summary>
    /// Creates a GUI to consult the properties of an account.
    /// </summary>
    public partial class FrmAccount : Form {
        /// <summary>
        /// The account that will be displayed in the form.
        /// </summary>
        private Account Account { get; set; }
        // Positioning parameters.
        private int PositionLeft { get; set; }
        private int PositionTop { get; set; }
        // Pointer to the authenticator form that invoked this form.
        private FrmAuthenticator Authenticator { get; set; }
                
        #region "Form Events"
        /// <summary>
        /// Instantiate a form to display the details of an account.
        /// </summary>
        /// <param name="account">The account to display.</param>
        /// <param name="left">Positioning the left of the form</param>
        /// <param name="top">Positioning the top of the form</param>
        public FrmAccount(Account account, FrmAuthenticator authenticator, int left, int top) {
            InitializeComponent();
            Account = account;
            this.Authenticator = authenticator;
            this.PositionLeft = left;
            this.PositionTop = top;
        }
        
        // Load the graphical objects with the properties of the account.
        private void FrmAccount_Load(object sender, EventArgs e) {
            this.Left = PositionLeft;
            this.Top = PositionTop;

            TxtEmail.Text = Account.Email;
            TxtLoginURL.Text = Account.LoginURL;
            TxtServerID.Text = Account.Server;
            TxtAlgorithm.Text = Account.Key.ToString();
            TxtNotes.Text = Account.Notes;
            
            PicAccount.Image = Account.Icon;
        }
        // If there are changes, check to save them before closing.
        private void FrmAccount_FormClosing(object sender, FormClosingEventArgs e) {
            if (TxtNotes.Text != Account.Notes || TxtLoginURL.Text != Account.LoginURL) {
                DialogResult _answer = MessageBox.Show(this, "There are unsaved changes to the account. Save?", "Changes Pending", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);

                if (_answer == DialogResult.Yes) {
                    SaveChanges();
                }
                else if (_answer == DialogResult.No)
                    this.Dispose();
                else
                    e.Cancel = true;
            }
        }

        #endregion

        #region "Control Events"
        
        // Changes are saved and the interface is closed.
        private void BtnOK_Click(object sender, EventArgs e) {
            if (TxtNotes.Text != Account.Notes || TxtLoginURL.Text != Account.LoginURL) {
                SaveChanges();
            }
            this.Dispose();
        }

        private void BtnCancel_Click(object sender, EventArgs e) {
            this.Close();
        }
        #endregion

        #region "Data Management"
        
        // Apply changes to the account.
        private void SaveChanges() {
            Account.LoginURL = TxtLoginURL.Text;
            Account.Notes = TxtNotes.Text;
            Authenticator.Vault.Changed = true;
            Authenticator.UpdateStatus("Account modified");
        }

        #endregion
    }
}
