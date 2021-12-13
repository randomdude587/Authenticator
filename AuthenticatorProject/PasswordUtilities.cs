using System;
using System.Drawing;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AuthenticatorProject {
    // Password related utility functions.
    public class PasswordUtilities {
    /// <summary>
    /// Calls the HaveIBeenPwned API and gets the number of times that password was cracked.
    /// </summary>
    /// <param name="password">The password to check.</param>
    /// <returns></returns>
        public static int NbFoundOccurrences(string password) {
            string hash = Utilities.ByteArrayToHex(Utilities.GetSha1(password)).Substring(2).ToUpper();

            string contents = (new WebClient()).DownloadString("https://api.pwnedpasswords.com/range/" + hash.Substring(0, 5));
            //MessageBox.Show(contents);

            string[] lines = contents.Split('\n');
            string pattern = hash.Substring(5);
            foreach (string line in lines) {
                string[] passwordDetails = line.Split(':');
                if (passwordDetails[0] == pattern) {
                    return int.Parse(passwordDetails[1]);
                }
            }
            // If we reach this, the password was not found, return 0.
            return 0;
        }

        /// <summary>
        /// An approach to calculate the number of bits of entropy to a password.
        /// </summary>
        /// <param name="password">The password.</param>
        /// <returns>Bits of entropy expressed as a double.</returns>
        public static double CalculateEntropy(string password) {
            var cardinality = 0;

            // Password contains lowercase letters.
            if (password.Any(c => char.IsLower(c))) {
                cardinality = 26;
            }

            // Password contains uppercase letters.
            if (password.Any(c => char.IsUpper(c))) {
                cardinality += 26;
            }

            // Password contains numbers.
            if (password.Any(c => char.IsDigit(c))) {
                cardinality += 10;
            }

            // Password contains symbols.
            if (password.IndexOfAny("\\|¬¦`!\"£$%^&*()_+-=[]{};:'@#~<>,./? ".ToCharArray()) >= 0) {
                cardinality += 36;
            }

            return Math.Log(cardinality, 2) * password.Length;
        }

        /// <summary>
        /// Generate a string of random alphanumerical characters, from an alphabet of 62 characters.
        /// </summary>
        /// <param name="size">The number of characters to generate.</param>
        /// <returns></returns>
        public static string GenerateRandomContent(int size, string alphabet) {
            //string alphabet = "0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";

            Random rnd = new Random();

            StringBuilder content = new StringBuilder(size);
            for (int i = 0; i < size; i++) {
                content.Append(alphabet[rnd.Next(0, alphabet.Length)]);
            }
            return content.ToString();
        }

        /// <summary>
        /// Translates the security criteria (predictability, occurrences in breaches) to a specific color.
        /// </summary>
        /// <param name="entropy"></param>
        /// <param name="nbOccurrences"></param>
        /// <returns></returns>
        public static Color GetColor(double entropy, int nbOccurrences = 0) {
            if (nbOccurrences > 0)
                return Color.Red;

            if (entropy < 25)
                return Color.Red;
            else if (entropy < 40)
                return Color.Orange;
            else if (entropy < 60)
                return Color.Yellow;
            else
                return Color.Green;
        }
        /// <summary>
        /// Translates the security criteria (predictability, occurrences in breaches) to a specific description.
        /// </summary>
        /// <param name="entropy"></param>
        /// <param name="nbOccurrences"></param>
        /// <returns>The description for the password provided.</returns>
        public static string GetDescription(double entropy, int nbOccurrences = 0) {
            if (nbOccurrences > 0)
                return "Predictable";
            if (entropy < 25)
                return "Very Weak";
            else if (entropy < 40)
                return "Weak";
            else if (entropy < 60)
                return "Passable";
            else
                return "Strong";
        }
    }
}
