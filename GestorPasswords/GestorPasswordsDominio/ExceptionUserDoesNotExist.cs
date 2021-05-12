using System;

namespace GestorPasswordsDominio
{
    public class ExceptionUserDoesNotExist : Exception
    {
        public ExceptionUserDoesNotExist(string message) : base(message) { }
    }
}