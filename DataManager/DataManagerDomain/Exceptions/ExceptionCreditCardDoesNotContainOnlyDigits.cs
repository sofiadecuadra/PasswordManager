using System;

namespace DataManagerDomain
{
    public class ExceptionCreditCardDoesNotContainOnlyDigits : ExceptionCreditCard
    {
        public ExceptionCreditCardDoesNotContainOnlyDigits(string message) : base(message) { }
    }
}