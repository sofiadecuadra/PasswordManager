using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorPasswordsDominio
{
    public class PasswordGenerationConditions
    {
        public int Length { get; set; }
        public bool HasUpperCase { get; set; }
        public bool HasLowerCase { get; set; }
        public bool HasDigits { get; set; }
        public bool HasSpecials{ get; set; }
    }
}
