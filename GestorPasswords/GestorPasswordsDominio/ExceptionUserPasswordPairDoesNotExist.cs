using System;

namespace DataManagerDomain
{
    public class ExceptionUserPasswordPairDoesNotExist : Exception
    {
        public ExceptionUserPasswordPairDoesNotExist(string message) : base(message) { }
    }
}