using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorPasswordsDominio
{
    public class ExceptionCategoryAlreadyExists : Exception
    {
        public ExceptionCategoryAlreadyExists() { }
        public ExceptionCategoryAlreadyExists(string message) : base(message) { }
        public ExceptionCategoryAlreadyExists(string message, Exception inner) : base(message, inner) { }
    }
}
