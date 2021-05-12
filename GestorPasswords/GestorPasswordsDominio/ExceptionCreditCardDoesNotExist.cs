using System;

namespace GestorPasswordsDominio
{
    public class ExceptionCreditCardDoesNotExist : Exception
    {
        public ExceptionCreditCardDoesNotExist(string message) : base(message) { }
    }
}