using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorPasswordsDominio
{
    public class SpecialCategory : Category
    {
        public SpecialCategory()
        {
            Name = "Shared Passwords";
        }

        public override bool AddUserPasswordPair(UserPasswordPair aUserPasswordPair)
        {
            AddUserPasswordPairToHashTable(aUserPasswordPair);
            return true;
        }

        public override bool RemoveUserPasswordPair(UserPasswordPair aUserPasswordPair)
        {
            RemoveUserPasswordPairFromCollection(aUserPasswordPair);
            return true;
        }
    }
}
