using System;
using System.Windows.Forms;
using AuthenticatorProject.EasyAuthentication;
using Attribute = AuthenticatorProject.EasyAuthentication.Attribute;

namespace AuthenticatorProject {
    /// <summary>
    /// Interface used to authenticate a new session on the web server.
    /// </summary>
    public partial class FrmSignIn : Form {
        private Account Account { get; set; }
        private int PositionLeft { get; set; }
        private int PositionTop { get; set; }
        private EasyAuthenticationMessage Message { get; set; }
        private FrmAuthenticator Authenticator { get; set; }

        #region "Form Events"

        /// <summary>
        /// Constructing the interface.
        /// </summary>
        /// <param name="account">The account used to sign in.</param>
        /// <param name="left">Positioning parameter.</param>
        /// <param name="top">Positioning parameter.</param>
        /// <param name="message">The message received from the web server.</param>
        public FrmSignIn(FrmAuthenticator authenticator, Account account, int left, int top, EasyAuthenticationMessage message) {
            InitializeComponent();
            Account = account;
            this.PositionLeft = left;
            this.PositionTop = top;
            this.Message = message;
            this.Authenticator = authenticator;
            
        }
        // Populating the interface: mostly just displaying details of the account used to sign.
        private void FrmSignIn_Load(object sender, EventArgs e) {
            this.Left = PositionLeft;
            this.Top = PositionTop;

            TxtEmail.Text = Account.Email;
            TxtServerID.Text = Account.Server;
            TxtAlgorithm.Text = Account.Key.ToString();
            PicAccount.Image = Account.Icon;
            switch( this.Message.ValidateChallenge()) {
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

        #region "Drag and Drop Management"

        private void PicChallenge_MouseDown(object sender, MouseEventArgs e) {
            // Signing in requires the email address and the signature to be provided.
            string _signature = this.Account.Key.Sign(Message.ProvidedParameters.GetFirstParameterByAttribute(Attribute.Challenge).Value);

            EasyAuthenticationMessage _response = new EasyAuthenticationMessage();

            foreach(Parameter _p in Message.RequestedParameters)
                _response.ProvidedParameters.Parameters.AddLast(_p);

            _response.ProvidedParameters.GetFirstParameterByAttribute(Attribute.EmailAddress).Value = Account.Email;
            _response.ProvidedParameters.GetFirstParameterByAttribute(Attribute.Signature).Value = _signature;
            
            PicChallenge.DoDragDrop(_response.ToString(), DragDropEffects.Move);
        }

        private void PicChallenge_QueryContinueDrag(object sender, QueryContinueDragEventArgs e) {
            if (e.Action == DragAction.Drop) {
                this.Close();
                this.Authenticator.Focus();
            }
                
        }

        #endregion
    }
}
