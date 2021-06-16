using System;

namespace DataManagerDomain
{
    public class ExceptionIncorrectMasterPassword : ExceptionUser
    {
        public ExceptionIncorrectMasterPassword(string message) : base(message) { }
    }
}