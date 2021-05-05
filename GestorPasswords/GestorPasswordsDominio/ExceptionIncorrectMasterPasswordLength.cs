using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorPasswordsDominio
{
    public class ExceptionIncorrectMasterPasswordLength : Exception
    {
        public ExceptionIncorrectMasterPasswordLength() { }
        public ExceptionIncorrectMasterPasswordLength(string message) : base(message) { }
        public ExceptionIncorrectMasterPasswordLength(string message, Exception inner) : base(message, inner) { }
    }
}
