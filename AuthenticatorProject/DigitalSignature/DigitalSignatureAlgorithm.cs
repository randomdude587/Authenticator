
namespace AuthenticatorProject.DigitalSignature {
    /// <summary>
    /// Provides access to the types of digital signature algorithms: RSA, ECDSA, and DSA.
    /// </summary>
    public class DigitalSignatureAlgorithm {
        // Digital Signature Algorithm: The standard algorithm for digital signatures.
        public static readonly DigitalSignatureAlgorithm DSA = new DigitalSignatureAlgorithm("DSA");
        // Elliptic Curve Digital Signature Algorithm.
        public static readonly DigitalSignatureAlgorithm ECDSA = new DigitalSignatureAlgorithm("ECDSA");
        // Rivest, Shamir, Adleman (RSA) Digital Signature Algorithm.
        public static readonly DigitalSignatureAlgorithm RSA = new DigitalSignatureAlgorithm("RSA");

        private string _name = null;
        /// <summary>
        /// Get the short name of the algorithm.
        /// </summary>
        public string Name {
            get { return this._name; }
        }
        /// <summary>
        /// Private constructor: only supported algorithms get visibility.
        /// </summary>
        /// <param name="name"></param>
        private DigitalSignatureAlgorithm(string name) {
            this._name = name;
        }
        /// <summary>
        /// Return the algorithm short name.
        /// </summary>
        /// <returns>The algorithm short name.</returns>
        public override string ToString() {
            return this.Name;
        }
    }

}
