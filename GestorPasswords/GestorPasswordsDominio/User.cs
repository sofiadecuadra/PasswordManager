using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorPasswordsDominio
{
    public class User
    {
        public string MasterPassword { get; set; }
        private string name;
        private SortedList<string, Category> categoriesList;
        private List<UserPasswordPair> redUserPasswordPairs;
        private List<UserPasswordPair> orangeUserPasswordPairs;
        private List<UserPasswordPair> yellowUserPasswordPairs;
        private List<UserPasswordPair> lightGreenUserPasswordPairs;
        private List<UserPasswordPair> darkGreenUserPasswordPairs;


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
            redUserPasswordPairs = new List<UserPasswordPair>();
            orangeUserPasswordPairs = new List<UserPasswordPair>();
            yellowUserPasswordPairs = new List<UserPasswordPair>();
            lightGreenUserPasswordPairs = new List<UserPasswordPair>();
            darkGreenUserPasswordPairs = new List<UserPasswordPair>();
            SharedPasswords = new Category()
            {
                User = this,
                Name = "Shared Passwords"
            };
        }

        public UserPasswordPair[] GetRedUserPasswordPairs()
        {
            UserPasswordPair[] redUserPasswordPairsArray = new UserPasswordPair[redUserPasswordPairs.Count];
            redUserPasswordPairs.CopyTo(redUserPasswordPairsArray);
            return redUserPasswordPairsArray; 
        }

        public void AddRedUserPasswordPair(UserPasswordPair aRedUserPasswordPair)
        {
            redUserPasswordPairs.Add(aRedUserPasswordPair);
        }

        public void DeleteRedUserPasswordPair(UserPasswordPair aRedUserPasswordPair)
        {
            redUserPasswordPairs.Remove(aRedUserPasswordPair);
        }

        public UserPasswordPair[] GetOrangeUserPasswordPairs()
        {
            UserPasswordPair[] orangeUserPasswordPairsArray = new UserPasswordPair[orangeUserPasswordPairs.Count];
            orangeUserPasswordPairs.CopyTo(orangeUserPasswordPairsArray);
            return orangeUserPasswordPairsArray;
        }

        public void AddOrangeUserPasswordPair(UserPasswordPair anOrangeUserPasswordPair)
        {
            orangeUserPasswordPairs.Add(anOrangeUserPasswordPair);
        }
        public void DeleteOrangeUserPasswordPair(UserPasswordPair anOrangeUserPasswordPair)
        {
            orangeUserPasswordPairs.Remove(anOrangeUserPasswordPair);
        }

        public UserPasswordPair[] GetYellowUserPasswordPairs()
        {
            UserPasswordPair[] yellowUserPasswordPairsArray = new UserPasswordPair[yellowUserPasswordPairs.Count];
            yellowUserPasswordPairs.CopyTo(yellowUserPasswordPairsArray);
            return yellowUserPasswordPairsArray;
        }

        public void AddYellowUserPasswordPair(UserPasswordPair aYellowUserPasswordPair)
        {
            yellowUserPasswordPairs.Add(aYellowUserPasswordPair);
        }

        public void DeleteYellowUserPasswordPair(UserPasswordPair aYellowUserPasswordPair)
        {
           yellowUserPasswordPairs.Remove(aYellowUserPasswordPair);
        }

        public UserPasswordPair[] GetLightGreenUserPasswordPairs()
        {
            UserPasswordPair[] lightGreenUserPasswordPairsArray = new UserPasswordPair[lightGreenUserPasswordPairs.Count];
            lightGreenUserPasswordPairs.CopyTo(lightGreenUserPasswordPairsArray);
            return lightGreenUserPasswordPairsArray;
        }

        public void AddLightGreenUserPasswordPair(UserPasswordPair aLightGreenUserPasswordPair)
        {
            lightGreenUserPasswordPairs.Add(aLightGreenUserPasswordPair);
        }

        public void DeleteLightGreenUserPasswordPair(UserPasswordPair aYellowUserPasswordPair)
        {
            lightGreenUserPasswordPairs.Remove(aYellowUserPasswordPair);
        }

        public UserPasswordPair[] GetDarkGreenUserPasswordPairs()
        {
            UserPasswordPair[] darkGreenUserPasswordPairsArray = new UserPasswordPair[darkGreenUserPasswordPairs.Count];
            darkGreenUserPasswordPairs.CopyTo(darkGreenUserPasswordPairsArray);
            return darkGreenUserPasswordPairsArray;
        }

        public void AddDarkGreenUserPasswordPair(UserPasswordPair aDarkGreenUserPasswordPair)
        {
            darkGreenUserPasswordPairs.Add(aDarkGreenUserPasswordPair);
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
    }
}
