using System;

namespace AuthenticatorProject.EasyAuthentication {
    /// <summary>
    /// Application-specific exception to be thrown when an error occurs during handling of a message.
    /// </summary>
    public class EasyAuthenticationMessageException : Exception {
        public EasyAuthenticationMessageException (string message) : base(message) { }
    }
}
