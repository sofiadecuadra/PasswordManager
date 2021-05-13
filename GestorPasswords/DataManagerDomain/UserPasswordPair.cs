using System;
using System.Collections;

namespace DataManagerDomain
{
    public class UserPasswordPair
    {
        public string password;
        public string Password
        {
            get { return password; }
            set
            {
                LastModifiedDate = DateTime.Now;
                PasswordStrength = PasswordHandler.PasswordStrength(value);
                password = value;
            }
        }
        public Hashtable UsersWithAccess { get; private set; }
        private string username;
        public string Username
        {
            get { return username; }
            set { username = value.ToLower(); }
        }
        private string site;
        public string Site
        {
            get { return site; }
            set { site = value.ToLower(); }
        }
        public string Notes { get; set; }
        public DateTime LastModifiedDate { get; private set; }
        public NormalCategory Category { get; set; }
        public PasswordStrengthType PasswordStrength { get; private set; }

        public UserPasswordPair()
        {
            UsersWithAccess = new Hashtable();
        }

        public bool HasAccess(string name)
        {
            return UsersWithAccess.ContainsKey(name.ToLower());
        }

        internal void IncludeInUsersWithAccess(User userToRecivePassword)
        {
            UsersWithAccess.Add(userToRecivePassword.Name, userToRecivePassword);
        }

        internal void RemoveFromUsersWithAccess(User userToRevokeSharedPassword)
        {
            UsersWithAccess.Remove(userToRevokeSharedPassword.Name);
        }

        public override string ToString()
        {
            return $"[{Category.Name}] [{Site}] [{Username}]";
        }

        public User[] GetUsersWithAccessArray()
        {
            if (UsersWithAccess.Count == 0)
            {
                throw new ExceptionUserPasswordPairIsNotSharedWithAnyone("This password has not been shared with anyone");
            }
            User[] usersToReturn = new User[UsersWithAccess.Count];
            UsersWithAccess.Values.CopyTo(usersToReturn, 0);
            return usersToReturn;
        }

        public bool UserPasswordPairDataIsValid()
        {
            CheckSiteLength();
            CheckUsernameLength();
            CheckNotesLength();
            return true;
        }

        private void CheckSiteLength()
        {
            if (!SiteHasValidLength())
            {
                throw new ExceptionIncorrectLength($"The site's length must be between 3 and 25, but it's current length is: {Site.Length}");
            }
        }

        private bool SiteHasValidLength()
        {
            return Site.Length >= 3 && Site.Length <= 25;
        }

        private void CheckUsernameLength()
        {
            if (!LengthBetween5And25(Username))
            {
                throw new ExceptionIncorrectLength($"The username's length must be between 5 and 25, but it's current length is: {Username.Length}");
            }
        }

        private static bool LengthBetween5And25(string stringToCheck)
        {
            return stringToCheck.Length >= 5 && stringToCheck.Length <= 25;
        }

        private void CheckNotesLength()
        {
            if (!NotesHaveValidLength())
            {
                throw new ExceptionIncorrectLength($"The notes' length must be up to 250, but it's current length is: {Notes.Length}");
            }
        }

        private bool NotesHaveValidLength()
        {
            return Notes.Length <= 250;
        }

        public bool IsARedPassword()
        {
            return PasswordStrength == PasswordStrengthType.Red;
        }

        public bool IsAnOrangePassword()
        {
            return PasswordStrength == PasswordStrengthType.Orange;
        }

        public bool IsAYellowPassword()
        {
            return PasswordStrength == PasswordStrengthType.Yellow;
        }

        public bool IsALightGreenPassword()
        {
            return PasswordStrength == PasswordStrengthType.LightGreen;
        }

        public bool IsADarkGreenPassword()
        {
            return PasswordStrength == PasswordStrengthType.DarkGreen;
        }
    }
}