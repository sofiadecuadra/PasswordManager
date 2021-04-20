using System;
using System.Runtime.Serialization;

namespace GestorPasswordsDominio
{
    [Serializable]
    public class IncorrectLengthException : Exception
    {
        public IncorrectLengthException()
        {
        }

        public IncorrectLengthException(string message) : base(message)
        {
            Console.WriteLine(message);
        }

        public IncorrectLengthException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected IncorrectLengthException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}