using System;
using System.Collections.Generic;
using System.Linq;

namespace GestorPasswordsDominio
{
    public abstract class Category
    {
        public String Name
        {
            get { return name; }
            set { name = value.ToLower(); }
        }
        private String name;
        public User User { get; set; }
        public Dictionary<string, UserPasswordPair> userPasswordPairsHash;

        public Category()
        {
            this.userPasswordPairsHash = new Dictionary<string, UserPasswordPair>();
        }

        public abstract bool AddUserPasswordPair(UserPasswordPair aUserPasswordPair);

        public abstract bool RemoveUserPasswordPair(UserPasswordPair aUserPasswordPair);

        public UserPasswordPair[] GetUserPasswordsPairs()
        {
            return userPasswordPairsHash.Values.ToArray();
        }

        protected void AddUserPasswordPairToHashTable(UserPasswordPair aUserPasswordPair)
        {
            this.userPasswordPairsHash.Add(aUserPasswordPair.Site + aUserPasswordPair.Username, aUserPasswordPair);
        }
        protected void RemoveUserPasswordPairFromCollection(UserPasswordPair aUserPasswordPair)
        {
            this.userPasswordPairsHash.Remove($"{aUserPasswordPair.Site}{ aUserPasswordPair.Username}");
        }

        public bool UserPasswordPairAlredyExistsInCategory(string username, string site)
        {
            return this.userPasswordPairsHash.ContainsKey(site + username);
        }
    }
}
