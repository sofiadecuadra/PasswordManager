using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorPasswordsDominio
{
    public class ExceptionIncorrectGenerationPasswordType : Exception
    {
        public ExceptionIncorrectGenerationPasswordType() { }
        public ExceptionIncorrectGenerationPasswordType(string message) : base(message) { }
        public ExceptionIncorrectGenerationPasswordType(string message, Exception inner) : base(message, inner) { }
    }
}
