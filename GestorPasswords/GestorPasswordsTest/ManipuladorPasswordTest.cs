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
            Assert.AreEqual(PasswordStrengthType.Red, PasswordHandler.PasswordStrength("hola"));
        }

        [TestMethod]
        public void PasswordConLargoEntre8Y14Caracteres()
        {
            Assert.AreEqual(PasswordStrengthType.Orange, PasswordHandler.PasswordStrength("holamundoesto"));
        }

        [TestMethod]
        public void PasswordConLargoMayorA14CaracteresSoloMinusculas()
        {
            Assert.AreEqual(PasswordStrengthType.Yellow, PasswordHandler.PasswordStrength("holamundoestoesunapass"));
        }

        [TestMethod]
        public void PasswordConLargoMayorA14CaracteresSoloMayusculas()
        {
            Assert.AreEqual(PasswordStrengthType.Yellow, PasswordHandler.PasswordStrength("AHHHHHHHHHHHHHHH"));
        }

        [TestMethod]
        public void PasswordConLargoMayorA14CaracteresSoloMayusculasYMinusculas()
        {
            Assert.AreEqual(PasswordStrengthType.LightGreen, PasswordHandler.PasswordStrength("holaMundoEstoEsUnaPass"));
        }

        [TestMethod]
        public void PasswordConLargoMayorA14CaracteresSoloMayusculasMinusculasNumerosYSimbolos()
        {
            Assert.AreEqual(PasswordStrengthType.DarkGreen, PasswordHandler.PasswordStrength("holaMundoEstoEs1234-+@"));
        }

        [TestMethod]
        public void PasswordConLargoMayorA14CaracteresSoloMayusculasMinusculasYSimbolos()
        {
            Assert.AreEqual(PasswordStrengthType.LightGreen, PasswordHandler.PasswordStrength("holaMundoEstoEs-+@"));
        }

        [TestMethod]
        public void PasswordConLargoMayorA14CaracteresSoloMayusculasMinusculasYNumeros()
        {
            Assert.AreEqual(PasswordStrengthType.LightGreen, PasswordHandler.PasswordStrength("holaMundoEstoEs1234"));
        }

        [TestMethod]
        public void PasswordConLargoMayorA14CaracteresSoloNumerosYSimbolos()
        {
            Assert.AreEqual(PasswordStrengthType.Yellow, PasswordHandler.PasswordStrength("123456789@!#$%^"));
        }

        [TestMethod]
        public void PasswordConLargoMayorA14CaracteresSoloMayusculasYSimbolos()
        {
            Assert.AreEqual(PasswordStrengthType.Yellow, PasswordHandler.PasswordStrength("HOLAESTOSONMAYUS@!#$%^"));
        }

        [TestMethod]
        public void PasswordConLargoMayorA14CaracteresSoloMinusculasYSimbolos()
        {
            Assert.AreEqual(PasswordStrengthType.Yellow, PasswordHandler.PasswordStrength("holaestosonminus@!#$%^"));
        }

        [TestMethod]
        public void PasswordConLargoMayorA14CaracteresSoloMayusculasYNumeros()
        {
            Assert.AreEqual(PasswordStrengthType.Yellow, PasswordHandler.PasswordStrength("HOLAESTOSONMAYUS12345"));
        }

        [TestMethod]
        public void PasswordConLargoMayorA14CaracteresSoloMinusculasYNumeros()
        {
            Assert.AreEqual(PasswordStrengthType.Yellow, PasswordHandler.PasswordStrength("holaestosonminus12345"));
        }

        [TestMethod]
        [ExpectedException(typeof(IncorrectLengthException))]
        public void PasswordConLargoMayorA25Caracteres() => PasswordHandler.PasswordStrength("012345678901234567890123456");

        [TestMethod]
        [ExpectedException(typeof(IncorrectLengthException))]
        public void PasswordConLargoMenorA5Caracteres() => PasswordHandler.PasswordStrength("0123");
    }
}
