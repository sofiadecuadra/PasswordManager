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
        public string MasterPassword;
        private SortedList<string, Category> categoriesList;

        public User()
        {
            categoriesList = new SortedList<string, Category>();
        }

        public bool ChangeMasterPassword(string currentPassword, string newPassword)
        {
            if(!PasswordsMatch(currentPassword, this.MasterPassword))
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

        public void AddCategory(Category aCategory)
        {
            this.categoriesList.Add(aCategory.Name , aCategory);
        }

        public Category[] GetCategories()
        {
            IList<Category> categories = categoriesList.Values;
            return categories.ToArray();
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
