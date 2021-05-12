using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorPasswordsDominio
{
    public class ExceptionCreditCardDoesNotExist : Exception
    {
        public ExceptionCreditCardDoesNotExist(string message) : base(message) { }
    }
}
