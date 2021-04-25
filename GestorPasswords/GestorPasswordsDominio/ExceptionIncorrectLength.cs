using System;
using System.Runtime.Serialization;

namespace GestorPasswordsDominio
{
    [Serializable]
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

        protected ExceptionIncorrectLength(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}