using System;

namespace DataManagerDomain
{
    public class ExceptionUserAlreadyExists : Exception
    {
        public ExceptionUserAlreadyExists(string message) : base(message) { }
    }
}
