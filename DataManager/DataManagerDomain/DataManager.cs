using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;

namespace DataManagerDomain
{
    public class DataManager
    {
        public List<User> Users { get; set; }
        private User currentUser;
        public User CurrentUser
        {
            get { return currentUser; }
            set { currentUser = ReturnUserIfItExists(value); }
        }

        public DataManager()
        {
            Users = new List<User>();
        }

        public User[] GetUsers()
        {
            using (var dbContext = new DataManagerContext())
            {
                return dbContext.Users.ToArray();
            }
        }

        private User ReturnUserIfItExists(User value)
        {
            return HasUser(value.Username) ? value : throw new ExceptionUserDoesNotExist("The user does not exist");
        }

        public bool HasUser(string name)
        {
            using (var dbContext = new DataManagerContext())
            {
                return dbContext.Users
                    .ToList()
                    .Exists(user => user.Username == name.ToLower());
            }
        }

        public void AddUser(User myUser)
        {
            CheckIfUserAlreadyExists(myUser);
            using (var dbContext = new DataManagerContext())
            {
                dbContext.Users.Add(myUser);
                dbContext.SaveChanges();
            }
        }

        private void CheckIfUserAlreadyExists(User myUser)
        {
            if (HasUser(myUser.Username))
            {
                throw new ExceptionUserAlreadyExists("The user already exists");
            }
        }

        public void LogIn(string username, string masterPassword)
        {
            username = username.Trim();
            ValidateUser(username, masterPassword);
            CurrentUser = FindUser(username);
        }

        public void ValidateUser(string username, string masterPassword)
        {
            if (!HasUser(username))
            {
                throw new ExceptionUserDoesNotExist($"The user {username} does not exist");
            }
            if (!MasterPasswordEnteredIsCorrect(username, masterPassword))
            {
                throw new ExceptionIncorrectMasterPassword("Wrong password");
            }
        }

        private bool MasterPasswordEnteredIsCorrect(string username, string masterPassword)
        {
            return FindUser(username).MasterPassword.Equals(masterPassword);
        }

        public User FindUser(string name)
        {
            using (var dbContext = new DataManagerContext())
            {
                return dbContext.Users
                    .Include(user => user.Categories)
                    .FirstOrDefault(user => user.Username == name.ToLower());
            }
        }

        public void SharePassword(UserPasswordPair passwordToShare, User userToRecivePassword)
        {
            CheckIfUserIsNotNull(userToRecivePassword);
            CheckIfUserExists(userToRecivePassword);
            passwordToShare.IncludeInUsersWithAccess(userToRecivePassword);
        }

        private static void CheckIfUserIsNotNull(User aUser)
        {
            if (!ValidUser(aUser))
            {
                throw new ExceptionUserDoesNotExist($"Please, choose a valid user");
            }
        }

        private static bool ValidUser(User aUser)
        {
            return aUser != null;
        }

        private void CheckIfUserExists(User aUser)
        {
            if (!HasUser(aUser.Username))
            {
                throw new ExceptionUserDoesNotExist($"The user {aUser} does not exist");
            }
        }

        public void UnsharePassword(UserPasswordPair passwordToStopSharing, User userToRevokeSharedPassword)
        {
            CheckIfUserIsNotNull(userToRevokeSharedPassword);
            CheckIfUserExists(userToRevokeSharedPassword);
            passwordToStopSharing.RemoveFromUsersWithAccess(userToRevokeSharedPassword);
        }
    }
}