using System;

namespace GestorPasswordsDominio
{
    public class ExceptionCreditCardDoesNotContainOnlyDigits : Exception
    {
        public ExceptionCreditCardDoesNotContainOnlyDigits(string message) : base(message) { }
    }
}