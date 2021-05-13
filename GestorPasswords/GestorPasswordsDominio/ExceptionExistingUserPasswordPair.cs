using System;

namespace DataManagerDomain
{
    public class ExceptionExistingUserPasswordPair : Exception
    {
        public ExceptionExistingUserPasswordPair(string message) : base(message) { }
    }
}