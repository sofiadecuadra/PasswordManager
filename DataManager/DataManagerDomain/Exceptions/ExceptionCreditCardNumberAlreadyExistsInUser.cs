using System;

namespace DataManagerDomain
{
    public class ExceptionCreditCardNumberAlreadyExistsInUser : ExceptionCreditCard
    {
        public ExceptionCreditCardNumberAlreadyExistsInUser(string message) : base(message) { }
    }
}