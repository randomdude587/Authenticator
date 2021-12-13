using System;
using System.Collections.Generic;
using System.IO;

namespace AuthenticatorProject.Encryption {
    /// <summary>
    /// Defines an access control based on specifically designed USB Keys: they hold at the root of the drive a file that identifies them
    /// and another file that holds a keyfile.
    /// </summary>
    public class UsbSecurityKey : AccessControl {
        /// <summary>
        /// File name for the USB Security Key identifying string.
        /// </summary>
        public static string KEY_ID_FILE = "security_key_id.txt";
        /// <summary>
        /// File name for the USB Security Key key file.
        /// </summary>
        public static string KEY_FILE = "key_file.txt";

        private string _driveName;
        private string _volumeLabel;
        private string _identifier;
        /// <summary>
        /// The drive name of the USB Security Key, such as E:\ or F:\
        /// </summary>
        public string DriveName { get { return this._driveName; } }
        /// <summary>
        /// The volume label of the key, which can also serve as an identifier.
        /// </summary>
        public string VolumeLabel { get { return this._volumeLabel; } }
        /// <summary>
        /// The string to specifically identify the USB Security Key. It is not restricted in length or content, as the volume label would be.
        /// </summary>
        public string Identifier { get { return this._identifier; } }

        public UsbSecurityKey(string keyIdentifier) {
            bool found = false;
            foreach (var drive in DriveInfo.GetDrives()) {
                if (File.Exists(drive.Name + KEY_ID_FILE) && File.ReadAllText(drive.Name + KEY_ID_FILE) == keyIdentifier) {
                    this._identifier = keyIdentifier;
                    this._volumeLabel = drive.VolumeLabel;
                    this._driveName = drive.Name;
                    this.key = Utilities.GetSha256File(drive.Name + KEY_ID_FILE);
                    found = true;
                }
            }
            if (!found)
                throw new Exception("An error occurred: no key found using identifier: " + keyIdentifier);
        }
        /// <summary>
        /// Internal constructor to explicitly define the instance. The parameters must be validated beforehand.
        /// </summary>
        /// <param name="driveName">The drive name.</param>
        /// <param name="keyIdentifier">The key identifier string.</param>
        /// <param name="volumeLabel">The key volume label.</param>
        private UsbSecurityKey(string driveName, string keyIdentifier, string volumeLabel) {
            this._driveName = driveName;
            this._identifier = keyIdentifier;
            this._volumeLabel = volumeLabel;
            this.key = Utilities.GetSha256File(_driveName + KEY_ID_FILE);
        }
        /// <summary>
        /// Creating a new USB Security Key. The key file on the device will be generated and written, along with the identifier string
        /// in dedicated files at the root.
        /// </summary>
        /// <param name="driveName">The name of the drive, such as F:\</param>
        /// <param name="keyIdentifier">The string identifier of the security key.</param>
        /// <param name="volumeLabel">The security key volume label, that will be applied to the key.</param>
        /// <returns></returns>
        public static UsbSecurityKey GenerateNew(string driveName, string keyIdentifier, string volumeLabel) {
            foreach (var drive in DriveInfo.GetDrives()) {
                if (drive.Name == driveName) {
                    drive.VolumeLabel = volumeLabel;

                    // Generate new key file.
                    string content = PasswordUtilities.GenerateRandomContent(300, "0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ");

                    File.WriteAllText(drive.Name + UsbSecurityKey.KEY_FILE, content);
                    File.WriteAllText(drive.Name + UsbSecurityKey.KEY_ID_FILE, keyIdentifier);

                    return new UsbSecurityKey(driveName, keyIdentifier, volumeLabel);
                }
            }
            // If reaching this, the key was not found so the generation could not happen.
            throw new Exception("An error occurred when generating the key file on the USB Key. No such drive: " + driveName);
        }
        /// <summary>
        /// Get all the USB Security Keys that can be detected in the system, meaning they contain at the root
        /// the specific files that define them as USB Security Key.
        /// </summary>
        /// <returns>An array of all the keys found, or null if none is found.</returns>
        public static UsbSecurityKey[] GetAllDetectedKeys() {
            List<UsbSecurityKey> temp = new List<UsbSecurityKey>();
            
            foreach (var drive in DriveInfo.GetDrives()) {
                if (File.Exists(drive.Name + UsbSecurityKey.KEY_FILE) && File.Exists(drive.Name + UsbSecurityKey.KEY_ID_FILE)) {
                    // This is a security key device. Get the key identifier.
                    string key_id = File.ReadAllText(drive.Name + UsbSecurityKey.KEY_ID_FILE);
                    UsbSecurityKey key = new UsbSecurityKey(File.ReadAllText(drive.Name + UsbSecurityKey.KEY_ID_FILE));
                    temp.Add(key);
                }
            }
            if (temp.Count == 0)
                return null;

            UsbSecurityKey[] allKeys = new UsbSecurityKey[temp.Count];
            for (int i = 0; i < temp.Count; i++) {
                allKeys[i] = temp[i];
            }
            return allKeys;
        }
    }
}
