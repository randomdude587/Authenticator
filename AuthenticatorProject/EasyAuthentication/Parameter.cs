
namespace AuthenticatorProject.EasyAuthentication {
    /// <summary>
    /// The unit of an EasyAuthenticationMessage: a parameter, provided or requested, and its properties.
    /// </summary>
    public class Parameter {
        /// <summary>
        ///  The name of the parameter. Standard names can be recognized by the application and acted on in a specific way.
        ///  Generic names can also be used to request additional information.
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// The user-friendly name to attach to the parameter: can be used in form creation.
        /// </summary>
        public string Label { get; set; }
        /// <summary>
        /// The description can be useful in GUI forms and tool tips.
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// The value type expected for the parameter, on in which it was provided. Useful for validation and manipulation.
        /// </summary>
        public ValueType ValueType { get; set; }
        /// <summary>
        /// Only relevant for requested parameters: indicates that a value (neither null or empty) is expected in response.
        /// </summary>
        public bool Mandatory { get; set; }
        /// <summary>
        /// The value of the parameter: either provided, proposed for the response, or to be set by the interaction.
        /// </summary>
        public string Value { get; set; }
        /// <summary>
        /// A default value applied when requesting the parameter.
        /// </summary>
        public string Default { get; set; }
        /// <summary>
        /// The attribute is used to associate the parameter to a standard type of information commonly exchanged.
        /// </summary>
        public Attribute Attribute { get; set; }
        /// <summary>
        /// A flag to indicate if the value should be handled in the background or displayed to the user.
        /// </summary>
        public bool Visible { get; set; }

        /// <summary>
        /// Default empty constructor.
        /// </summary>
        public Parameter() {
            this.Visible = true;
        }

        /// <summary>
        /// Creates a new parameter by cloning an existing one.
        /// </summary>
        /// <param name="parameter"></param>
        public Parameter(Parameter parameter) {
            this.Name = parameter.Name;
            this.Label = parameter.Label;
            this.Description = parameter.Description;
            this.Attribute = parameter.Attribute;
            this.ValueType = parameter.ValueType;
            this.Value = parameter.Value;
            this.Default = parameter.Default;
            this.Mandatory = parameter.Mandatory;
            this.Visible = parameter.Visible;
        }

        /// <summary>
        /// Creation of a basic parameter to be defined more fully later.
        /// </summary>
        /// <param name="name">Name that identifies the parameter.</param>
        /// <param name="attribute">The basic attribute that it refers to.</param>
        /// <param name="visible">Is the parameter to be displayed or kept hidden.</param>
        public Parameter(string name, Attribute attribute, bool visible = true) {
            this.Name = name;
            this.Attribute = attribute;
            this.Visible = visible;
        }

        /// <summary>
        /// Constructor for the parameter with all the properties.
        /// </summary>
        /// <param name="name">Name that identifies the parameter.</param>
        /// <param name="label">The label to attach as a user-friendly identifier.</param>
        /// <param name="description">The description of the parameter.</param>
        /// <param name="type">What format is the value provided in</param>
        /// <param name="attribute">The basic attribute that it refers to.</param>
        /// <param name="visible">Is the parameter to be displayed or kept hidden.</param>
        public Parameter(string name, string label, string description, ValueType type, Attribute attribute, bool visible = true) {
            this.Name = name;
            this.Label = label;
            this.Description = description;
            this.ValueType = type;
            this.Attribute = attribute;
            this.Visible = visible;
        }

        /// <summary>
        /// If the type of the parameter is a list: the value will be separated by '|'. This will return a list of values by splitting them up.
        /// </summary>
        /// <returns></returns>
        public string[] GetListFromValue() {
            return this.Value.Split('|');
        }

