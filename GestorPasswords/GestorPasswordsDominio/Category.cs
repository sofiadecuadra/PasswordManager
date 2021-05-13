﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace DataManagerDomain
{
    public abstract class Category
    {
        private String name;
        public String Name
        {
            get { return name; }
            set { name = value.ToLower(); }
        }
        public User User { get; set; }
        public Dictionary<string, UserPasswordPair> userPasswordPairs;

        public Category()
        {
            userPasswordPairs = new Dictionary<string, UserPasswordPair>();
        }

        public override string ToString()
        {
            return Name;
        }

        public UserPasswordPair[] GetUserPasswordsPairs()
        {
            return userPasswordPairs.Values.ToArray();
        }

        protected void AddUserPasswordPairToCollection(UserPasswordPair aUserPasswordPair)
        {
            userPasswordPairs.Add(aUserPasswordPair.Site + aUserPasswordPair.Username, aUserPasswordPair);
        }

        protected void RemoveUserPasswordPairFromCollection(UserPasswordPair aUserPasswordPair)
        {
            userPasswordPairs.Remove($"{aUserPasswordPair.Site}{ aUserPasswordPair.Username}");
        }

        public abstract bool AddUserPasswordPair(UserPasswordPair aUserPasswordPair);

        public abstract bool RemoveUserPasswordPair(UserPasswordPair aUserPasswordPair);

        public bool UserPasswordPairAlredyExistsInCategory(string username, string site)
        {
            return userPasswordPairs.ContainsKey(site + username);
        }
    }
}
