using System;

namespace DataManagerDomain
{
    public class ExceptionUserPasswordPairIsNotSharedWithAnyone : ExceptionUserPasswordPair
    {
        public ExceptionUserPasswordPairIsNotSharedWithAnyone(string message) : base(message) { }
    }
}