using System;

namespace DataManagerDomain
{
    public class ExceptionCreditCardDoesNotExist : Exception
    {
        public ExceptionCreditCardDoesNotExist(string message) : base(message) { }
    }
}