using System;
using System.IO;
using System.Windows.Forms;

namespace AuthenticatorProject {
    /// <summary>
    /// Interface to manage the application settings.
    /// </summary>
    public partial class FrmSettings : Form {
        // Positioning parameters.
        private int PositionLeft { get; set; }
        private int PositionTop { get; set; }

        #region "Form Events"
        /// <summary>
        /// Construct the interface.
        /// </summary>
        /// <param name="left">Position left.</param>
        /// <param name="top">Position top.</param>
        public FrmSettings(int left, int top) {
            this.PositionLeft = left;
            this.PositionTop = top;
            InitializeComponent();
        }
        // Fill the interface with the current settings.
        private void FrmSettings_Load(object sender, EventArgs e) {
            // Position the interface.
            this.Left = PositionLeft;
            this.Top = PositionTop;

            // Load the settings in the interface.1

            // General preferences.
            ChkTopMost.Checked = Properties.Settings.Default.StartOnTop;
            OptOpenURL.Checked = !Properties.Settings.Default.ActivateAccountShowsDetails;
            OptShowDetails.Checked = Properties.Settings.Default.ActivateAccountShowsDetails;

            // Vault preferences.
            TxtDirectory.Text = Properties.Settings.Default.VaultDirectory;
            ChkOpenLast.Checked = Properties.Settings.Default.OpenLast;

            // Security preferences.
            ChkWarnUnprotected.Checked = Properties.Settings.Default.WarnUnprotected;
            LstAlgorithms.Items.AddRange(Properties.Settings.Default.PreferredAlgo.Split('|'));
        }

        #endregion

        #region "Control Events"

        // Set the path for the default directory.
        private void BtnDirectory_Click(object sender, EventArgs e) {
            DialogResult result = FolderBrowserDialog.ShowDialog();
            if (result == DialogResult.OK)
                TxtDirectory.Text = FolderBrowserDialog.SelectedPath;
        }

        // Sort the algorithms to use.
        private void BtnUp_Click(object sender, EventArgs e) {
            if (LstAlgorithms.SelectedItems.Count == 0)
                return;

            if (LstAlgorithms.SelectedItems.Count > 1)
                return;

            int index = LstAlgorithms.SelectedIndex;

            if (index == 0)
                return;

            string[] newList = new string[LstAlgorithms.Items.Count];

            for (int i = 0; i < newList.Length; i++) {
                if (i != index && i != index - 1)
                    newList[i] = LstAlgorithms.Items[i].ToString();
                else if (i == index - 1)
                    newList[i] = LstAlgorithms.Items[index].ToString();
                else if (i == index)
                    newList[i] = LstAlgorithms.Items[index - 1].ToString();
            }

            LstAlgorithms.Items.Clear();
            LstAlgorithms.Items.AddRange(newList);

            LstAlgorithms.SelectedIndex = index - 1;
        }

        // Sort the algorithms to use.
        private void BtnDown_Click(object sender, EventArgs e) {
            if (LstAlgorithms.SelectedItems.Count == 0)
                return;

            if (LstAlgorithms.SelectedItems.Count > 1)
                return;

            int index = LstAlgorithms.SelectedIndex;

            if (index == LstAlgorithms.Items.Count - 1)
                return;

            string[] newList = new string[LstAlgorithms.Items.Count];

            for (int i = 0; i < newList.Length; i++) {
                if (i != index && i != index + 1)
                    newList[i] = LstAlgorithms.Items[i].ToString();
                else if (i == index)
                    newList[i] = LstAlgorithms.Items[index + 1].ToString();
                else if (i == index + 1)
                    newList[i] = LstAlgorithms.Items[index].ToString();
            }

            LstAlgorithms.Items.Clear();
            LstAlgorithms.Items.AddRange(newList);

            LstAlgorithms.SelectedIndex = index + 1;
        }

        private void BtnCancel_Click(object sender, EventArgs e) {
            this.Dispose();
        }

        private void TxtDirectory_DragEnter(object sender, DragEventArgs e) {
            if (e.Data.GetDataPresent(DataFormats.FileDrop, false) == true) {
                e.Effect = DragDropEffects.Copy;
            }
        }

        private void TxtDirectory_DragDrop(object sender, DragEventArgs e) {
            string[] files = (string[]) e.Data.GetData(DataFormats.FileDrop);
            if (files != null && files.Length != 0) {
                if (Directory.Exists(files[0])) {
                    TxtDirectory.Text = files[0];
                }
            }
        }

        /// <summary>
        /// Apply the settings as they are in the form.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnOK_Click(object sender, EventArgs e) {
            // General preferences.
            Properties.Settings.Default.StartOnTop = ChkTopMost.Checked;
            Properties.Settings.Default.ActivateAccountShowsDetails = OptShowDetails.Checked;

            // Vault preferences.
            Properties.Settings.Default.VaultDirectory = TxtDirectory.Text;
            Properties.Settings.Default.OpenLast = ChkOpenLast.Checked;

            // Security preferences.
            Properties.Settings.Default.WarnUnprotected = ChkWarnUnprotected.Checked;

            string algos = "";
            for (int i = 0; i < LstAlgorithms.Items.Count; i++) {
                algos += (algos == "" ? "" : "|") + LstAlgorithms.Items[i].ToString();
            }
            Properties.Settings.Default.PreferredAlgo = algos;

            Properties.Settings.Default.Save();

            this.Dispose();
        }

        #endregion
    }
}
