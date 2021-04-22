using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorPasswordsDominio
{
    public class Usuario
    {
        public List<Categoria> listOfCategories;

        public Usuario()
        {
            listOfCategories = new List<Categoria>();
        }

        public bool CreditCardNumberExists(string creditCardNumber)
        {
            bool creditCardExists = false;
            foreach (Categoria aCategory in this.listOfCategories)
            {
                if (aCategory.CreditCardNumberAlreadyExistsInCategory(creditCardNumber))
                {
                    creditCardExists = true;
                    break;
                }
            }
            return creditCardExists;
        }

        public bool UserPasswordPairExists(string username, string site)
        {
            bool pairExists = false;

            foreach (Categoria aCategory in this.listOfCategories)
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