        /// <summary>
        /// Create a standard parameter with default properties based on its recognized name.
        /// </summary>
        /// <param name="name">The name associated to the parameter.</param>
        /// <returns></returns>
        public static Parameter FromKeyword(string name) {
            switch (name) {
                case "user_name": return new Parameter("user_name", "Username", "Unique identifier for user", ValueType.String, Attribute.UserName);
                case "email_address": return new Parameter("email_address", "Email Address", "Email Address", ValueType.Email, Attribute.EmailAddress);
                case "first_name": return new Parameter("first_name", "First Name", "First Name", ValueType.String, Attribute.FirstName);
                case "last_name": return new Parameter("last_name", "Last Name", "Last Name", ValueType.String, Attribute.LastName);
                case "organization": return new Parameter("organization", "Organization", "Organization", ValueType.String, Attribute.Organization);
                case "title": return new Parameter("title", "Title", "Title", ValueType.String, Attribute.Title);
                case "address": return new Parameter("address", "Address", "Address", ValueType.String, Attribute.Address);
                case "phone_number": return new Parameter("phone_number", "Phone Number", "Phone Number", ValueType.String, Attribute.PhoneNumber);
                case "digital_signature_algorithm": return new Parameter("digital_signature_algorithm", "Algorithm", "Digital Signature Algorithm", ValueType.ClosedList, Attribute.DigitalSignatureAlgorithm);
                case "public_key": return new Parameter("public_key", "Public Key", "Public Key", ValueType.String, Attribute.PublicKey, false);
                case "challenge": return new Parameter("challenge", "Challenge", "Challenge", ValueType.Hexadecimal, Attribute.Challenge, false);
                case "validation_code": return new Parameter("validation_code", "Validation Code", "Validation Code", ValueType.Hexadecimal, Attribute.ValidationCode, false);
                case "signature": return new Parameter("signature", "Signature", "Signature", ValueType.Hexadecimal, Attribute.Signature, false);
                case "transaction": return new Parameter("transaction", "Transaction", "Transaction", ValueType.String, Attribute.Transaction);
                case "avatar": return new Parameter("avatar", "Avatar", "Avatar", ValueType.Base64Image, Attribute.Avatar);
                case "identification": return new Parameter("identification", "Identification", "Identification", ValueType.String, Attribute.Identification);
                case "url": return new Parameter("url", "URL", "URL", ValueType.URL, Attribute.URL);
                case "certificate": return new Parameter("certificate", "Certificate", "CA-signed X509 Certificate", ValueType.Base64, Attribute.Certificate);
                default: return new Parameter(name, Attribute.Generic);
            }
        }

        /// <summary>
        /// Get the value type from the property of the parameter.
        /// </summary>
        /// <param name="type">A string indicating what the format of the value is supposed to be.</param>
        /// <returns>A ValueType of the format.</returns>
        public static ValueType GetValueTypeFromName(string type) {
            switch (type) {
                case "hexadecimal": return ValueType.Hexadecimal;
                case "string": return ValueType.String;
                case "email": return ValueType.Email;
                case "integer": return ValueType.Integer;
                case "closed_list": return ValueType.ClosedList;
                case "open_list": return ValueType.OpenList;
                case "base64_image": return ValueType.Base64Image;
                case "base64": return ValueType.Base64;
                case "url": return ValueType.URL;
                default: throw new EasyAuthenticationMessageException("Unrecognized parameter value type");
            }
        }

        /// <summary>
        /// From the value type, provide the string that represents it.
        /// </summary>
        /// <returns>The string definition of the value type.</returns>
        public string GetNameFromType() {
            switch (this.ValueType) {
                case ValueType.Hexadecimal: return "hexadecimal";
                case ValueType.Email: return "email";
                case ValueType.Integer: return "integer";
                case ValueType.ClosedList: return "closed_list";
                case ValueType.OpenList: return "open_list";
                case ValueType.Base64Image: return "base64_image";
                case ValueType.Base64: return "base64";
                case ValueType.URL: return "url";
                default: return "string";

            }
        }

        /// <summary>
        /// Recreates an XML node representing the parameter in a protocol-compliant way.
        /// </summary>
        /// <returns>The XML node for the parameter with all its properties defined.</returns>
        public override string ToString() {
            string _xml = "<parameter name='" + this.Name + "' label='" + (this.Label == null ? "" : this.Label) + "' " +
                "description='" + (this.Description == null ? "" : this.Description) + "' type='" + this.GetNameFromType() + "' " +
                "value='" + (this.Value == null ? "" : this.Value) + "' " +
                "default='" + (this.Default == null ? "" : this.Default) + "' " +
                "mandatory='" + (this.Mandatory ? "true" : "false") + "' " +
                "visible='" + (this.Visible ? "true" : "false") + "' />";

            return _xml;
        }
    }

    /// <summary>
    /// The types of format used for the parameter values.
    /// </summary>
    public enum ValueType {
        Hexadecimal, String, Email, Integer, ClosedList, OpenList, Base64Image, Base64, URL
    }

    /// <summary>
    /// The known attribute that are associated to parameter in use for this application.
    /// </summary>
    public enum Attribute {
        UserName, EmailAddress, FirstName, LastName, Title, Address, PhoneNumber, Transaction, Organization, Certificate,
        DigitalSignatureAlgorithm, PublicKey, ValidationCode, Signature, Challenge, Avatar, Identification, URL, Generic
    }

}
