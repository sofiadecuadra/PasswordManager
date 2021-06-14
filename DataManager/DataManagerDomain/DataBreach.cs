using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;

namespace DataManagerDomain
{
    public class DataBreach
    {
        public int Id { get; set; }
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
            using (var dbContext = new DataManagerContext())
            {
                dbContext.UserPasswordPairs.Attach(aLeakedUserPasswordPair);
                var dataBreach = dbContext.DataBreaches
                    .FirstOrDefault(element => element.Id == Id);
                dataBreach.LeakedUserPasswordPairsOfUser.Add(aLeakedUserPasswordPair);
                dbContext.SaveChanges();
            }
        }

        public void AddLeakedCreditCardOfUser(CreditCard aLeakedCreditCard)
        {
            using (var dbContext = new DataManagerContext())
            {
                dbContext.CreditCards.Attach(aLeakedCreditCard);
                var dataBreach = dbContext.DataBreaches
                    .FirstOrDefault(element => element.Id == Id);
                dataBreach.LeakedCreditCardsOfUser.Add(aLeakedCreditCard);
                dbContext.SaveChanges();
            }
        }

        public void AddLeakedUserPasswordPair(LeakedPassword aLeakedUserPasswordPair)
        {
            using (var dbContext = new DataManagerContext())
            {
                var dataBreach = dbContext.DataBreaches
                    .Include(element => element.LeakedPasswords)
                    .FirstOrDefault(element => element.Id == Id);
                dataBreach.LeakedPasswords.Add(aLeakedUserPasswordPair);
                dbContext.SaveChanges();
            }
        }

        public void AddLeakedCreditCard(LeakedCreditCard aLeakedCreditCard)
        {
            using (var dbContext = new DataManagerContext())
            {
                var dataBreach = dbContext.DataBreaches
                    .Include(element => element.LeakedCreditCards)
                    .FirstOrDefault(element => element.Id == Id);
                dataBreach.LeakedCreditCards.Add(aLeakedCreditCard);
                dbContext.SaveChanges();
            }
        }

        public void RemoveCreditCard(CreditCard aLeakedCreditCard)
        {
            using (var dbContext = new DataManagerContext())
            {
                dbContext.CreditCards.Attach(aLeakedCreditCard);
                var dataBreach = dbContext.DataBreaches
                    .FirstOrDefault(element => element.Id == Id);
                dataBreach.LeakedCreditCardsOfUser.Remove(aLeakedCreditCard);
                dbContext.SaveChanges();
            }
        }

        public void RemoveUserPasswordPair(UserPasswordPair aLeakedUserPasswordPair)
        {
            using (var dbContext = new DataManagerContext())
            {
                dbContext.UserPasswordPairs.Attach(aLeakedUserPasswordPair);
                var dataBreach = dbContext.DataBreaches
                    .FirstOrDefault(element => element.Id == Id);
                dataBreach.LeakedUserPasswordPairsOfUser.Remove(aLeakedUserPasswordPair);
                dbContext.SaveChanges();
            }
        }

        public bool PasswordWasModified(UserPasswordPair aLeakedUserPasswordPair)
        {
            return aLeakedUserPasswordPair.LastModifiedDate > DateTime;
        }

        public bool PasswordAppearedInDataBreach(string aPassword)
        {
            using (var dbContext = new DataManagerContext())
            {
                var dataBreach = dbContext.DataBreaches
                    .Include(element => element.LeakedPasswords)
                    .FirstOrDefault(element => element.Id == Id);
                return dataBreach.LeakedPasswords.Exists(leakedPassword => leakedPassword.Password == aPassword);
            }
        }
    }
}