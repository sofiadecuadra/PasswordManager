using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorPasswordsDominio
{
    public class ExceptionUserPasswordPairHasInvalidUsernameLength : Exception
    {
        public ExceptionUserPasswordPairHasInvalidUsernameLength() { }
        public ExceptionUserPasswordPairHasInvalidUsernameLength(string message) : base(message) { }
        public ExceptionUserPasswordPairHasInvalidUsernameLength(string message, Exception inner) : base(message, inner) { }
    }
}
