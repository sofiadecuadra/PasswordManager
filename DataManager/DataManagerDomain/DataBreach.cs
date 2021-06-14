using System;
using System.Collections.Generic;

namespace DataManagerDomain
{
    public class DataBreach
    {
        public DateTime DateTime { get; set; }
        public List<UserPasswordPair> LeakedUserPasswordPairsOfUser { get; set; }
        public List<CreditCard> LeakedCreditCardsOfUser { get; set; }
        public List<string> LeakedCreditCards { get; set; }
        public List<string> LeakedUserPasswordPairs { get; set; }

        public DataBreach()
        {
            DateTime = DateTime.Now;
            LeakedUserPasswordPairsOfUser = new List<UserPasswordPair>();
            LeakedCreditCardsOfUser = new List<CreditCard>();
            LeakedUserPasswordPairs = new List<string>();
            LeakedCreditCards = new List<string>();
        }

        public void AddLeakedUserPasswordPairOfUser(UserPasswordPair aLeakedUserPasswordPair)
        {
            LeakedUserPasswordPairsOfUser.Add(aLeakedUserPasswordPair);
        }

        public void AddLeakedCreditCardOfUser(CreditCard aLeakedCreditCard)
        {
            LeakedCreditCardsOfUser.Add(aLeakedCreditCard);
        }

        public void AddLeakedUserPasswordPair(string aLeakedUserPasswordPair)
        {
            LeakedUserPasswordPairs.Add(aLeakedUserPasswordPair);
        }

        public void AddLeakedCreditCard(string aLeakedCreditCard)
        {
            LeakedCreditCards.Add(aLeakedCreditCard);
        }

        public bool PasswordWasModified(UserPasswordPair aLeakedUserPasswordPair)
        {
            return aLeakedUserPasswordPair.LastModifiedDate > DateTime;
        }

        public bool PasswordAppearedInDataBreach(string aPassword)
        {
            return LeakedUserPasswordPairs.Contains(aPassword);
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
