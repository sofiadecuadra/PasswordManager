using Microsoft.VisualStudio.TestTools.UnitTesting;
using GestorPasswordsDominio;
using System;

namespace GestorPasswordsTest
{
    [TestClass]
    public class ManipuladorPasswordTest
    {
        [TestMethod]
        public void EsPasswordDebil()
        {
            Assert.AreEqual(TipoFortaleza.Rojo, ManipuladorPassword.FortalezaDePassword("hola"));
        }

        [TestMethod]
        public void PasswordConLargoEntre8Y14Caracteres()
        {
            Assert.AreEqual(TipoFortaleza.Naranja, ManipuladorPassword.FortalezaDePassword("holamundoesto"));
        }

        [TestMethod]
        public void PasswordConLargoMayorA14CaracteresSoloMinusculas()
        {
            Assert.AreEqual(TipoFortaleza.Amarillo, ManipuladorPassword.FortalezaDePassword("holamundoestoesunapass"));
        }

        [TestMethod]
        public void PasswordConLargoMayorA14CaracteresSoloMayusculas()
        {
            Assert.AreEqual(TipoFortaleza.Amarillo, ManipuladorPassword.FortalezaDePassword("AHHHHHHHHHHHHHHH"));
        }

        [TestMethod]
        public void PasswordConLargoMayorA14CaracteresSoloMayusculasYMinusculas()
        {
            Assert.AreEqual(TipoFortaleza.VerdeClaro, ManipuladorPassword.FortalezaDePassword("holaMundoEstoEsUnaPass"));
        }

        [TestMethod]
        public void PasswordConLargoMayorA14CaracteresSoloMayusculasMinusculasNumerosYSimbolos()
        {
            Assert.AreEqual(TipoFortaleza.VerdeOscuro, ManipuladorPassword.FortalezaDePassword("holaMundoEstoEs1234-+@"));
        }

        [TestMethod]
        public void PasswordConLargoMayorA14CaracteresSoloMayusculasMinusculasYSimbolos()
        {
            Assert.AreEqual(TipoFortaleza.VerdeClaro, ManipuladorPassword.FortalezaDePassword("holaMundoEstoEs-+@"));
        }

        [TestMethod]
        public void PasswordConLargoMayorA14CaracteresSoloMayusculasMinusculasYNumeros()
        {
            Assert.AreEqual(TipoFortaleza.VerdeClaro, ManipuladorPassword.FortalezaDePassword("holaMundoEstoEs1234"));
        }

        [TestMethod]
        public void PasswordConLargoMayorA14CaracteresSoloNumerosYSimbolos()
        {
            Assert.AreEqual(TipoFortaleza.Amarillo, ManipuladorPassword.FortalezaDePassword("123456789@!#$%^"));
        }

        [TestMethod]
        public void PasswordConLargoMayorA14CaracteresSoloMayusculasYSimbolos()
        {
            Assert.AreEqual(TipoFortaleza.Amarillo, ManipuladorPassword.FortalezaDePassword("HOLAESTOSONMAYUS@!#$%^"));
        }

        [TestMethod]
        public void PasswordConLargoMayorA14CaracteresSoloMinusculasYSimbolos()
        {
            Assert.AreEqual(TipoFortaleza.Amarillo, ManipuladorPassword.FortalezaDePassword("holaestosonminus@!#$%^"));
        }

        [TestMethod]
        public void PasswordConLargoMayorA14CaracteresSoloMayusculasYNumeros()
        {
            Assert.AreEqual(TipoFortaleza.Amarillo, ManipuladorPassword.FortalezaDePassword("HOLAESTOSONMAYUS12345"));
        }

        [TestMethod]
        public void PasswordConLargoMayorA14CaracteresSoloMinusculasYNumeros()
        {
            Assert.AreEqual(TipoFortaleza.Amarillo, ManipuladorPassword.FortalezaDePassword("holaestosonminus12345"));
        }

        [TestMethod]
        [ExpectedException(typeof(ExcepcionLargoIncorrecto),
    "LA contrasena debe tener un largo entre 14 y 25 caracteres")]
        public void PasswordConLargoMayorA25Caracteres()
        {
            ManipuladorPassword.FortalezaDePassword("012345678901234567890123456");
        }
    }
}
