using System.Drawing;

namespace AuthenticatorProject {
    /// <summary>
    /// For ease-of-use, the authenticator application allows the user to save definitions of
    /// typical user profiles, for quick registration afterwards. This is the object representation
    /// of such a profile.
    /// </summary>
    public class UserProfile {
        /// <summary>
        /// The unique name associated to the profile.
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// The email associated to the profile.
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// The first name associated to the profile.
        /// </summary>
        public string FirstName { get; set; }
        /// <summary>
        /// The last name associated to the profile.
        /// </summary>
        public string LastName { get; set; }
        /// <summary>
        /// The title associated to the profile.
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// The phone number associated to the profile.
        /// </summary>
        public string PhoneNumber { get; set; }
        /// <summary>
        /// The organization associated to the profile.
        /// </summary>
        public string Organization { get; set; }
        /// <summary>
        /// The postal address associated to the profile.
        /// </summary>
        public string Address { get; set; }
        /// <summary>
        /// The image representation associated to the profile.
        /// </summary>
        public Image Avatar { get; set; }

        /// <summary>
        /// Clones the instance of the profile.
        /// </summary>
        /// <returns>An exact copy of the profile.</returns>
        public UserProfile Clone() {
            UserProfile _profile = new UserProfile();
            _profile.Name = this.Name;
            _profile.Email = this.Email;
            _profile.FirstName = this.FirstName;
            _profile.LastName = this.LastName;
            _profile.Title = this.Title;
            _profile.PhoneNumber = this.PhoneNumber;
            _profile.Organization = this.Organization;
            _profile.Address = this.Address;
            if (this.Avatar != null)
                _profile.Avatar = (Image) this.Avatar.Clone();
            return _profile;
        }
    }
}
