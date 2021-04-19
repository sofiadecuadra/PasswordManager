using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorPasswordsDominio
{
    public class Categoria
    {
        public bool AgregarTarjetaCredito(TarjetaCredito unaTarjetaCredito)
        {
            if(unaTarjetaCredito.numero.Length == 16)
            {
                return true;
            }
            return false;
        }
    }
}
