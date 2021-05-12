using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorPasswordsDominio
{
    public class ExceptionUsernameContainsSpaces : Exception
    {
        public ExceptionUsernameContainsSpaces(string message) : base(message) { }
    }
}
