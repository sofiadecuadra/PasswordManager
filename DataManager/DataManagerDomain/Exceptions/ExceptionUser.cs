using System;

namespace DataManagerDomain
{
    public class ExceptionUser : Exception
    {
        public ExceptionUser(string message) : base(message) { }
    }
}