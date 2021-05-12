using System;
using System.Collections.Generic;
using System.Linq;

namespace GestorPasswordsDominio
{
    public class NormalCategory : Category
    {
        private Dictionary<string, CreditCard> creditCards;
        public int RedUserPasswordPairsQuantity { get; set; }
        public int OrangeUserPasswordPairsQuantity { get; set; }
        public int YellowUserPasswordPairsQuantity { get; set; }
        public int LightGreenUserPasswordPairsQuantity { get; set; }
        public int DarkGreenUserPasswordPairsQuantity { get; set; }

        public NormalCategory()
        {
            creditCards = new Dictionary<string, CreditCard>();
        }

        public CreditCard[] GetCreditCards()
        {
            return creditCards.Values.ToArray();
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
            creditCards.Add(aCreditCard.Number, aCreditCard);
        }

        public bool ModifyCreditCard(CreditCard oldCreditCard, CreditCard newCreditCard)
        {
            if (ModifiedCreditCardIsValid(oldCreditCard, newCreditCard))
            {            
                RemoveCreditCard(oldCreditCard.Number);
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

        public bool RemoveCreditCard(string number)
        {
            if (!CreditCardNumberAlreadyExistsInCategory(number))
            {
                throw new ExceptionCreditCardDoesNotExist($"The credit card {number} does not exist in this category");
            }

            creditCards.Remove(number);
            return true;
        }

        public bool CreditCardNumberAlreadyExistsInCategory(string creditCardNumber)
        {
            return creditCards.ContainsKey(creditCardNumber);
        }

        public CreditCard ReturnCreditCardInCategoryThatAppearedInDataBreaches(string creditCardNumber)
        {
            if (CreditCardNumberAlreadyExistsInCategory(creditCardNumber))
            {
                return creditCards[creditCardNumber];
            }
            return null;
        }

        public override bool AddUserPasswordPair(UserPasswordPair aUserPasswordPair)
        {
            bool userPasswordPairAdded = false;
            if (UserPasswordPairIsValid(aUserPasswordPair))
            {
                AddUserPasswordPairToCollection(aUserPasswordPair);
                AddUserPasswordPairToStrengthGroup(aUserPasswordPair);
                userPasswordPairAdded = true;
            }
            return userPasswordPairAdded;
        }

        private bool UserPasswordPairIsValid(UserPasswordPair aUserPasswordPair)
        {
            if (UserPasswordPairAlredyExistsInUser(aUserPasswordPair.Username, aUserPasswordPair.Site))
            {
                throw new ExceptionExistingUserPasswordPair("The userPassword pair already exists in user");
            }
            return aUserPasswordPair.UserPasswordPairDataIsValid();
        }

        private bool UserPasswordPairAlredyExistsInUser(string username, string site)
        {
            return User.UserPasswordPairExists(username, site);
        }

        private void AddUserPasswordPairToStrengthGroup(UserPasswordPair aUserPasswordPair)
        {
            if (aUserPasswordPair.IsARedPassword())
            {
                AddToRedGroup(aUserPasswordPair);
            }
            if (aUserPasswordPair.IsAnOrangePassword())
            {
                AddToOrangeGroup(aUserPasswordPair);
            }
            if (aUserPasswordPair.IsAYellowPassword())
            {
                AddToYellowGroup(aUserPasswordPair);
            }
            if (aUserPasswordPair.IsALightGreenPassword())
            {
                AddToLightGreenGroup(aUserPasswordPair);
            }
            if (aUserPasswordPair.IsADarkGreenPassword())
            {
                AddToDarkGreenGroup(aUserPasswordPair);
            }
        }

        private void AddToRedGroup(UserPasswordPair aUserPasswordPair)
        {
            aUserPasswordPair.Category.RedUserPasswordPairsQuantity++;
            User.AddRedUserPasswordPair(aUserPasswordPair);
        }

        private void AddToOrangeGroup(UserPasswordPair aUserPasswordPair)
        {
            aUserPasswordPair.Category.OrangeUserPasswordPairsQuantity++;
            User.AddOrangeUserPasswordPair(aUserPasswordPair);
        }

        private void AddToYellowGroup(UserPasswordPair aUserPasswordPair)
        {
            aUserPasswordPair.Category.YellowUserPasswordPairsQuantity++;
            User.AddYellowUserPasswordPair(aUserPasswordPair);
        }

        private void AddToLightGreenGroup(UserPasswordPair aUserPasswordPair)
        {
            aUserPasswordPair.Category.LightGreenUserPasswordPairsQuantity++;
            User.AddLightGreenUserPasswordPair(aUserPasswordPair);
        }

        private void AddToDarkGreenGroup(UserPasswordPair aUserPasswordPair)
        {
            aUserPasswordPair.Category.DarkGreenUserPasswordPairsQuantity++;
            User.AddDarkGreenUserPasswordPair(aUserPasswordPair);
        }

        public bool ModifyUserPasswordPair(UserPasswordPair oldUserPasswordPair, UserPasswordPair newUserPasswordPair)
        {
            bool modified = false;
            if (newUserPasswordPair.UserPasswordPairDataIsValid())
            {
                ChangeUserPasswordPairData(oldUserPasswordPair, newUserPasswordPair);
                modified = true;
            }
            return modified;
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
            DeleteUserPasswordPairFromStrengthGroup(oldUserPasswordPair);
            UpdateUsernameSiteAndNotes(oldUserPasswordPair, newUserPasswordPair);
            oldUserPasswordPair.Password = newUserPasswordPair.Password;
            AddUserPasswordPairToStrengthGroup(oldUserPasswordPair);
        }

        public void UpdateAllPropertiesExceptPassword(UserPasswordPair oldUserPasswordPair, UserPasswordPair newUserPasswordPair)
        {
            DeleteUserPasswordPairFromStrengthGroup(oldUserPasswordPair);
            UpdateUsernameSiteAndNotes(oldUserPasswordPair, newUserPasswordPair);
            RemoveUserPasswordPairFromCollection(oldUserPasswordPair);
            oldUserPasswordPair.Category = newUserPasswordPair.Category;
            oldUserPasswordPair.Category.AddUserPasswordPairToCollection(oldUserPasswordPair);
            AddUserPasswordPairToStrengthGroup(oldUserPasswordPair);
        }

        public void UpdateAllProperties(UserPasswordPair oldUserPasswordPair, UserPasswordPair newUserPasswordPair)
        {
            DeleteUserPasswordPairFromStrengthGroup(oldUserPasswordPair);
            UpdateUsernameSiteAndNotes(oldUserPasswordPair, newUserPasswordPair);
            oldUserPasswordPair.Password = newUserPasswordPair.Password;
            RemoveUserPasswordPairFromCollection(oldUserPasswordPair);
            oldUserPasswordPair.Category = newUserPasswordPair.Category;
            oldUserPasswordPair.Category.AddUserPasswordPairToCollection(oldUserPasswordPair);
            AddUserPasswordPairToStrengthGroup(oldUserPasswordPair);
        }

        public bool HasSameCategory(NormalCategory aCategory, NormalCategory otherCategory)
        {
            return aCategory.Name == otherCategory.Name;
        }

        public bool PasswordsAreEqual(String aPassword, String otherPassword)
        {
            return aPassword == otherPassword;
        }

        private void DeleteUserPasswordPairFromStrengthGroup(UserPasswordPair aUserPasswordPair)
        {
            if (aUserPasswordPair.IsARedPassword())
            {
                RemoveFromRedGroup(aUserPasswordPair);
            }
            if (aUserPasswordPair.IsAnOrangePassword())
            {
                RemoveFromOrangeGroup(aUserPasswordPair);
            }
            if (aUserPasswordPair.IsAYellowPassword())
            {
                RemoveFromYellowGroup(aUserPasswordPair);
            }
            if (aUserPasswordPair.IsALightGreenPassword())
            {
                RemoveFromLightGreenGroup(aUserPasswordPair);
            }
            if (aUserPasswordPair.IsADarkGreenPassword())
            {
                RemoveFromDarkGreenGroup(aUserPasswordPair);
            }
        }

        private void RemoveFromRedGroup(UserPasswordPair aUserPasswordPair)
        {
            RedUserPasswordPairsQuantity--;
            User.DeleteRedUserPasswordPair(aUserPasswordPair);
        }

        private void RemoveFromOrangeGroup(UserPasswordPair aUserPasswordPair)
        {
            OrangeUserPasswordPairsQuantity--;
            User.DeleteOrangeUserPasswordPair(aUserPasswordPair);
        }

        private void RemoveFromYellowGroup(UserPasswordPair aUserPasswordPair)
        {
            YellowUserPasswordPairsQuantity--;
            User.DeleteYellowUserPasswordPair(aUserPasswordPair);
        }

        private void RemoveFromLightGreenGroup(UserPasswordPair aUserPasswordPair)
        {
            LightGreenUserPasswordPairsQuantity--;
            User.DeleteLightGreenUserPasswordPair(aUserPasswordPair);
        }

        private void RemoveFromDarkGreenGroup(UserPasswordPair aUserPasswordPair)
        {
            DarkGreenUserPasswordPairsQuantity--;
            User.DeleteDarkGreenUserPasswordPair(aUserPasswordPair);
        }

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

        public override bool RemoveUserPasswordPair(UserPasswordPair aUserPasswordPair)
        {
            if (!UserPasswordPairAlredyExistsInCategory(aUserPasswordPair.Username, aUserPasswordPair.Site))
            {
                throw new ExceptionUserPasswordPairDoesNotExist($"The user-password pair ({aUserPasswordPair.Username}-{aUserPasswordPair.Site}) does not exist in {this.Name}");
            }

            RemoveUserPasswordPairFromCollection(aUserPasswordPair);
            DeleteUserPasswordPairFromStrengthGroup(aUserPasswordPair);
            return true;
        }

        public List <UserPasswordPair> ReturnListOfUserPasswordPairInCategoryWhosePasswordAppearedInDataBreaches (string aPassword)
        {
            List<UserPasswordPair> pairsList = new List<UserPasswordPair>();
            foreach (UserPasswordPair userPasswordPair in userPasswordPairs.Values)
            {
                if (PasswordsAreEqual(userPasswordPair.Password, aPassword))
                {
                    pairsList.Add(userPasswordPair);
                }
            }
            return pairsList;
        }

        internal UserPasswordPair FindUserPasswordPair(string siteUsername, string site)
        {
            return userPasswordPairs[site + siteUsername];
        }
    }
}
