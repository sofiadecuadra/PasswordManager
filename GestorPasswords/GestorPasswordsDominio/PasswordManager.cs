using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorPasswordsDominio
{
    public class PasswordManager
    {
        private Hashtable users;
        public PasswordManager()
        {
            this.users = new Hashtable();
        }

        private User currentUser;

        public User CurrentUser
        {
            get { return currentUser; }
            set { currentUser = ReturnUserIfItExists(value); }
        }

        public User[] Users
        {
            get
            {
                User[] usersToReturn = new User[users.Count];
                users.Values.CopyTo(usersToReturn, 0);
                return usersToReturn;
            }
        }

        private User ReturnUserIfItExists(User value)
        {
            return HasUser(value.Name) ? value : throw new ExceptionUserDoesNotExist("The user does not exist");
        }

        public bool AddUser(User myUser)
        {
            users.Add(myUser.Name, myUser);
            return true;
        }

        public bool HasUser(string name)
        {
            return users.Contains(name.ToLower());
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

        public void LogIn(string username, string masterPassword)
        {
            if (ValidateUser(username.Trim(), masterPassword))
            {
                this.CurrentUser = FindUser(username.Trim());
            }
            else
            {
                throw new ExceptionIncorrectMasterPassword("Wrong password");
            }
        }

        public User FindUser(string name)
        {
            return (User)users[name.ToLower()];
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
