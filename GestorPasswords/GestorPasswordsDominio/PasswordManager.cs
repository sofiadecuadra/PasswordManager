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
        public bool AddUser(User myUser)
        {
            users.Add(myUser.Name, myUser);
            return true;
        }

        public bool HasUser(string name)
        {
            return users.Contains(name);
        }

        public bool ValidateUser(string username, string masterPassword)
        {
            var usernameInLower = username.ToLower();
            if (!HasUser(usernameInLower))
            {
                throw new ExceptionUserDoesNotExist($"The user {username} does not exist");
            }

            return ((User)users[usernameInLower]).MasterPassword.Equals(masterPassword);
        }
    }
}
