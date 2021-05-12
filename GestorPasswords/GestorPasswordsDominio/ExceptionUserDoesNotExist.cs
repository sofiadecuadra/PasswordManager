using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorPasswordsDominio
{
    public class ExceptionUserDoesNotExist : Exception
    {
        public ExceptionUserDoesNotExist(string message) : base(message) { }
    }
}
