using System.Collections.Generic;

namespace GestorPasswordsDominio
{
    public class PasswordManager
    {
        private Dictionary<string, User> users;
        private User currentUser;
        public User CurrentUser
        {
            get { return currentUser; }
            set { currentUser = ReturnUserIfItExists(value); }
        }

        public PasswordManager()
        {
            users = new Dictionary<string, User>();
        }

        public User[] GetUsers()
        {
            User[] usersToReturn = new User[users.Count];
            users.Values.CopyTo(usersToReturn, 0);
            return usersToReturn;
        }

        private User ReturnUserIfItExists(User value)
        {
            return HasUser(value.Name) ? value : throw new ExceptionUserDoesNotExist("The user does not exist");
        }

        public bool HasUser(string name)
        {
            return users.ContainsKey(name.ToLower());
        }

        public bool AddUser(User myUser)
        {
            users.Add(myUser.Name, myUser);
            return true;
        }

        public void LogIn(string username, string masterPassword)
        {
            if (ValidateUser(username.Trim(), masterPassword))
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
            return users[name.ToLower()];
        }

        public void SharePassword(UserPasswordPair passwordToShare, string name)
        {
            if (!HasUser(name))
            {
                throw new ExceptionUserDoesNotExist($"The user {name} does not exist");
            }
            var userToRecivePassword = FindUser(name);
            passwordToShare.IncludeInUsersWithAccess(userToRecivePassword);
            userToRecivePassword.AddSharedUserPasswordPair(passwordToShare);
        }

        public void UnsharePassword(UserPasswordPair passwordToStopSharing, string name)
        {
            if (!HasUser(name))
            {
                throw new ExceptionUserDoesNotExist($"The user {name} does not exist");
            }
            var userToRevokeSharedPassword = FindUser(name);
            passwordToStopSharing.RemoveFromUsersWithAccess(userToRevokeSharedPassword);
            userToRevokeSharedPassword.UnshareUserPasswordPair(passwordToStopSharing);
        }
    }
}
