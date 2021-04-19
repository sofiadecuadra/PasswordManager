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
            if (unaTarjetaCredito.tipo.Length < 3) return false;
            return (
                TarjetaCreditoContiene16Digitos(unaTarjetaCredito.numero) &&
                TarjetaCreditoContieneSoloDigitos(unaTarjetaCredito.numero));
        }


        public bool TarjetaCreditoContieneSoloDigitos(string numeroTarjetaCredito)
        {
            return Regex.IsMatch(numeroTarjetaCredito, @"^[0-9]+$");
        }
        public bool TarjetaCreditoContiene16Digitos(string numeroTarjetaCredito)
        {
            if (numeroTarjetaCredito.Length == 16) return true;
            return false;
        }
    }
}
