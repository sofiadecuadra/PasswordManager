using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorPasswordsDominio
{
    public class ExceptionUserPasswordPairHasInvalidSiteLength : Exception
    {
        public ExceptionUserPasswordPairHasInvalidSiteLength() { }
        public ExceptionUserPasswordPairHasInvalidSiteLength(string message) : base(message) { }
        public ExceptionUserPasswordPairHasInvalidSiteLength(string message, Exception inner) : base(message, inner) { }
    }
}
