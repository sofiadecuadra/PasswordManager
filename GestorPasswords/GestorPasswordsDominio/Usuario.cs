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

        public bool NumeroTarjetaCreditoExistente(string numeroTarjetaCredito)
        {
            foreach (Categoria unaCategoria in this.listOfCategories)
            {
                if (unaCategoria.CreditCardNumberAlreadyExistsInCategory(numeroTarjetaCredito))
                {
                    return true;
                }
            }
            return false;
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
