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
            return (
                NumeroTarjetaCreditoContieneSoloDigitos(unaTarjetaCredito.numero) &&
                NumeroTarjetaCreditoContiene16Digitos(unaTarjetaCredito.numero) &&
                TextoConLargoEntre3y25Caracteres(unaTarjetaCredito.tipo) &&
                TextoConLargoEntre3y25Caracteres(unaTarjetaCredito.nombre) &&
                CodigoTarjetaCreditoCon3o4Caracteres(unaTarjetaCredito.codigo) &&
                NotasConLargoMenorA250Caracteres(unaTarjetaCredito.notas));
        }

        public bool NotasConLargoMenorA250Caracteres (string notas)
        {
            return notas.Length <= 250;
        }
        public bool CodigoTarjetaCreditoCon3o4Caracteres(string codigo)
        {
            return codigo.Length == 3 || codigo.Length == 4;
        }

        public bool TextoConLargoEntre3y25Caracteres(string texto)
        {
            return texto.Length >= 3 && texto.Length <= 25;
        }

        public bool NumeroTarjetaCreditoContieneSoloDigitos(string numeroTarjetaCredito)
        {
            return Regex.IsMatch(numeroTarjetaCredito, @"^[0-9]+$");
        }

        public bool NumeroTarjetaCreditoContiene16Digitos(string numeroTarjetaCredito)
        {
            if (numeroTarjetaCredito.Length == 16) return true;
            return false;
        }
    }
}
