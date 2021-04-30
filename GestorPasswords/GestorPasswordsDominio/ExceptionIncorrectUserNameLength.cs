using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorPasswordsDominio
{

    public class ExceptionIncorrectUserNameLength : Exception
    {
        public ExceptionIncorrectUserNameLength() { }
        public ExceptionIncorrectUserNameLength(string message) : base(message) { }
        public ExceptionIncorrectUserNameLength(string message, Exception inner) : base(message, inner) { }
    }
}
