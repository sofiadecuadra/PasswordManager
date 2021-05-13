using System;

namespace DataManagerDomain
{
    public class ExceptionIncorrectLength : Exception
    {
        public ExceptionIncorrectLength(string message) : base(message) { }
    }
}