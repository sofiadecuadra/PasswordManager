using System;

namespace DataManagerDomain
{
    public class ExceptionCategoryNotExists : ExceptionCategory
    {
        public ExceptionCategoryNotExists(string message) : base(message) { }
    }
}