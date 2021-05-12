using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorPasswordsDominio
{
    public class ExceptionCategoryNotExists : Exception
    {
        public ExceptionCategoryNotExists(string message) : base(message) { }
    }
}
