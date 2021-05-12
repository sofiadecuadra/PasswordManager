using System;

namespace GestorPasswordsDominio
{
    public class ExceptionIncorrectMasterPassword : Exception
    {
        public ExceptionIncorrectMasterPassword(string message) : base(message) { }
    }
}