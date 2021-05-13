using System;

namespace DataManagerDomain
{
    public class ExceptionUserDoesNotExist : Exception
    {
        public ExceptionUserDoesNotExist(string message) : base(message) { }
    }
}