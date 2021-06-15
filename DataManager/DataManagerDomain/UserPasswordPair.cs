using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;

namespace DataManagerDomain
{
    public class UserPasswordPair
    {
        public int Id { get; set; }
        public string EncryptedPassword { get; set; }
        public string Password
        {
            get { return DecryptPassword(); }
            set
            {
                LastModifiedDate = DateTime.Now;
                PasswordStrength = PasswordHandler.PasswordStrength(value);
                EncryptedPassword = EncryptPassword(value);
            }
        }
        public List<User> UsersWithAccess { get; private set; }
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
        public DateTime LastModifiedDate { get; set; }
        public Category Category { get; set; }
        public PasswordStrengthType PasswordStrength { get; private set; }
        public List<DataBreach> DataBreaches { get; set; }

        public UserPasswordPair()
        {
            UsersWithAccess = new List<User>();
            DataBreaches = new List<DataBreach>();
        }

        public override string ToString()
        {
            return $"[{Category.Name}] [{Site}] [{Username}]";
        }

        private string DecryptPassword()
        {
            var user = Category?.User;
            if (user == null)
            {
                using (var dbContext = new DataManagerContext())
                {
                    user = dbContext.UserPasswordPairs
                        .Include(userPasswordPair => userPasswordPair.Category)
                        .Include(userPasswordPair => userPasswordPair.Category.User)
                        .FirstOrDefault(userPasswordPair => userPasswordPair.Id == Id)
                        .Category.User;
                }
            }
            var privateKey = user.PrivateKey;
            return Encrypter.Decrypt(EncryptedPassword, privateKey);
        }

        private string EncryptPassword(string aPassword)
        {
            var user = Category?.User;
            if (user == null)
            {
                using (var dbContext = new DataManagerContext())
                {
                    user = dbContext.UserPasswordPairs
                        .Include(userPasswordPair => userPasswordPair.Category)
                        .Include(userPasswordPair => userPasswordPair.Category.User)
                        .FirstOrDefault(userPasswordPair => userPasswordPair.Id == Id)
                        .Category.User;
                }
            }
            var publicKey = user.PublicKey;
            return Encrypter.Encrypt(aPassword, publicKey);
        }

        public bool HasAccess(string name)
        {
            using (var dbContext = new DataManagerContext())
            {
                var userPasswordPairSelected = dbContext.UserPasswordPairs
                    .Include(userPasswordPair => userPasswordPair.UsersWithAccess)
                    .FirstOrDefault(userPasswordPair => userPasswordPair.Id == Id);
                return userPasswordPairSelected.UsersWithAccess.Exists(user => user.Username == name);
            }
        }

        internal void IncludeInUsersWithAccess(User aUser)
        {
            using (var dbContext = new DataManagerContext())
            {
                var userPasswordPairSelected = dbContext.UserPasswordPairs
                    .Include(userPasswordPair => userPasswordPair.UsersWithAccess)
                    .FirstOrDefault(userPasswordPair => userPasswordPair.Id == Id);
                var userToShare = dbContext.Users
                    .FirstOrDefault(user => user.Username == aUser.Username);
                userPasswordPairSelected.UsersWithAccess.Add(userToShare);
                dbContext.SaveChanges();
            }
        }

        internal void RemoveFromUsersWithAccess(User aUser)
        {
            using (var dbContext = new DataManagerContext())
            {
                var userPasswordPairSelected = dbContext.UserPasswordPairs
                    .Include(userPasswordPair => userPasswordPair.UsersWithAccess)
                    .FirstOrDefault(userPasswordPair => userPasswordPair.Id == Id);
                var userToUnshare = dbContext.Users
                    .FirstOrDefault(user => user.Username == aUser.Username);
                userPasswordPairSelected.UsersWithAccess.Remove(userToUnshare);
                dbContext.SaveChanges();
            }
        }

        public User[] GetUsersWithAccessArray()
        {
            using (var dbContext = new DataManagerContext())
            {
                var userPasswordPairSelected = dbContext.UserPasswordPairs
                    .Include(userPasswordPair => userPasswordPair.UsersWithAccess)
                    .FirstOrDefault(userPasswordPair => userPasswordPair.Id == Id);
                if (userPasswordPairSelected.UsersWithAccess.Count == 0)
                {
                    throw new ExceptionUserPasswordPairIsNotSharedWithAnyone("This password has not been shared with anyone");
                }
                return userPasswordPairSelected.UsersWithAccess.ToArray();
            }
        }

        public bool UserPasswordPairDataIsValid()
        {
            CheckSiteLength();
            CheckUsernameLength();
            CheckPasswordLength();
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

        private void CheckPasswordLength()
        {
            if (!LengthBetween5And25(Password))
            {
                throw new ExceptionIncorrectLength($"The password's length must be between 5 and 25, but it's current length is: {Password.Length}");
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
    }
}