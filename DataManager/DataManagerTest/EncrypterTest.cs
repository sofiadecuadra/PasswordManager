using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using DataManagerDomain;

namespace DataManagerTest
{
    [TestClass]
    public class EncrypterTest
    {
        private string publicKey;
        private string privateKey;
        private string password;
        private string encryptedPassword;

        [TestInitialize]
        public void Initialize()
        {
            var keys = Encrypter.GenerateKeys();
            publicKey = keys.Item2;
            privateKey = keys.Item1;
            password = "myPassword";
            encryptedPassword = Encrypter.Encrypt(password, publicKey);
        }

        [TestMethod]
        public void ValidateEncryption()
        {
            var decriptedPassword = Encrypter.Decrypt(encryptedPassword, privateKey);

            Assert.AreEqual(password, decriptedPassword);
        }
    }
}
