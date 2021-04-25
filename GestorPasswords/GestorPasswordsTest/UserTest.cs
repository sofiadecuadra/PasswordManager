using GestorPasswordsDominio;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace GestorPasswordsTest
{
    [TestClass]
    public class UserTest
    {
        private User aUser;

        [TestInitialize]
        public void Initialize()
        {
            aUser = new User()
            {
                MasterPassword = "myPassword"
            };
        }

        [TestMethod]
        [ExpectedException(typeof(ExceptionIncorrectMasterPassword))]
        public void IncorrectMasterPassword()
        {
            string currentPassword = "aWrongPassword";
            string newPassword = "myNewPassword";
            aUser.ChangeMasterPassword(currentPassword, newPassword);
        }

        [TestMethod]
        [ExpectedException(typeof(ExceptionIncorrectLength))]
        public void NewMasterPasswordWithLengthUnder5()
        {
            string currentPassword = "myPassword";
            string newPassword = "new";
            aUser.ChangeMasterPassword(currentPassword, newPassword);
        }

        [TestMethod]
        [ExpectedException(typeof(ExceptionIncorrectLength))]
        public void NewMasterPasswordWithLengthOver25()
        {
            string currentPassword = "myPassword";
            string newPassword = "newPasswordnewPasswordnewPassword";
            aUser.ChangeMasterPassword(currentPassword, newPassword);
        }

        [TestMethod]
        public void ChangeMasterPasswordCorrectly()
        {
            string currentPassword = "myPassword";
            string newPassword = "myNewPassword";
            Assert.IsTrue(aUser.ChangeMasterPassword(currentPassword, newPassword));
        }

    }
}
