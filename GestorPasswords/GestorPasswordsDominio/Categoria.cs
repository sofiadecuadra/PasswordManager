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
        public Usuario User { get; set; }
        public Hashtable listaTarjetasCredito;
        public Hashtable userPasswordPairsHash;


        public Categoria()
        {
            this.listaTarjetasCredito = new Hashtable();
            this.userPasswordPairsHash = new Hashtable();
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
            return !User.NumeroTarjetaCreditoExistente(numeroTarjetaCredito);
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

        public bool AddUserPasswordPair(UserPasswordPair aUserPasswordPair)
        {
            bool pairAdded = false;

            if (UserPasswordPairAlredyExistsInUser(aUserPasswordPair.Username, aUserPasswordPair.Site))
            {
                throw new ExceptionExistingUserPasswordPair();
            }

            if (!UsernameHasValidLength(aUserPasswordPair.Username))
            {
                throw new ExceptionUserPasswordPairHasInvalidUsernameLength("The username's length must be between 5 and 25, but it's current length is " + aUserPasswordPair.Username);
            }

            if (!PasswordHasValidLength(aUserPasswordPair.Password))
            {
                throw new ExceptionUserPasswordPairHasInvalidPasswordLength("The password's length must be between 5 and 25, but it's current length is " + aUserPasswordPair.Password);
            }

            if (!siteHasValidLength(aUserPasswordPair.Site))
            {
                throw new ExceptionUserPasswordPairHasInvalidSiteLength("The site's length must be between 5 and 25, but it's current length is " + aUserPasswordPair.Site);
            }

            if (notesHaveValidLength(aUserPasswordPair.Notes))
            {
                this.userPasswordPairsHash.Add(aUserPasswordPair.Site + aUserPasswordPair.Username, aUserPasswordPair);
                pairAdded = true;
            }
            else
            {
                throw new ExceptionUserPasswordPairHasInvalidNotesLength("The notes' length must be up to 250, but it's current length is " + aUserPasswordPair.Notes);
            }

            return pairAdded;
        }

        private static bool PasswordHasValidLength(String password)
        {
            return password.Length >= 5 && password.Length <= 25;
        }

        private static bool UsernameHasValidLength(String username)
        {
            return username.Length >= 5 && username.Length <= 25;
        }

        private static bool siteHasValidLength(String site)
        {
            return site.Length >= 3 && site.Length <= 25;
        }

        private static bool notesHaveValidLength(String notes)
        {
            return notes.Length <= 250;
        }

        private bool UserPasswordPairAlredyExistsInUser(string username, string site)
        {
            return this.User.UserPasswordPairExists(username, site);
        }

        public bool UserPasswordPairAlredyExistsInCategory(string username, string site)
        {
            return this.userPasswordPairsHash.ContainsKey(site + username);
        }
    }
}
