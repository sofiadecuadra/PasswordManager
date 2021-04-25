using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorPasswordsDominio
{
    class ExceptionCategoryNotExists : Exception
    {
        public ExceptionCategoryNotExists() { }
        public ExceptionCategoryNotExists(string message) : base(message) { }
        public ExceptionCategoryNotExists(string message, Exception inner) : base(message, inner) { }
    }
}
