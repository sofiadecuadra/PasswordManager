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

        public Hashtable UsersWithAccess{ get; set; }

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

        public String LastModifiedShortFormat { get { return LastModifiedDate.ToString("d"); } }

        public Category Category { get; set; }

        public String CategoryName { get { return Category.Name; }  }

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
            return "[" + Category.Name + "] [" + Site + "] [" + Username + "]";
        }
    }
}