
namespace AuthenticatorProject.Encryption {
    /// <summary>
    /// This implements a password protection access control. The key is the SHA-256 hashcode of the password.
    /// </summary>
    public class Password : AccessControl {
        public Password(string password) : base() {
            base.key = Utilities.GetSha256(password);
        }
    }
}
