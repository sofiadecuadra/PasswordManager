using Microsoft.VisualStudio.TestTools.UnitTesting;
using GestorPasswordsDominio;
using System;

namespace GestorPasswordsTest
{
    [TestClass]
    public class PasswordHandlerTest
    {
        [TestMethod]
        public void IsWeakPassword()
        {
            Assert.AreEqual(PasswordStrengthType.Red, PasswordHandler.PasswordStrength("hola1"));
        }

        [TestMethod]
        public void PasswordWithLengthBetween8And14Characters()
        {
            Assert.AreEqual(PasswordStrengthType.Orange, PasswordHandler.PasswordStrength("holamundoesto"));
        }

        [TestMethod]
        public void PasswordWithLengthOver14AndJustLowerCase()
        {
            Assert.AreEqual(PasswordStrengthType.Yellow, PasswordHandler.PasswordStrength("holamundoestoesunapass"));
        }

        [TestMethod]
        public void PasswordWithLengthOver14AndJustUpperCase()
        {
            Assert.AreEqual(PasswordStrengthType.Yellow, PasswordHandler.PasswordStrength("AHHHHHHHHHHHHHHH"));
        }

        [TestMethod]
        public void PasswordWithLengthOver14AndJustUpperAndLowerCase()
        {
            Assert.AreEqual(PasswordStrengthType.LightGreen, PasswordHandler.PasswordStrength("holaMundoEstoEsUnaPass"));
        }

        [TestMethod]
        public void PasswordWithLengthOver14AndJustUpperLowerCaseNumersAndSymbols()
        {
            Assert.AreEqual(PasswordStrengthType.DarkGreen, PasswordHandler.PasswordStrength("holaMundoEstoEs1234-+@"));
        }

        [TestMethod]
        public void PasswordWithLengthOver14AndJustUpperLowerCaseAndSymbols()
        {
            Assert.AreEqual(PasswordStrengthType.LightGreen, PasswordHandler.PasswordStrength("holaMundoEstoEs-+@"));
        }

        [TestMethod]
        public void PasswordWithLengthOver14AndJustUpperLowerCaseAndNumbers()
        {
            Assert.AreEqual(PasswordStrengthType.LightGreen, PasswordHandler.PasswordStrength("holaMundoEstoEs1234"));
        }

        [TestMethod]
        public void PasswordWithLengthOver14AndJustNumbersAndSymbols()
        {
            Assert.AreEqual(PasswordStrengthType.Yellow, PasswordHandler.PasswordStrength("123456789@!#$%^"));
        }

        [TestMethod]
        public void PasswordWithLengthOver14AndJustUpperCaseAndSymbols()
        {
            Assert.AreEqual(PasswordStrengthType.Yellow, PasswordHandler.PasswordStrength("HOLAESTOSONMAYUS@!#$%^"));
        }

        [TestMethod]
        public void PasswordWithLengthOver14AndJustLowerCaseAndSymbols()
        {
            Assert.AreEqual(PasswordStrengthType.Yellow, PasswordHandler.PasswordStrength("holaestosonminus@!#$%^"));
        }

        [TestMethod]
        public void PasswordWithLengthOver14AndJustUpperCaseAndNumbers()
        {
            Assert.AreEqual(PasswordStrengthType.Yellow, PasswordHandler.PasswordStrength("HOLAESTOSONMAYUS12345"));
        }

        [TestMethod]
        public void PasswordWithLengthOver14AndJustLowerCaseAndNumbers()
        {
            Assert.AreEqual(PasswordStrengthType.Yellow, PasswordHandler.PasswordStrength("holaestosonminus12345"));
        }

        [TestMethod]
        public void PasswordWithLengthOver14AndJustNumbers()
        {
            Assert.AreEqual(PasswordStrengthType.Yellow, PasswordHandler.PasswordStrength("123456789012345"));
        }

        [TestMethod]
        public void PasswordWithLengthOver14AndJustNumbersSymbolsAndUpperCase()
        {
            Assert.AreEqual(PasswordStrengthType.LightGreen, PasswordHandler.PasswordStrength("1234567890@!#$HOLA"));
        }

        [TestMethod]
        public void PasswordWithLengthOver14AndJustNumbersSymbolsAndLowerCase()
        {
            Assert.AreEqual(PasswordStrengthType.LightGreen, PasswordHandler.PasswordStrength("1234567890@!#$hola"));
        }

        [TestMethod]
        [ExpectedException(typeof(ExceptionIncorrectLength))]
        public void PasswordWithLengthOver25() => PasswordHandler.PasswordStrength("012345678901234567890123456");

        [TestMethod]
        [ExpectedException(typeof(ExceptionIncorrectLength))]
        public void PasswordWithLengthUnder5() => PasswordHandler.PasswordStrength("0123");
    }
}
