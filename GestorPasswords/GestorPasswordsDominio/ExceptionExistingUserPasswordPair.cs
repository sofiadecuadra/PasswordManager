using System;

namespace GestorPasswordsDominio
{
    public class ExceptionExistingUserPasswordPair : Exception
    {
        public ExceptionExistingUserPasswordPair(string message) : base(message) { }
    }
}