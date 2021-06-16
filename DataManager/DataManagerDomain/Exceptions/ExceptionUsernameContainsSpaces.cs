using System;

namespace DataManagerDomain
{
    public class ExceptionUsernameContainsSpaces : ExceptionUser
    {
        public ExceptionUsernameContainsSpaces(string message) : base(message) { }
    }
}