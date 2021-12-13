using System;
using System.Text;
using System.Security.Cryptography.X509Certificates;
using System.Security.Cryptography;
using System.IO;

namespace AuthenticatorProject.DigitalSignature {
    /// <summary>
    /// An encapsulation of the X509Certificate2 class to accomodate functionalities of the Authenticator system.
    /// </summary>
    public class Certificate {
        protected X509Certificate2 _x509 = null;
        private string _password = null;
        private CanonicalInformation _subjectInformation;
        private CanonicalInformation _issuerInformation;
        private DigitalSignatureImplementation _implementation;
        private string _publicKey = null;
        private byte[] _fileContents;
        
        /// <summary>
        /// Access the X509Certificate2 instance encapsulated in the Certificate.
        /// </summary>
        public X509Certificate2 InnerCertificate {
            get { return this._x509; }
        }

        /// <summary>
        /// Format of the certificate: should be X509.
        /// </summary>
        public string Format {
            get { return this._x509.GetFormat(); }
        }
        /// <summary>
        /// Serial number of the certificate.
        /// </summary>
        public string SerialNumber {
            get { return this._x509.SerialNumber; }
        }
        /// <summary>
        /// The version of the certificate, typically "3".
        /// </summary>
        public string Version {
            get { return this._x509.Version.ToString();  }
        }

        /// <summary>
        /// Date at which the certificate becomes active.
        /// </summary>
        public DateTime NotBefore {
            get { return this._x509.NotBefore; }
        }
        /// <summary>
        /// Date at which the certificate expires.
        /// </summary>
        public DateTime NotAfter {
            get { return this._x509.NotAfter; }
        }
        /// <summary>
        /// The thumbprint of the certificate.
        /// </summary>
        public string Thumbprint {
            get { return this._x509.Thumbprint;  }
        }
        /// <summary>
        /// Indicates if the private key is within the certificate or not.
        /// </summary>
        public bool HasPrivateKey {
            get { return this._x509.HasPrivateKey;  }
        }
        /// <summary>
        /// Indicates if the certificate is currently active.
        /// </summary>
        public bool IsActive {
            get { return this.NotBefore < DateTime.UtcNow && this.NotAfter > DateTime.UtcNow; }
        }
        /// <summary>
        /// Indicates if the date of expiration has passed.
        /// </summary>
        public bool IsExpired {
            get { return this.NotAfter < DateTime.UtcNow; }
        }
        /// <summary>
        /// Number of days to go before the certificate expires: negative means it expired already.
        /// </summary>
        public int DaysBeforeExpiration {
            get { return this.NotAfter.Subtract(DateTime.UtcNow).Days; }
        }
        /// <summary>
        /// Number of days that passed since activation.
        /// </summary>
        public int DaysSinceActivation {
            get { return DateTime.UtcNow.Subtract(this.NotBefore).Days; }
        }
        /// <summary>
        /// The life span of the certificate measured in days.
        /// </summary>
        public int LifeSpanInDays {
            get { return this.NotAfter.Subtract(this.NotBefore).Days; }
        }
        /// <summary>
        /// The life span of the certificate in number of years.
        /// </summary>
        public double LifeSpanInYears {
            get { return this.NotAfter.Subtract(this.NotBefore).TotalDays / 365; }
        }
        /// <summary>
        /// A composite of the canonical information of the subject of the certificate.
        /// </summary>
        public CanonicalInformation Subject {
            get { return this._subjectInformation; }
        }
        /// <summary>
        /// A composite of the canonical information of the issuer of the certificate.
        /// </summary>
        public CanonicalInformation Issuer {
            get { return this._issuerInformation; }
        }
        /// <summary>
        /// The simple name of the subject. Same as field CN of the canonical information.
        /// </summary>
        public string SubjectName {
            get { return this._x509.GetNameInfo(X509NameType.SimpleName, true); }
        }
        /// <summary>
        /// The simple name of the issuer. Same as field CN of the canonical information.
        /// </summary>
        public string IssuerName {
            get { return this._x509.GetNameInfo(X509NameType.SimpleName, true); }
        }
        /// <summary>
        /// The algorithm used to produce the signature on the certificate.
        /// </summary>
        public string SignatureAlgorithm {
            get { return this._x509.SignatureAlgorithm.FriendlyName; }
        }
        /// <summary>
        /// The public key of the certificate: in a JSON-encoded format for use with the Authenticator.
        /// </summary>
        public string PublicKey {
            get { return this._publicKey; }
        }
        /// <summary>
        /// The digital signature implementation of the public key in the certificate, for use with the Authenticator.
        /// </summary>
        public DigitalSignatureImplementation Implementation {
            get { return this._implementation; }
        }
        /// <summary>
        /// Exports the XML definition of the certificate.
        /// </summary>
        /// <returns>An XML structure with the file contents in base64 and the password to decrypt.</returns>
        public string ToXmlString() {
            return "<Certificate><Data>" + Utilities.ByteArrayToBase64(this._fileContents) + "</Data><Password>" + this._password + "</Password></Certificate>";
        }
        /// <summary>
        /// Empty constructor, for inherited objects.
        /// </summary>
        protected Certificate() { }

