using System;

namespace GestorPasswordsDominio
{
    public class ExceptionIncorrectLength : Exception
    {
        public ExceptionIncorrectLength(string message) : base(message)
        {
            Console.WriteLine(message);
        }
    }
}