using System;

namespace DataManagerDomain
{
    public class ExceptionCreditCardDoesNotExist : ExceptionCreditCard
    {
        public ExceptionCreditCardDoesNotExist(string message) : base(message) { }
    }
}