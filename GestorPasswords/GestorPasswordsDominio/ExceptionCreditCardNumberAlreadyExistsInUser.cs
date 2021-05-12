using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorPasswordsDominio
{
    public class ExceptionCreditCardNumberAlreadyExistsInUser : Exception
    {
        public ExceptionCreditCardNumberAlreadyExistsInUser(string message) : base(message) { }
    }
}
