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
        private Hashtable categoriesHashTable;

        public User()
        {
            categoriesHashTable = new Hashtable();
        }

        public void AddCategory(Category aCategory)
        {
            this.categoriesHashTable.Add(aCategory.Name , aCategory);
        }

        public Category[] GetCategories()
        {
            Category[] categories = new Category[this.categoriesHashTable.Count];
            categories.CopyTo(categories, 0);

            return categories;
        }

        public bool CreditCardNumberExists(string creditCardNumber)
        {
            bool creditCardExists = false;
            foreach (DictionaryEntry pair in this.categoriesHashTable)
            {
                if (CreditCardExistsInCategory((Category)pair.Value, creditCardNumber)) 
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

            foreach (Category aCategory in this.categoriesHashTable)
            {
                
                if (aCategory.UserPasswordPairAlredyExistsInCategory(username, site))
                {
                    pairExists = true;
                    break;
                }
            }

            return pairExists;
        }
    }
}
