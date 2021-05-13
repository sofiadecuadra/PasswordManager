using System;

namespace DataManagerDomain
{
    public class ExceptionCategoryNotExists : Exception
    {
        public ExceptionCategoryNotExists(string message) : base(message) { }
    }
}