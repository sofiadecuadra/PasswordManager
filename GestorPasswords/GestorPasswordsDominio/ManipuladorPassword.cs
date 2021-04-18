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
            if (passwordToCheck.Length < 8) return TipoFortaleza.Rojo;
            if (passwordToCheck.Length >= 8 && passwordToCheck.Length <= 14) return TipoFortaleza.Naranja;

            return TipoFortaleza.Rojo;
        }
    }

    public enum TipoFortaleza
    {
        Rojo = 0,
        Naranja = 1
    }
}
