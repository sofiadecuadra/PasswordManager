using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace DataManagerDomain
{
    public class Category 
    {
        public int Id { get; set; }
        public int RedUserPasswordPairsQuantity { get; set; }
        public int OrangeUserPasswordPairsQuantity { get; set; }
        public int YellowUserPasswordPairsQuantity { get; set; }
        public int LightGreenUserPasswordPairsQuantity { get; set; }
        public int DarkGreenUserPasswordPairsQuantity { get; set; }
        public User User { get; set; }
        private string name { get; set; }
        public string Name
        {
            get { return name; }
            set { name = value.Trim().ToLower(); }
        }
        public List<UserPasswordPair> UserPasswordPairs;
        private List<CreditCard> creditCards;

        public Category()
        {
            UserPasswordPairs = new List<UserPasswordPair>();
            creditCards = new List<CreditCard>();
        }

        public CreditCard[] GetCreditCards()
        {
            return creditCards.ToArray();
        }

        public User GetUser()
        {
            return User;
        }

        protected void AddUserPasswordPairToCollection(UserPasswordPair aUserPasswordPair)
        {
            using (var dbContext = new DataManagerContext())
            {
                dbContext.UserPasswordPairs.Add(aUserPasswordPair);
                dbContext.SaveChanges();
            }
        }

        protected bool RemoveUserPasswordPairFromCollection(UserPasswordPair aUserPasswordPair)
        {
            using (var dbContext = new DataManagerContext())
            {
                dbContext.UserPasswordPairs.Remove(aUserPasswordPair);
                dbContext.SaveChanges();
                return true;
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

        public UserPasswordPair[] GetUserPasswordsPairs()
        {
            using (var dbContext = new DataManagerContext())
            {
                return dbContext.UserPasswordPairs.Where(userPasswordPair => userPasswordPair.Category.Id == Id).ToArray();
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
            if (CreditCardNumberAlreadyExistsInUser(aCreditCard.Number))
            {
                throw new ExceptionCreditCardNumberAlreadyExistsInUser("The credit card number already exists in user");
            }
            return aCreditCard.CreditCardDataIsValid();
        }

        private bool CreditCardNumberAlreadyExistsInUser(string creditCardNumber)
        {
            return User.CreditCardNumberExists(creditCardNumber);
        }

        protected void AddCreditCardToCollection(CreditCard aCreditCard)
        {
            using (var dbContext = new DataManagerContext())
            {
                dbContext.CreditCards.Add(aCreditCard);
                dbContext.SaveChanges();
            }
        }

        public bool ModifyCreditCard(CreditCard oldCreditCard, CreditCard newCreditCard)
        {
            if (ModifiedCreditCardIsValid(oldCreditCard, newCreditCard))
            {            
                RemoveCreditCard(oldCreditCard);
                if (HasSameCategory(oldCreditCard.Category, newCreditCard.Category))
                {
                    AddCreditCardToCollection(newCreditCard);
                }
                else
                {
                    newCreditCard.Category.AddCreditCardToCollection(newCreditCard);
                }
            }
            return true;
        }

        private bool ModifiedCreditCardIsValid(CreditCard oldCreditCard, CreditCard newCreditCard)
        {
            if (!CreditCardNumbersAreEqual(oldCreditCard.Number, newCreditCard.Number) && CreditCardNumberAlreadyExistsInUser(newCreditCard.Number))
            {
                throw new ExceptionCreditCardNumberAlreadyExistsInUser("The credit card number already exists in user");
            }
            return newCreditCard.CreditCardDataIsValid();
        }

        private bool CreditCardNumbersAreEqual(string oldCreditCardNumber, string newCreditCardNumber)
        {
            return oldCreditCardNumber == newCreditCardNumber;
        }

        private bool RemoveCreditCardFromCollection(CreditCard aCreditCard)
        {
            using (var dbContext = new DataManagerContext())
            {
                dbContext.CreditCards.Remove(aCreditCard);
                dbContext.SaveChanges();
                return true;
            }
        }

        public bool RemoveCreditCard(CreditCard aCreditCard)
        {
            if (!RemoveCreditCardFromCollection(aCreditCard))
            {
                throw new ExceptionCreditCardDoesNotExist($"The credit card {aCreditCard.Number} does not exist in this category");
            }
            User.RemoveCreditCardFromDataBreaches(aCreditCard);
            return true;
        }

        public bool CreditCardNumberAlreadyExistsInCategory(string aCreditCardNumber)
        {
            using (var dbContext = new DataManagerContext())
            {
                var creditCards = dbContext.CreditCards.Where(creditCard => creditCard.Category.Id == Id).ToList();
                return creditCards.Exists(creditCard => creditCard.Number == aCreditCardNumber);
            }
        }

        public CreditCard ReturnCreditCardInCategoryThatAppearedInDataBreaches(string aCreditCardNumber)
        {
            if (CreditCardNumberAlreadyExistsInCategory(aCreditCardNumber))
            {
                return creditCards.Find(creditCard => creditCard.Number == aCreditCardNumber);
            }
            return null;
        }

        public bool AddUserPasswordPair(UserPasswordPair aUserPasswordPair)
        {
            bool userPasswordPairAdded = false;
            if (UserPasswordPairIsValid(aUserPasswordPair))
            {
                AddUserPasswordPairToCollection(aUserPasswordPair);
                //AddUserPasswordPairToStrengthGroup(aUserPasswordPair);
                userPasswordPairAdded = true;
            }
            return userPasswordPairAdded;
        }

        private bool UserPasswordPairIsValid(UserPasswordPair aUserPasswordPair)
        {
            if (UserPasswordPairAlredyExistsInUser(aUserPasswordPair))
            {
                throw new ExceptionExistingUserPasswordPair("The userPassword pair already exists in user");
            }
            return aUserPasswordPair.UserPasswordPairDataIsValid();
        }

        private bool UserPasswordPairAlredyExistsInUser(UserPasswordPair aUserPasswordPair)
        {
            return User.UserPasswordPairExists(aUserPasswordPair);
        }

        //private void AddUserPasswordPairToStrengthGroup(UserPasswordPair aUserPasswordPair)
        //{
        //    if (aUserPasswordPair.IsARedPassword())
        //    {
        //        AddToRedGroup(aUserPasswordPair);
        //    }
        //    if (aUserPasswordPair.IsAnOrangePassword())
        //    {
        //        AddToOrangeGroup(aUserPasswordPair);
        //    }
        //    if (aUserPasswordPair.IsAYellowPassword())
        //    {
        //        AddToYellowGroup(aUserPasswordPair);
        //    }
        //    if (aUserPasswordPair.IsALightGreenPassword())
        //    {
        //        AddToLightGreenGroup(aUserPasswordPair);
        //    }
        //    if (aUserPasswordPair.IsADarkGreenPassword())
        //    {
        //        AddToDarkGreenGroup(aUserPasswordPair);
        //    }
        //}

        //private void AddToRedGroup(UserPasswordPair aUserPasswordPair)
        //{
        //    aUserPasswordPair.Category.RedUserPasswordPairsQuantity++;
        //    User.AddRedUserPasswordPair(aUserPasswordPair);
        //}

        //private void AddToOrangeGroup(UserPasswordPair aUserPasswordPair)
        //{
        //    aUserPasswordPair.Category.OrangeUserPasswordPairsQuantity++;
        //    User.AddOrangeUserPasswordPair(aUserPasswordPair);
        //}

        //private void AddToYellowGroup(UserPasswordPair aUserPasswordPair)
        //{
        //    aUserPasswordPair.Category.YellowUserPasswordPairsQuantity++;
        //    User.AddYellowUserPasswordPair(aUserPasswordPair);
        //}

        //private void AddToLightGreenGroup(UserPasswordPair aUserPasswordPair)
        //{
        //    aUserPasswordPair.Category.LightGreenUserPasswordPairsQuantity++;
        //    User.AddLightGreenUserPasswordPair(aUserPasswordPair);
        //}

        //private void AddToDarkGreenGroup(UserPasswordPair aUserPasswordPair)
        //{
        //    aUserPasswordPair.Category.DarkGreenUserPasswordPairsQuantity++;
        //    User.AddDarkGreenUserPasswordPair(aUserPasswordPair);
        //}

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
            if(!UsernamesAreEqual(oldUserPasswordPair.Username, newUserPasswordPair.Username) || !SitesAreEqual(oldUserPasswordPair.Site, newUserPasswordPair.Site))
            {
                if (UserPasswordPairAlredyExistsInUser(newUserPasswordPair))
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
            bool hasSameCategory = HasSameCategory(oldUserPasswordPair.Category, newUserPasswordPair.Category);
            bool passwordsAreEqual = PasswordsAreEqual(oldUserPasswordPair.Password, newUserPasswordPair.Password);
            if (hasSameCategory && !passwordsAreEqual)
            {
                UpdateAllPropertiesExceptCategory(oldUserPasswordPair, newUserPasswordPair);
            }
            if (hasSameCategory && passwordsAreEqual)
            {
                UpdateUsernameSiteAndNotes(oldUserPasswordPair, newUserPasswordPair);
            }
            if (!hasSameCategory && passwordsAreEqual)
            {
                UpdateAllPropertiesExceptPassword(oldUserPasswordPair, newUserPasswordPair);
            }
            if (!hasSameCategory && !passwordsAreEqual)
            {
                UpdateAllProperties(oldUserPasswordPair, newUserPasswordPair);
            }
        }

        public void UpdateAllPropertiesExceptCategory(UserPasswordPair oldUserPasswordPair, UserPasswordPair newUserPasswordPair)
        {
            //DeleteUserPasswordPairFromStrengthGroup(oldUserPasswordPair);
            UpdateUsernameSiteAndNotes(oldUserPasswordPair, newUserPasswordPair);
            oldUserPasswordPair.Password = newUserPasswordPair.Password;
            //AddUserPasswordPairToStrengthGroup(oldUserPasswordPair);
        }

        public void UpdateAllPropertiesExceptPassword(UserPasswordPair oldUserPasswordPair, UserPasswordPair newUserPasswordPair)
        {
            //DeleteUserPasswordPairFromStrengthGroup(oldUserPasswordPair);
            UpdateUsernameSiteAndNotes(oldUserPasswordPair, newUserPasswordPair);
            RemoveUserPasswordPairFromCollection(oldUserPasswordPair);
            oldUserPasswordPair.Category = newUserPasswordPair.Category;
            oldUserPasswordPair.Category.AddUserPasswordPairToCollection(oldUserPasswordPair);
            //AddUserPasswordPairToStrengthGroup(oldUserPasswordPair);
        }

        public void UpdateAllProperties(UserPasswordPair oldUserPasswordPair, UserPasswordPair newUserPasswordPair)
        {
            //DeleteUserPasswordPairFromStrengthGroup(oldUserPasswordPair);
            UpdateUsernameSiteAndNotes(oldUserPasswordPair, newUserPasswordPair);
            oldUserPasswordPair.Password = newUserPasswordPair.Password;
            RemoveUserPasswordPairFromCollection(oldUserPasswordPair);
            oldUserPasswordPair.Category = newUserPasswordPair.Category;
            oldUserPasswordPair.Category.AddUserPasswordPairToCollection(oldUserPasswordPair);
            //AddUserPasswordPairToStrengthGroup(oldUserPasswordPair);
        }

        public bool HasSameCategory(Category aCategory, Category otherCategory)
        {
            return aCategory.Name == otherCategory.Name;
        }

        public static bool PasswordsAreEqual(string aPassword, string otherPassword)
        {
            return aPassword == otherPassword;
        }

        //private void DeleteUserPasswordPairFromStrengthGroup(UserPasswordPair aUserPasswordPair)
        //{
        //    if (aUserPasswordPair.IsARedPassword())
        //    {
        //        RemoveFromRedGroup(aUserPasswordPair);
        //    }
        //    if (aUserPasswordPair.IsAnOrangePassword())
        //    {
        //        RemoveFromOrangeGroup(aUserPasswordPair);
        //    }
        //    if (aUserPasswordPair.IsAYellowPassword())
        //    {
        //        RemoveFromYellowGroup(aUserPasswordPair);
        //    }
        //    if (aUserPasswordPair.IsALightGreenPassword())
        //    {
        //        RemoveFromLightGreenGroup(aUserPasswordPair);
        //    }
        //    if (aUserPasswordPair.IsADarkGreenPassword())
        //    {
        //        RemoveFromDarkGreenGroup(aUserPasswordPair);
        //    }
        //}

        //private void RemoveFromRedGroup(UserPasswordPair aUserPasswordPair)
        //{
        //    RedUserPasswordPairsQuantity--;
        //    User.DeleteRedUserPasswordPair(aUserPasswordPair);
        //}

        //private void RemoveFromOrangeGroup(UserPasswordPair aUserPasswordPair)
        //{
        //    OrangeUserPasswordPairsQuantity--;
        //    User.DeleteOrangeUserPasswordPair(aUserPasswordPair);
        //}

        //private void RemoveFromYellowGroup(UserPasswordPair aUserPasswordPair)
        //{
        //    YellowUserPasswordPairsQuantity--;
        //    User.DeleteYellowUserPasswordPair(aUserPasswordPair);
        //}

        //private void RemoveFromLightGreenGroup(UserPasswordPair aUserPasswordPair)
        //{
        //    LightGreenUserPasswordPairsQuantity--;
        //    User.DeleteLightGreenUserPasswordPair(aUserPasswordPair);
        //}

        //private void RemoveFromDarkGreenGroup(UserPasswordPair aUserPasswordPair)
        //{
        //    DarkGreenUserPasswordPairsQuantity--;
        //    User.DeleteDarkGreenUserPasswordPair(aUserPasswordPair);
        //}

        private void UpdateUsernameSiteAndNotes(UserPasswordPair oldUserPasswordPair, UserPasswordPair newUserPasswordPair)
        {
            if (!HasSameSiteAndUsername(oldUserPasswordPair, newUserPasswordPair))
            {
                RemoveUserPasswordPairFromCollection(oldUserPasswordPair);
                oldUserPasswordPair.Username = newUserPasswordPair.Username;
                oldUserPasswordPair.Site = newUserPasswordPair.Site;
                oldUserPasswordPair.Category.AddUserPasswordPairToCollection(oldUserPasswordPair);
            }
            oldUserPasswordPair.Notes = newUserPasswordPair.Notes;
        }

        public static bool HasSameSiteAndUsername(UserPasswordPair oldUserPasswordPair, UserPasswordPair newUserPasswordPair)
        {
            return oldUserPasswordPair.Username == newUserPasswordPair.Username && oldUserPasswordPair.Site == newUserPasswordPair.Site;
        }

        public bool RemoveUserPasswordPair(UserPasswordPair aUserPasswordPair)
        {
            if (!RemoveUserPasswordPairFromCollection(aUserPasswordPair))
            {
                throw new ExceptionUserPasswordPairDoesNotExist($"The user-password pair ({aUserPasswordPair.Username}-{aUserPasswordPair.Site}) does not exist in {this.Name}");
            }
            //DeleteUserPasswordPairFromStrengthGroup(aUserPasswordPair);
            User.RemoveUserPasswordPairFromDataBreaches(aUserPasswordPair);
            return true;
        }

        public List <UserPasswordPair> ReturnListOfUserPasswordPairInCategoryWhosePasswordAppearedInDataBreaches (string aPassword)
        {
            List<UserPasswordPair> pairsList = new List<UserPasswordPair>();
            foreach (UserPasswordPair userPasswordPair in UserPasswordPairs)
            {
                if (PasswordsAreEqual(userPasswordPair.Password, aPassword))
                {
                    pairsList.Add(userPasswordPair);
                }
            }
            return pairsList;
        }

        internal UserPasswordPair FindUserPasswordPair(UserPasswordPair aUserPasswordPair)
        {
            return UserPasswordPairs.First(userPasswordPair => userPasswordPair.Id == aUserPasswordPair.Id);
        }
    }
}
