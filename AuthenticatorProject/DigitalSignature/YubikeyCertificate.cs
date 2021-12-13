
using Yubico.YubiKey;
using Yubico.YubiKey.Piv;


namespace AuthenticatorProject.DigitalSignature {
    /// <summary>
    /// Authenticator defined certificate stored in the Yubikey.
    /// </summary>
    public class YubikeyCertificate : Certificate {
        // Serial key and slot number for the certificate location.
        private byte _slot;
        private string _serial = null;
        /// <summary>
        /// The slot number used for storage.
        /// </summary>
        public byte Slot {
            get { return this._slot; }
        }
        /// <summary>
        /// The Yubikey device serial number.
        /// </summary>
        public string DeviceSerialNumber {
            get { return this._serial; }
        }
        /// <summary>
        /// The constructor of the YubikeyCertificate.
        /// </summary>
        /// <param name="serialNumber">The device serial number</param>
        /// <param name="slot">The slot location for the certificate.</param>
        public YubikeyCertificate(string serialNumber, byte slot) : base() {
            this._slot = slot;
            this._serial = serialNumber;
            
            foreach (IYubiKeyDevice device in YubiKeyDevice.FindAll()) {
                if (device.SerialNumber == int.Parse(serialNumber)) {
                    PivSession pivSession = new PivSession(device);
                    try {
                        this._x509 = pivSession.GetCertificate(slot);
                        LoadInformation();
                    }
                    catch {
                        this._x509 = null;
                    }
                    pivSession.Connection.Dispose();
                }
            }      
        }
    }
}
