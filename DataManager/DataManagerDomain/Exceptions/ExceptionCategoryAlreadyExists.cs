using System;

namespace DataManagerDomain
{
    public class ExceptionCategoryAlreadyExists : ExceptionCategory
    {
        public ExceptionCategoryAlreadyExists(string message) : base(message) { }
    }
}