using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace GestorPasswordsDominio
{
    public class Category
    {
        private String name;
        public User User { get; set; }
        private Hashtable creditCardHashTable;
        public Hashtable userPasswordPairsHash;

        public String Name { 
            get { return name; } 
            set { this.name = value.ToLower(); }  
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

        public bool AddUserPasswordPair(UserPasswordPair aUserPasswordPair)
        {
            if (UserPasswordPairAlredyExistsInUser(aUserPasswordPair.Username, aUserPasswordPair.Site))
            {
                throw new ExceptionExistingUserPasswordPair();
            }

            if (!UsernameHasValidLength(aUserPasswordPair.Username))
            {
                throw new ExceptionUserPasswordPairHasInvalidUsernameLength("The username's length must be between 5 and 25, but it's current length is " + aUserPasswordPair.Username);
            }

            if (!PasswordHasValidLength(aUserPasswordPair.Password))
            {
                throw new ExceptionUserPasswordPairHasInvalidPasswordLength("The password's length must be between 5 and 25, but it's current length is " + aUserPasswordPair.Password);
            }

            if (!siteHasValidLength(aUserPasswordPair.Site))
            {
                throw new ExceptionUserPasswordPairHasInvalidSiteLength("The site's length must be between 5 and 25, but it's current length is " + aUserPasswordPair.Site);
            }

            if (!notesHaveValidLength(aUserPasswordPair.Notes))
            {
                throw new ExceptionUserPasswordPairHasInvalidNotesLength("The notes' length must be up to 250, but it's current length is " + aUserPasswordPair.Notes);
            }

            this.userPasswordPairsHash.Add(aUserPasswordPair.Site + aUserPasswordPair.Username, aUserPasswordPair);
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
    }
}
