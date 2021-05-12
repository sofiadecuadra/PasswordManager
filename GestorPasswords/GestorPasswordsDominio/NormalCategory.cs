using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace GestorPasswordsDominio
{
    public class NormalCategory : Category
    {
        private Dictionary<string, CreditCard> creditCardHashTable;
        public int RedUserPasswordPairsQuantity { get; set; }
        public int OrangeUserPasswordPairsQuantity { get; set; }
        public int YellowUserPasswordPairsQuantity { get; set; }
        public int LightGreenUserPasswordPairsQuantity { get; set; }
        public int DarkGreenUserPasswordPairsQuantity { get; set; }

        public NormalCategory()
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

            return CreditCardDataIsValid(aCreditCard);
        }

        public bool CreditCardDataIsValid(CreditCard aCreditCard)
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
            if (CreditCardHasExpired(aCreditCard.ExpirationDate))
            {
                throw new ExceptionCreditCardHasExpired("The credit card must be valid, but it has expired in " + aCreditCard.ExpirationDate.Month + "/" + aCreditCard.ExpirationDate.Year);
            }

            return true;
        }

        public bool CreditCardHasExpired(DateTime expirationDate)
        {    
            return expirationDate < DateTime.Now;
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

        private bool CreditCardNumbersAreEqual (string oldCreditCardNumber, string newCreditCardNumber)
        {
            return oldCreditCardNumber == newCreditCardNumber;
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

            return CreditCardDataIsValid(newCreditCard);
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

        public override bool AddUserPasswordPair(UserPasswordPair aUserPasswordPair)
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

            return UserPasswordPairDataIsValid(aUserPasswordPair);
        }

        public bool UserPasswordPairDataIsValid(UserPasswordPair newUserPasswordPair)
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
                throw new ExceptionUserPasswordPairHasInvalidSiteLength("The site's length must be between 3 and 25, but it's current length is " + newUserPasswordPair.Site.Length);
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

        public bool ModifyUserPasswordPair(UserPasswordPair oldUserPasswordPair, UserPasswordPair newUserPasswordPair)
        {
            bool modified = false;
            if (UserPasswordPairDataIsValid(newUserPasswordPair))
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
                DeleteUserPasswordPairFromStrengthGroup(oldUserPasswordPair);
                UpdateUsernameSiteAndNotes(oldUserPasswordPair, newUserPasswordPair);
                UpdatePassword(oldUserPasswordPair, newUserPasswordPair);
                RemoveUserPasswordPairFromCollection(oldUserPasswordPair);
                UpdateCategory(oldUserPasswordPair, newUserPasswordPair);
                oldUserPasswordPair.Category.AddUserPasswordPairToHashTable(oldUserPasswordPair);
                AddUserPasswordPairToStrengthGroup(oldUserPasswordPair);
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

        public bool HasSameCategory(NormalCategory aCategory, NormalCategory otherCategory)
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

        public override bool RemoveUserPasswordPair(UserPasswordPair aUserPasswordPair)
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

    }
}
