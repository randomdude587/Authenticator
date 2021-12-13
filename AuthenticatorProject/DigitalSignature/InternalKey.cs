using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Xml;

namespace AuthenticatorProject.DigitalSignature {
    /// <summary>
    /// Implements an AuthenticatorKey when internally generated and the private key is owned by the Authenticator.
    /// </summary>
    public class InternalKey : AuthenticatorKey {
        private RSACryptoServiceProvider _rsaKey = null;
        private DSACng _dsaKey { get; set; }
        private ECDsa _ecdsaKey { get; set; }
        /// <summary>
        /// Create an instance of the InternalKey.
        /// </summary>
        /// <param name="implementation">The digital signature implementation used for the InternalKey.</param>
        public InternalKey(DigitalSignatureImplementation implementation) : base(implementation, PrivateKeyStorage.INTERNAL) { }

        public override void Generate (string parameters) {
            if (Implementation.Algorithm.Name == "RSA") {
                this._hashFunction = HashFunction.SHA256;
                if (Implementation == DigitalSignatureImplementation.RSA2048)
                    this._rsaKey = new RSACryptoServiceProvider(2048);

                else if (Implementation == DigitalSignatureImplementation.RSA3072)
                    this._rsaKey = new RSACryptoServiceProvider(3072);

                else if (Implementation == DigitalSignatureImplementation.RSA4096)
                    this._rsaKey = new RSACryptoServiceProvider(4096);

                else
                    // This could not happen, since the enum does not have additional values to use.
                    throw new UnsupportedAlgorithmException("Unsupported RSA implementation: " + this.Implementation.Name);
            }
            else if (Implementation.Algorithm.Name == "DSA") {
                if (Implementation == DigitalSignatureImplementation.DSA1024) {
                    this._dsaKey = new DSACng(1024);
                    this._hashFunction = HashFunction.SHA1;
                }
                else if (Implementation == DigitalSignatureImplementation.DSA2048) {
                    this._dsaKey = new DSACng(2048);
                    this._hashFunction = HashFunction.SHA256;
                }
                else if (Implementation == DigitalSignatureImplementation.DSA3072) {
                    this._dsaKey = new DSACng(3072);
                    this._hashFunction = HashFunction.SHA384;
                }
                else
                    // This could not happen, since the enum does not have additional values to use.
                    throw new UnsupportedAlgorithmException("Unsupported DSA implementation: " + this.Implementation.Name);
            }
            else if (Implementation.Algorithm.Name == "ECDSA") {
                this._ecdsaKey = ECDsa.Create();
                switch (Implementation.Name) {
                    case "ECDSA-NIST256p":
                        _ecdsaKey.GenerateKey(ECCurve.NamedCurves.nistP256);
                        this._hashFunction = HashFunction.SHA256;
                        break;
                    case "ECDSA-NIST384p":
                        _ecdsaKey.GenerateKey(ECCurve.NamedCurves.nistP384);
                        this._hashFunction = HashFunction.SHA384;
                        break;
                    case "ECDSA-NIST521p":
                        _ecdsaKey.GenerateKey(ECCurve.NamedCurves.nistP521);
                        this._hashFunction = HashFunction.SHA512;
                        break;
                    default:
                        throw new UnsupportedAlgorithmException("Unrecognized curve definition for ECDSA: " + Implementation.Name);
                }


            }
        }
    
        public override void Load(string parameters) {
            if (Implementation.Algorithm == DigitalSignatureAlgorithm.RSA) {
                this._rsaKey = new RSACryptoServiceProvider();
                this._rsaKey.FromXmlString(parameters);
                this._hashFunction = HashFunction.SHA256;
            }
            else if (Implementation.Algorithm == DigitalSignatureAlgorithm.DSA) {
                this._dsaKey = new DSACng();
                this._dsaKey.FromXmlString(parameters);
                this._implementation = DigitalSignatureImplementation.FromName("DSA-" + _dsaKey.KeySize);
                switch (_dsaKey.KeySize) {
                    case 1024:
                        this._hashFunction = HashFunction.SHA1;
                        break;
                    case 2048:
                        this._hashFunction = HashFunction.SHA256;
                        break;
                    case 3072:
                        this._hashFunction = HashFunction.SHA384;
                        break;
                }
            }
            else if (Implementation.Algorithm == DigitalSignatureAlgorithm.ECDSA) {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.LoadXml(parameters);
                ECCurve _curve;

                switch (xmlDoc.GetElementsByTagName("Curve")[0].InnerText) {
                    case "ECDSA-NIST256p":
                        _curve = ECCurve.NamedCurves.nistP256;
                        this._hashFunction = HashFunction.SHA256;
                        break;
                    case "ECDSA-NIST384p":
                        _curve = ECCurve.NamedCurves.nistP384;
                        this._hashFunction = HashFunction.SHA384;
                        break;
                    case "ECDSA-NIST521p":
                        _curve = ECCurve.NamedCurves.nistP521;
                        this._hashFunction = HashFunction.SHA512;
                        break;
                    default:
                        throw new UnsupportedAlgorithmException("Unrecognized curve definition for ECDSA: " + xmlDoc.GetElementsByTagName("Curve")[0].InnerText);
                }

                byte[] _privateKey = Utilities.HexToByteArray(xmlDoc.GetElementsByTagName("PrivateKey")[0].InnerText);
                byte[] _publicKey = Utilities.HexToByteArray(xmlDoc.GetElementsByTagName("PublicKey")[0].InnerText);
                int _size = _publicKey.Length / 2;

                var param = new ECParameters {
                    D = _privateKey,
                    Q = new ECPoint {
                        X = _publicKey.Take(_size).ToArray(),
                        Y = _publicKey.Skip(_size).ToArray()
                    },
                    Curve = _curve
                };

                this._ecdsaKey = ECDsa.Create(param);
                this._implementation = DigitalSignatureImplementation.FromName(xmlDoc.GetElementsByTagName("Curve")[0].InnerText);

            }
        }
    
