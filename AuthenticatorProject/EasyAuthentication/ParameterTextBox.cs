using System.Windows.Forms;

namespace AuthenticatorProject.EasyAuthentication {
    /// <summary>
    /// A text box to which a parameter is attached.
    /// </summary>
    public class ParameterTextBox : TextBox {
        
        public Parameter Parameter { get; set; }
        /// <summary>
        /// Constructor for the Control.
        /// </summary>
        /// <param name="parameter">The parameter associated to the control.</param>
        public ParameterTextBox(Parameter parameter) {
            this.Parameter = parameter;
            this.Text = parameter.Default;
        }
    }
}
