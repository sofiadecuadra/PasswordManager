using System;

namespace DataManagerDomain
{
    public class ExceptionUserAlreadyHasAccess : Exception
    {
        public ExceptionUserAlreadyHasAccess(string message) : base(message) { }
    }
}