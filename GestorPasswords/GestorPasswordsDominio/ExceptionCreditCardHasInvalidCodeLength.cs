using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorPasswordsDominio
{
    public class ExceptionCreditCardHasInvalidCodeLength : Exception
    {
        public ExceptionCreditCardHasInvalidCodeLength() { }
        public ExceptionCreditCardHasInvalidCodeLength(string message) : base(message) { }
        public ExceptionCreditCardHasInvalidCodeLength(string message, Exception inner) : base(message, inner) { }
    }
}
