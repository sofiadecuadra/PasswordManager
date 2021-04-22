using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorPasswordsDominio
{
    public class ExceptionCreditCardHasInvalidNotesLength : Exception
    {
        public ExceptionCreditCardHasInvalidNotesLength() { }
        public ExceptionCreditCardHasInvalidNotesLength(string message) : base(message) { }
        public ExceptionCreditCardHasInvalidNotesLength(string message, Exception inner) : base(message, inner) { }
    }
}
