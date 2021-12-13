using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Xml;
using AuthenticatorProject.DigitalSignature;
using AuthenticatorProject.Encryption;

namespace AuthenticatorProject {
    /// <summary>
    /// A vault is a file where the account information, including private keys, is stored.
    /// </summary>
    public class Vault {
        /// <summary>
        /// The file path of the vault.
        /// </summary>
        public string Path { get; set; }
        /// <summary>
        /// The access control used to protect the vault.
        /// </summary>
        public AccessControl AccessControl { get; set; }
        /// <summary>
        /// A flag to indicate that the content has been modified and should be saved to preserve it.
        /// </summary>
        public bool Changed { get; set; }
        /// <summary>
        /// The list of accounts stored in the vault.
        /// </summary>
        public List<Account> Accounts { get; set; }
        /// <summary>
        /// A string representation of the date that the vault was created.
        /// </summary>
        public string DateCreated { get; set; }

        /// <summary>
        /// Instantiate a new vault with a given path.
        /// </summary>
        /// <param name="path">The file path of the vault to create.</param>
        public Vault(string path, AccessControl accessControl) {
            this.Path = path;
            this.AccessControl = accessControl;
            this.Accounts = new List<Account>();
        }
        /// <summary>
        /// Saves all the accounts in their current form to the file associated with the vault.
        /// </summary>
        public void Save() {
            // Save the vault contents to file.
            try {
                string content = Serialize();
                byte[] data = AccessControl.Encrypt(content);
                File.WriteAllText(Path, Utilities.ByteArrayToBase64(data));
            }
            catch (Exception ex) {
                throw new VaultException(ex.Message);
            }
        }
        /// <summary>
        /// Creates an XML representation of the contents of the vault for storing as text.
        /// </summary>
        /// <returns>The XML encoding of the vault.</returns>
        private string Serialize() {
            StringBuilder _contents = new StringBuilder("<?xml version=\"1.0\" encoding=\"UTF-8\"?>\n<vault>\n  <settings>\n    <dateCreated>");
            if (DateCreated == null) {
                _contents.Append(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            }
            else {
                _contents.Append(DateCreated);
            }

            _contents.Append("</dateCreated>\n  </settings>\n  <accounts>\n");

            foreach (Account _account in Accounts) {
                _contents.Append(_account.Serialize());
            }
            _contents.Append("  </accounts>\n</vault>\n");

            return _contents.ToString();
        }
        /// <summary>
        /// Loads the accounts into the instantiated file.
        /// </summary>
        public void LoadAccounts() {
            string _xmlString = null;
            try {
                // Acquire the whole contents of the vault file.
                // Several errors may occur during this process.
                if (!File.Exists(Path))
                    throw new VaultException("File " + Path + " was not found");

                var _fileStream = new FileStream(Path, FileMode.Open);
                if (!_fileStream.CanRead)
                    throw new VaultException("Unable to read file " + Path);

                StreamReader _reader = new StreamReader(_fileStream);

                string _content = _reader.ReadToEnd();
                _reader.Close();
                _xmlString = AccessControl.Decrypt(Utilities.Base64ToByteArray(_content));
                //_xmlString = _content;
            }
            catch (Exception ex) {
                throw new VaultException("Error encountered trying to open the vault: " + ex.Message);
            }
            
            // Read and acquire the XML content to get the vault.
            XmlDocument _xmlDoc = new XmlDocument();
            
            try {
                _xmlDoc.LoadXml(_xmlString);

                // Extract the properties of the vault.
                if (_xmlDoc.GetElementsByTagName("dateCreated") == null || _xmlDoc.GetElementsByTagName("dateCreated").Count == 0)
                    DateCreated = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                else
                    DateCreated = _xmlDoc.GetElementsByTagName("dateCreated")[0].InnerText;

                if (_xmlDoc.GetElementsByTagName("accounts") == null || _xmlDoc.GetElementsByTagName("accounts").Count == 0)
                    throw new VaultException("No tag 'accounts' found in the vault file");

                XmlNode _accounts = _xmlDoc.GetElementsByTagName("accounts")[0];

                // Check all the children of the node "groups". Each of them is a group.
                foreach (XmlNode _accountNode in _accounts.ChildNodes) {
                    Account _newAccount = new Account();

                    foreach (XmlNode _accountMember in _accountNode.ChildNodes) {
                        if (_accountMember.Name == "email")
                            _newAccount.Email = _accountMember.InnerText;
                        else if (_accountMember.Name == "loginURL")
                            _newAccount.LoginURL = _accountMember.InnerText;
                        else if (_accountMember.Name == "notes")
                            _newAccount.Notes = _accountMember.InnerText;
                        else if (_accountMember.Name == "key") {
                            string type = _accountMember.Attributes.GetNamedItem("type").InnerText;
                            string storage = _accountMember.Attributes.GetNamedItem("storage").InnerText;
                            //string hash = _accountMember.Attributes.GetNamedItem("hash_function").InnerText;

                            _newAccount.Key = AuthenticatorKey.FromSpecification(DigitalSignatureImplementation.FromName(type),
                                    PrivateKeyStorage.FromName(storage));
                                
                            _newAccount.Key.Load(Utilities.Base64ToString(_accountMember.InnerText));
                        }
                        else if (_accountMember.Name == "server")
                            _newAccount.Server = _accountMember.InnerText;
                        else if (_accountMember.Name == "icon")
                            _newAccount.Icon = Utilities.Base64ToImage(_accountMember.InnerText);
                    }
                    Accounts.Add(_newAccount);
                }
            }
            catch (XmlException) {
                throw new VaultException("The vault file is not valid XML");
            }
        }
        /// <summary>
        /// Indicates that the pointed account must be removed from the file. This changes the volatile contents 
        /// of the file. Changes are not permanent until saved.
        /// </summary>
        /// <param name="account"></param>
        public void RemoveAccount(Account account) {
            Changed = true;
            Accounts.Remove(account);
        }
        /// <summary>
        /// Sort the accounts in the vault using the default comparer in Account.
        /// </summary>
        public void Sort() {
            Accounts.Sort();
        }
    }
}