        public override string Sign(string data) {
            byte[] _signature;

            if (Implementation.Algorithm == DigitalSignatureAlgorithm.RSA) 
                _signature = this._rsaKey.SignData(Encoding.UTF8.GetBytes(data), this._hashFunction.HashAlgorithmName, RSASignaturePadding.Pkcs1);
            
            else if (Implementation.Algorithm == DigitalSignatureAlgorithm.DSA)
                _signature = this._dsaKey.SignData(Encoding.UTF8.GetBytes(data), this._hashFunction.HashAlgorithmName);
                
            else  // DigitalSignatureAlgorithm.ECDSA)
                _signature = this._ecdsaKey.SignData(Encoding.UTF8.GetBytes(data), this._hashFunction.HashAlgorithmName);

            return FormatSignature(_signature);
        }

        public override string Export(bool includePrivateKey) {
            if (Implementation.Algorithm == DigitalSignatureAlgorithm.RSA) {
                if (includePrivateKey) {
                    // Return the complete key XML encoded.
                    return this._rsaKey.ToXmlString(true);
                }
                else {
                    // Return the public key: we encode it to JSON format to facilitate transfer.
                    // The public key has two components: Exponent and Modulus. We encode and send both.
                    return "{\"e\": \"" + Utilities.ByteArrayToHex(this._rsaKey.ExportParameters(false).Exponent) +
                        "\", \"n\":\"" + Utilities.ByteArrayToHex(this._rsaKey.ExportParameters(false).Modulus) + "\"}";
                }
            }
            else if (Implementation.Algorithm == DigitalSignatureAlgorithm.DSA) {
                if (includePrivateKey) {
                    return this._dsaKey.ToXmlString(true);
                }
                else {
                    return "{\"Y\":\"" + Utilities.ByteArrayToHex(_dsaKey.ExportParameters(true).Y) + "\"," +
                    "\"G\":\"" + Utilities.ByteArrayToHex(_dsaKey.ExportParameters(true).G) + "\", \"P\":\"" +
                    Utilities.ByteArrayToHex(_dsaKey.ExportParameters(true).P) + "\"," +
                    "\"Q\":\"" + Utilities.ByteArrayToHex(_dsaKey.ExportParameters(true).Q) + "\"}";
                }
            }
            else { // DigitalSignatureAlgorithm.ECDSA)
                byte[] byte_x = _ecdsaKey.ExportExplicitParameters(false).Q.X;
                byte[] byte_y = _ecdsaKey.ExportExplicitParameters(false).Q.Y;
                byte[] _privateKey = _ecdsaKey.ExportExplicitParameters(true).D;
                byte[] _publicKey = new byte[byte_x.Length + byte_y.Length];

                byte_x.CopyTo(_publicKey, 0);
                byte_y.CopyTo(_publicKey, byte_x.Length);

                if (includePrivateKey) {
                    // Return the complete key XML-encoded.
                    return "<ECDSA>\n  <PrivateKey>" + Utilities.ByteArrayToHex(_privateKey) + "</PrivateKey>\n" +
                        "  <PublicKey>" + Utilities.ByteArrayToHex(_publicKey) + "</PublicKey>\n" +
                        "  <Curve>" + Implementation.Name + "</Curve>\n</ECDSA>";
                }
                else {
                    // Return the public key: we encode it to JSON format to facilitate transfer.
                    return "{\"publicKey\": \"" + Utilities.ByteArrayToHex(_publicKey) + "\"}";
                }
            }
        }
    }
}
