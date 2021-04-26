using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorPasswordsDominio
{
    public class ExceptionUserPasswordPairDoesNotExist : Exception
    {

        public ExceptionUserPasswordPairDoesNotExist() { }
        public ExceptionUserPasswordPairDoesNotExist(string message) : base(message) { }
        public ExceptionUserPasswordPairDoesNotExist(string message, Exception inner) : base(message, inner) { }

    }
}
