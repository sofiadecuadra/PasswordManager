using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorPasswordsDominio
{
    public class ExceptionCreditCardDoesNotExist : Exception
    {
        public ExceptionCreditCardDoesNotExist() { }
        public ExceptionCreditCardDoesNotExist(string message) : base(message) { }
        public ExceptionCreditCardDoesNotExist(string message, Exception inner) : base(message, inner) { }
    }
}
