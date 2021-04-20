using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace GestorPasswordsDominio
{
    public class Categoria
    {
        public Usuario usuario;
        public Hashtable listaTarjetasCredito;

        public Categoria()
        {
            this.listaTarjetasCredito = new Hashtable();
        }
        public bool AgregarTarjetaCredito(TarjetaCredito unaTarjetaCredito)
        {
            if (ValidarTarjeta(unaTarjetaCredito))
            {
                listaTarjetasCredito.Add(unaTarjetaCredito.numero, unaTarjetaCredito);
                return true;
            }
            return false;
        }

        public bool NumeroDeTarjetaExistenteEnLaCategoria(string numeroTarjetaCredito)
        {
            return listaTarjetasCredito.ContainsKey(numeroTarjetaCredito);
        }

        public bool NumeroTarjetaCreditoNoExisteEnUsuario(string numeroTarjetaCredito)
        {
            return !usuario.NumeroTarjetaCreditoExistente(numeroTarjetaCredito);
        }

        public bool ValidarTarjeta(TarjetaCredito unaTarjetaCredito)
        {
            return (
                NumeroTarjetaCreditoContieneSoloDigitos(unaTarjetaCredito.numero) &&
                NumeroTarjetaCreditoContiene16Digitos(unaTarjetaCredito.numero) &&
                TextoConLargoEntre3y25Caracteres(unaTarjetaCredito.tipo) &&
                TextoConLargoEntre3y25Caracteres(unaTarjetaCredito.nombre) &&
                CodigoTarjetaCreditoCon3o4Caracteres(unaTarjetaCredito.codigo) &&
                NotasConLargoMenorA250Caracteres(unaTarjetaCredito.notas) &&
                NumeroTarjetaCreditoNoExisteEnUsuario(unaTarjetaCredito.numero));
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

        // -----------------------------------------------

        public bool AddUserPasswordPair(UserPasswordPair aUserPasswordPair)
        {
            throw new NotImplementedException();
        }
    }
}
