using System.Collections.Generic;
using System.Linq;

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

        private User ReturnUserIfItExists(User aUser)
        {
            return HasUser(aUser.Name) ? aUser : throw new ExceptionUserDoesNotExist("The user does not exist");
        }

        public bool HasUser(string name)
        {
            using (var dbContext = new DataManagerContext())
            {
                return dbContext.Users.ToList().Exists(user => user.Name == name);
            }
        }

        public void AddUser(User myUser)
        {
            using (var dbContext = new DataManagerContext())
            {
                dbContext.Users.Add(myUser);
                dbContext.SaveChanges();
            }
        }

        public void LogIn(string username, string masterPassword)
        {
            if (ValidateUser(username, masterPassword))
            {
                CurrentUser = FindUser(username.Trim());
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
                return dbContext.Users.ToList().Find(user => user.Name == name);
            }
        }

        public void SharePassword(UserPasswordPair passwordToShare, User userToRecivePassword)
        {
            if (!HasUser(userToRecivePassword.Name))
            {
                throw new ExceptionUserDoesNotExist($"The user {userToRecivePassword} does not exist");
            }
            passwordToShare.IncludeInUsersWithAccess(userToRecivePassword);
            userToRecivePassword.AddSharedUserPasswordPair(passwordToShare);
        }

        public void UnsharePassword(UserPasswordPair passwordToStopSharing, User userToRevokeSharedPassword)
        {
            if (!HasUser(userToRevokeSharedPassword.Name))
            {
                throw new ExceptionUserDoesNotExist($"The user {userToRevokeSharedPassword} does not exist");
            }
            passwordToStopSharing.RemoveFromUsersWithAccess(userToRevokeSharedPassword);
            userToRevokeSharedPassword.UnshareUserPasswordPair(passwordToStopSharing);
        }
    }
}