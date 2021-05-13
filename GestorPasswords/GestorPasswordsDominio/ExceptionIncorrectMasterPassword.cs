using System;

namespace DataManagerDomain
{
    public class ExceptionIncorrectMasterPassword : Exception
    {
        public ExceptionIncorrectMasterPassword(string message) : base(message) { }
    }
}