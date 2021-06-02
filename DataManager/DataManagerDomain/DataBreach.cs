using System;
using System.Collections.Generic;

namespace DataManagerDomain
{
    public class DataBreach
    {
        public DateTime DateTime { get; private set; }
        public List<UserPasswordPair> LeakedUserPasswordPairsOfUser { get; set; }
        public List<CreditCard> LeakedCreditCardsOfUser { get; set; }
        public List<String> LeakedCreditCards { get; set; }
        public List<String> LeakedUserPasswordPairs { get; set; }

        public DataBreach()
        {
            DateTime = DateTime.Now;
            LeakedUserPasswordPairsOfUser = new List<UserPasswordPair>();
            LeakedCreditCardsOfUser = new List<CreditCard>();
            LeakedUserPasswordPairs = new List<String>();
            LeakedCreditCards = new List <String>();
        }

        public void AddLeakedUserPasswordPairOfUser(UserPasswordPair aLeakedUserPasswordPair)
        {
            this.LeakedUserPasswordPairsOfUser.Add(aLeakedUserPasswordPair);
        }

        public void AddLeakedCreditCardOfUser(CreditCard aLeakedCreditCard)
        {
            this.LeakedCreditCardsOfUser.Add(aLeakedCreditCard);
        }

        public void AddLeakedUserPasswordPair(String aLeakedUserPasswordPair)
        {
            this.LeakedUserPasswordPairs.Add(aLeakedUserPasswordPair);
        }

        public void AddLeakedCreditCard(String aLeakedCreditCard)
        {
            this.LeakedCreditCards.Add(aLeakedCreditCard);
        }

        public bool PasswordWasModified(UserPasswordPair aLeakedUserPasswordPair)
        {
            return aLeakedUserPasswordPair.LastModifiedDate > this.DateTime;
        }

        public void RemoveCreditCard(CreditCard aLeakedCreditCard)
        {
            LeakedCreditCardsOfUser.Remove(aLeakedCreditCard);
        }

        public void RemoveUserPasswordPair(UserPasswordPair aLeakedUserPasswordPair)
        {
            LeakedUserPasswordPairsOfUser.Remove(aLeakedUserPasswordPair);
        }
    }
}
