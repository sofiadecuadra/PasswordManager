using System;

namespace GestorPasswordsDominio
{
    public class ExceptionUsernameContainsSpaces : Exception
    {
        public ExceptionUsernameContainsSpaces(string message) : base(message) { }
    }
}