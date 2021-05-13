using System;

namespace DataManagerDomain
{
    public class ExceptionCreditCardDoesNotContainOnlyDigits : Exception
    {
        public ExceptionCreditCardDoesNotContainOnlyDigits(string message) : base(message) { }
    }
}