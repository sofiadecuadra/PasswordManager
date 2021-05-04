using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace GestorPasswordsDominio
{
    public class User
    {
        public string MasterPassword { get; set; }
        private string name;
        private SortedList<string, Category> categoriesList;

        public string Name
        {
            get { return name; }
            set { name = ValidUserName(value); }
        }

        public Category SharedPasswords { get; private set; }

        private static string ValidUserName(string value)
        {
            if (!isBetween5And25Characters(value))
            {
                string errorMessage = $"The provided user name should be between 5 and 25 characters but is: {value.Length} charachterslong";
                throw new ExceptionIncorrectUserNameLength(errorMessage);
            }
            return value.ToLower();
        }

        private static bool isBetween5And25Characters(string value)
        {
            return value.Length >= 5 && value.Length <= 25;
        }

        public User()
        {
            categoriesList = new SortedList<string, Category>();
            SharedPasswords = new Category()
            {
                User = this,
                Name = "Shared Passwords"
            };
        }

        public bool ChangeMasterPassword(string currentPassword, string newPassword)
        {
            if (!PasswordsMatch(currentPassword, this.MasterPassword))
            {
                throw new ExceptionIncorrectMasterPassword("The password entered by the user did not match the master password");
            }
            if (!NewPasswordHasValidLength(newPassword))
            {
                throw new ExceptionIncorrectLength("The new password's length must be between 5 and 25, but it's current length is " + newPassword.Length);
            }
            this.MasterPassword = newPassword;
            return true;
        }

        public bool NewPasswordHasValidLength(string aPassword)
        {
            return aPassword.Length >= 5 && aPassword.Length <= 25;
        }

        public bool PasswordsMatch(string currentPassword, string masterPassword)
        {
            return currentPassword == masterPassword;
        }

        public bool AddCategory(Category aCategory)
        {
            bool categoryAdded = false;
            if (CategoryHasValidLength(aCategory.Name))
            {
                AddCategoryToSortedList(aCategory);
                categoryAdded = true;
            }

            return categoryAdded;
        }

        internal void AddSharedUserPasswordPair(UserPasswordPair passwordToShare)
        {
            SharedPasswords.AddUserPasswordPair(passwordToShare);
        }

        internal void UnshareUserPasswordPair(UserPasswordPair passwordToStopSharing)
        {
            SharedPasswords.RemoveUserPasswordPair(passwordToStopSharing);
        }

        private void AddCategoryToSortedList(Category aCategory)
        {
            this.categoriesList.Add(aCategory.Name, aCategory); // If it already exists in the list throws an exception
        }

        private static bool CategoryHasValidLength(string categoryName)
        {
            if (categoryName.Length < 3 || categoryName.Length > 15)
            {
                throw new ExceptionCategoryHasInvalidNameLength("The category length must be between 3 and 15, but it's current length is " + categoryName.Length);
            }

            return true;
        }

        public Category[] GetCategories()
        {
            IList<Category> categories = categoriesList.Values;
            return categories.ToArray();
        }

        public bool ModifyCategory(Category aCategory, string newName)
        {
            bool categoryModified = false;
            if (CategoryCouldBeModified(aCategory, newName))
            {
                UpdateCategory(aCategory, newName);
                categoryModified = true;
            }
            return categoryModified;
        }

        private void UpdateCategory(Category aCategory, string newName)
        {
            aCategory.Name = newName;
        }

        private bool CategoryCouldBeModified(Category aCategory, string newName)
        {
            bool categoryCouldBeModified = false;

            if (!CategoryExists(aCategory))
            {
                throw new ExceptionCategoryNotExists();
            }

            if (CategoryHasValidLength(newName))
            {
                categoryCouldBeModified = true;
            }

            return categoryCouldBeModified;
        }

        private bool CategoryExists(Category aCategory)
        {
            return this.categoriesList.ContainsKey(aCategory.Name);
        }

        public bool CreditCardNumberExists(string creditCardNumber)
        {
            bool creditCardExists = false;
            foreach (KeyValuePair<string, Category> pair in this.categoriesList)
            {
                if (CreditCardExistsInCategory(pair.Value, creditCardNumber))
                {
                    creditCardExists = true;
                    break;
                }
            }
            return creditCardExists;
        }

        public bool HasSharedPasswordOf(string username, string site)
        {
            return SharedPasswords.UserPasswordPairAlredyExistsInCategory(username, site);
        }

        private static bool CreditCardExistsInCategory(Category aCategory, string creditCardNumber)
        {
            return aCategory.CreditCardNumberAlreadyExistsInCategory(creditCardNumber);
        }

        public bool UserPasswordPairExists(string username, string site)
        {
            bool pairExists = false;
            foreach (KeyValuePair<string, Category> pair in this.categoriesList)
            {
                if (UserPasswordPairExistsInCategory(pair.Value, username, site))
                {
                    pairExists = true;
                    break;
                }
            }
            return pairExists;
        }
        private static bool UserPasswordPairExistsInCategory(Category aCategory, string username, string site)
        {
            return aCategory.UserPasswordPairAlredyExistsInCategory(username, site);
        }

        public UserPasswordPair FindUserPasswordPair(string username, string site)
        {
            UserPasswordPair userPasswordPair = null;
            foreach (KeyValuePair<string, Category> pair in this.categoriesList)
            {
                if (UserPasswordPairExistsInCategory(pair.Value, username, site))
                {
                    userPasswordPair = pair.Value.FindUserPasswordPair(username, site);
                    break;
                }
            }

            return userPasswordPair != null ? userPasswordPair : throw new ExceptionUserPasswordPairDoesNotExist(); 
        }

        private CreditCard ReturnCreditCardIfItExistsInCategory(Category aCategory, string creditCardNumber)
        {
            return aCategory.ReturnCreditCardIfItExistsInCategory(creditCardNumber);
        }

        private CreditCard ReturnCreditCardIfItExists(string creditCardNumber)
        {
            CreditCard creditCard = null;

            foreach (KeyValuePair<string, Category> pair in this.categoriesList)
            {
                string creditCardNumberWithoutBlankSpace = creditCardNumber.Replace(" ", string.Empty);

                creditCard = ReturnCreditCardIfItExistsInCategory(pair.Value, creditCardNumberWithoutBlankSpace);

                if (creditCard!= null)
                {
                    break;
                }
            }
            return creditCard;
        }

        private List<UserPasswordPair> ReturnUserPasswordPairsInCategoryWhosePasswordMatches(Category aCategory, string creditCardNumber)
        {
            return aCategory.ReturnUserPasswordPairsInCategoryWhosePasswordMatches(creditCardNumber);
        }


        private List <UserPasswordPair> ReturnUserPasswordPairsWhosePasswordMatches(string aPassword)
        {
            List<UserPasswordPair> userPasswordPairList = new List<UserPasswordPair>();

            foreach (KeyValuePair<string, Category> pair in this.categoriesList)
            {
                List<UserPasswordPair> userPasswordPairListInCategory = ReturnUserPasswordPairsInCategoryWhosePasswordMatches(pair.Value, aPassword);

                foreach (UserPasswordPair element in userPasswordPairListInCategory)
                {
                    userPasswordPairList.Add(element);
                }
            }
            return userPasswordPairList;
        }

        private bool containsOnlyDigits(string element)
        {
            return Regex.IsMatch(element, @"^[0-9]+$");
        }

        private bool LengthIsFour (string element)
        {
            return element.Length == 4;
        }

        private bool ItsACreditCard(string element)
        {
            string [] dataToCheck = element.Split (' ');

            foreach (string item in dataToCheck)
            {
                if (!containsOnlyDigits (item) || !LengthIsFour (item))
                {
                    return false;
                }
            }
            return true;
        }

        public (List <UserPasswordPair>, List <CreditCard>) CheckDataBreaches(IDataBreachesFormatter dataBreaches)
        {
            List<CreditCard> creditCardsOfUserLeakedList = new List<CreditCard>();

            List<UserPasswordPair> passwordsOfUserLeakedList = new List<UserPasswordPair>();

            string [] leakedData = dataBreaches.ConvertToArray();

            foreach (string element in leakedData)
            {
                if (ItsACreditCard(element))
                {
                    CreditCard creditCardOfUserLeaked = ReturnCreditCardIfItExists(element);

                    if (creditCardOfUserLeaked != null)
                    {
                        creditCardsOfUserLeakedList.Add(creditCardOfUserLeaked);
                    }
                }
                else
                {
                    foreach (UserPasswordPair pair in ReturnUserPasswordPairsWhosePasswordMatches(element))
                    {
                        passwordsOfUserLeakedList.Add(pair);
                    }
                }              
            }
            return (passwordsOfUserLeakedList, creditCardsOfUserLeakedList);
        }
    }
}
