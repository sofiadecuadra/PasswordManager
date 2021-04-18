using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace GestorPasswordsDominio
{
    public class ManipuladorPassword
    {
        public static TipoFortaleza FortalezaDePassword(String passwordToCheck)
        {
            if (ContieneMenosDe8Caracteres(passwordToCheck)) return TipoFortaleza.Rojo;
            if (ContieneEntre8Y14Caracteres(passwordToCheck)) return TipoFortaleza.Naranja;
            if (ContieneSoloMayusculasYMinusculas(passwordToCheck)) return TipoFortaleza.VerdeClaro;
            if (ContieneSoloMayusculasOMinusculas(passwordToCheck)) return TipoFortaleza.Amarillo;

            return TipoFortaleza.Rojo;
        }

        private static bool ContieneSoloMayusculasYMinusculas(string passwordToCheck)
        {
            return Regex.IsMatch(passwordToCheck, @"^(?=[a-z]+[A-Z]+|[A-Z]+[a-z]+)[a-zA-Z]{14,25}$");
        }

        private static bool ContieneSoloMayusculasOMinusculas(string passwordToCheck)
        {
            return Regex.IsMatch(passwordToCheck, @"^[A-Za-z\s]+$");
        }

        private static bool ContieneMenosDe8Caracteres(string passwordToCheck)
        {
            return passwordToCheck.Length < 8;
        }

        private static bool ContieneEntre8Y14Caracteres(string passwordToCheck)
        {
            return passwordToCheck.Length >= 8 && passwordToCheck.Length <= 14;
        }
    }

    public enum TipoFortaleza
    {
        Rojo = 0,
        Naranja = 1,
        Amarillo = 2,
        VerdeClaro = 3
    }
}
