using System;
using System.Windows.Forms;
using AuthenticatorProject.EasyAuthentication;
using Attribute = AuthenticatorProject.EasyAuthentication.Attribute;

namespace AuthenticatorProject {
    public partial class FrmTerminate : Form {
        /// <summary>
        /// Interface used to confirm a termination request of the account on the web server interface.
        /// </summary>
        private EasyAuthenticationMessage Message { get; set; }
        private Account Account { get; set; }
        private int PositionLeft { get; set; }
        private int PositionTop { get; set; }
        private FrmAuthenticator Authenticator { get; set; }

        #region "Form Events"
        
        /// <summary>
        /// Constructing the interface.
        /// </summary>
        /// <param name="account">The account being terminated.</param>
        /// <param name="authenticator">The instance of the main interface.</param>
        /// <param name="left">Positioning parameter.</param>
        /// <param name="top">Positioning parameter.</param>
        /// <param name="message">The message received from the web server.</param>
        public FrmTerminate(Account account, FrmAuthenticator authenticator, int left, int top, EasyAuthenticationMessage message) {
            InitializeComponent();
            Account = account;
            this.PositionLeft = left;
            this.PositionTop = top;
            this.Message = message;
            this.Authenticator = authenticator;
        }

        // Populating the interface. Display which account is being terminated.
        private void FrmTerminate_Load(object sender, EventArgs e) {
            this.Left = PositionLeft;
            this.Top = PositionTop;

            TxtServerID.Text = Account.Email + " on " + Account.Server;
        }

        #endregion

        #region "Drag and Drop Operations"

        // Termination only requires a signature to be applied.
        private void PicTermination_MouseDown(object sender, MouseEventArgs e) {
            EasyAuthenticationMessage _response = new EasyAuthenticationMessage();
            string _signature = this.Account.Key.Sign(Message.ProvidedParameters.GetFirstParameterByAttribute(Attribute.Challenge).Value);

            Parameter _p = new Parameter();
            _p.Name = "signature";
            _p.Attribute = Attribute.Signature;
            _p.Value = _signature;

            _response.ProvidedParameters.Parameters.AddLast(_p);

            PicTermination.DoDragDrop(_response.ToString(), DragDropEffects.Move);
        }

        // When dropping the token, automatically delete the account from the vault. Action still needs to be saved to be permanent and can be undone.
        private void PicTermination_QueryContinueDrag(object sender, QueryContinueDragEventArgs e) {
            if (e.Action == DragAction.Drop) {
                // Delete the account from the vault.
                Authenticator.Vault.RemoveAccount(Account);
                Authenticator.UpdateStatus("Account removed from the vault");
                Authenticator.RefreshList();
                Authenticator.Focus();
                this.Dispose();
            }
        }

        #endregion
    }
}
