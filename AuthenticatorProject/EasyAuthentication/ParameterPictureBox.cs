using System;
using System.Drawing;
using System.Windows.Forms;

namespace AuthenticatorProject.EasyAuthentication {
    /// <summary>
    /// A picture box to which a parameter is attached.
    /// </summary>
    public class ParameterPictureBox : PictureBox {
        public Parameter Parameter { get; set; }
        /// <summary>
        /// Constructor for the Control.
        /// </summary>
        /// <param name="parameter">The parameter associated to the control.</param>
        public ParameterPictureBox(Parameter parameter) {
            this.Parameter = parameter;
            this.Text = parameter.Default;
            this.DoubleClick += this.ParameterPictureBox_DoubleClick;
        }

        private void ParameterPictureBox_DoubleClick(object sender, System.EventArgs e) {
            OpenFileDialog OpenImage = new OpenFileDialog();
            OpenImage.Filter = "Image Files| *.jpg; *.jpeg; *.png";
            OpenImage.FileName = "";
            OpenImage.AddExtension = true;
            OpenImage.CheckFileExists = true;
            OpenImage.CheckPathExists = true;
            OpenImage.DefaultExt = "png";
            OpenImage.Multiselect = false;

            if (OpenImage.ShowDialog() == DialogResult.OK) {
                try {
                    this.Image = Image.FromFile(OpenImage.FileName);
                }
                catch (Exception ex) {
                    MessageBox.Show(this, "An error occurred: " + ex.Message, "Unexpected Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
