using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace DataManagerDomain
{
    public class Category
    {
        public int Id { get; set; }
        public User User { get; set; }
        private string name { get; set; }
        public string Name
        {
            get { return name; }
            set { name = value.Trim().ToLower(); }
        }
        public List<UserPasswordPair> UserPasswordPairs { get; set; }
        private List<CreditCard> creditCards;

        public Category()
        {
            UserPasswordPairs = new List<UserPasswordPair>();
            creditCards = new List<CreditCard>();
        }

        public override string ToString()
        {
            return Name;
        }

        public CreditCard[] GetCreditCards()
        {
            using (var dbContext = new DataManagerContext())
            {
                var creditCards = dbContext.CreditCards.Where(creditCard => creditCard.Category.Id == Id);
                return creditCards.ToArray();
            }
        }

        public UserPasswordPair[] GetUserPasswordsPairs()
        {
            using (var dbContext = new DataManagerContext())
            {
                var passwords = dbContext.UserPasswordPairs.Where(userPasswordPair => userPasswordPair.Category.Id == Id).Include(password => password.Category).Include(password => password.Category.User);
                return passwords.ToArray();
            }
        }

        public bool AddCreditCard(CreditCard aCreditCard)
        {
            bool creditCardAdded = false;
            if (CreditCardIsValid(aCreditCard))
            {
                AddCreditCardToCollection(aCreditCard);
                creditCardAdded = true;
            }
            return creditCardAdded;
        }

        private bool CreditCardIsValid(CreditCard aCreditCard)
        {
            if (CreditCardNumberAlreadyExistsInUser(aCreditCard))
            {
                throw new ExceptionCreditCardNumberAlreadyExistsInUser("The credit card number already exists in user");
            }
            return aCreditCard.CreditCardDataIsValid();
        }

        private bool CreditCardNumberAlreadyExistsInUser(CreditCard aCreditCard)
        {
            using (var dbContext = new DataManagerContext())
            {
                var userSelected = dbContext.Users
                    .FirstOrDefault(user => user.Username == aCreditCard.Category.User.Username);
                return userSelected
                    .CreditCardNumberExists(aCreditCard.Number);
            }
        }

        protected void AddCreditCardToCollection(CreditCard aCreditCard)
        {
            using (var dbContext = new DataManagerContext())
            {
                dbContext.Categories.Attach(aCreditCard.Category);
                dbContext.CreditCards.Add(aCreditCard);
                dbContext.SaveChanges();
            }
        }

        public bool ModifyCreditCard(CreditCard oldCreditCard, CreditCard newCreditCard)
        {
            if (ModifiedCreditCardIsValid(oldCreditCard, newCreditCard))
            {
                UpdateCreditCardData(oldCreditCard, newCreditCard);
            }
            return true;
        }

        private bool ModifiedCreditCardIsValid(CreditCard oldCreditCard, CreditCard newCreditCard)
        {
            if (!CreditCardNumbersAreEqual(oldCreditCard.Number, newCreditCard.Number) && CreditCardNumberAlreadyExistsInUser(newCreditCard))
            {
                throw new ExceptionCreditCardNumberAlreadyExistsInUser("The credit card number already exists in user");
            }
            return newCreditCard.CreditCardDataIsValid();
        }

        private void UpdateCreditCardData(CreditCard oldCreditCard, CreditCard newCreditCard)
        {
            using (var dbContext = new DataManagerContext())
            {
                var creditCardToModify = dbContext.CreditCards
                    .FirstOrDefault(creditCard => creditCard.Id == oldCreditCard.Id);
                var newCategory = dbContext.Categories
                    .FirstOrDefault(category => category.Id == newCreditCard.Category.Id);
                creditCardToModify.Category = newCategory;
                creditCardToModify.Number = newCreditCard.Number;
                creditCardToModify.Notes = newCreditCard.Notes;
                creditCardToModify.ExpirationDate = newCreditCard.ExpirationDate;
                creditCardToModify.Code = newCreditCard.Code;
                creditCardToModify.Name = newCreditCard.Name;
                creditCardToModify.Type = newCreditCard.Type;
                dbContext.Entry(creditCardToModify).State = EntityState.Modified;
                dbContext.Entry(newCategory).State = EntityState.Modified;
                dbContext.SaveChanges();
            }
        }

        private bool CreditCardNumbersAreEqual(string oldCreditCardNumber, string newCreditCardNumber)
        {
            return oldCreditCardNumber == newCreditCardNumber;
        }

        public void RemoveCreditCard(CreditCard aCreditCard)
        {
            if (!CreditCardNumberAlreadyExistsInCategory(aCreditCard.Number))
            {
                throw new ExceptionCreditCardDoesNotExist($"The credit card {aCreditCard.Number} does not exist in this category");
            }
            RemoveCreditCardFromCollection(aCreditCard);
            //User.RemoveCreditCardFromDataBreaches(aCreditCard);
        }

        private void RemoveCreditCardFromCollection(CreditCard aCreditCard)
        {
            using (var dbContext = new DataManagerContext())
            {
                dbContext.CreditCards.Attach(aCreditCard);
                dbContext.CreditCards.Remove(aCreditCard);
                dbContext.SaveChanges();
            }
        }

        public bool CreditCardNumberAlreadyExistsInCategory(string aCreditCardNumber)
        {
            using (var dbContext = new DataManagerContext())
            {
                var creditCards = dbContext.CreditCards.Where(creditCard => creditCard.Category.Id == Id).ToList();
                return creditCards.Exists(creditCard => creditCard.Number == aCreditCardNumber);
            }
        }

        public CreditCard CreditCardInCategoryThatAppearedInDataBreaches(string aCreditCardNumber)
        {
            if (CreditCardNumberAlreadyExistsInCategory(aCreditCardNumber))
            {
                using (var dbContext = new DataManagerContext())
                {
                    var creditCardOfUser = dbContext.CreditCards
                        .Include(creditCard => creditCard.Category)
                        .FirstOrDefault(creditCard => creditCard.Number == aCreditCardNumber && creditCard.Category.Id == Id);
                    return creditCardOfUser;
                }
            }
            return null;
        }

        public bool AddUserPasswordPair(UserPasswordPair aUserPasswordPair)
        {
            bool userPasswordPairAdded = false;
            if (UserPasswordPairIsValid(aUserPasswordPair))
            {
                AddUserPasswordPairToCollection(aUserPasswordPair);
                userPasswordPairAdded = true;
            }
            return userPasswordPairAdded;
        }

        private bool UserPasswordPairIsValid(UserPasswordPair aUserPasswordPair)
        {
            if (UserPasswordPairAlreadyExistsInUser(aUserPasswordPair))
            {
                throw new ExceptionExistingUserPasswordPair("The userPassword pair already exists in user");
            }
            return aUserPasswordPair.UserPasswordPairDataIsValid();
        }

        private bool UserPasswordPairAlreadyExistsInUser(UserPasswordPair aUserPasswordPair)
        {
            using (var dbContext = new DataManagerContext())
            {
                var userSelected = dbContext.Users.FirstOrDefault(user => user.Username == aUserPasswordPair.Category.User.Username);
                return userSelected.UserPasswordPairExists(aUserPasswordPair);
            }
        }

        protected void AddUserPasswordPairToCollection(UserPasswordPair aUserPasswordPair)
        {
            using (var dbContext = new DataManagerContext())
            {
                dbContext.Categories.Attach(aUserPasswordPair.Category);
                dbContext.UserPasswordPairs.Add(aUserPasswordPair);
                dbContext.SaveChanges();
            }
        }

        public bool UserPasswordPairAlredyExistsInCategory(UserPasswordPair aUserPasswordPair)
        {
            using (var dbContext = new DataManagerContext())
            {
                var passwords = dbContext.UserPasswordPairs.Where(userPasswordPair => userPasswordPair.Category.Id == Id).ToList();
                return passwords.Exists(password => password.Id == aUserPasswordPair.Id);
            }
        }

        public int GetUserPasswordPairsOfASpecificColorQuantity(PasswordStrengthType strengthType)
        {
            using (var dbContext = new DataManagerContext())
            {
                int count = dbContext.UserPasswordPairs.Include(userPasswordPair => userPasswordPair.Category).Where(userPasswordPair => userPasswordPair.Category.Id == Id && userPasswordPair.PasswordStrength == strengthType).Count();
                return count;
            }
        }

        public bool ModifyUserPasswordPair(UserPasswordPair oldUserPasswordPair, UserPasswordPair newUserPasswordPair)
        {
            bool modified = false;
            if (newUserPasswordPair.UserPasswordPairDataIsValid())
            {
                if (!NewUserPasswordPairAlreadyExistsInUser(oldUserPasswordPair, newUserPasswordPair))
                {
                    ChangeUserPasswordPairData(oldUserPasswordPair, newUserPasswordPair);
                    modified = true;
                }
            }
            return modified;
        }

        private bool NewUserPasswordPairAlreadyExistsInUser(UserPasswordPair oldUserPasswordPair, UserPasswordPair newUserPasswordPair)
        {
            if (!UsernamesAreEqual(oldUserPasswordPair.Username, newUserPasswordPair.Username) || !SitesAreEqual(oldUserPasswordPair.Site, newUserPasswordPair.Site))
            {
                if (UserPasswordPairAlreadyExistsInUser(newUserPasswordPair))
                {
                    throw new ExceptionExistingUserPasswordPair("The userPassword pair already exists in user");
                }
            }
            return false;
        }

        private bool UsernamesAreEqual(string aUsername, string otherUsername)
        {
            return aUsername == otherUsername;
        }
        private bool SitesAreEqual(string aSite, string otherSite)
        {
            return aSite == otherSite;
        }

        private void ChangeUserPasswordPairData(UserPasswordPair oldUserPasswordPair, UserPasswordPair newUserPasswordPair)
        {
            bool passwordsAreEqual = PasswordsAreEqual(oldUserPasswordPair.Password, newUserPasswordPair.Password);
            if (passwordsAreEqual)
            {
                UpdateAllPropertiesOfUserPasswordPairExceptForPassword(oldUserPasswordPair, newUserPasswordPair);
            }
            else
            {
                UpdateAllPropertiesOfUserPasswordPair(oldUserPasswordPair, newUserPasswordPair);
            }
        }

        private static void UpdateAllPropertiesOfUserPasswordPair(UserPasswordPair oldUserPasswordPair, UserPasswordPair newUserPasswordPair)
        {
            UpdateAllPropertiesOfUserPasswordPairExceptForPassword(oldUserPasswordPair, newUserPasswordPair);
            using (var dbContext = new DataManagerContext())
            {
                var passwordToModify = dbContext.UserPasswordPairs.Include(userPasswordPair => userPasswordPair.Category).Include(userPasswordPair => userPasswordPair.Category.User).FirstOrDefault(userPasswordPair => userPasswordPair.Id == oldUserPasswordPair.Id);
                passwordToModify.Password = newUserPasswordPair.Password;
                dbContext.Entry(passwordToModify).State = EntityState.Modified;
                dbContext.SaveChanges();
            }
        }

        private static void UpdateAllPropertiesOfUserPasswordPairExceptForPassword(UserPasswordPair oldUserPasswordPair, UserPasswordPair newUserPasswordPair)
        {
            using (var dbContext = new DataManagerContext())
            {
                var passwordToModify = dbContext.UserPasswordPairs.FirstOrDefault(userPasswordPair => userPasswordPair.Id == oldUserPasswordPair.Id);
                var newCategory = dbContext.Categories.FirstOrDefault(category => category.Id == newUserPasswordPair.Category.Id);
                passwordToModify.Category = newCategory;
                passwordToModify.Site = newUserPasswordPair.Site;
                passwordToModify.Notes = newUserPasswordPair.Notes;
                passwordToModify.Username = newUserPasswordPair.Username;
                dbContext.Entry(passwordToModify).State = EntityState.Modified;
                dbContext.Entry(newCategory).State = EntityState.Modified;
                dbContext.SaveChanges();
            }
        }

        public static bool PasswordsAreEqual(string aPassword, string otherPassword)
        {
            return aPassword == otherPassword;
        }

        public bool RemoveUserPasswordPair(UserPasswordPair aUserPasswordPair)
        {
            if (!RemoveUserPasswordPairFromCollection(aUserPasswordPair))
            {
                throw new ExceptionUserPasswordPairDoesNotExist($"The user-password pair ({aUserPasswordPair.Username}-{aUserPasswordPair.Site}) does not exist in {name}");
            }
            //User.RemoveUserPasswordPairFromDataBreaches(aUserPasswordPair);
            return true;
        }

        protected bool RemoveUserPasswordPairFromCollection(UserPasswordPair aUserPasswordPair)
        {
            using (var dbContext = new DataManagerContext())
            {
                dbContext.UserPasswordPairs.Attach(aUserPasswordPair);
                dbContext.UserPasswordPairs.Remove(aUserPasswordPair);
                dbContext.SaveChanges();
                return true;
            }
        }

        public UserPasswordPair[] ListOfUserPasswordPairInCategoryWhosePasswordAppearedInDataBreaches(string aPassword)
        {
            using (var dbContext = new DataManagerContext())
            {
                return dbContext.UserPasswordPairs
                    .Where(userPasswordPair => userPasswordPair.Category.Id == Id && userPasswordPair.Password == aPassword)
                    .Include(userPasswordPair => userPasswordPair.Category)
                    .ToArray();
            }
        }
    }
}