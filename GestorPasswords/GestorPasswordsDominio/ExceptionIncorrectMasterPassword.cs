using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorPasswordsDominio
{
    public class ExceptionIncorrectMasterPassword : Exception
    {
        public ExceptionIncorrectMasterPassword() { }
        public ExceptionIncorrectMasterPassword(string message) : base(message) { }
        public ExceptionIncorrectMasterPassword(string message, Exception inner) : base(message, inner) { }
    }
}
