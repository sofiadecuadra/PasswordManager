using System;

namespace DataManagerDomain
{
    public class ExceptionUserDoesNotHaveAccess : Exception
    {
        public ExceptionUserDoesNotHaveAccess(string message) : base(message) { }
    }
}