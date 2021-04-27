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
    }
}
