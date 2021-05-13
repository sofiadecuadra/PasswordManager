using System;

namespace DataManagerDomain
{
    public class ExceptionIncorrectGenerationPasswordType : Exception
    {
        public ExceptionIncorrectGenerationPasswordType(string message) : base(message) { }
    }
}