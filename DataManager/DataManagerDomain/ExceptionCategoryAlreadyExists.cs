using System;

namespace DataManagerDomain
{
    public class ExceptionCategoryAlreadyExists : Exception
    {
        public ExceptionCategoryAlreadyExists(string message) : base(message) { }
    }
}