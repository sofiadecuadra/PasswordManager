using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataManagerDomain
{
    public class DataBreach
    {
        public DateTime DateTime { get; private set; }
        public List <UserPasswordPair> LeakedUserPasswordPairs { get; set; }
        public List <CreditCard> LeakedCreditCards { get; set; }

        public DataBreach()
        {
            DateTime = DateTime.Now;
            LeakedUserPasswordPairs = new List<UserPasswordPair>();
            LeakedCreditCards = new List<CreditCard>();
        }

        public void AddLeakedUserPasswordPair(UserPasswordPair aLeakedUserPasswordPair)
        {
            this.LeakedUserPasswordPairs.Add(aLeakedUserPasswordPair);
        }

        public void AddLeakedCreditCard(CreditCard aLeakedCreditCard)
        {
            this.LeakedCreditCards.Add(aLeakedCreditCard);
        }

        public bool PasswordWasModified(UserPasswordPair aLeakedUserPasswordPair)
        {
            return aLeakedUserPasswordPair.LastModifiedDate > this.DateTime;
        }
    }

}
