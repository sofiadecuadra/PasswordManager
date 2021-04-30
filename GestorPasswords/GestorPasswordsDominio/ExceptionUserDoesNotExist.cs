using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorPasswordsDominio
{
    public class ExceptionUserDoesNotExist : Exception
    {
        public ExceptionUserDoesNotExist() { }
        public ExceptionUserDoesNotExist(string message) : base(message) { }
        public ExceptionUserDoesNotExist(string message, Exception inner) : base(message, inner) { }
    }
}
