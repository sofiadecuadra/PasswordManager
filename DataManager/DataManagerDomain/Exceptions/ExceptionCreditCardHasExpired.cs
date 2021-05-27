using System;

namespace DataManagerDomain
{
    public class ExceptionCreditCardHasExpired : Exception
    {
        public ExceptionCreditCardHasExpired(string message) : base(message) { }
    }
}