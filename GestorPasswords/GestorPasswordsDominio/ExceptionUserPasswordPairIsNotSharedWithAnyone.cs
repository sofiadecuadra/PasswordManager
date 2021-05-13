using System;

namespace DataManagerDomain
{
    public class ExceptionUserPasswordPairIsNotSharedWithAnyone : Exception
    {
        public ExceptionUserPasswordPairIsNotSharedWithAnyone(string message) : base(message) { }
    }
}