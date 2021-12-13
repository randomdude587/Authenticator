using System;
using System.Windows.Forms;
using System.Xml;
using Yubico.YubiKey;
using Yubico.YubiKey.Piv;

namespace AuthenticatorProject.DigitalSignature {
    /// <summary>
    /// Implementation of the AuthenticatorKey when the private key is stored in the Yubikey.
    /// </summary>
    public class Yubikey : AuthenticatorKey {

        private PivSession _yubikey = null;
        private byte _slot { get; set; }
        private string _serial { get; set; }
        private string _publicKey { get; set; }
        /// <summary>
        /// Constructor for  the instance: no arguments required as only the ECDSA-NIST256p is supported for Yubikey.
        /// </summary>
        public Yubikey() : base(DigitalSignatureImplementation.ECDSANIST256p, PrivateKeyStorage.YUBIKEY) { }

        public override void Generate(string parameters) {
            // Support for Yubikey is provided for Elliptic Curve NIST256p.
            // The parameters will need to specify: the Serial Number of the Yubikey, the slot to use, and the public key of the yubikey certificate.
            string[] yubikey_params = parameters.Split('|');

            this._serial = yubikey_params[0];
            this._slot = Utilities.HexToByteArray(yubikey_params[1])[0];
            this._publicKey = yubikey_params[2];
            this._hashFunction = HashFunction.SHA256;
        }

        public override void Load(string parameters) {
            // The private key is stored on the YUBIKEY.
            // The implementation must be a ECDSA-NIST256p with SHA-256.
            // The parameters will be a XML definition of the Yubikey slot used.
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(parameters);
            this._serial = xmlDoc.GetElementsByTagName("Serial")[0].InnerText;
            this._slot = Utilities.HexToByteArray(xmlDoc.GetElementsByTagName("Slot")[0].InnerText)[0];
            this._publicKey = xmlDoc.GetElementsByTagName("PublicKey")[0].InnerText;

            _hashFunction = HashFunction.SHA256;
        }

        public override string Sign(string data) {
            try {
                IYubiKeyDevice _device = null;
                foreach (IYubiKeyDevice key in YubiKeyDevice.FindAll()) {
                    if (key.SerialNumber == int.Parse(this._serial)) {
                        _device = key;
                        break;
                    }
                }
                if (_device == null) {
                    throw new Exception("Device " + _serial + " could not be detected");
                }

                this._yubikey = new PivSession(_device);
                _yubikey.KeyCollector = FrmPIN.GetCredential;

                // The signature for the yubikey does NOT compute the hash, it must be done before calling.
                ReadOnlyMemory<byte> rodata = new ReadOnlyMemory<byte>(Utilities.GetSha256(data));

                // The signature can be generated at this time.
                byte[] _signature = this._yubikey.Sign(this._slot, rodata);

                this._yubikey.Connection.Dispose();

                // Get the hex representation: it is BER encoded.
                string hexSignature = Utilities.ByteArrayToHex(_signature);

                // The BER encoding must be reverted to the standard encoding used for a digital signature.
                hexSignature = hexSignature.Substring(2);   // Remove the 0x;
                hexSignature = hexSignature.Substring(7);  // Remove the BER header.

                // Start of the second part of the sequence.
                int splitPosition = hexSignature.IndexOf("022");

                // Extract the r and s from the sequence.
                string r = hexSignature.Substring(0, splitPosition);
                string s = hexSignature.Substring(splitPosition + 3);

                // Remove leading 0s to get the expected length.
                while (r.Length > 64)
                    r = r.Substring(1);
                while (s.Length > 64)
                    s = s.Substring(1);

                // Reconstruct the proper signature encoding in JSON format for the web server.
                hexSignature = "0x" + r + s;
                return FormatSignature(Utilities.HexToByteArray(hexSignature));
            }
            catch (Exception ex) {
                FrmPIN.ClearData();
                throw ex;
            }
        }

        public override string Export(bool includePrivateKey) {
            if (includePrivateKey) {
                // Cannot include the private key with this, so even if asked for, not gonna happen.
                // We provide all the XML we can for internal use: where the private actually is.
                return "<Yubikey>\n  <Serial>" + this._serial + "</Serial>\n  <Slot>" + _slot.ToString("X2") + "</Slot>\n" +
                        "  <PublicKey>" + this._publicKey + "</PublicKey>\n</Yubikey>";
            }
            else {
                // Just the public key in typical encoding.
                return _publicKey;
            }
        }

        public override string ToString() {
            return this._storage.ToString() + " " + _serial + "-0x" + _slot.ToString("X2") + 
                ", " + this._implementation.Name + "-" + this._hashFunction.Name;
        }
    }
}
