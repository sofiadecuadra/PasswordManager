using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace GestorPasswordsDominio
{
    public class Categoria
    {
        public bool AgregarTarjetaCredito(TarjetaCredito unaTarjetaCredito)
        {
            if (TarjetaCreditoContiene16Digitos(unaTarjetaCredito.numero) && Regex.IsMatch(unaTarjetaCredito.numero, @"^[0-9]+$")) return true;          
            return false;
        }

        public bool TarjetaCreditoContiene16Digitos(string numeroTarjetaCredito)
        {
            if (numeroTarjetaCredito.Length == 16) return true;
            return false;
        }
    }
}
