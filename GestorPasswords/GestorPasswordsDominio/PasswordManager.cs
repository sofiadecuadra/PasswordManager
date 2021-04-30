﻿using System;
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

        private User ReturnUserIfItExists(User value)
        {
            return HasUser(value.Name) ? value : throw new ExceptionUserDoesNotExist();
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

        public void ValidateAndSetCurrentUser(string username, string masterPassword)
        {
            if (ValidateUser(username, masterPassword))
            {
                this.CurrentUser = FindUser(username);
            }
            else
            {

                throw new ExceptionIncorrectMasterPassword();
            }
        }

        private User FindUser(string name)
        {
            return (User)users[name.ToLower()];
        }
    }
}