using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorPasswordsDominio
{
    public class ExceptionExistingUserPasswordPair : Exception
    {
        public ExceptionExistingUserPasswordPair(string message) : base(message) { }
    }
}
