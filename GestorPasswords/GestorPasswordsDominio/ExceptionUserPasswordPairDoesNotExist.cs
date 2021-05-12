using System;

namespace GestorPasswordsDominio
{
    public class ExceptionUserPasswordPairDoesNotExist : Exception
    {
        public ExceptionUserPasswordPairDoesNotExist(string message) : base(message) { }
    }
}