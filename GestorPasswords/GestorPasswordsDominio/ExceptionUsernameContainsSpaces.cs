using System;

namespace DataManagerDomain
{
    public class ExceptionUsernameContainsSpaces : Exception
    {
        public ExceptionUsernameContainsSpaces(string message) : base(message) { }
    }
}