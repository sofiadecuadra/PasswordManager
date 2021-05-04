using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorPasswordsDominio
{
    public class TextBoxDataBreaches : IDataBreachesFormatter
    {
        public string txtDataBreaches;
        public string [] ConvertToArray ()
        {
            return txtDataBreaches.Split('\n');
        }

    }
}
