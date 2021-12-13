using System;

namespace AuthenticatorProject.DigitalSignature {
    /// <summary>
    /// Application-specific exception to be thrown when an unrecognized/unsupported algorithm is requested.
    /// </summary>
    public class UnsupportedAlgorithmException : Exception {
        public UnsupportedAlgorithmException(string message) : base(message) { }
    }
}
