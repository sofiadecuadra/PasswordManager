using System;

namespace DataManagerDomain
{
    public class ExceptionExistingUserPasswordPair : ExceptionUserPasswordPair
    {
        public ExceptionExistingUserPasswordPair(string message) : base(message) { }
    }
}