        /// <summary>
        /// Load a certificate from the path: use if no password is applied.
        /// </summary>
        /// <param name="path">File path for the certificate</param>
        public Certificate(string path) : this (path, "") { }
        /// <summary>
        /// Load a certificate using a path and the password.
        /// </summary>
        /// <param name="path">File path for the certificate.</param>
        /// <param name="password">Password to access the contents of the certificate.</param>
        public Certificate(string path, string password) {
            this._x509 = new X509Certificate2();
            this._fileContents = ReadFully(File.OpenRead(path));
            _x509.Import(_fileContents, password, X509KeyStorageFlags.Exportable | X509KeyStorageFlags.PersistKeySet);
            this._password = password;
            LoadInformation();
        }
        /// <summary>
        /// Create the certificate from the file contents and the password.
        /// </summary>
        /// <param name="contents">Byte array of the file contents.</param>
        /// <param name="password">Password used to decrypt.</param>
        public Certificate (byte[] contents, string password) {
            this._fileContents = contents;
            this._x509 = new X509Certificate2();
            _x509.Import(_fileContents, password, X509KeyStorageFlags.Exportable | X509KeyStorageFlags.PersistKeySet);
            this._password = password;
            LoadInformation();
        }

        /// <summary>
        /// Generate from a certificate object.
        /// </summary>
        /// <param name="x509certificate">The already instantiated certificate.</param>
        public Certificate(X509Certificate2 x509certificate) {
            this._x509 = x509certificate;
            LoadInformation();
        }
        /// <summary>
        /// Load the certificate details into the object.
        /// </summary>
        protected void LoadInformation() { 
            this._subjectInformation = new CanonicalInformation(_x509.Subject);
            this._issuerInformation = new CanonicalInformation(_x509.Issuer);

            //Certificate.SignatureAlgorithm.FriendlyName + "  (" + Certificate.SignatureAlgorithm.Value + ")";

            RSA rsa = _x509.GetRSAPublicKey();
            DSA dsa = _x509.GetDSAPublicKey();
            ECDsa ecdsa = _x509.GetECDsaPublicKey();

            if (rsa != null) {
                this._implementation = DigitalSignatureImplementation.FromName("RSA-" + rsa.KeySize);
                this._publicKey = "{\"e\": \"" + Utilities.ByteArrayToHex(rsa.ExportParameters(false).Exponent) +
                            "\", \"n\":\"" + Utilities.ByteArrayToHex(rsa.ExportParameters(false).Modulus) + "\"}";
            }
            else if (dsa != null) {
                this._implementation = DigitalSignatureImplementation.FromName("DSA-" + dsa.KeySize);
                this._publicKey = "{\"Y\":\"" + Utilities.ByteArrayToHex(dsa.ExportParameters(false).Y) + "\"," +
                        "\"G\":\"" + Utilities.ByteArrayToHex(dsa.ExportParameters(false).G) + "\", \"P\":\"" +
                        Utilities.ByteArrayToHex(dsa.ExportParameters(false).P) + "\"," +
                        "\"Q\":\"" + Utilities.ByteArrayToHex(dsa.ExportParameters(false).Q) + "\"}";
            }
            else if (ecdsa != null) {
                ECCurve curve = ecdsa.ExportParameters(false).Curve;
                if (curve.Oid.FriendlyName == "nistP256") {
                    this._implementation = DigitalSignatureImplementation.ECDSANIST256p;
                }
                else if (curve.Oid.FriendlyName == "nistP384") {
                    this._implementation = DigitalSignatureImplementation.ECDSANIST384p;
                }
                else if (curve.Oid.FriendlyName == "nistP521") {
                    this._implementation = DigitalSignatureImplementation.ECDSANIST521p;
                }
                byte[] byte_x = ecdsa.ExportExplicitParameters(false).Q.X;
                byte[] byte_y = ecdsa.ExportExplicitParameters(false).Q.Y;
                byte[] _publicKey = new byte[byte_x.Length + byte_y.Length];

                byte_x.CopyTo(_publicKey, 0);
                byte_y.CopyTo(_publicKey, byte_x.Length);
                this._publicKey = "{\"publicKey\": \"" + Utilities.ByteArrayToHex(_publicKey) + "\"}";
            }
        }
        /// <summary>
        /// Read the file containing the certificate.
        /// </summary>
        /// <param name="stream">Open file to read.</param>
        /// <returns>The byte array of the file contents.</returns>
        private static byte[] ReadFully(Stream stream) {
            byte[] buffer = new byte[32768];
            using (MemoryStream ms = new MemoryStream()) {
                while (true) {
                    int read = stream.Read(buffer, 0, buffer.Length);
                    if (read <= 0)
                        return ms.ToArray();
                    ms.Write(buffer, 0, read);
                }
            }
        }
        /// <summary>
        /// Extract the CRT of the certificate for sharing: no private key inside.
        /// </summary>
        /// <returns>The generic encoding of the certificate using the -----BEGIN CERTIFICATE----- delimiter.</returns>
        public string GetCrt() {
            StringBuilder builder = new StringBuilder();
            
            builder.AppendLine("-----BEGIN CERTIFICATE-----");
            builder.AppendLine(Convert.ToBase64String(_x509.Export(X509ContentType.Cert), Base64FormattingOptions.InsertLineBreaks));
            builder.AppendLine("-----END CERTIFICATE-----");

            return builder.ToString();
        }
    }
}
