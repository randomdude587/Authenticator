
namespace AuthenticatorProject.Encryption {
    /// <summary>
    /// Null access control where the AES key is zeroised. There is still encryption applied with the key, and a random IV, 
    /// but it is considered a null protection factor. This is useful as a starting point for an access control, wherein other
    /// controls can be added to this one and XORed together.
    /// </summary>
    public class Unprotected : AccessControl {
        public Unprotected() : base() {
            // No protection is applied.
            this.key = new byte[32];  // Empty key.
        }
    }
}
