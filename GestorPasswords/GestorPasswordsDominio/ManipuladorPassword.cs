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
            return TipoFortaleza.Rojo;
        }
    }

    public enum TipoFortaleza
    {
        Rojo = 0
    }
}
