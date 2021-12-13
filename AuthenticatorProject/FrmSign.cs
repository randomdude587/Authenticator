using System;
using System.Windows.Forms;
using AuthenticatorProject.EasyAuthentication;
using Attribute = AuthenticatorProject.EasyAuthentication.Attribute;

namespace AuthenticatorProject {
    /// <summary>
    /// Interface allowing to sign an transaction on the server: generic application of a digital signature.
    /// </summary>
    public partial class FrmSign : Form {
        private EasyAuthenticationMessage Message { get; set; }
        private Account Account { get; set; }
        private int PositionLeft { get; set; }
        private int PositionTop { get; set; }

        #region "Form Events"

        /// <summary>
        /// Constructing the interface.
        /// </summary>
        /// <param name="account">The account used to sign.</param>
        /// <param name="left">Positioning parameter.</param>
        /// <param name="top">Positioning parameter.</param>
        /// <param name="message">Message received from the web server.</param>
        public FrmSign(Account account, int left, int top, EasyAuthenticationMessage message) {
            InitializeComponent();
            Account = account;
            this.PositionLeft = left;
            this.PositionTop = top;
            this.Message = message;
        }

        // Setting the interface: what is the server asking?
        private void FrmSign_Load(object sender, EventArgs e) {
            this.Left = PositionLeft;
            this.Top = PositionTop;

            TxtTransaction.Text = Account.Server + " requests a signature for: " + Message.ProvidedParameters.GetFirstParameterByAttribute(Attribute.Transaction).Value;
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
        }

        #endregion

        #region "Drag and Drop"

        // Providing the signature.
        private void PicSignature_MouseDown(object sender, MouseEventArgs e) {
            EasyAuthenticationMessage _response = new EasyAuthenticationMessage();
            string _signature = this.Account.Key.Sign(Message.ProvidedParameters.GetFirstParameterByAttribute(Attribute.Challenge).Value);

            Parameter _p = new Parameter();
            _p.Name = "signature";
            _p.Attribute = Attribute.Signature;
            _p.Value = _signature;
           
            _response.ProvidedParameters.Parameters.AddLast(_p);

            PicSignature.DoDragDrop(_response.ToString(), DragDropEffects.Move);
        }

        private void PicSignature_QueryContinueDrag(object sender, QueryContinueDragEventArgs e) {
            if (e.Action == DragAction.Drop)
                this.Dispose();
        }

        #endregion
    }
}
