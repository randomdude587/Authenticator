using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace AuthenticatorProject.DigitalSignature {
    /// <summary>
    /// Implements an authenticator key where the private key is embedded in a certificate.
    /// </summary>
    public class CertificateKey : AuthenticatorKey {
        /// <summary>
        /// The certificate key is built on a Certificate.
        /// </summary>
        private Certificate _certificate { get; set; }

        public CertificateKey(DigitalSignatureImplementation implementation) : base (implementation, PrivateKeyStorage.CERTIFICATE) { }

        public override void Generate(string parameters) {
            // A new key is not generated: it was done before when the certificate was created and signed.
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(parameters);
            byte[] contents = Utilities.Base64ToByteArray(xmlDoc.GetElementsByTagName("Data")[0].InnerText);
            string password = xmlDoc.GetElementsByTagName("Password")[0].InnerText;
            this._certificate = new Certificate(contents, password);

            if (Implementation == DigitalSignatureImplementation.ECDSANIST384p || Implementation == DigitalSignatureImplementation.DSA3072)
                this._hashFunction = HashFunction.SHA384;
            else if (Implementation == DigitalSignatureImplementation.ECDSANIST521p)
                this._hashFunction = HashFunction.SHA512;
            else if (Implementation == DigitalSignatureImplementation.DSA1024)
                this._hashFunction = HashFunction.SHA1;
            else
                this._hashFunction = HashFunction.SHA256;
        }

        public override void Load(string parameters) {
            this.Generate(parameters);
        }

        public override string Sign(string data) {
            // Signing data means asking the embedded private key to sign. We don't have direct access.
            X509Certificate2 _cert = _certificate.InnerCertificate;
            byte[] _signature;
            if (Implementation.Algorithm == DigitalSignatureAlgorithm.RSA)
                _signature = _cert.GetRSAPrivateKey().SignData(Encoding.UTF8.GetBytes(data), this._hashFunction.HashAlgorithmName, RSASignaturePadding.Pkcs1);

            else if (Implementation.Algorithm == DigitalSignatureAlgorithm.ECDSA)
                _signature = _cert.GetECDsaPrivateKey().SignData(Encoding.UTF8.GetBytes(data), this._hashFunction.HashAlgorithmName);
            else   // DigitalSignatureAlgorithm.DSA) {
                _signature = _cert.GetDSAPrivateKey().SignData(Encoding.UTF8.GetBytes(data), this._hashFunction.HashAlgorithmName);

            return FormatSignature(_signature);
        }

        public override string Export(bool includePrivateKey) {
            if (includePrivateKey)
                return _certificate.ToXmlString();
            return this._certificate.PublicKey;
        }

        
    }
}
