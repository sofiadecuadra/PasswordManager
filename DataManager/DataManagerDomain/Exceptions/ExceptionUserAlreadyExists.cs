using System;

namespace DataManagerDomain.Exceptions
{
    public class ExceptionUserAlreadyExists : Exception
    {
        public ExceptionUserAlreadyExists(string message) : base(message) { }
    }
}
