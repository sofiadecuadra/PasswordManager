using System;

namespace DataManagerDomain
{
    public class ExceptionUserAlreadyHasAccess : ExceptionUser
    {
        public ExceptionUserAlreadyHasAccess(string message) : base(message) { }
    }
}