using System;

namespace DataManagerDomain
{
    public class ExceptionUserAlreadyExists : ExceptionUser
    {
        public ExceptionUserAlreadyExists(string message) : base(message) { }
    }
}
