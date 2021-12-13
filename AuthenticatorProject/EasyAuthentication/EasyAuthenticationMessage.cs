using System;
using System.Globalization;
using System.Text;
using System.Xml;
using System.Windows.Forms;

namespace AuthenticatorProject.EasyAuthentication {
    /// <summary>
    /// The representation of the message being transited between two different entities to implement the 
    /// EasyAuthentication protocol.
    /// </summary>
    public class EasyAuthenticationMessage {
        /// <summary>
        /// Specifies the intent of the message: the action being carried out.
        /// </summary>
        public MessageAction Action { get; set; }
        /// <summary>
        /// A list of provided parameters in the message to give meaning to the message.
        /// </summary>
        public ParameterList ProvidedParameters { get; set; }
        /// <summary>
        /// A list of requested parameters that must be sent in response to complete the action.
        /// </summary>
        public ParameterList RequestedParameters { get; set; }

        /// <summary>
        /// Basic constructor for the class: create empty lists of provided and requested parameters.
        /// </summary>
        public EasyAuthenticationMessage() {
            this.ProvidedParameters = new ParameterList();
            this.RequestedParameters = new ParameterList();
        }
        /// <summary>
        /// Create an instance of the message using a protocol-compliant XML definition of the message. This
        /// is the typical way to create a message in the system: capture the XML sent by the external entity
        /// and instantiate the object.
        /// </summary>
        /// <param name="xmlContent"></param>
        public EasyAuthenticationMessage(string xmlContent) {
            ProvidedParameters = new ParameterList();
            RequestedParameters = new ParameterList();
            
            // Deserialize the XML content into the object.
            XmlDocument xmlDoc = new XmlDocument();
            try {
                xmlDoc.LoadXml(xmlContent);
                XmlNodeList _nodes = xmlDoc.GetElementsByTagName("easy_authentication_message");
                if (_nodes.Count != 1)
                    throw new EasyAuthenticationMessageException("Could not find the message root");

                XmlNode _root = _nodes[0];
                if (_root.Attributes.GetNamedItem("action") != null) {
                    Action = GetActionFromName(_root.Attributes.GetNamedItem("action").InnerText);
                }
                else
                    throw new EasyAuthenticationMessageException("Action of the message is not defined");

                XmlNode _provided = null;
                XmlNode _requested = null;

                _nodes = xmlDoc.GetElementsByTagName("provided_parameters");
                if (_nodes.Count > 1) {
                    throw new EasyAuthenticationMessageException("More than one section of provided parameters is defined");
                }
                else if (_nodes.Count == 1) {
                    _provided = _nodes[0];
                }

                _nodes = xmlDoc.GetElementsByTagName("requested_parameters");
                if (_nodes.Count > 1) {
                    throw new EasyAuthenticationMessageException("More than one section of requested parameters is defined");
                }
                else if (_nodes.Count == 1) {
                    _requested = _nodes[0];
                }

                if (_provided == null && _requested == null)
                    throw new EasyAuthenticationMessageException("The message has neither provided parameters nor requested parameters");

                if (_provided != null)
                    LoadParameters(ProvidedParameters, _provided);

                if (_requested != null)
                    LoadParameters(RequestedParameters, _requested);

            }
            catch (XmlException) {
                throw new EasyAuthenticationMessageException("The message is not valid XML");
            }
        }       
        
        // Load a parameter list from an XML node.
        private void LoadParameters(ParameterList list, XmlNode node) {
            // Read the provided parameters.
            foreach (XmlNode _child in node.ChildNodes) {
                if (_child.Name != "parameter")
                    throw new EasyAuthenticationMessageException("Illegal tag in message: " + _child.Name);

                Parameter _param = null;
                if (_child.Attributes.GetNamedItem("name") != null)
                    _param = Parameter.FromKeyword(_child.Attributes.GetNamedItem("name").InnerText);
                else
                    throw new EasyAuthenticationMessageException("Parameters must have a name");

                if (_child.Attributes.GetNamedItem("label") != null) 
                    _param.Label = _child.Attributes.GetNamedItem("label").InnerText;
                
                if (_child.Attributes.GetNamedItem("description") != null) 
                    _param.Description = _child.Attributes.GetNamedItem("description").InnerText;

                if (_child.Attributes.GetNamedItem("mandatory") != null)
                    _param.Mandatory = (_child.Attributes.GetNamedItem("mandatory").InnerText == "true");

                if (_child.Attributes.GetNamedItem("type") != null) 
                    _param.ValueType = Parameter.GetValueTypeFromName(_child.Attributes.GetNamedItem("type").InnerText);
                
                if (_child.Attributes.GetNamedItem("value") != null) 
                    _param.Value = _child.Attributes.GetNamedItem("value").InnerText;
                
                if (_child.Attributes.GetNamedItem("default") != null) 
                    _param.Default = _child.Attributes.GetNamedItem("default").InnerText;

                list.Parameters.AddLast(_param);
            }
        } 
        
