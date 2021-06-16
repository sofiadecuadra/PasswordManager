using System;

namespace DataManagerDomain
{
    public class ExceptionCreditCardHasExpired : ExceptionCreditCard
    {
        public ExceptionCreditCardHasExpired(string message) : base(message) { }
    }
}