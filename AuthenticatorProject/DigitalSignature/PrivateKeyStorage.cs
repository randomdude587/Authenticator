
namespace AuthenticatorProject.DigitalSignature {
    /// <summary>
    /// Indication of the location of the private key used for digital signatures.
    /// </summary>
    public class PrivateKeyStorage {
        private string _storage = null;
        /// <summary>
        /// Get the string representation of the storage.
        /// </summary>
        public string Name {
            get { return this._storage; }
        }
        // Supported locations for private key storage options.
        public static readonly PrivateKeyStorage INTERNAL = new PrivateKeyStorage("INTERNAL");
        public static readonly PrivateKeyStorage CERTIFICATE = new PrivateKeyStorage("CERTIFICATE");
        public static readonly PrivateKeyStorage YUBIKEY = new PrivateKeyStorage("YUBIKEY");

        /// <summary>
        /// Private constructor: only approved storage key locations can be instantiated.
        /// </summary>
        /// <param name="storage">String representation of the private key storage.</param>
        private PrivateKeyStorage(string storage) {
            _storage = storage;
        }
        /// <summary>
        /// Get the private key storage location from string.
        /// </summary>
        /// <param name="name">The specific string definition of the private key storage.</param>
        /// <returns>The private key storage instance.</returns>
        public static PrivateKeyStorage FromName(string name) {
            if (name == "INTERNAL") return INTERNAL;
            if (name == "CERTIFICATE") return CERTIFICATE;
            if (name == "YUBIKEY") return YUBIKEY;

            throw new UnsupportedAlgorithmException("Unrecognized private key storage: " + name);
        }
        /// <summary>
        /// Get the string representation of the private key storage location.
        /// </summary>
        /// <returns></returns>
        public override string ToString() {
            if (this == INTERNAL) return "Internal";
            if (this == CERTIFICATE) return "Certificate";
            if (this == YUBIKEY) return "Yubikey";
            return null;
        }
    }
}
