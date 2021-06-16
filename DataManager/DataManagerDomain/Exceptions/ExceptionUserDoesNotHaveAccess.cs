using System;

namespace DataManagerDomain
{
    public class ExceptionUserDoesNotHaveAccess : ExceptionUser
    {
        public ExceptionUserDoesNotHaveAccess(string message) : base(message) { }
    }
}