using System;
using System.Text;
using System.Drawing;
using System.IO;
using System.Security.Cryptography;

namespace AuthenticatorProject {
    public class Utilities {
        // To capture input and output when talking to a Yubikey.
        private static StringBuilder stdOutput { get; set; }
        private static StringBuilder stdError { get; set; }
        /// <summary>
        /// Keeps count of the instances of the authenticator forms in use.
        /// </summary>
        public static int FormsCount { get; set; }

        /// <summary>
        /// Transform an image to its base64 representation.
        /// </summary>
        /// <param name="image">The image to convert.</param>
        /// <returns>A base64 encoding of the image.</returns>
        public static string ImageToBase64(Image image) {

            using (MemoryStream m = new MemoryStream()) {
                image.Save(m, image.RawFormat);
                byte[] imageBytes = m.ToArray();
                return Convert.ToBase64String(imageBytes);
            }
        }

        /// <summary>
        /// Transform a base64 representation of the digital content of an image to an actual image.
        /// </summary>
        /// <param name="base64">The base64 encoding of the image.</param>
        /// <returns>An image object.</returns>
        public static Image Base64ToImage(string base64) {
            if (base64 == "") return null;

            byte[] bytes = Convert.FromBase64String(base64);

            using (MemoryStream ms = new MemoryStream(bytes)) {
                return Image.FromStream(ms);
            }
        }

        /// <summary>
        /// When creating XML strings, this ensures that data to be inserted is properly encoded.
        /// </summary>
        /// <param name="data">The data string to encode for XML.</param>
        /// <returns>The properly encoded XML string</returns>
        public static string EncodeXMLEntities(string data) {
            if (data == null) return "";
            return data.Replace("&", "&amp;").Replace("<", "&lt;").Replace(">", "&gt;").Replace("'", "&#039;").Replace("\"", "&quot;");
        }

        /// <summary>
        /// Converts an array of bytes to the equivalent hexadecimal representation.
        /// </summary>
        /// <param name="values">The array of bytes.</param>
        /// <returns>A hexadecimal string using upper case characters and a '0x' prefix.</returns>
        public static string ByteArrayToHex(byte[] values) {
            return "0x" + BitConverter.ToString(values).Replace("-", "").ToUpper(); ;
        }

        /// <summary>
        /// Converts a base64 code to the equivalent array of bytes.
        /// </summary>
        /// <param name="base64string">The base64 encoding.</param>
        /// <returns>An array of bytes.</returns>
        public static byte[] Base64ToByteArray(string base64string) {
            return Convert.FromBase64String(base64string);
        }

        /// <summary>
        /// Converts an array of bytes to the equivalent base64 encoding.
        /// </summary>
        /// <param name="values">An array of bytes.</param>
        /// <returns>A base64 encoding.</returns>
        public static string ByteArrayToBase64(byte[] values) {
            return Convert.ToBase64String(values);
        }

        /// <summary>
        /// Calculates the hashcode value of a string using SHA-256.
        /// </summary>
        /// <param name="message">The UTF-8 string to hash.</param>
        /// <returns>An array of bytes representing the hashcode.</returns>
        public static byte[] GetSha256(string message) {
            SHA256 hashFunction = SHA256.Create();
            return hashFunction.ComputeHash(Encoding.UTF8.GetBytes(message));
        }
        /// <summary>
        /// Calculates the hashcode value of a string using SHA-384.
        /// </summary>
        /// <param name="message">The UTF-8 string to hash.</param>
        /// <returns>An array of bytes representing the hashcode.</returns>
        public static byte[] GetSha384(string message) {
            SHA384 hashFunction = SHA384.Create();
            return hashFunction.ComputeHash(Encoding.UTF8.GetBytes(message));
        }
        /// <summary>
        /// Get the SHA-256 hashcode of a file.
        /// </summary>
        /// <param name="path">The path to the file.</param>
        /// <returns>The array of bytes for the hashcode.</returns>
        public static byte[] GetSha256File(string path) {
            SHA256 hashFunction = SHA256.Create();
            FileStream fileStream = File.Open(path, FileMode.Open);
            // Be sure it's positioned to the beginning of the stream.
            fileStream.Position = 0;
            // Compute the hash of the fileStream.
            byte[] hashValue = hashFunction.ComputeHash(fileStream);
            fileStream.Close();

            return hashValue;
        }

        /// <summary>
        /// Calculates the hashcode value of a string using SHA-1.
        /// </summary>
        /// <param name="message">The UTF-8 string to hash.</param>
        /// <returns>An array of bytes representing the hashcode.</returns>
        public static byte[] GetSha1(string message) {
            SHA1 hashFunction = SHA1.Create();
            return hashFunction.ComputeHash(Encoding.UTF8.GetBytes(message));
        }

        /// <summary>
        /// Converts a string to its base64 representation.
        /// </summary>
        /// <param name="plainText">The UTF-8 string to encode.</param>
        /// <returns>The base64 representation of the string.</returns>
        public static string StringToBase64(string plainText) {
            var plainTextBytes = Encoding.UTF8.GetBytes(plainText);
            return Convert.ToBase64String(plainTextBytes);
        }

        /// <summary>
        /// Converts a base64 encoding to the equivalent UTF-8 string.
        /// </summary>
        /// <param name="base64EncodedData">The base64 encoding.</param>
        /// <returns>The UTF-8 string equivalent.</returns>
        public static string Base64ToString(string base64EncodedData) {
            var base64EncodedBytes = Convert.FromBase64String(base64EncodedData);
            return Encoding.UTF8.GetString(base64EncodedBytes);
        }

        /// <summary>
        /// Converts an hexadecimal string to its equivalent as an array of bytes.
        /// </summary>
        /// <param name="hex">The hexadecimal string.</param>
        /// <returns>An array of bytes.</returns>
        public static byte[] HexToByteArray(string hex) {
            if (hex.StartsWith("0x"))
                hex = hex.Substring(2);

            hex = hex.ToLower();

            int NumberChars = hex.Length;
            byte[] bytes = new byte[NumberChars / 2];
            for (int i = 0; i < NumberChars; i += 2)
                bytes[i / 2] = Convert.ToByte(hex.Substring(i, 2), 16);
            return bytes;
        }

        /// <summary>
        /// When the web server proposes a list of supported algorithms for digital signatures,
        /// sort them by user preferences according to the application settings.
        /// </summary>
        /// <param name="supported">The list of supported algorithms, to offer only the relevant ones.</param>
        /// <returns></returns>
        public static string[] SortAlgorithmByPreference(string[] supported) {
            string[] preferred = Properties.Settings.Default.PreferredAlgo.Split('|');

            string[] ordered = new string[supported.Length];

            int currentIndex = 0;

            foreach (string algoType in preferred) {
                foreach (string supportedImplementation in supported) {
                    if (supportedImplementation.StartsWith(algoType)) {
                        ordered[currentIndex] = supportedImplementation;
                        currentIndex++;
                    }
                }
            }
            return ordered;
        }
        
    }
}
