using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AuthenticatorProject {
    /// <summary>
    /// Utility class that allows to query the user to obtain a specific piece of information.
    /// </summary>
    public partial class FrmValueInput : Form {
        // Can the user reply with an empty value or not.
        private bool EmptyAllowed { get; set; }
        private int PositionLeft { get; set; }
        private int PositionTop { get; set; }
        // If true, the user can provide a free form answer. Otherwise, an answer must be selected from a list.
        private bool FreeForm { get; set; }
        // The value returned.
        public string Value { get; set; }
        // List of values that cannot be used as an answer.
        public string[] Denied { get; set; }
        // List of values from which an answer must be selected.
        public string[] Allowed { get; set; }

        #region "Form Events"
        /// <summary>
        /// Constructing the interface.
        /// </summary>
        /// <param name="title">Title to use on the interface.</param>
        /// <param name="question">Question to ask the user.</param>
        /// <param name="initialValue">Initial value to suggest for the user.</param>
        /// <param name="emptyAllowed">Can an empty answer be returned or not.</param>
        /// <param name="left">Positioning parameter.</param>
        /// <param name="top">Positioning parameter.</param>
        /// <param name="allowedValues">List of allowed values in which to choose an answer.</param>
        /// <param name="deniedValues">List of values that cannot be used as an answer.</param>
        public FrmValueInput(string title, string question, string initialValue, bool emptyAllowed, int left, int top, 
                             string[] allowedValues = null, string[] deniedValues = null) {
            InitializeComponent();

            this.LblQuestion.Text = question;
            this.Text = title;
            this.EmptyAllowed = emptyAllowed;

            this.Denied = deniedValues;
            this.Allowed = allowedValues;

            // Do we use the interface to select from multiple values, or is it free-form?
            this.FreeForm = this.Allowed == null;

            this.PositionLeft = left;
            this.PositionTop = top;

            
            if (FreeForm) {
                // So it's free form. Use the textbox.
                this.TxtValue.Text = initialValue;
                this.TxtValue.SelectAll();
                this.CboValue.Visible = false;
            }
            else {
                this.TxtValue.Visible = false;
                CboValue.Top = 35;
                CboValue.Items.AddRange(Allowed);
                CboValue.SelectedIndex = 0;   
            }
        }
        // Position the interface.
        private void FrmValueInput_Load(object sender, EventArgs e) {
            this.Top = this.PositionTop;
            this.Left = this.PositionLeft;
        }

        #endregion

        #region "Button Actions"
        // If the user cancels, a null answer is returned.
        private void BtnCancel_Click(object sender, EventArgs e) {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
        // Check the value that is being submitted.
        private void BtnOk_Click(object sender, EventArgs e) {
            if (FreeForm) {
                if (EmptyAllowed || TxtValue.Text != "") {
                    // Did the user select a value that is restricted?
                    if (Denied != null) { // Some values cannot be used.
                        foreach (string _value in Denied) {
                            if (TxtValue.Text == _value) {
                                MessageBox.Show(this, "The value " + TxtValue.Text + " cannot be used", "Denied Value", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                        }
                    }

                    this.Value = TxtValue.Text;
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else {
                    MessageBox.Show(this, "Provided value cannot be empty", "Empty Value", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else {
                // Straight-forward: limited selection from a pre-determined list.
                this.Value = CboValue.Text;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        #endregion
    }
}
