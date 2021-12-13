using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using AuthenticatorProject.DigitalSignature;

namespace AuthenticatorProject {
    /// <summary>
    /// Object representation of a user account on a web service provider.
    /// </summary>
    public class Account : IComparer<Account>, IComparable<Account> {
        /// <summary>
        /// The email associated to the account.
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// The authenticator key associated to the account.
        /// </summary>
        public AuthenticatorKey Key { get; set; }
        /// <summary>
        /// The server icon associated to the account (provided by the server).
        /// </summary>
        public Image Icon { get; set; }
        /// <summary>
        /// A server identification string for the account (provided by the server).
        /// </summary>
        public string Server { get; set; }
        /// <summary>
        /// The URL for the login page of the service.
        /// </summary>
        public string LoginURL { get; set; }
        /// <summary>
        /// Client-side notes compiled for the service.
        /// </summary>
        public string Notes { get; set; }
        /// <summary>
        /// Creates an XML serialization of the account contents.
        /// </summary>
        /// <returns>An XML-encoded definition of the account for storage in a vault file.</returns>
        public string Serialize () {
            StringBuilder _contents = new StringBuilder();
            _contents.Append("    <account>\n");

            _contents.Append("      <email>" + Utilities.EncodeXMLEntities(this.Email) + "</email>\n");
            _contents.Append("      <loginURL>" + Utilities.EncodeXMLEntities(this.LoginURL) + "</loginURL>\n");

            //_contents.Append("      <key type=\"" + _account.Key.Implementation.Name + "\" storage=\"" + _account.Key.Storage.ToString() +
            //       "\" hashFunction=\"" + _account.Key.HashFunction.ToString() + "\">" + 
            //    Utilities.StringToBase64(_account.Key.Export(true)) + "</key>\n");
            _contents.Append("      <key type=\"" + this.Key.Implementation.Name + "\" storage=\"" + this.Key.Storage.Name +
                   "\">" + Utilities.StringToBase64(this.Key.Export(true)) + "</key>\n");

            _contents.Append("      <icon>" + Utilities.ImageToBase64(this.Icon) + "</icon>\n");
            _contents.Append("      <server>" + Utilities.EncodeXMLEntities(this.Server) + "</server>\n");

            _contents.Append("      <notes>" + Utilities.EncodeXMLEntities(this.Notes) + "</notes>\n");
            _contents.Append("    </account>\n");

            return _contents.ToString();
        }
        /// <summary>
        /// Compare two accounts.
        /// </summary>
        /// <param name="account1">Account to compare.</param>
        /// <param name="account2">Account to compare.</param>
        /// <returns>True if accounts have the same servers and same email addresses, false otherwise.</returns>
        public static bool operator ==(Account account1, Account account2) {
            if (((object) account1) == ((object) account2)) return true;
            if (((object) account1) == null || ((object) account2) == null) return false;
            return account1.Equals(account2);
        }

        /// <summary>
        /// Check if two accounts are different.
        /// </summary>
        /// <param name="account1">Account to compare.</param>
        /// <param name="account2">Account to compare.</param>
        /// <returns>True if the accounts have different servers or different email addresses. False otherwise.</returns>
        public static bool operator !=(Account account1, Account account2) {
            return ! (account1.Server == account2.Server && account1.Email == account2.Email);
        }

        /// <summary>
        /// Implementation of the comparison of an account to another object instance.
        /// </summary>
        /// <param name="obj">The object to which this account will be compared.</param>
        /// <returns></returns>
        public override bool Equals(object obj) {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;

            return Equals(obj as Account);
        }

        /// <summary>
        /// Compare this account to an instance of another account.
        /// </summary>
        /// <param name="account">The account to which this one will be compared.</param>
        /// <returns>True if the account have the same server and same email addresses, false otherwise.</returns>
        public bool Equals(Account account) {
            return this.Server == (account).Server && this.Email == (account).Email;
        }
        /// <summary>
        /// Get the hashcode of the account instance.
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode() {
            if (Server == null && Email == null) return 0;
                        
            return ((Server?? "") + (Email?? "")).GetHashCode();
        }

        /// <summary>
        /// Compare this instance to another instance of an object.
        /// </summary>
        /// <param name="obj">The object for comparison (assumed to be an account).</param>
        /// <returns>-1 if this object is smaller, 1 if it is bigger, and 0 if they are equal.</returns>
        public int CompareTo(Account account) {           
            // Sort firts on the email address.
            if (this.Email.CompareTo(account.Email) < 0)
                return -1;
            else if (this.Email.CompareTo(account.Email) > 0)
                return 1;
            else {
                // The emails are equals. So we compared the servers.
                if (this.Server.CompareTo(account.Server) < 0)
                    return -1;
                else if (this.Server.CompareTo(account.Server) > 0)
                    return 1;
                else
                    return 0;  // Both equal? Should never happen...
            }
        }

        /// <summary>
        /// Compare two instances of accounts.
        /// </summary>
        /// <param name="x">First account in the comparison.</param>
        /// <param name="y">Second account in the comparison.</param>
        /// <returns>-1 if first object is smaller, 1 if it is bigger, and 0 if they are equal.</returns>
        public int Compare(Account x, Account y) {
            Account a = (Account) x;
            Account b = (Account) y;

            // Sort firts on the email address.
            if (a.Email.CompareTo(b.Email) < 0)
                return -1;
            else if (a.Email.CompareTo(b.Email) > 0)
                return 1;
            else {
                // The emails are equals. So we compared the servers.
                if (a.Server.CompareTo(b.Server) < 0)
                    return -1;
                else if (a.Server.CompareTo(b.Server) > 0)
                    return 1;
                else
                    return 0;  // Both equal? Should never happen...
            }
        }
    }
}
