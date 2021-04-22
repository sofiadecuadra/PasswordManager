using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorPasswordsDominio
{
    public class ExceptionUserPasswordPairHasInvalidNotesLength : Exception
    {
        public ExceptionUserPasswordPairHasInvalidNotesLength() { }
        public ExceptionUserPasswordPairHasInvalidNotesLength(string message) : base(message) { }
        public ExceptionUserPasswordPairHasInvalidNotesLength(string message, Exception inner) : base(message, inner) { }
    }
}
