using System;

namespace DataManagerDomain
{
    public class ExceptionCreditCardCodeHasNonNumericCharacters : Exception
    {
        public ExceptionCreditCardCodeHasNonNumericCharacters(string message) : base(message) { }
    }
}