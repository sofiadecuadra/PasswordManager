using System;

namespace GestorPasswordsDominio
{
    public class ExceptionCreditCardHasExpired : Exception
    {
        public ExceptionCreditCardHasExpired(string message) : base(message) { }
    }
}