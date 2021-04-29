using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using GestorPasswordsDominio;

namespace GestorPasswordsTest
{
    [TestClass]
    public class SystemTest
    {
        PasswordManager _PasswordManager;

        [TestInitialize]
        public void Initialize()
        {
            _PasswordManager = new PasswordManager();
        }

        [TestMethod]
        public void AddValidUserToSystem()
        {
            PasswordManager _PasswordManager= new PasswordManager();
            User myUser = new User() { 
                MasterPassword = "myMasterPassword123$",
                Name = "JuanP"
            };
            Assert.IsTrue(_PasswordManager.AddUser(myUser));
            Assert.IsTrue(_PasswordManager.HasUser(myUser.Name));
        }

        [TestMethod]
        [ExpectedException(typeof(ExceptionIncorrectUserNameLength))]
        public void AddUserWhitNameTooShort()
        {
            PasswordManager _PasswordManager = new PasswordManager();
            User myUser = new User()
            {
                MasterPassword = "myMasterPassword123$",
                Name = "Juan"
            };
        }

        [TestMethod]
        [ExpectedException(typeof(ExceptionIncorrectUserNameLength))]
        public void AddUserWhitNameTooLong()
        {
            PasswordManager _PasswordManager = new PasswordManager();
            User myUser = new User()
            {
                MasterPassword = "myMasterPassword123$",
                Name = "Juan1234567890123456789012"
            };
        }


    }
}
