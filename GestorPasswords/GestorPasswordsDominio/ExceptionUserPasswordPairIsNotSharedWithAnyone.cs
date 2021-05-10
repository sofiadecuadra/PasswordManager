using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorPasswordsDominio
{
    public class ExceptionUserPasswordPairIsNotSharedWithAnyone : Exception
    {
        public ExceptionUserPasswordPairIsNotSharedWithAnyone() { }
        public ExceptionUserPasswordPairIsNotSharedWithAnyone(string message) : base(message) { }
        public ExceptionUserPasswordPairIsNotSharedWithAnyone(string message, Exception inner) : base(message, inner) { }
    }
}
