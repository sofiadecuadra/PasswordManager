using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorPasswordsDominio
{
    public class ExceptionCategoryHasInvalidNameLength : Exception
    {
        public ExceptionCategoryHasInvalidNameLength() { }
        public ExceptionCategoryHasInvalidNameLength(string message) : base(message) { }
        public ExceptionCategoryHasInvalidNameLength(string message, Exception inner) : base(message, inner) { }
    }
}
