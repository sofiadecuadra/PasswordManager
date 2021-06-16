using System;

namespace DataManagerDomain
{
    public class ExceptionUserDoesNotExist : ExceptionUser
    {
        public ExceptionUserDoesNotExist(string message) : base(message) { }
    }
}