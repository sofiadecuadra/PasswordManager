using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace GestorPasswordsDominio
{
    public class Category
    {
        private String name;
        public User User { get; set; }
        private Dictionary<string, CreditCard> creditCardHashTable;
        public Dictionary<string, UserPasswordPair> userPasswordPairsHash;
        public int RedUserPasswordPairsQuantity { get; set; }
        public int OrangeUserPasswordPairsQuantity { get; set; }
        public int YellowUserPasswordPairsQuantity { get; set; }
        public int LightGreenUserPasswordPairsQuantity { get; set; }
        public int DarkGreenUserPasswordPairsQuantity { get; set; }

        public String Name
        {
            get { return name; }
            set { name = value.ToLower(); }
        }

        public Category()
        {
            this.creditCardHashTable = new Dictionary<string, CreditCard>();
            this.userPasswordPairsHash = new Dictionary<string, UserPasswordPair>();
        }

        public override string ToString()
        {
            return Name;
        }

        public CreditCard[] GetCreditCards()
        {
            return creditCardHashTable.Values.ToArray();
        }

        public UserPasswordPair[] GetUserPasswordsPairs()
        {
            return userPasswordPairsHash.Values.ToArray();
        }

        public bool AddCreditCard(CreditCard aCreditCard)
        {
            bool creditCardAdded = false;
            if (CreditCardIsValid(aCreditCard))
            {
                this.creditCardHashTable.Add(aCreditCard.Number, aCreditCard);
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

        public bool CreditCardNumberAlreadyExistsInCategory(string creditCardNumber)
        {
            return creditCardHashTable.ContainsKey(creditCardNumber);
        }

        public bool ModifyCreditCard(CreditCard oldCreditCard, CreditCard newCreditCard)
        {
            if (ModifiedCreditCardIsValid(oldCreditCard, newCreditCard))
            {            
                RemoveCreditCard(oldCreditCard.Number);
                if (HasSameCategory(oldCreditCard.Category, newCreditCard.Category))
                {
                    AddCreditCardToHashTable(newCreditCard);
                }
                else
                {
                    newCreditCard.Category.AddCreditCardToHashTable(newCreditCard);
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

        private void AddCreditCardToHashTable(CreditCard newCreditCard)
        {
            this.creditCardHashTable.Add(newCreditCard.Number, newCreditCard);
        }

        public CreditCard ReturnCreditCardInCategoryThatAppearedInDataBreaches(string creditCardNumber)
        {
            if(HasCreditCard(creditCardNumber))
            {
                return creditCardHashTable[creditCardNumber];
            }
            return null;
        }

        public bool HasCreditCard(string creditCardNumber)
        {
            return creditCardHashTable.ContainsKey(creditCardNumber);
        }

        public bool AddUserPasswordPair(UserPasswordPair aUserPasswordPair)
        {
            bool userPasswordPairAdded = false;
            if (UserPasswordPairIsValid(aUserPasswordPair))
            {
                AddUserPasswordPairToHashTable(aUserPasswordPair);
                AddUserPasswordPairToStrengthGroup(aUserPasswordPair);
                userPasswordPairAdded = true;
            }
            return userPasswordPairAdded;
        }

        private void AddUserPasswordPairToHashTable(UserPasswordPair aUserPasswordPair)
        {
            this.userPasswordPairsHash.Add(aUserPasswordPair.Site + aUserPasswordPair.Username, aUserPasswordPair);
        }

        private void AddUserPasswordPairToStrengthGroup(UserPasswordPair aUserPasswordPair)
        {
            PasswordStrengthType passwordStrength = PasswordHandler.PasswordStrength(aUserPasswordPair.Password);

            if (passwordStrength == PasswordStrengthType.Red)
            {
                aUserPasswordPair.Category.RedUserPasswordPairsQuantity++;
                User.AddRedUserPasswordPair(aUserPasswordPair);
            }
            if (passwordStrength == PasswordStrengthType.Orange)
            {
                aUserPasswordPair.Category.OrangeUserPasswordPairsQuantity++;
                User.AddOrangeUserPasswordPair(aUserPasswordPair);
            }
            if (passwordStrength == PasswordStrengthType.Yellow)
            {
                aUserPasswordPair.Category.YellowUserPasswordPairsQuantity++;
                User.AddYellowUserPasswordPair(aUserPasswordPair);
            }
            if (passwordStrength == PasswordStrengthType.LightGreen)
            {
                aUserPasswordPair.Category.LightGreenUserPasswordPairsQuantity++;
                User.AddLightGreenUserPasswordPair(aUserPasswordPair);
            }
            if (passwordStrength == PasswordStrengthType.DarkGreen)
            {
                aUserPasswordPair.Category.DarkGreenUserPasswordPairsQuantity++;
                User.AddDarkGreenUserPasswordPair(aUserPasswordPair);
            }
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
            return this.User.UserPasswordPairExists(username, site);
        }

        public bool UserPasswordPairAlredyExistsInCategory(string username, string site)
        {
            return this.userPasswordPairsHash.ContainsKey(site + username);
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
                DeleteUserPasswordPairFromStrengthGroup(oldUserPasswordPair);
                UpdateUsernameSiteAndNotes(oldUserPasswordPair, newUserPasswordPair);
                UpdatePassword(oldUserPasswordPair, newUserPasswordPair);
                AddUserPasswordPairToStrengthGroup(oldUserPasswordPair);
            }
            if (hasSameCategory && passwordsAreEqual)
            {
                UpdateUsernameSiteAndNotes(oldUserPasswordPair, newUserPasswordPair);
            }
            if (!hasSameCategory && passwordsAreEqual)
            {
                DeleteUserPasswordPairFromStrengthGroup(oldUserPasswordPair);
                UpdateUsernameSiteAndNotes(oldUserPasswordPair, newUserPasswordPair);
                RemoveUserPasswordPairFromCollection(oldUserPasswordPair);
                UpdateCategory(oldUserPasswordPair, newUserPasswordPair);
                oldUserPasswordPair.Category.AddUserPasswordPairToHashTable(oldUserPasswordPair);
                AddUserPasswordPairToStrengthGroup(oldUserPasswordPair);
            }
            if (!hasSameCategory && !passwordsAreEqual)
            {
                RemoveUserPasswordPairFromCollection(oldUserPasswordPair);
                DeleteUserPasswordPairFromStrengthGroup(oldUserPasswordPair);
                newUserPasswordPair.Category.AddUserPasswordPairToHashTable(newUserPasswordPair);
                AddUserPasswordPairToStrengthGroup(newUserPasswordPair);
            }
        }

        private void DeleteUserPasswordPairFromStrengthGroup(UserPasswordPair aUserPasswordPair)
        {
            PasswordStrengthType passwordStrength = PasswordHandler.PasswordStrength(aUserPasswordPair.Password);

            if (passwordStrength == PasswordStrengthType.Red)
            {
                RedUserPasswordPairsQuantity--;
                User.DeleteRedUserPasswordPair(aUserPasswordPair);
            }
            if (passwordStrength == PasswordStrengthType.Orange)
            {
                OrangeUserPasswordPairsQuantity--;
                User.DeleteOrangeUserPasswordPair(aUserPasswordPair);
            }
            if (passwordStrength == PasswordStrengthType.Yellow)
            {
                YellowUserPasswordPairsQuantity--;
                User.DeleteYellowUserPasswordPair(aUserPasswordPair);
            }
            if (passwordStrength == PasswordStrengthType.LightGreen)
            {
                LightGreenUserPasswordPairsQuantity--;
                User.DeleteLightGreenUserPasswordPair(aUserPasswordPair);
            }
            if (passwordStrength == PasswordStrengthType.DarkGreen)
            {
                DarkGreenUserPasswordPairsQuantity--;
                User.DeleteDarkGreenUserPasswordPair(aUserPasswordPair);
            }
        }

        private void AddUserPasswordPairToStrengthGroup(UserPasswordPair aUserPasswordPair, PasswordStrengthType passwordStrength)
        {
            if (passwordStrength == PasswordStrengthType.Red)
            {
                RedUserPasswordPairsQuantity++;
                User.AddRedUserPasswordPair(aUserPasswordPair);
            }
            if (passwordStrength == PasswordStrengthType.Orange)
            {
                OrangeUserPasswordPairsQuantity++;
                User.AddOrangeUserPasswordPair(aUserPasswordPair);
            }
            if (passwordStrength == PasswordStrengthType.Yellow)
            {
                YellowUserPasswordPairsQuantity++;
                User.AddYellowUserPasswordPair(aUserPasswordPair);
            }
            if (passwordStrength == PasswordStrengthType.LightGreen)
            {
                LightGreenUserPasswordPairsQuantity++;
                User.AddLightGreenUserPasswordPair(aUserPasswordPair);
            }
            if (passwordStrength == PasswordStrengthType.DarkGreen)
            {
                DarkGreenUserPasswordPairsQuantity++;
                User.AddDarkGreenUserPasswordPair(aUserPasswordPair);
            }
        }

        internal UserPasswordPair FindUserPasswordPair(string siteUsername, string site)
        {
            return userPasswordPairsHash[site + siteUsername];
        }

        private static void UpdatePassword(UserPasswordPair oldUserPasswordPair, UserPasswordPair newUserPasswordPair)
        {
            oldUserPasswordPair.Password = newUserPasswordPair.Password;
        }

        private static void UpdateCategory(UserPasswordPair oldUserPasswordPair, UserPasswordPair newUserPasswordPair)
        {
            oldUserPasswordPair.Category = newUserPasswordPair.Category;
        }

        private void UpdateUsernameSiteAndNotes(UserPasswordPair oldUserPasswordPair, UserPasswordPair newUserPasswordPair)
        {
            if (!HasSameSiteAndUsername(oldUserPasswordPair, newUserPasswordPair))
            {
                RemoveUserPasswordPairFromCollection(oldUserPasswordPair);
                oldUserPasswordPair.Username = newUserPasswordPair.Username;
                oldUserPasswordPair.Site = newUserPasswordPair.Site;
                oldUserPasswordPair.Category.AddUserPasswordPairToHashTable(oldUserPasswordPair);
            }
            oldUserPasswordPair.Notes = newUserPasswordPair.Notes;
        }

        public static bool HasSameSiteAndUsername(UserPasswordPair oldUserPasswordPair, UserPasswordPair newUserPasswordPair)
        {
            return oldUserPasswordPair.Username == newUserPasswordPair.Username && oldUserPasswordPair.Site == newUserPasswordPair.Site;
        }

        public bool PasswordsAreEqual(String aPassword, String otherPassword)
        {
            return aPassword == otherPassword;
        }

        public bool HasSameCategory(Category aCategory, Category otherCategory)
        {
            return aCategory.Name == otherCategory.Name;
        }

        public bool RemoveCreditCard(string number)
        {
            if (!CreditCardNumberAlreadyExistsInCategory(number))
            { 
                throw new ExceptionCreditCardDoesNotExist($"The credit card {number} does not exist in this category");
            }

            this.creditCardHashTable.Remove(number);
            return true;
        }

        public bool RemoveUserPasswordPair(UserPasswordPair aUserPasswordPair)
        {
            if (!this.UserPasswordPairAlredyExistsInCategory(aUserPasswordPair.Username, aUserPasswordPair.Site))
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

            foreach (UserPasswordPair userPasswordPair in userPasswordPairsHash.Values)
            {
                if (PasswordsAreEqual(userPasswordPair.Password, aPassword))
                {
                    pairsList.Add(userPasswordPair);
                }
            }
            return pairsList;
        }
      
        private void RemoveUserPasswordPairFromCollection(UserPasswordPair aUserPasswordPair)
        {
            this.userPasswordPairsHash.Remove($"{aUserPasswordPair.Site}{ aUserPasswordPair.Username}");
        }

    }
}
