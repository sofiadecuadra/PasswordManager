using System;
using System.Collections.Generic;
using System.Linq;

namespace DataManagerDomain
{
    public class DataBreach
    {
        public User User { get; set; }
        public DateTime DateTime { get; set; }
        public virtual List<UserPasswordPair> LeakedUserPasswordPairsOfUser { get; set; }
        public virtual List<CreditCard> LeakedCreditCardsOfUser { get; set; }
        public List<LeakedPassword> LeakedPasswords { get; set; }
        public List<LeakedCreditCard> LeakedCreditCards { get; set; }

        public DataBreach()
        {
            DateTime = DateTime.Now;
            LeakedUserPasswordPairsOfUser = new List<UserPasswordPair>();
            LeakedCreditCardsOfUser = new List<CreditCard>();
            LeakedPasswords = new List<LeakedPassword>();
            LeakedCreditCards = new List<LeakedCreditCard>();
        }

        public void AddLeakedUserPasswordPairOfUser(UserPasswordPair aLeakedUserPasswordPair)
        {
            LeakedUserPasswordPairsOfUser.Add(aLeakedUserPasswordPair);
        }

        public void AddLeakedCreditCardOfUser(CreditCard aLeakedCreditCard)
        {
            LeakedCreditCardsOfUser.Add(aLeakedCreditCard);
        }

        public void AddLeakedUserPasswordPair(LeakedPassword aLeakedUserPasswordPair)
        {
            LeakedPasswords.Add(aLeakedUserPasswordPair);
        }

        public void AddLeakedCreditCard(LeakedCreditCard aLeakedCreditCard)
        {
            LeakedCreditCards.Add(aLeakedCreditCard);
        }

        public bool PasswordWasModified(UserPasswordPair aLeakedUserPasswordPair)
        {
            return aLeakedUserPasswordPair.LastModifiedDate > DateTime;
        }

        public bool PasswordAppearedInDataBreach(string aPassword)
        {
            foreach (LeakedPassword leakedPassword in LeakedPasswords)
            {
                if (leakedPassword.Password == aPassword)
                {
                    return true;
                }
            }
            return false;
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
