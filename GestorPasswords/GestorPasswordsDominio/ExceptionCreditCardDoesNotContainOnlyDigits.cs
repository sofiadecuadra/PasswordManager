using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorPasswordsDominio
{
    public class ExceptionCreditCardDoesNotContainOnlyDigits : Exception
    {
        public ExceptionCreditCardDoesNotContainOnlyDigits() { }
        public ExceptionCreditCardDoesNotContainOnlyDigits(string message) : base(message) { }
        public ExceptionCreditCardDoesNotContainOnlyDigits(string message, Exception inner) : base(message, inner) { }
    }
}
