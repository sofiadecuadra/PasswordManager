﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using GestorPasswordsDominio;

namespace GestorPasswordsTest
{
    [TestClass]
    public class SystemTest
    {
        PasswordManager _PasswordManager;
        User myUser;

        [TestInitialize]
        public void Initialize()
        {
            _PasswordManager = new PasswordManager();
            myUser = new User()
            {
                MasterPassword = "myMasterPassword123$",
                Name = "JuanP"
            };
            _PasswordManager.AddUser(myUser);
        }

        [TestMethod]
        public void AddValidUserToSystem()
        {
            User aUser = new User()
            {
                MasterPassword = "myMasterPassword123$",
                Name = "JuanPa"
            };
            Assert.IsTrue(_PasswordManager.AddUser(aUser));
            Assert.IsTrue(_PasswordManager.HasUser(aUser.Name));
        }

        [TestMethod]
        [ExpectedException(typeof(ExceptionIncorrectUserNameLength))]
        public void AddUserWhitNameTooShort()
        {
            User aUser = new User()
            {
                MasterPassword = "myMasterPassword123$",
                Name = "Juan"
            };
            _PasswordManager.AddUser(aUser);
        }

        [TestMethod]
        [ExpectedException(typeof(ExceptionIncorrectUserNameLength))]
        public void AddUserWhitNameTooLong()
        {
            User aUser = new User()
            {
                MasterPassword = "myMasterPassword123$",
                Name = "Juan1234567890123456789012"
            };
            _PasswordManager.AddUser(aUser);
        }

        [TestMethod]
        public void ValidateUserCorrectly()
        {
            Assert.IsTrue(_PasswordManager.ValidateUser("juanp", "myMasterPassword123$"));
        }

        [TestMethod]
        public void ValidateUserNotInLowerCorrectly()
        {
            Assert.IsTrue(_PasswordManager.ValidateUser("JuanP", "myMasterPassword123$"));
        }

        [TestMethod]
        public void ValidateUserWithIncorrectPassword()
        {
            Assert.IsFalse(_PasswordManager.ValidateUser("juanp", "NotThePassword"));
        }

        [TestMethod]
        [ExpectedException(typeof(ExceptionUserDoesNotExist))]
        public void ValidateNonExistingUser()
        {
            _PasswordManager.ValidateUser("NotTheUser", "myMasterPassword123$");
        }

        [TestMethod]
        public void SetCurrentUserCorrectly()
        {
            _PasswordManager.CurrentUser = myUser;
            Assert.AreEqual(myUser.Name, _PasswordManager.CurrentUser.Name);
        }

        [TestMethod]
        [ExpectedException(typeof(ExceptionUserDoesNotExist))]
        public void SetCurrentUserThatDoesNotExist()
        {
            User aUser = new User()
            {
                MasterPassword = "myMasterPassword123$",
                Name = "JuanPa"
            };

            _PasswordManager.CurrentUser = aUser;
        }

        [TestMethod]
        public void ValidateAndSetCurrentUserCorrectly()
        {
            _PasswordManager.ValidateAndSetCurrentUser(myUser.Name, myUser.MasterPassword);
            Assert.AreEqual(myUser.Name, _PasswordManager.CurrentUser.Name);
        }

        [TestMethod]
        [ExpectedException(typeof(ExceptionIncorrectMasterPassword))]
        public void ValidateAndSetCurrentUserWithWrongPassword()
        {
            _PasswordManager.ValidateAndSetCurrentUser(myUser.Name, "NotThePasswordSir");
        }

        [TestMethod]
        [ExpectedException(typeof(ExceptionUserDoesNotExist))]
        public void ValidateAndSetCurrentUserWithWrongName()
        {
            _PasswordManager.ValidateAndSetCurrentUser("ThisIsNotTheName", myUser.MasterPassword);
        }

        [TestMethod]
        public void ShareValidPassword()
        {
            var aUser = new User()
            {
                MasterPassword = "myMasterPassword123$",
                Name = "JuanPa"
            };
            _PasswordManager.CurrentUser = myUser;
            _PasswordManager.AddUser(aUser);
            UserPasswordPair aUserPasswordPair = LoadTestCategoryToMyUserWithAUserPasswordPair();

            _PasswordManager.SharePassword(aUserPasswordPair, aUser.Name);
            Assert.IsTrue(_PasswordManager.FindUser(aUser.Name).HasSharedPasswordOf(aUserPasswordPair.Username, aUserPasswordPair.Site));
            Assert.IsTrue(aUserPasswordPair.HasAccess(aUser.Name));
        }

        [TestMethod]
        [ExpectedException(typeof(ExceptionUserDoesNotExist))]
        public void ShareValidPasswordToUserThatDoesNotExist()
        {
            _PasswordManager.CurrentUser = myUser;
            UserPasswordPair aUserPasswordPair = LoadTestCategoryToMyUserWithAUserPasswordPair();

            _PasswordManager.SharePassword(aUserPasswordPair, "JuanPa");
        }

        [TestMethod]
        public void UnsharePassword()
        {
            var aUser = new User()
            {
                MasterPassword = "myMasterPassword123$",
                Name = "JuanPa"
            };
            _PasswordManager.CurrentUser = myUser;
            _PasswordManager.AddUser(aUser);
            UserPasswordPair aUserPasswordPair = LoadTestCategoryToMyUserWithAUserPasswordPair();

            _PasswordManager.SharePassword(aUserPasswordPair, aUser.Name);

            _PasswordManager.UnsharePassword(aUserPasswordPair, aUser.Name);

            Assert.IsFalse(_PasswordManager.FindUser(aUser.Name).HasSharedPasswordOf(aUserPasswordPair.Username, aUserPasswordPair.Site));
            Assert.IsFalse(aUserPasswordPair.HasAccess(aUser.Name));
        }

        [TestMethod]
        [ExpectedException(typeof(ExceptionUserDoesNotExist))]
        public void UnsharePasswordToUserThatDoesNotExist()
        {
            _PasswordManager.CurrentUser = myUser;
            UserPasswordPair aUserPasswordPair = LoadTestCategoryToMyUserWithAUserPasswordPair();

            _PasswordManager.SharePassword(aUserPasswordPair, "JuanPa");
        }

        private UserPasswordPair LoadTestCategoryToMyUserWithAUserPasswordPair()
        {
            var aCategory = new Category()
            {
                Name = "aCategory",
                User = myUser
            };
            var aUserPasswordPair = new UserPasswordPair()
            {
                Password = "thisIsAPassword",
                Notes = "these are my notes",
                Username = "myUserName",
                Site = "mySite",
                Category = aCategory,
            };
            myUser.AddCategory(aCategory);

            aCategory.AddUserPasswordPair(aUserPasswordPair);
            return aUserPasswordPair;
        }
    }
}
