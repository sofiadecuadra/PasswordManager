using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace GestorPasswordsDominio
{
    public class CreditCard
    {
        private string number;
        public string Number
        {
            get { return number; }
            set {
                 number = value.Replace(" ", string.Empty);
            }
        }
        public string Type { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string Notes { get; set; }
        public DateTime ExpirationDate { get; set; }
        public Category Category { get; set; }
    }
}