        // Get the action type from its name.
        private static MessageAction GetActionFromName(string action) {
            switch (action) {
                case "register": return MessageAction.Register;
                case "sign_in": return MessageAction.SignIn;
                case "sign": return MessageAction.Sign;
                case "terminate": return MessageAction.Terminate;
                case "reset_key": return MessageAction.ResetKey;
                case "renew_key": return MessageAction.RenewKey;
                case "edit_account": return MessageAction.EditAccount;
                default: throw new EasyAuthenticationMessageException("Action not recognized:" + action);
            }
        }

        // Get the string name of the action from its type.
        private string GetNameFromAction() {
            switch (this.Action) {
                case MessageAction.Register: return "register";
                case MessageAction.SignIn: return "sign_in";
                case MessageAction.Sign: return "sign";
                case MessageAction.Terminate: return "terminate";
                case MessageAction.ResetKey: return "reset_key";
                case MessageAction.RenewKey: return "renew_key";
                case MessageAction.EditAccount: return "edit_account";
                default: throw new EasyAuthenticationMessageException("Unmanaged type of message action");
            }
        }

        /// <summary>
        /// This projects the message instance onto a XML-encoded representation that is compliant with
        /// the EasyAuthentication protocol.
        /// </summary>
        /// <returns></returns>
        public override string ToString() {
            // Encode the XML equivalent of the message to be sent out.
            StringBuilder _xml = new StringBuilder("<?xml version=\"1.0\" encoding=\"UTF-8\"?>");
            _xml.Append("<easy_authentication_message action=\"" + GetNameFromAction() + "\">");
            _xml.Append("<provided_parameters>");

            foreach(Parameter _p in this.ProvidedParameters) 
                _xml.Append(_p.ToString());

            foreach (Parameter _p in this.RequestedParameters)
                _xml.Append(_p.ToString());

            _xml.Append("</provided_parameters>");
            _xml.Append("<requested_parameters>");
            _xml.Append("</requested_parameters>");
            _xml.Append("</easy_authentication_message>");
            return _xml.ToString();
        }

        /// <summary>
        /// Validate the challenge received for server identification and expiration.
        /// </summary>
        /// <returns>A ChallengeStatus value that represents the status.</returns>
        public ChallengeStatus ValidateChallenge() {

            string challenge = this.ProvidedParameters.GetFirstParameterByAttribute(Attribute.Challenge).Value;
            string serverId = this.ProvidedParameters.GetFirstParameterByAttribute(Attribute.Identification).Value;

            string[] challengeParameters = challenge.Split('|');
            if (serverId != challengeParameters[1])
                return ChallengeStatus.WrongIdentification;  // Disparity between server identification in message and in the challenge.

            DateTime challengeDate = DateTime.ParseExact(challengeParameters[0], "yyyy-MM-dd HH:mm:ssZ", CultureInfo.InvariantCulture);
            DateTime challengeExpiration = challengeDate.AddSeconds(60);

            if (challengeExpiration >  DateTime.UtcNow)
                return ChallengeStatus.Expired; // Challenge is expired.

            if (challengeDate > DateTime.UtcNow)
                return ChallengeStatus.InTheFuture; // Challenge was set in the future.

            return ChallengeStatus.Valid;  // Challenge is valid.
        }
    }

    /// <summary>
    /// A list of recognized message actions for this application.
    /// </summary>
    public enum MessageAction {
        Register, SignIn, Sign, Terminate, ResetKey, RenewKey, EditAccount
    }

    public enum ChallengeStatus {
        WrongIdentification, Expired, InTheFuture, Valid
    }
}
