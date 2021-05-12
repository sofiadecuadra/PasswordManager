using System;

namespace GestorPasswordsDominio
{
    public class ExceptionCategoryAlreadyExists : Exception
    {
        public ExceptionCategoryAlreadyExists(string message) : base(message) { }
    }
}