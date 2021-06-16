using System;

namespace DataManagerDomain
{
    public class ExceptionUserPasswordPairDoesNotExist : ExceptionUserPasswordPair
    {
        public ExceptionUserPasswordPairDoesNotExist(string message) : base(message) { }
    }
}