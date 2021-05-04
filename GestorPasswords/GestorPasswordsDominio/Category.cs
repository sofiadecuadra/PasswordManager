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
        private Hashtable creditCardHashTable;
        public Hashtable userPasswordPairsHash;
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
            this.creditCardHashTable = new Hashtable();
            this.userPasswordPairsHash = new Hashtable();
        }

        public CreditCard[] GetCreditCards()
        {
            CreditCard[] creditCards = new CreditCard[this.creditCardHashTable.Count];
            creditCardHashTable.CopyTo(creditCards, 0);

            return creditCards;
        }

        public UserPasswordPair[] GetUserPasswordsPair()
        {
            UserPasswordPair[] userPasswordPairs = new UserPasswordPair[this.userPasswordPairsHash.Count];
            userPasswordPairsHash.CopyTo(userPasswordPairs, 0);

            return userPasswordPairs;
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
            if (!CreditCardContainsOnlyDigits(aCreditCard.Number))
            {
                throw new ExceptionCreditCardDoesNotContainOnlyDigits("The credit card number must only contain digits");
            }
            if (!CreditCardNumberHasValidLength(aCreditCard.Number))
            {
                throw new ExceptionCreditCardHasInvalidNumberLength("The credit card number must contain 16 digits, but currently it has " + aCreditCard.Number.Length);
            }
            if (!LengthBetween3And25(aCreditCard.Type))
            {
                throw new ExceptionCreditCardHasInvalidTypeLength("The type's length must be between 3 and 25, but it's current length is " + aCreditCard.Type.Length);
            }
            if (!LengthBetween3And25(aCreditCard.Name))
            {
                throw new ExceptionCreditCardHasInvalidNameLength("The name's length must be between 3 and 25, but it's current length is " + aCreditCard.Name.Length);
            }
            if (!codeHasValidLength(aCreditCard.Code))
            {
                throw new ExceptionCreditCardHasInvalidCodeLength("The code's length must be between 3 and 4, but it's current length is " + aCreditCard.Code.Length);
            }
            if (!codeContainNumericCharactersOnly(aCreditCard.Code))
            {
                throw new ExceptionCreditCardCodeHasNonNumericCharacters("The code should contain numeric characters only but is " + aCreditCard.Code);
            }
            if (!notesHaveValidLength(aCreditCard.Notes))
            {
                throw new ExceptionCreditCardHasInvalidNotesLength("The notes' length must be up to 250, but it's current length is " + aCreditCard.Notes.Length);
            }
            if (CreditCardNumberAlreadyExistsInUser(aCreditCard.Number))
            {
                throw new ExceptionCreditCardNumberAlreadyExistsInUser("The credit card number already exists in user");
            }

            return true;
        }

        internal UserPasswordPair FindUserPasswordPair(string siteUsername, string site)
        {
            return (UserPasswordPair)userPasswordPairsHash[site + siteUsername];
        }

        public bool CreditCardNumberAlreadyExistsInCategory(string creditCardNumber)
        {
            return creditCardHashTable.ContainsKey(creditCardNumber);
        }

        private bool CreditCardNumberAlreadyExistsInUser(string creditCardNumber)
        {
            return User.CreditCardNumberExists(creditCardNumber);
        }

        private bool codeHasValidLength(string creditCardCode)
        {
            return creditCardCode.Length == 3 || creditCardCode.Length == 4;
        }

        public bool codeContainNumericCharactersOnly(string creditCardCode)
        {
            return Regex.IsMatch(creditCardCode, @"^[0-9]+$");
        }

        private bool LengthBetween3And25(string stringToCheck)
        {
            return stringToCheck.Length >= 3 && stringToCheck.Length <= 25;
        }

        private bool CreditCardContainsOnlyDigits(string creditCardNumber)
        {
            return Regex.IsMatch(creditCardNumber, @"^[0-9]+$");
        }

        private bool CreditCardNumberHasValidLength(string creditCardNumber)
        {
            return creditCardNumber.Length == 16;
        }


        private bool newCreditCardIsValid(CreditCard oldCreditCard, CreditCard newCreditCard)
        {
            if (!CreditCardContainsOnlyDigits(newCreditCard.Number))
            {
                throw new ExceptionCreditCardDoesNotContainOnlyDigits("The credit card number must only contain digits");
            }
            if (!CreditCardNumberHasValidLength(newCreditCard.Number))
            {
                throw new ExceptionCreditCardHasInvalidNumberLength("The credit card number must contain 16 digits, but currently it has " + newCreditCard.Number.Length);
            }
            if (!LengthBetween3And25(newCreditCard.Type))
            {
                throw new ExceptionCreditCardHasInvalidTypeLength("The type's length must be between 3 and 25, but it's current length is " + newCreditCard.Type.Length);
            }
            if (!LengthBetween3And25(newCreditCard.Name))
            {
                throw new ExceptionCreditCardHasInvalidNameLength("The name's length must be between 3 and 25, but it's current length is " + newCreditCard.Name.Length);
            }
            if (!codeHasValidLength(newCreditCard.Code))
            {
                throw new ExceptionCreditCardHasInvalidCodeLength("The code's length must be between 3 and 4, but it's current length is " + newCreditCard.Code.Length);
            }
            if (!codeContainNumericCharactersOnly(newCreditCard.Code))
            {
                throw new ExceptionCreditCardCodeHasNonNumericCharacters("The code should contain numeric characters only but is " + newCreditCard.Code);
            }
            if (!notesHaveValidLength(newCreditCard.Notes))
            {
                throw new ExceptionCreditCardHasInvalidNotesLength("The notes' length must be up to 250, but it's current length is " + newCreditCard.Notes.Length);
            }

            if (!CreditCardNumbersAreEqual(oldCreditCard.Number, newCreditCard.Number) && CreditCardNumberAlreadyExistsInUser(newCreditCard.Number))
            {
                throw new ExceptionCreditCardNumberAlreadyExistsInUser("The credit card number already exists in user");
            }

            return true;
        }

        private bool CreditCardNumbersAreEqual (string oldCreditCardNumber, string newCreditCardNumber)
        {
            return oldCreditCardNumber == newCreditCardNumber;
        }


        public bool ModifyCreditCard(CreditCard oldCreditCard, CreditCard newCreditCard)
        {
            if (newCreditCardIsValid(oldCreditCard, newCreditCard))
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

        private void AddCreditCardToHashTable(CreditCard newCreditCard)
        {
            this.creditCardHashTable.Add(newCreditCard.Number, newCreditCard);
        }

        public bool AddUserPasswordPair(UserPasswordPair aUserPasswordPair)
        {
            bool userPasswordPairAdded = false;
            if (UserPasswordPairIsValid(aUserPasswordPair))
            {
                AddUserPasswordPairToHashTable(aUserPasswordPair);
                AddUserPasswordPairToGroup(aUserPasswordPair);
                userPasswordPairAdded = true;
            }
            return userPasswordPairAdded;
        }

        private void AddUserPasswordPairToHashTable(UserPasswordPair aUserPasswordPair)
        {
            this.userPasswordPairsHash.Add(aUserPasswordPair.Site + aUserPasswordPair.Username, aUserPasswordPair);
        }

        private void AddUserPasswordPairToGroup(UserPasswordPair aUserPasswordPair)
        {
            PasswordStrengthType passwordStrength = PasswordHandler.PasswordStrength(aUserPasswordPair.Password);

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
                YellowUserPasswordPairsQuantity++;
                User.AddLightGreenUserPasswordPair(aUserPasswordPair);
            }
            if (passwordStrength == PasswordStrengthType.DarkGreen)
            {
                YellowUserPasswordPairsQuantity++;
                User.AddDarkGreenUserPasswordPair(aUserPasswordPair);
            }
        }

        private bool UserPasswordPairIsValid(UserPasswordPair aUserPasswordPair)
        {
            if (UserPasswordPairAlredyExistsInUser(aUserPasswordPair.Username, aUserPasswordPair.Site))
            {
                throw new ExceptionExistingUserPasswordPair("The userPassword pair already exists in user");
            }

            return NewUserPasswordPairIsValid(aUserPasswordPair);
        }

        public bool NewUserPasswordPairIsValid(UserPasswordPair newUserPasswordPair)
        {
            if (!UsernameHasValidLength(newUserPasswordPair.Username))
            {
                throw new ExceptionUserPasswordPairHasInvalidUsernameLength("The username's length must be between 5 and 25, but it's current length is " + newUserPasswordPair.Username.Length);
            }

            if (!PasswordHasValidLength(newUserPasswordPair.Password))
            {
                throw new ExceptionUserPasswordPairHasInvalidPasswordLength("The password's length must be between 5 and 25, but it's current length is " + newUserPasswordPair.Password.Length);
            }

            if (!siteHasValidLength(newUserPasswordPair.Site))
            {
                throw new ExceptionUserPasswordPairHasInvalidSiteLength("The site's length must be between 5 and 25, but it's current length is " + newUserPasswordPair.Site.Length);
            }

            if (!notesHaveValidLength(newUserPasswordPair.Notes))
            {
                throw new ExceptionUserPasswordPairHasInvalidNotesLength("The notes' length must be up to 250, but it's current length is " + newUserPasswordPair.Notes.Length);
            }

            return true;
        }

        private static bool PasswordHasValidLength(String password)
        {
            return password.Length >= 5 && password.Length <= 25;
        }

        private static bool UsernameHasValidLength(String username)
        {
            return username.Length >= 5 && username.Length <= 25;
        }

        private static bool siteHasValidLength(String site)
        {
            return site.Length >= 3 && site.Length <= 25;
        }

        private static bool notesHaveValidLength(String notes)
        {
            return notes.Length <= 250;
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
            if (NewUserPasswordPairIsValid(newUserPasswordPair))
            {
                ChangeUserPasswordPairData(oldUserPasswordPair, newUserPasswordPair);
                ChangeUserPasswordGroup(oldUserPasswordPair, newUserPasswordPair);
                modified = true;
            }

            return modified;
        }

        private void ChangeUserPasswordGroup(UserPasswordPair oldUserPasswordPair, UserPasswordPair newUserPasswordPair)
        {
            PasswordStrengthType oldPasswordStrength = PasswordHandler.PasswordStrength(oldUserPasswordPair.Password);
            PasswordStrengthType newPasswordStrength = PasswordHandler.PasswordStrength(newUserPasswordPair.Password);

            if (!(oldPasswordStrength == newPasswordStrength))
            {
                DeleteUserPasswordPairFromGroup(oldUserPasswordPair, oldPasswordStrength);
                AddUserPasswordPairToGroup(newUserPasswordPair);
            }
        }

        private void DeleteUserPasswordPairFromGroup(UserPasswordPair aUserPasswordPair, PasswordStrengthType passwordStrength)
        {
            if (passwordStrength == PasswordStrengthType.Red)
            {
                RedUserPasswordPairsQuantity--; ;
                User.DeleteRedUserPasswordPair(aUserPasswordPair);
            }
            if (passwordStrength == PasswordStrengthType.Orange)
            {
                OrangeUserPasswordPairsQuantity--; ;
                User.DeleteOrangeUserPasswordPair(aUserPasswordPair);
            }
            if (passwordStrength == PasswordStrengthType.Yellow)
            {
                YellowUserPasswordPairsQuantity--; ;
                User.DeleteYellowUserPasswordPair(aUserPasswordPair);
            }
            if (passwordStrength == PasswordStrengthType.LightGreen)
            {
                LightGreenUserPasswordPairsQuantity--; ;
                User.DeleteLightGreenUserPasswordPair(aUserPasswordPair);
            }
            if (passwordStrength == PasswordStrengthType.DarkGreen)
            {
                DarkGreenUserPasswordPairsQuantity--; ;
                User.DeleteDarkGreenUserPasswordPair(aUserPasswordPair);
            }
        }

        private void ChangeUserPasswordPairData(UserPasswordPair oldUserPasswordPair, UserPasswordPair newUserPasswordPair)
        {
            bool hasSameCategory = HasSameCategory(oldUserPasswordPair.Category, newUserPasswordPair.Category);
            bool passwordsAreEqual = PasswordsAreEqual(oldUserPasswordPair.Password, newUserPasswordPair.Password);
            if (hasSameCategory && !passwordsAreEqual)
            {
                RemoveUserPasswordPair(oldUserPasswordPair);
                AddUserPasswordPairToHashTable(newUserPasswordPair);
            }
            if (hasSameCategory && passwordsAreEqual)
            {
                UpdateUsernameSiteAndNotes(oldUserPasswordPair, newUserPasswordPair);
            }
            if (!hasSameCategory && passwordsAreEqual)
            {
                RemoveUserPasswordPair(oldUserPasswordPair);
                UpdateUsernameSiteAndNotes(oldUserPasswordPair, newUserPasswordPair);
                UpdateCategory(oldUserPasswordPair, newUserPasswordPair);
                oldUserPasswordPair.Category.AddUserPasswordPairToHashTable(oldUserPasswordPair);
            }
            if (!hasSameCategory && !passwordsAreEqual)
            {
                RemoveUserPasswordPair(oldUserPasswordPair);
                newUserPasswordPair.Category.AddUserPasswordPairToHashTable(newUserPasswordPair);
            }
        }

        private static void UpdateCategory(UserPasswordPair oldUserPasswordPair, UserPasswordPair newUserPasswordPair)
        {
            oldUserPasswordPair.Category = newUserPasswordPair.Category;
        }

        private static void UpdateUsernameSiteAndNotes(UserPasswordPair oldUserPasswordPair, UserPasswordPair newUserPasswordPair)
        {
            oldUserPasswordPair.Username = newUserPasswordPair.Username;
            oldUserPasswordPair.Site = newUserPasswordPair.Site;
            oldUserPasswordPair.Notes = newUserPasswordPair.Notes;
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
            
            this.userPasswordPairsHash.Remove($"{aUserPasswordPair.Site}{ aUserPasswordPair.Username}");
            DeleteUserPasswordPairFromGroup(aUserPasswordPair, PasswordHandler.PasswordStrength(aUserPasswordPair.Password));
            return true;
        }
    }
}
