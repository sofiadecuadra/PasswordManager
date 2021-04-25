using System;

namespace GestorPasswordsDominio
{
    public class ExceptionIncorrectLength : Exception
    {
        public ExceptionIncorrectLength()
        {
        }

        public ExceptionIncorrectLength(string message) : base(message)
        {
            Console.WriteLine(message);
        }

        public ExceptionIncorrectLength(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}