using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthenticatorProject.DigitalSignature {
    /// <summary>
    /// Defines an easy access object to the canonical information for the subject and issuer.
    /// </summary>
    public class CanonicalInformation {
        private string _name = "";
        private string _emailAddress = "";
        private string _organisation = "";
        private string _organisationalUnit = "";
        private string _locality = "";
        private string _state = "";
        private string _country = "";
        private string _address = "";
        private string _complete = "";
        /// <summary>
        /// Common Name.
        /// </summary>
        public string Name {
            get { return this._name; }
        }
        /// <summary>
        /// Common Name.
        /// </summary>
        public string CN {
            get { return this._name; }
        }
        /// <summary>
        /// Email address. Not a standard field and deprecated.
        /// </summary>
        public string EmailAddress {
            get { return this._emailAddress; }
        }
        /// <summary>
        /// Email address. Not a standard field and deprecated.
        /// </summary>
        public string E {
            get { return this._emailAddress; }
        }
        /// <summary>
        /// The organisation field of the canonical information.
        /// </summary>
        public string Organisation {
            get { return this._organisation; }
        }
        /// <summary>
        /// The organisation field of the canonical information.
        /// </summary>
        public string O {
            get { return this._organisation; }
        }
        /// <summary>
        /// The organisational unit field of the canonical information.
        /// </summary>
        public string OrganisationalUnit {
            get { return this._organisationalUnit; }
        }
        /// <summary>
        /// The organisational unit field of the canonical information.
        /// </summary>
        public string OU {
            get { return this._organisation; }
        }
        /// <summary>
        /// The locality field of the canonical information.
        /// </summary>
        public string Locality {
            get { return this._locality; }
        }
        /// <summary>
        /// The locality field of the canonical information.
        /// </summary>
        public string L {
            get { return this._locality; }
        }
        /// <summary>
        /// The state field of the canonical information.
        /// </summary>
        public string State {
            get { return this._state; }
        }
        /// <summary>
        /// The state field of the canonical information.
        /// </summary>
        public string ST {
            get { return this._state; }
        }
        /// <summary>
        /// The country field of the canonical information.
        /// </summary>
        public string Country {
            get { return this._country; }
        }
        /// <summary>
        /// The country field of the canonical information.
        /// </summary>
        public string C {
            get { return this._country; }
        }
        /// <summary>
        /// Creates a composite address using, if available, the locality, state, country fields..
        /// </summary>
        public string Address {
            get { return this._address; }
        }
        /// <summary>
        /// Splits a canonical information string into several fields for simplified access.
        /// </summary>
        /// <param name="canonicalInformation">The canonical string, typically: CN=..., O=..., etc.</param>
        public CanonicalInformation(string canonicalInformation) {
            this._complete = canonicalInformation;
            string[] subjectDetails = canonicalInformation.Split(',');
            foreach (string detail in subjectDetails) {
                string info = detail.Trim();
                if (info.StartsWith("O="))
                    _organisation = info.Substring(2);
                else if (info.StartsWith("OU="))
                    _organisationalUnit = info.Substring(3);
                else if (info.StartsWith("L="))
                    _locality = info.Substring(2);
                else if (info.StartsWith("C="))
                    _country = info.Substring(2);
                else if (info.StartsWith("S="))
                    _state = info.Substring(3);
                else if (info.StartsWith("CN="))
                    _name = info.Substring(3);
                else if (info.StartsWith("E="))
                    _emailAddress = info.Substring(2);
            }

            if (_locality != "") _address = _locality;
            if (_state != "")
                _address = _address == "" ? _state : _address + ", " + _state;
            if (_country != "")
                _address = _address == "" ? _country : _address + ", " + _country;
        }
        /// <summary>
        /// Returns the encapsulated canonical information string.
        /// </summary>
        /// <returns></returns>
        public override string ToString() {
            return this._complete;
        }
    }
}
