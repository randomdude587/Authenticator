
namespace AuthenticatorProject.DigitalSignature {
    /// <summary>
    /// Base class to create implementations of authenticator keys.
    /// </summary>
    public abstract class AuthenticatorKey {
        // Aspects inherited.
        protected DigitalSignatureImplementation _implementation = null;
        protected PrivateKeyStorage _storage = null;
        protected HashFunction _hashFunction;
        
        /// <summary>
        /// The digital signature implementation for the authenticator.
        /// </summary>
        public DigitalSignatureImplementation Implementation {
            get { return this._implementation; }
        }
        /// <summary>
        /// Where is the private key stored?
        /// </summary>
        public PrivateKeyStorage Storage {
            get { return this._storage; }
        }
        /// <summary>
        /// The hash function used when creating a digital signature.
        /// </summary>
        public HashFunction HashFunction {
            get { return this._hashFunction; }
        }

        /// <summary>
        /// Base class construction, indicating the implementation and the storage of the private key.
        /// </summary>
        /// <param name="implementation"></param>
        /// <param name="storage"></param>
        public AuthenticatorKey(DigitalSignatureImplementation implementation, PrivateKeyStorage storage) {
            this._implementation = implementation;
            this._storage = storage;
        }
        /// <summary>
        /// Service method to instantiate an authenticator key when loading from file.
        /// </summary>
        /// <param name="implementation">The implementation of the digital signature algorithm.</param>
        /// <param name="storage">The private key storage.</param>
        /// <returns></returns>
        public static AuthenticatorKey FromSpecification(DigitalSignatureImplementation implementation, PrivateKeyStorage storage) {
            if (storage == PrivateKeyStorage.YUBIKEY)
                return new Yubikey();

            if (storage == PrivateKeyStorage.CERTIFICATE)
                return new CertificateKey(implementation);

            return new InternalKey(implementation);
        }

        /// <summary>
        /// Generate the authenticator key from parameters provided.
        /// </summary>
        /// <param name="parameters">The parameters that define to authenticator key.</param>
        public abstract void Generate(string parameters);
        
        /// <summary>
        /// Generate a key without parameters: typically for an internally generated key on the fly.
        /// </summary>
        public void Generate() {
            Generate(null);
        }

        /// <summary>
        /// Load the key from storage. Similar to Generate but used when the key is defined and is being loaded, not initially created.
        /// </summary>
        /// <param name="parameters"></param>
        public abstract void Load(string parameters);

        /// <summary>
        /// Create a digital signature on the data provided: use the hashing function of the authenticator key to first hash,
        /// then the private key to encrypt and create the signature.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public abstract string Sign(string data);

        /// <summary>
        /// This method uses the byte array signature and encodes it in a JSON format to specify the signature and hash function for transfer as text.
        /// </summary>
        /// <param name="signature"></param>
        /// <returns></returns>
        protected string FormatSignature(byte[] signature) {
            return "{\"signature\": \"" + Utilities.ByteArrayToHex(signature) + "\", \"hash_function\": \"" + this._hashFunction.HashAlgorithmName + "\"}";
        }

        /// <summary>
        /// Export the details of the authenticator key.
        /// </summary>
        /// <param name="includePrivateKey">If set to true, either the private key is detailed, or how to access the key if it is not exportable directly.</param>
        /// <returns></returns>
        public abstract string Export(bool includePrivateKey);
        
        /// <summary>
        /// Get the string representation of the authenticator key.
        /// </summary>
        /// <returns>JSON-encoded string with the algorithm, implementation, and hashing function of the authenticator key.</returns>
        public override string ToString() {
            return this._storage.ToString() + ", using " + this._implementation.Name + " with " + this._hashFunction.Name;
        }
    }
}
