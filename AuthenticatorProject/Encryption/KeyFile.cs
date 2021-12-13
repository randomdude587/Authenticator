
namespace AuthenticatorProject.Encryption {
    public class KeyFile : AccessControl {
        /// <summary>
        /// Protection applied via a key file: the SHA-256 hashcode of the file is the key for encryption.
        /// </summary>
        /// <param name="filePath">The access path to the keyfile.</param>
        public KeyFile(string filePath) : base() {
            key = Utilities.GetSha256File(filePath);
        }
    }
}
