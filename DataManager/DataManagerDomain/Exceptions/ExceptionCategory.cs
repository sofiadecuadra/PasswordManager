using System;

namespace DataManagerDomain
{
    public class ExceptionCategory : Exception
    {
        public ExceptionCategory(string message) : base(message) { }
    }
}
