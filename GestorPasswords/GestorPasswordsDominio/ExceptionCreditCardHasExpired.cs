using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorPasswordsDominio
{
    public class ExceptionCreditCardHasExpired : Exception
    {
        public ExceptionCreditCardHasExpired() { }
        public ExceptionCreditCardHasExpired(string message) : base(message) { }
        public ExceptionCreditCardHasExpired(string message, Exception inner) : base(message, inner) { }
    }
}
