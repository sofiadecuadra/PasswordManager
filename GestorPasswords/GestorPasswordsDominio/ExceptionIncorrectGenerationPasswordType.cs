using System;

namespace GestorPasswordsDominio
{
    public class ExceptionIncorrectGenerationPasswordType : Exception
    {
        public ExceptionIncorrectGenerationPasswordType(string message) : base(message) { }
    }
}