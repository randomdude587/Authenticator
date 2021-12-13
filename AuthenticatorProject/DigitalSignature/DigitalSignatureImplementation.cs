
namespace AuthenticatorProject.DigitalSignature {
    /// <summary>
    /// Represents the implementation of a digital signature algorithm.
    /// </summary>
    public class DigitalSignatureImplementation {
        private string _name = null;
        private DigitalSignatureAlgorithm _algorithm = null;
        // The supported implementations of RSA in the Authenticator.
        public static readonly DigitalSignatureImplementation RSA2048 = new DigitalSignatureImplementation(DigitalSignatureAlgorithm.RSA, "RSA-2048");
        public static readonly DigitalSignatureImplementation RSA3072 = new DigitalSignatureImplementation(DigitalSignatureAlgorithm.RSA, "RSA-3072");
        public static readonly DigitalSignatureImplementation RSA4096 = new DigitalSignatureImplementation(DigitalSignatureAlgorithm.RSA, "RSA-4096");
        // The supported implementations of ECDSA in the Authenticator.
        public static readonly DigitalSignatureImplementation ECDSANIST256p = new DigitalSignatureImplementation(DigitalSignatureAlgorithm.ECDSA, "ECDSA-NIST256p");
        public static readonly DigitalSignatureImplementation ECDSANIST384p = new DigitalSignatureImplementation(DigitalSignatureAlgorithm.ECDSA, "ECDSA-NIST384p");
        public static readonly DigitalSignatureImplementation ECDSANIST521p = new DigitalSignatureImplementation(DigitalSignatureAlgorithm.ECDSA, "ECDSA-NIST521p");
        // The supported implementations of DSA in the Authenticator.
        public static readonly DigitalSignatureImplementation DSA1024 = new DigitalSignatureImplementation(DigitalSignatureAlgorithm.DSA, "DSA-1024"); 
        public static readonly DigitalSignatureImplementation DSA2048 = new DigitalSignatureImplementation(DigitalSignatureAlgorithm.DSA, "DSA-2048");
        public static readonly DigitalSignatureImplementation DSA3072 = new DigitalSignatureImplementation(DigitalSignatureAlgorithm.DSA, "DSA-3072");
        
        /// <summary>
        /// Returns the specific name of the implementation.
        /// </summary>
        public string Name { 
            get { return this._name; }
        }
        /// <summary>
        /// Returns the underlying algorithm used by the implementation.
        /// </summary>
        public DigitalSignatureAlgorithm Algorithm {
            get { return this._algorithm; }
        }
        /// <summary>
        /// Private constructor: only approved and supported implementations can be used.
        /// </summary>
        /// <param name="algorithm">Underlying algorithm.</param>
        /// <param name="name">Specific name of the implementation.</param>
        private DigitalSignatureImplementation(DigitalSignatureAlgorithm algorithm, string name) {
            this._algorithm = algorithm;
            this._name = name;
        }
        /// <summary>
        /// Create the instance from a known name provided as a string.
        /// </summary>
        /// <param name="name">The name of the implementation.</param>
        /// <returns>A supported digital signature implementation.</returns>
        public static DigitalSignatureImplementation FromName(string name) {
            switch (name) {
                case "RSA-2048": return RSA2048;
                case "RSA-3072": return RSA3072;
                case "RSA-4096": return RSA4096;
                case "ECDSA-NIST256p": return ECDSANIST256p;
                case "ECDSA-NIST384p": return ECDSANIST384p;
                case "ECDSA-NIST521p": return ECDSANIST521p;
                case "DSA-1024": return DSA1024;
                case "DSA-2048": return DSA2048;
                case "DSA-3072": return DSA3072;
                default: throw new UnsupportedAlgorithmException("Unrecognized implementation: " + name);
            }
        }
    }
}
