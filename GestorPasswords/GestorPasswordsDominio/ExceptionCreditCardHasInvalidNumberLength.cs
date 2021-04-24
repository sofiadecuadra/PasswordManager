using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorPasswordsDominio
{
    public class ExceptionCreditCardHasInvalidNumberLength : Exception
    {
        public ExceptionCreditCardHasInvalidNumberLength() { }
        public ExceptionCreditCardHasInvalidNumberLength(string message) : base(message) { }
        public ExceptionCreditCardHasInvalidNumberLength(string message, Exception inner) : base(message, inner) { }
    }
}
