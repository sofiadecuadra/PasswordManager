using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorPasswordsDominio
{
    public class UserPasswordPair
    {
        public string Password { get; set; }
        public Hashtable UsersWithAccess{ get; private set; }
        private string username;
        public string Username
        {
            get { return username; }
            set {
                LastModifiedDate = DateTime.Now;
                username = value.ToLower(); 
            }
        }
        private string site;
        public string Site
        {
            get { return site; }
            set { site = value.ToLower(); }
        }
        public string Notes { get; set; }
        public DateTime LastModifiedDate { get; private set; }
        public string LastModifiedShortFormat { get { return LastModifiedDate.ToString("d"); } }
        public Category Category { get; set; }
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

        override
        public string ToString()
        {
            return $"[{Category.Name}] [{Site}] [{Username}]";
        }

        public User[] GetUsersWithAccessArray()
        {
            if (UsersWithAccess.Count == 0)
            {
                throw new ExceptionUserPasswordPairIsNotSharedWithAnyone();
            }
            User[] usersToReturn = new User[UsersWithAccess.Count];
            UsersWithAccess.Values.CopyTo(usersToReturn, 0);
            return usersToReturn;
        }

        public bool UserPasswordPairDataIsValid()
        {
            if (!SiteHasValidLength())
            {
                throw new ExceptionUserPasswordPairHasInvalidSiteLength($"The site's length must be between 3 and 25, but it's current length is: {Site.Length}");
            }
            if (!LengthBetween5And25(Username))
            {
                throw new ExceptionUserPasswordPairHasInvalidUsernameLength($"The username's length must be between 5 and 25, but it's current length is: {Username.Length}");
            }
            if (!LengthBetween5And25(Password))
            {
                throw new ExceptionUserPasswordPairHasInvalidPasswordLength($"The password's length must be between 5 and 25, but it's current length is: {Password.Length}");
            }
            if (!NotesHaveValidLength())
            {
                throw new ExceptionUserPasswordPairHasInvalidNotesLength($"The notes' length must be up to 250, but it's current length is: {Notes.Length}");
            }
            return true;
        }

        private bool SiteHasValidLength()
        {
            return Site.Length >= 3 && Site.Length <= 25;
        }

        private static bool LengthBetween5And25(string stringToCheck)
        {
            return stringToCheck.Length >= 5 && stringToCheck.Length <= 25;
        }

        private bool NotesHaveValidLength()
        {
            return Notes.Length <= 250;
        }
    }
}