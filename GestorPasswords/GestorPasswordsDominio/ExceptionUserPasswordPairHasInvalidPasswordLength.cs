using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorPasswordsDominio
{
    public class ExceptionUserPasswordPairHasInvalidPasswordLength : Exception
    {
        public ExceptionUserPasswordPairHasInvalidPasswordLength() { }
        public ExceptionUserPasswordPairHasInvalidPasswordLength(string message) : base(message) { }
        public ExceptionUserPasswordPairHasInvalidPasswordLength(string message, Exception inner) : base(message, inner) { }
    }
}
