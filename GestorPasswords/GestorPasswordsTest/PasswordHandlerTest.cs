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

        [TestMethod]
        [ExpectedException(typeof(ExceptionIncorrectLength))]
        public void GeneratePasswordWithLengthLessThan5()
        {
            PasswordGenerationConditions conditions = new PasswordGenerationConditions()
            {
                Length = 3,
                HasUpperCase = true,
                HasLowerCase = false,
                HasDigits = false,
                HasSymbols = true,
            };
            _ = PasswordHandler.GenerateRandomPassword(conditions);
        }

        [TestMethod]
        [ExpectedException(typeof(ExceptionIncorrectLength))]
        public void GeneratePasswordWithLengthGreaterThan25()
        {
            PasswordGenerationConditions conditions = new PasswordGenerationConditions()
            {
                Length = 26,
                HasUpperCase = false,
                HasLowerCase = true,
                HasDigits = true,
                HasSymbols = false,
            };
            _ = PasswordHandler.GenerateRandomPassword(conditions);

        }

        [TestMethod]
        [ExpectedException(typeof(ExceptionIncorrectGenerationPasswordType))]
        public void GeneratePasswordWithValidLengthAndNoUpperCaseNoLowerCaseNoDigitsAndNoSymbols()
        {
            PasswordGenerationConditions conditions = new PasswordGenerationConditions()
            {
                Length = 15,
                HasUpperCase = false,
                HasLowerCase = false,
                HasDigits = false,
                HasSymbols = false,
            };
            _ = PasswordHandler.GenerateRandomPassword(conditions);
        }

        [TestMethod]
        public void GeneratePasswordWithLengthLessThan8()
        {
            PasswordGenerationConditions conditions = new PasswordGenerationConditions()
            {
                Length = 7,
                HasUpperCase = true,
                HasLowerCase = true,
                HasDigits = true,
                HasSymbols = true,
            };

            string randomPassword = PasswordHandler.GenerateRandomPassword(conditions);
            Assert.AreEqual(7, randomPassword.Length);
            Assert.AreEqual(PasswordStrengthType.Red, PasswordHandler.PasswordStrength(randomPassword));
        }

        [TestMethod]
        public void GeneratePasswordWithLengthBetween8And14()
        {
            PasswordGenerationConditions conditions = new PasswordGenerationConditions()
            {
                Length = 11,
                HasUpperCase = true,
                HasLowerCase = true,
                HasDigits = true,
                HasSymbols = true,
            };

            string randomPassword = PasswordHandler.GenerateRandomPassword(conditions);
            Assert.AreEqual(11, randomPassword.Length);
            Assert.AreEqual(PasswordStrengthType.Orange, PasswordHandler.PasswordStrength(randomPassword));
        }

        [TestMethod]
        public void GeneratePasswordWithLengthBetween15And25AndOnlyLowers()
        {
            PasswordGenerationConditions conditions = new PasswordGenerationConditions()
            {
                Length = 15,
                HasUpperCase = false,
                HasLowerCase = true,
                HasDigits = false,
                HasSymbols = false,
            };

            string randomPassword = PasswordHandler.GenerateRandomPassword(conditions);
            Assert.AreEqual(15, randomPassword.Length);
            Assert.AreEqual(PasswordStrengthType.Yellow, PasswordHandler.PasswordStrength(randomPassword));
        }

        [TestMethod]
        public void GeneratePasswordWithLengthBetween15And25AndOnlyUppers()
        {
            PasswordGenerationConditions conditions = new PasswordGenerationConditions()
            {
                Length = 17,
                HasUpperCase = true,
                HasLowerCase = false,
                HasDigits = false,
                HasSymbols = false,
            };

            string randomPassword = PasswordHandler.GenerateRandomPassword(conditions);
            Assert.AreEqual(17, randomPassword.Length);
            Assert.AreEqual(PasswordStrengthType.Yellow, PasswordHandler.PasswordStrength(randomPassword));
        }

        [TestMethod]
        public void GeneratePasswordWithLengthBetween15And25AndOnlyDigits()
        {
            PasswordGenerationConditions conditions = new PasswordGenerationConditions()
            {
                Length = 18,
                HasUpperCase = false,
                HasLowerCase = false,
                HasDigits = true,
                HasSymbols = false,
            };

            string randomPassword = PasswordHandler.GenerateRandomPassword(conditions);
            Assert.AreEqual(18, randomPassword.Length);
            Assert.AreEqual(PasswordStrengthType.Yellow, PasswordHandler.PasswordStrength(randomPassword));
        }

        [TestMethod]
        public void GeneratePasswordWithLengthBetween15And25AndOnlySymbols()
        {
            PasswordGenerationConditions conditions = new PasswordGenerationConditions()
            {
                Length = 18,
                HasUpperCase = false,
                HasLowerCase = false,
                HasDigits = false,
                HasSymbols = true,
            };

            string randomPassword = PasswordHandler.GenerateRandomPassword(conditions);
            Assert.AreEqual(18, randomPassword.Length);
            Assert.AreEqual(PasswordStrengthType.Yellow, PasswordHandler.PasswordStrength(randomPassword));
        }

        [TestMethod]
        public void GeneratePasswordWithLengthBetween15And25AndOnlyUppersAndLowers()
        {
            PasswordGenerationConditions conditions = new PasswordGenerationConditions()
            {
                Length = 19,
                HasUpperCase = true,
                HasLowerCase = true,
                HasDigits = false,
                HasSymbols = false,
            };

            string randomPassword = PasswordHandler.GenerateRandomPassword(conditions);
            Assert.AreEqual(19, randomPassword.Length);
            Assert.AreEqual(PasswordStrengthType.LightGreen, PasswordHandler.PasswordStrength(randomPassword));
        }

        [TestMethod]
        public void GeneratePasswordWithLengthBetween15And25AndOnlyLowersAndDigits()
        {
            PasswordGenerationConditions conditions = new PasswordGenerationConditions()
            {
                Length = 19,
                HasUpperCase = false,
                HasLowerCase = true,
                HasDigits = true,
                HasSymbols = false,
            };

            string randomPassword = PasswordHandler.GenerateRandomPassword(conditions);
            Assert.AreEqual(19, randomPassword.Length);
            Assert.AreEqual(PasswordStrengthType.Yellow, PasswordHandler.PasswordStrength(randomPassword));
        }

        [TestMethod]
        public void GeneratePasswordWithLengthBetween15And25AndOnlyLowersAndSymbols()
        {
            PasswordGenerationConditions conditions = new PasswordGenerationConditions()
            {
                Length = 20,
                HasUpperCase = false,
                HasLowerCase = true,
                HasDigits = false,
                HasSymbols = true,
            };

            string randomPassword = PasswordHandler.GenerateRandomPassword(conditions);
            Assert.AreEqual(20, randomPassword.Length);
            Assert.AreEqual(PasswordStrengthType.Yellow, PasswordHandler.PasswordStrength(randomPassword));
        }

        [TestMethod]
        public void GeneratePasswordWithLengthBetween15And25AndOnlyUppersAndDigits()
        {
            PasswordGenerationConditions conditions = new PasswordGenerationConditions()
            {
                Length = 21,
                HasUpperCase = true,
                HasLowerCase = false,
                HasDigits = true,
                HasSymbols = false,
            };

            string randomPassword = PasswordHandler.GenerateRandomPassword(conditions);
            Assert.AreEqual(21, randomPassword.Length);
            Assert.AreEqual(PasswordStrengthType.Yellow, PasswordHandler.PasswordStrength(randomPassword));
        }

        [TestMethod]
        public void GeneratePasswordWithLengthBetween15And25AndOnlyUppersAndSymbols()
        {
            PasswordGenerationConditions conditions = new PasswordGenerationConditions()
            {
                Length = 22,
                HasUpperCase = true,
                HasLowerCase = false,
                HasDigits = false,
                HasSymbols = true,
            };

            string randomPassword = PasswordHandler.GenerateRandomPassword(conditions);
            Assert.AreEqual(22, randomPassword.Length);
            Assert.AreEqual(PasswordStrengthType.Yellow, PasswordHandler.PasswordStrength(randomPassword));
        }
    }
}
