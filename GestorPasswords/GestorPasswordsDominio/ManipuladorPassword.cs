using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorPasswordsDominio
{
    public class ManipuladorPassword
    {
        public static TipoFortaleza FortalezaDePassword(String passwordToCheck)
        {
            if (MenosDe8Caracteres(passwordToCheck)) return TipoFortaleza.Rojo;
            if (Entre8Y14Caracteres(passwordToCheck)) return TipoFortaleza.Naranja;

            return TipoFortaleza.Rojo;
        }

        private static bool MenosDe8Caracteres(string passwordToCheck)
        {
            return passwordToCheck.Length < 8;
        }

        private static bool Entre8Y14Caracteres(string passwordToCheck)
        {
            return passwordToCheck.Length >= 8 && passwordToCheck.Length <= 14;
        }
    }

    public enum TipoFortaleza
    {
        Rojo = 0,
        Naranja = 1
    }
}
