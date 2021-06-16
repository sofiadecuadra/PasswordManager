using System;

namespace DataManagerDomain
{
    public class ExceptionCreditCard : Exception
    {
        public ExceptionCreditCard(string message) : base(message) { }
    }
}