using System;

namespace GestorPasswordsDominio
{
    public class ExceptionCreditCardCodeHasNonNumericCharacters : Exception
    {
        public ExceptionCreditCardCodeHasNonNumericCharacters(string message) : base(message) { }
    }
}