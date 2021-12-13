using System;
using System.Globalization;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using Yubico.YubiKey.Piv;
using Yubico.YubiKey.Cryptography;

namespace AuthenticatorProject.Yubico {

    public sealed class YubiKeySignatureGenerator : X509SignatureGenerator {
        private const string InvalidAlgorithmMessage = "The algorithm was not recognized.";
        private const string InvalidSlotMessage = "The slot number was invalid.";

        private readonly PivSession _pivSession;
        private readonly byte _slotNumber;
        private readonly PivAlgorithm _algorithm;

        private readonly X509SignatureGenerator _defaultGenerator;

        public YubiKeySignatureGenerator(PivSession pivSession, byte slotNumber, PivPublicKey pivPublicKey) {
            if (pivSession is null) {
                throw new ArgumentNullException(nameof(pivSession));
            }
            if (pivPublicKey is null) {
                throw new ArgumentNullException(nameof(pivPublicKey));
            }
            if (!PivSlot.IsValidSlotNumberForSigning(slotNumber)) {
                throw new ArgumentException(
                    string.Format(
                        CultureInfo.CurrentCulture,
                        InvalidSlotMessage));
            }

            _pivSession = pivSession;
            _slotNumber = slotNumber;
            _algorithm = pivPublicKey.Algorithm;

            AsymmetricAlgorithm dotNetPublicKey = KeyConverter.GetDotNetFromPivPublicKey(pivPublicKey);

            if (_algorithm.IsEcc()) {
                _defaultGenerator = X509SignatureGenerator.CreateForECDsa((ECDsa) dotNetPublicKey);
            }
            else {
                throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, InvalidAlgorithmMessage));
            }
        }

        // Return the public key as an instance of PublicKey.
        protected override PublicKey BuildPublicKey() {
            return _defaultGenerator.PublicKey;
        }

        // Get the AlgorithmIdentifier of the signature algorithm. This is the
        // algorithm that will be used to sign the cert request, cert, etc.
        public override byte[] GetSignatureAlgorithmIdentifier(HashAlgorithmName hashAlgorithm) {
            return _defaultGenerator.GetSignatureAlgorithmIdentifier(hashAlgorithm);
        }

        // Sign the data.
        // The data is the cert request's "ToBeSigned". So we need to use the
        // hashAlgorithm specified to digest it first. If this is RSA signing,
        // pad the data next. If ECC, there's no padding. Finally, perform the
        // YubiKey signing operation.
        public override byte[] SignData(byte[] data, HashAlgorithmName hashAlgorithm) {
            if (data is null) {
                throw new ArgumentNullException(nameof(data));
            }

            byte[] dataToSign = DigestData(data, hashAlgorithm);

            return _pivSession.Sign(_slotNumber, dataToSign);
        }

        // Compute the message digest of the data using the given hashAlgorithm.
        private byte[] DigestData(byte[] data, HashAlgorithmName hashAlgorithm) {
            HashAlgorithm digester;
            if (hashAlgorithm.Name == "SHA256")
                digester = CryptographyProviders.Sha256Creator();
            else if (hashAlgorithm.Name == "SHA384")
                digester = CryptographyProviders.Sha384Creator();
            else
                throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, InvalidAlgorithmMessage));



            int bufferSize;

            // If the algorithm is P-256, then make sure the digest is exactly 32
            // bytes. If it's P-384, the digest must be exactly 48 bytes.
            // We'll prepend 00 bytes if necessary.
            if (_algorithm == PivAlgorithm.EccP256)
                bufferSize = 32;
            else if (_algorithm == PivAlgorithm.EccP384)
                bufferSize = 48;
            else
                bufferSize = digester.HashSize / 8;

            byte[] digest = new byte[bufferSize];
            int offset = bufferSize - (digester.HashSize / 8);

            // If offset < 0, that means the digest is too big.
            if (offset < 0) {
                throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, InvalidAlgorithmMessage));
            }

            _ = digester.TransformFinalBlock(data, 0, data.Length);
            Array.Copy(digester.Hash, 0, digest, offset, digest.Length);

            return digest;
        }
    }
}