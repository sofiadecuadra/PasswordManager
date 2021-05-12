using System;

namespace GestorPasswordsDominio
{
    public class ExceptionCreditCardNumberAlreadyExistsInUser : Exception
    {
        public ExceptionCreditCardNumberAlreadyExistsInUser(string message) : base(message) { }
    }
}