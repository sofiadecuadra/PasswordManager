using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using DataManagerDomain.Exceptions;

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
                return dbContext.Users.ToList().Exists(user => user.Username == name.ToLower());
            }
        }

        public void AddUser(User myUser)
        {
            if (HasUser(myUser.Username))
            {
                throw new ExceptionUserAlreadyExists("The user already exists");
            }
            using (var dbContext = new DataManagerContext())
            {
                dbContext.Users.Add(myUser);
                dbContext.SaveChanges();
            }
        }

        public void LogIn(string username, string masterPassword)
        {
            username = username.Trim();
            if (ValidateUser(username, masterPassword))
            {
                CurrentUser = FindUser(username);
            }
            else
            {
                throw new ExceptionIncorrectMasterPassword("Wrong password");
            }
        }

        public bool ValidateUser(string username, string masterPassword)
        {
            if (!HasUser(username))
            {
                throw new ExceptionUserDoesNotExist($"The user {username} does not exist");
            }
            return FindUser(username)
                    .MasterPassword.Equals(masterPassword);
        }

        public User FindUser(string name)
        {
            using (var dbContext = new DataManagerContext())
            {
                return dbContext.Users.Include(user => user.Categories).FirstOrDefault(user => user.Username == name.ToLower());
            }
        }

        public void SharePassword(UserPasswordPair passwordToShare, User userToRecivePassword)
        {
            if (!HasUser(userToRecivePassword.Username))
            {
                throw new ExceptionUserDoesNotExist($"The user {userToRecivePassword} does not exist");
            }
            passwordToShare.IncludeInUsersWithAccess(userToRecivePassword);
        }

        public void UnsharePassword(UserPasswordPair passwordToStopSharing, User userToRevokeSharedPassword)
        {
            if (!HasUser(userToRevokeSharedPassword.Username))
            {
                throw new ExceptionUserDoesNotExist($"The user {userToRevokeSharedPassword} does not exist");
            }
            passwordToStopSharing.RemoveFromUsersWithAccess(userToRevokeSharedPassword);
        }
    }
}