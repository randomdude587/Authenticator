using System.Linq;
using System.IO;
using System.Security.Cryptography;

namespace AuthenticatorProject.Encryption {
    /// <summary>
    /// Abstract class used to implement an access control for vault file.
    /// </summary>
    public abstract class AccessControl {
        /// <summary>
        /// Protected property representing the encryption key of the access control.
        /// </summary>
        protected byte[] key = null;
        
        /// <summary>
        /// The encryption key used to create the access control.
        /// </summary>
        public byte[] Key { 
            get { return this.key; }
        }

        /// <summary>
        /// Access controled can be compounded. When an access control is added, the keys are XORed for a resulting key.
        /// </summary>
        /// <param name="accessControl">The access control to add to this one to create the composite.</param>
        public void Add (AccessControl accessControl) {
            // Merge the two access controls with an XOR operation.
            byte[] _compositeKey = new byte[32];

            for (int i = 0; i < 32; i++) {
                _compositeKey[i] = (byte) (this.key[i] ^ accessControl.key[i]);
            }

            this.key = _compositeKey;
        }

        /// <summary>
        /// Utility method to verify if the key of the access control is zeroized.
        /// </summary>
        /// <returns>True if the key is only zeroes, false otherwise.</returns>
        public bool IsNull () {
            for (int i = 0; i < 32; i++) {
                if (key[i] != 0)
                    return false;
            }
            return true;
        }

        /// <summary>
        /// Encrypts the plaintext string using the provided access control.
        /// </summary>
        /// <param name="plaintext">The plaintext string to encrypt.</param>
        /// <returns>The byte array of encrypted data.</returns>
        public byte[] Encrypt(string plaintext) {
            Aes _aes = Aes.Create();
            _aes.KeySize = 256;
            _aes.GenerateIV();
            //_aes.Key = accessControl.Key;

            ICryptoTransform encryptor = _aes.CreateEncryptor(this.Key, _aes.IV);
            byte[] cipher = null;

            // Create the streams used for encryption.
            using (MemoryStream msEncrypt = new MemoryStream()) {
                using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write)) {
                    using (StreamWriter swEncrypt = new StreamWriter(csEncrypt)) {
                        //Write all data to the stream.
                        swEncrypt.Write(plaintext);
                    }
                    // return msEncrypt.ToArray();
                    cipher = msEncrypt.ToArray();
                }
            }

            byte[] data = new byte[_aes.IV.Length + cipher.Length];

            _aes.IV.CopyTo(data, 0);
            cipher.CopyTo(data, _aes.IV.Length);

            return data;
        }

        /// <summary>
        /// Decrypts the data using the key of the access control.
        /// </summary>
        /// <param name="data">The data to decrypt.</param>
        /// <returns>The plaintext string of the decrypted data.</returns>
        public string Decrypt(byte[] data) {
            Aes _aes = Aes.Create();

            // First 16 bytes are the IV.
            byte[] iv = data.Take(16).ToArray();
            byte[] cipher = data.Skip(16).ToArray();

            ICryptoTransform decryptor = _aes.CreateDecryptor(this.Key, iv);
            string plaintext = null;
            // Create the streams used for decryption.
            using (MemoryStream msDecrypt = new MemoryStream(cipher)) {
                using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read)) {
                    using (StreamReader srDecrypt = new StreamReader(csDecrypt)) {

                        // Read the decrypted bytes from the decrypting stream
                        // and place them in a string.
                        plaintext = srDecrypt.ReadToEnd();
                    }
                }
            }
            return plaintext;
        }
    }
}
