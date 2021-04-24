using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorPasswordsDominio
{
    public class ExceptionCreditCardCodeHasNonNumericCharacters : Exception
    {
        public ExceptionCreditCardCodeHasNonNumericCharacters() { }
        public ExceptionCreditCardCodeHasNonNumericCharacters(string message) : base(message) { }
        public ExceptionCreditCardCodeHasNonNumericCharacters(string message, Exception inner) : base(message, inner) { }
    }
}