using System;

namespace DataManagerDomain
{
    public class ExceptionCreditCardNumberAlreadyExistsInUser : Exception
    {
        public ExceptionCreditCardNumberAlreadyExistsInUser(string message) : base(message) { }
    }
}