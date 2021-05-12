using System;

namespace GestorPasswordsDominio
{
    public class ExceptionUserPasswordPairIsNotSharedWithAnyone : Exception
    {
        public ExceptionUserPasswordPairIsNotSharedWithAnyone(string message) : base(message) { }
    }
}