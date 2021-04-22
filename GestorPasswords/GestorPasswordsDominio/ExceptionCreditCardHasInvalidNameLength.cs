using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorPasswordsDominio
{
    public class ExceptionCreditCardHasInvalidNameLength : Exception
    {
        public ExceptionCreditCardHasInvalidNameLength() { }
        public ExceptionCreditCardHasInvalidNameLength(string message) : base(message) { }
        public ExceptionCreditCardHasInvalidNameLength(string message, Exception inner) : base(message, inner) { }
    }
}
