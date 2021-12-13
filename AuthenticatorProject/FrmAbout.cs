using System;
using System.Windows.Forms;

namespace AuthenticatorProject {
    /// <summary>
    /// Display information about the application.
    /// </summary>
    public partial class FrmAbout : Form {
        // Positioning parameters.
        private int PositionLeft { get; set; }
        private int PositionTop { get; set; }

        #region "Form Events"

        public FrmAbout(int left, int top) {
            InitializeComponent();
            this.PositionLeft = left;
            this.PositionTop = top;
        }
        // Construct the interface.
        private void FrmAbout_Load(object sender, EventArgs e) {
            this.Left = PositionLeft;
            this.Top = PositionTop;

            this.LblVersion.Text = "Version: " + System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();
        }

        #endregion

        #region "Button Events"

        private void BtnOK_Click(object sender, EventArgs e) {
            this.Dispose();
        }

        #endregion
    }
}
