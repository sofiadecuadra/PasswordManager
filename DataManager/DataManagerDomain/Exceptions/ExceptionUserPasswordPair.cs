using System;

namespace DataManagerDomain
{
    public class ExceptionUserPasswordPair : Exception
    {
        public ExceptionUserPasswordPair(string message) : base(message) { }
    }
}