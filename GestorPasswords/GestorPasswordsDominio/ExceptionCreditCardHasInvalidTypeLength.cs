using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorPasswordsDominio
{
    public class ExceptionCreditCardHasInvalidTypeLength : Exception
    {
        public ExceptionCreditCardHasInvalidTypeLength() { }
        public ExceptionCreditCardHasInvalidTypeLength(string message) : base(message) { }
        public ExceptionCreditCardHasInvalidTypeLength(string message, Exception inner) : base(message, inner) { }
    }
}
