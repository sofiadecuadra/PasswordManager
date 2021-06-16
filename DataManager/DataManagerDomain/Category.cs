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

        public override string ToString()
        {
            return Name;
        }

        public CreditCard[] GetCreditCards()
        {
            using (var dbContext = new DataManagerContext())
            {
                var creditCards = dbContext.CreditCards
                    .Where(creditCard => creditCard.Category.Id == Id);
                return creditCards.ToArray();
            }
        }

        public void AddCreditCard(CreditCard aCreditCard)
        {
            if (CreditCardIsValid(aCreditCard))
            {
                AddCreditCardToCollection(aCreditCard);
            }
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

        public void ModifyCreditCard(CreditCard oldCreditCard, CreditCard newCreditCard)
        {
            if (ModifiedCreditCardIsValid(oldCreditCard, newCreditCard))
            {
                UpdateCreditCardData(oldCreditCard, newCreditCard);
            }
        }

        private bool ModifiedCreditCardIsValid(CreditCard oldCreditCard, CreditCard newCreditCard)
        {
            if (!CreditCardNumbersAreEqual(oldCreditCard.Number, newCreditCard.Number) && CreditCardNumberAlreadyExistsInUser(newCreditCard))
            {
                throw new ExceptionCreditCardNumberAlreadyExistsInUser("The credit card number already exists in user");
            }
            return newCreditCard.CreditCardDataIsValid();
        }

        private bool CreditCardNumbersAreEqual(string oldCreditCardNumber, string newCreditCardNumber)
        {
            return oldCreditCardNumber == newCreditCardNumber;
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

        public void RemoveCreditCard(CreditCard aCreditCard)
        {
            if (!CreditCardNumberAlreadyExistsInCategory(aCreditCard.Number))
            {
                throw new ExceptionCreditCardDoesNotExist($"The credit card {aCreditCard.Number} does not exist in this category");
            }
            RemoveCreditCardFromCollection(aCreditCard);
        }

        public bool CreditCardNumberAlreadyExistsInCategory(string aCreditCardNumber)
        {
            using (var dbContext = new DataManagerContext())
            {
                var creditCards = dbContext.CreditCards
                    .Where(creditCard => creditCard.Category.Id == Id).ToList();
                return creditCards.Exists(creditCard => creditCard.Number == aCreditCardNumber);
            }
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

        public UserPasswordPair[] GetUserPasswordsPairs()
        {
            using (var dbContext = new DataManagerContext())
            {
                var passwords = dbContext.UserPasswordPairs
                    .Where(userPasswordPair => userPasswordPair.Category.Id == Id)
                    .Include(password => password.Category)
                    .Include(password => password.Category.User);
                return passwords.ToArray();
            }
        }

        public void AddUserPasswordPair(UserPasswordPair aUserPasswordPair)
        {
            if (UserPasswordPairIsValid(aUserPasswordPair))
            {
                AddUserPasswordPairToCollection(aUserPasswordPair);
            }
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
                var userSelected = dbContext.Users
                    .FirstOrDefault(user => user.Username == aUserPasswordPair.Category.User.Username);
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
                var passwords = dbContext.UserPasswordPairs
                    .Where(userPasswordPair => userPasswordPair.Category.Id == Id)
                    .ToList();
                return passwords.Exists(password => password.Id == aUserPasswordPair.Id);
            }
        }

        public int GetUserPasswordPairsOfASpecificColorQuantity(PasswordStrengthType strengthType)
        {
            using (var dbContext = new DataManagerContext())
            {
                int count = dbContext.UserPasswordPairs
                    .Include(userPasswordPair => userPasswordPair.Category)
                    .Where(userPasswordPair => userPasswordPair.Category.Id == Id && userPasswordPair.PasswordStrength == strengthType)
                    .Count();
                return count;
            }
        }

        public void ModifyUserPasswordPair(UserPasswordPair oldUserPasswordPair, UserPasswordPair newUserPasswordPair)
        {
            if (newUserPasswordPair.UserPasswordPairDataIsValid())
            {
                if (!NewUserPasswordPairAlreadyExistsInUser(oldUserPasswordPair, newUserPasswordPair))
                {
                    ChangeUserPasswordPairData(oldUserPasswordPair, newUserPasswordPair);
                }
            }
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

        public static bool PasswordsAreEqual(string aPassword, string otherPassword)
        {
            return aPassword == otherPassword;
        }

        private static void UpdateAllPropertiesOfUserPasswordPair(UserPasswordPair oldUserPasswordPair, UserPasswordPair newUserPasswordPair)
        {
            UpdateAllPropertiesOfUserPasswordPairExceptForPassword(oldUserPasswordPair, newUserPasswordPair);
            using (var dbContext = new DataManagerContext())
            {
                var passwordToModify = dbContext.UserPasswordPairs
                    .Include(userPasswordPair => userPasswordPair.Category)
                    .Include(userPasswordPair => userPasswordPair.Category.User)
                    .FirstOrDefault(userPasswordPair => userPasswordPair.Id == oldUserPasswordPair.Id);
                passwordToModify.Password = newUserPasswordPair.Password;
                dbContext.Entry(passwordToModify).State = EntityState.Modified;
                dbContext.SaveChanges();
            }
        }

        private static void UpdateAllPropertiesOfUserPasswordPairExceptForPassword(UserPasswordPair oldUserPasswordPair, UserPasswordPair newUserPasswordPair)
        {
            using (var dbContext = new DataManagerContext())
            {
                var passwordToModify = dbContext.UserPasswordPairs
                    .FirstOrDefault(userPasswordPair => userPasswordPair.Id == oldUserPasswordPair.Id);
                var newCategory = dbContext.Categories.
                    FirstOrDefault(category => category.Id == newUserPasswordPair.Category.Id);
                passwordToModify.Category = newCategory;
                passwordToModify.Site = newUserPasswordPair.Site;
                passwordToModify.Notes = newUserPasswordPair.Notes;
                passwordToModify.Username = newUserPasswordPair.Username;
                dbContext.Entry(passwordToModify).State = EntityState.Modified;
                dbContext.Entry(newCategory).State = EntityState.Modified;
                dbContext.SaveChanges();
            }
        }

        public void RemoveUserPasswordPair(UserPasswordPair aUserPasswordPair)
        {
            if (!UserPasswordPairAlredyExistsInCategory(aUserPasswordPair))
            {
                throw new ExceptionUserPasswordPairDoesNotExist($"The user-password pair ({aUserPasswordPair.Username}-{aUserPasswordPair.Site}) does not exist in {name}");
            }
            RemoveUserPasswordPairFromCollection(aUserPasswordPair);
        }

        protected void RemoveUserPasswordPairFromCollection(UserPasswordPair aUserPasswordPair)
        {
            using (var dbContext = new DataManagerContext())
            {
                dbContext.UserPasswordPairs.Attach(aUserPasswordPair);
                dbContext.UserPasswordPairs.Remove(aUserPasswordPair);
                dbContext.SaveChanges();
            }
        }

        public UserPasswordPair[] GetUserPasswordPairInCategoryWhosePasswordAppearedInDataBreaches(string aPassword)
        {
            using (var dbContext = new DataManagerContext())
            {
                var categorySelected = dbContext.Categories
                    .Include(category => category.User)
                    .FirstOrDefault(category => category.Id == Id);
                return dbContext.UserPasswordPairs
                    .Include(userPasswordPair => userPasswordPair.Category)
                    .ToList()
                    .Where(userPasswordPair => userPasswordPair.Category.Id == Id && Encrypter.Decrypt(userPasswordPair.EncryptedPassword, categorySelected.User.PrivateKey) == aPassword)
                    .ToArray();
            }
        }
    }
}