using System.Windows.Forms;

namespace AuthenticatorProject.EasyAuthentication {
    /// <summary>
    /// A combo box to which a parameter is attached.
    /// </summary>
    public class ParameterComboBox : ComboBox {
        /// <summary>
        /// The parameter attached to the ComboBox.
        /// </summary>
        public Parameter Parameter { get; set; }

        /// <summary>
        /// Constructor for the Control.
        /// </summary>
        /// <param name="parameter">The parameter associated to the control.</param>
        public ParameterComboBox(Parameter parameter) {
            this.Parameter = parameter;
        }
    }
}
