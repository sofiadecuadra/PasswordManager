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
            User myUser = new User()
            {
                MasterPassword = "myMasterPassword123$",
                Name = "Juan1234567890123456789012"
            };
        }

        [TestMethod]
        public void ValidateUserCorrectly()
        {
            User myUser = new User()
            {
                MasterPassword = "myMasterPassword123$",
                Name = "JuanP"
            };
            _PasswordManager.AddUser(myUser);

            Assert.IsTrue(_PasswordManager.ValidateUser("juanp", "myMasterPassword123$"));
        }

        [TestMethod]
        public void ValidateUserNotInLowerCorrectly()
        {
            User myUser = new User()
            {
                MasterPassword = "myMasterPassword123$",
                Name = "JuanP"
            };
            _PasswordManager.AddUser(myUser);

            Assert.IsTrue(_PasswordManager.ValidateUser("JuanP", "myMasterPassword123$"));
        }

        [TestMethod]
        public void ValidateUserWithIncorrectPassword()
        {
            User myUser = new User()
            {
                MasterPassword = "myMasterPassword123$",
                Name = "JuanP"
            };
            _PasswordManager.AddUser(myUser);

            Assert.IsFalse(_PasswordManager.ValidateUser("juanp", "NotThePassword"));
        }

        [TestMethod]
        [ExpectedException(typeof(ExceptionUserDoesNotExist))]
        public void ValidateNonExistingUser()
        {
            User myUser = new User()
            {
                MasterPassword = "myMasterPassword123$",
                Name = "JuanP"
            };
            _PasswordManager.AddUser(myUser);

            _PasswordManager.ValidateUser("NotTheUser", "myMasterPassword123$");
        }

        [TestMethod]
        public void SetCurrentUserCorrectly()
        {
            User myUser = new User()
            {
                MasterPassword = "myMasterPassword123$",
                Name = "JuanP"
            };
            _PasswordManager.AddUser(myUser);

            _PasswordManager.CurrentUser = myUser;
            Assert.AreEqual(myUser.Name, _PasswordManager.CurrentUser.Name);
        }

        [TestMethod]
        [ExpectedException(typeof(ExceptionUserDoesNotExist))]
        public void SetCurrentUserThatDoesNotExist()
        {
            User myUser = new User()
            {
                MasterPassword = "myMasterPassword123$",
                Name = "JuanP"
            };

            _PasswordManager.CurrentUser = myUser;
        }
    }
}
