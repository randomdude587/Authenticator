
using System.Security.Cryptography;

namespace AuthenticatorProject.DigitalSignature {
    /// <summary>
    /// Encapsulation of the hashing functions used with the Authenticator.
    /// </summary>
    public class HashFunction {
        private string _name = null;
        private HashAlgorithmName _hashAlgorithmName { get; set; }
        public string Name {
            get { return this._name; }
        }
        /// <summary>
        /// The official name of the algorithm from .Net libraries.
        /// </summary>
        public HashAlgorithmName HashAlgorithmName {
            get { return this._hashAlgorithmName; }
        }
        // The hashing functions used in the Authenticator.
        public static readonly HashFunction SHA1 = new HashFunction("SHA1", HashAlgorithmName.SHA1);
        public static readonly HashFunction SHA256 = new HashFunction("SHA-256", HashAlgorithmName.SHA256);
        public static readonly HashFunction SHA384 = new HashFunction("SHA-384", HashAlgorithmName.SHA384);
        public static readonly HashFunction SHA512 = new HashFunction("SHA-512", HashAlgorithmName.SHA512);

        /// <summary>
        /// Private constructor: hashing functions must be supported to be used.
        /// </summary>
        /// <param name="name">The name used by the Authenticator.</param>
        /// <param name="hashAlgorithmName">The equivalent in the .Net libraries.</param>
        private HashFunction(string name, HashAlgorithmName hashAlgorithmName) {
            this._name = name;
            this._hashAlgorithmName = hashAlgorithmName;
        }
        /// <summary>
        /// Get the instance from the specific name.
        /// </summary>
        /// <param name="name">The hash function short name.</param>
        /// <returns>An instance of the HashFunction from its name.</returns>
        public static HashFunction FromName(string name) {
            if (name == "SHA1")
                return SHA1;
            if (name == "SHA-256")
                return SHA256;
            if (name == "SHA-384")
                return SHA256;
            if (name == "SHA-512")
                return SHA256;
            throw new UnsupportedAlgorithmException("Unrecognized hashing function: " + name);
        }
        /// <summary>
        /// Get the name representation of the hash function.
        /// </summary>
        /// <returns>The name of the implementation.</returns>
        public override string ToString() {
            if (this == SHA1) return "SHA1";
            if (this == SHA256) return "SHA256";
            if (this == SHA384) return "SHA384";
            if (this == SHA512) return "SHA512";
            return null;
        }
    }
}
