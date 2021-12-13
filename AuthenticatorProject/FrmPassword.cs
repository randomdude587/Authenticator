using System;
using System.Drawing;
using System.Windows.Forms;

namespace AuthenticatorProject {
    /// <summary>
    /// Password management and construction interface.
    /// </summary>
    public partial class FrmPassword : Form {
        private int PositionLeft;
        private int PositionTop;
        public string Password { get; set; }

        #region "Form Events"

        public FrmPassword(int left, int top, string password) {
            InitializeComponent();
            PositionLeft = left;
            PositionTop = top;
            this.Password = password;
        }
        /// <summary>
        /// Load the settings for the password generator portion.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmPassword_Load(object sender, EventArgs e) {
            this.Left = PositionLeft;
            this.Top = PositionTop;
            this.TxtPassword.Text = Password;

            NumPasswordLength.Value = Properties.Settings.Default.PasswordLength;
            ChkUpperCase.Checked = Properties.Settings.Default.PasswordUseUpper;
            ChkLowerCase.Checked = Properties.Settings.Default.PasswordUseLower;
            ChkDigits.Checked = Properties.Settings.Default.PasswordUseDigits;
            ChkSpecialChars.Checked = Properties.Settings.Default.PasswordUseSpecialChars;
            TxtSpecialCharsAlphabet.Text = Properties.Settings.Default.SpecialCharsAlphabet;

            RefreshInterface();
        }
        /// <summary>
        /// Save the settings if they were modified and the user agrees.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmPassword_FormClosing(object sender, FormClosingEventArgs e) {
            if (ChkDigits.Checked != Properties.Settings.Default.PasswordUseDigits ||
                ChkUpperCase.Checked != Properties.Settings.Default.PasswordUseUpper ||
                ChkLowerCase.Checked != Properties.Settings.Default.PasswordUseLower ||
                ChkSpecialChars.Checked != Properties.Settings.Default.PasswordUseSpecialChars ||
                NumPasswordLength.Value != Properties.Settings.Default.PasswordLength) {
                // The settings for the generator were modified.

                DialogResult result = MessageBox.Show(this, "Save the changes to the password generator settings?", "Save Settings",
                    MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);

                if (result == DialogResult.Cancel)
                    e.Cancel = true;
                else if (result == DialogResult.Yes) {
                    Properties.Settings.Default.PasswordUseDigits = ChkDigits.Checked;
                    Properties.Settings.Default.PasswordUseUpper = ChkUpperCase.Checked;
                    Properties.Settings.Default.PasswordUseLower = ChkLowerCase.Checked;
                    Properties.Settings.Default.PasswordUseSpecialChars = ChkSpecialChars.Checked;
                    Properties.Settings.Default.PasswordLength = (int) NumPasswordLength.Value;

                    Properties.Settings.Default.Save();
                }
            }
        }

        #endregion

        #region "Control Events"

        private void ChkDisplay_CheckedChanged(object sender, EventArgs e) {
            TxtPassword.UseSystemPasswordChar = !ChkDisplay.Checked;
        }

        private void TxtPassword_TextChanged(object sender, EventArgs e) {
            RefreshInterface();
        }

        private void BtnOK_Click(object sender, EventArgs e) {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void BtnCancel_Click(object sender, EventArgs e) {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void BtnGenerate_Click(object sender, EventArgs e) {
            string alphabet = "";

            if (ChkDigits.Checked)
                alphabet += "0123456789";
            if (ChkLowerCase.Checked)
                alphabet += "abcdefghijklmnopqrstuvwxyz";
            if (ChkUpperCase.Checked)
                alphabet += "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            if (ChkSpecialChars.Checked)
                alphabet += TxtSpecialCharsAlphabet.Text;

            TxtPassword.Text = PasswordUtilities.GenerateRandomContent((int) NumPasswordLength.Value, alphabet);
        }

        #endregion

        #region "Password Generator and Strength Evaluation"

        private void RefreshInterface() {
            // All the adjustments to make in the interface when the password in construction is modified.
            this.Password = TxtPassword.Text;

            if (Password == "") {
                LblPredictability.Text = "";
                LblEntropy.Text = "";

                LblPredictabilityColor.BackColor = Color.White;
                LblEntropyColor.BackColor = Color.White;
                return;
            }

            int nb = PasswordUtilities.NbFoundOccurrences(this.Password);
            double entropy = PasswordUtilities.CalculateEntropy(this.Password);

            LblPredictability.Text = "Number of occurrences in HaveIBeenPwned.com: " + nb.ToString("N0");
            LblEntropy.Text = "Calculated Password Entropy: " + PasswordUtilities.CalculateEntropy(this.Password).ToString("0.##") + " bits";

            LblPredictabilityColor.BackColor = nb > 0 ? Color.Red : Color.Green;
            LblEntropyColor.BackColor = PasswordUtilities.GetColor(entropy);
        }

        #endregion
    }
}
