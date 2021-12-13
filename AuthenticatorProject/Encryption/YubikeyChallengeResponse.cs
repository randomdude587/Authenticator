
namespace AuthenticatorProject.Encryption {
    /// <summary>
    /// Implementation of the Yubikey Challenge-Response protocol for encryption/decryption of vault files.
    /// </summary>
    public class YubikeyChallengeResponse : AccessControl {
        /// <summary>
        /// Create the access control with the response to the challenge that was sent to the Yubikey.
        /// </summary>
        /// <param name="response">The response from the Yubikey (a string of hexadecimal digits)</param>
        public YubikeyChallengeResponse(string response) {
            base.key = Utilities.GetSha256(response);
        }
    }
}
