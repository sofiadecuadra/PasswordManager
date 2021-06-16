using System;

namespace DataManagerDomain
{
    public class ExceptionCreditCardCodeHasNonNumericCharacters : ExceptionCreditCard
    {
        public ExceptionCreditCardCodeHasNonNumericCharacters(string message) : base(message) { }
    }
}