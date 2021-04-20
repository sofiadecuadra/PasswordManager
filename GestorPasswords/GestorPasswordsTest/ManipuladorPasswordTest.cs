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
            Assert.AreEqual(TipoFortaleza.Rojo, ManipuladorPassword.PasswordStrength("hola"));
        }

        [TestMethod]
        public void PasswordConLargoEntre8Y14Caracteres()
        {
            Assert.AreEqual(TipoFortaleza.Naranja, ManipuladorPassword.PasswordStrength("holamundoesto"));
        }

        [TestMethod]
        public void PasswordConLargoMayorA14CaracteresSoloMinusculas()
        {
            Assert.AreEqual(TipoFortaleza.Amarillo, ManipuladorPassword.PasswordStrength("holamundoestoesunapass"));
        }

        [TestMethod]
        public void PasswordConLargoMayorA14CaracteresSoloMayusculas()
        {
            Assert.AreEqual(TipoFortaleza.Amarillo, ManipuladorPassword.PasswordStrength("AHHHHHHHHHHHHHHH"));
        }

        [TestMethod]
        public void PasswordConLargoMayorA14CaracteresSoloMayusculasYMinusculas()
        {
            Assert.AreEqual(TipoFortaleza.VerdeClaro, ManipuladorPassword.PasswordStrength("holaMundoEstoEsUnaPass"));
        }

        [TestMethod]
        public void PasswordConLargoMayorA14CaracteresSoloMayusculasMinusculasNumerosYSimbolos()
        {
            Assert.AreEqual(TipoFortaleza.VerdeOscuro, ManipuladorPassword.PasswordStrength("holaMundoEstoEs1234-+@"));
        }

        [TestMethod]
        public void PasswordConLargoMayorA14CaracteresSoloMayusculasMinusculasYSimbolos()
        {
            Assert.AreEqual(TipoFortaleza.VerdeClaro, ManipuladorPassword.PasswordStrength("holaMundoEstoEs-+@"));
        }

        [TestMethod]
        public void PasswordConLargoMayorA14CaracteresSoloMayusculasMinusculasYNumeros()
        {
            Assert.AreEqual(TipoFortaleza.VerdeClaro, ManipuladorPassword.PasswordStrength("holaMundoEstoEs1234"));
        }

        [TestMethod]
        public void PasswordConLargoMayorA14CaracteresSoloNumerosYSimbolos()
        {
            Assert.AreEqual(TipoFortaleza.Amarillo, ManipuladorPassword.PasswordStrength("123456789@!#$%^"));
        }

        [TestMethod]
        public void PasswordConLargoMayorA14CaracteresSoloMayusculasYSimbolos()
        {
            Assert.AreEqual(TipoFortaleza.Amarillo, ManipuladorPassword.PasswordStrength("HOLAESTOSONMAYUS@!#$%^"));
        }

        [TestMethod]
        public void PasswordConLargoMayorA14CaracteresSoloMinusculasYSimbolos()
        {
            Assert.AreEqual(TipoFortaleza.Amarillo, ManipuladorPassword.PasswordStrength("holaestosonminus@!#$%^"));
        }

        [TestMethod]
        public void PasswordConLargoMayorA14CaracteresSoloMayusculasYNumeros()
        {
            Assert.AreEqual(TipoFortaleza.Amarillo, ManipuladorPassword.PasswordStrength("HOLAESTOSONMAYUS12345"));
        }

        [TestMethod]
        public void PasswordConLargoMayorA14CaracteresSoloMinusculasYNumeros()
        {
            Assert.AreEqual(TipoFortaleza.Amarillo, ManipuladorPassword.PasswordStrength("holaestosonminus12345"));
        }

        [TestMethod]
        [ExpectedException(typeof(IncorrectLengthException))]
        public void PasswordConLargoMayorA25Caracteres() => ManipuladorPassword.PasswordStrength("012345678901234567890123456");
    }
}
