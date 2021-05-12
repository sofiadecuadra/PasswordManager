using System;
using System.Collections;

namespace GestorPasswordsDominio
{
    public class UserPasswordPair
    {
        public string password;
        public string Password {
            get { return password; }
            set 
            {
                LastModifiedDate = DateTime.Now;
                password = value;
            }
        }

        public Hashtable UsersWithAccess{ get; private set; }

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

        public DateTime LastModifiedDate { get; private set; }

        public NormalCategory Category { get; set; }

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

        public override string ToString()
        {
            return "[" + Category.Name + "] [" + Site + "] [" + Username + "]";
        }

        public User[] GetUsersWithAccessArray()
        {
            if (UsersWithAccess.Count == 0)
            {
                throw new ExceptionUserPasswordPairIsNotSharedWithAnyone("This password has not been shared with anyone");
            }
            User[] usersToReturn = new User[UsersWithAccess.Count];
            UsersWithAccess.Values.CopyTo(usersToReturn, 0);
            return usersToReturn;
        }
    }
}