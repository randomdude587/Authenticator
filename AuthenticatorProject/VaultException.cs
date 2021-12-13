using System;

namespace AuthenticatorProject {
    /// <summary>
    /// Application-specific exception to be thrown when an issue occurs during vault handling.
    /// </summary>
    public class VaultException : Exception {
        public VaultException(string message) : base(message) { }
    }
}
