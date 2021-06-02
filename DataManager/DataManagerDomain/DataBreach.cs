using System;
using System.Collections.Generic;

namespace DataManagerDomain
{
    public class DataBreach
    {
        public DateTime DateTime { get; private set; }
        public List<UserPasswordPair> LeakedUserPasswordPairsOfUser { get; set; }
        public List<CreditCard> LeakedCreditCardsOfUser { get; set; }
        public string[] LeakedData { get; set; }

        public DataBreach()
        {
            DateTime = DateTime.Now;
            LeakedUserPasswordPairsOfUser = new List<UserPasswordPair>();
            LeakedCreditCardsOfUser = new List<CreditCard>();
        }

        public void AddLeakedUserPasswordPair(UserPasswordPair aLeakedUserPasswordPair)
        {
            this.LeakedUserPasswordPairsOfUser.Add(aLeakedUserPasswordPair);
        }

        public void AddLeakedCreditCard(CreditCard aLeakedCreditCard)
        {
            this.LeakedCreditCardsOfUser.Add(aLeakedCreditCard);
        }

        public bool PasswordWasModified(UserPasswordPair aLeakedUserPasswordPair)
        {
            return aLeakedUserPasswordPair.LastModifiedDate > this.DateTime;
        }

        public bool RemoveCreditCard(CreditCard aLeakedCreditCard)
        {
            return LeakedCreditCardsOfUser.Remove(aLeakedCreditCard);
        }

    }
}
