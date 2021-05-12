using System;

namespace GestorPasswordsDominio
{
    public class ExceptionCategoryNotExists : Exception
    {
        public ExceptionCategoryNotExists(string message) : base(message) { }
    }
}