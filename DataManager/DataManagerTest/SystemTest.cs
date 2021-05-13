﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using DataManagerDomain;

namespace DataManagerTest
{
    [TestClass]
    public class SystemTest
    {
        DataManager _PasswordManager;
        User myUser;

        [TestInitialize]
        public void Initialize()
        {
            _PasswordManager = new DataManager();
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
        [ExpectedException(typeof(ExceptionIncorrectLength))]
        public void AddUserWithNameTooShort()
        {
            User aUser = new User()
            {
                MasterPassword = "myMasterPassword123$",
                Name = "Juan"
            };
            _PasswordManager.AddUser(aUser);
        }

        [TestMethod]
        [ExpectedException(typeof(ExceptionIncorrectLength))]
        public void AddUserWithNameTooLong()
        {
            User aUser = new User()
            {
                MasterPassword = "myMasterPassword123$",
                Name = "Juan1234567890123456789012"
            };
            _PasswordManager.AddUser(aUser);
        }

        [TestMethod]
        [ExpectedException(typeof(ExceptionUsernameContainsSpaces))]
        public void AddUserWithUsernameContainingBlankSpacesBetweenCharacters()
        {
            User aUser = new User()
            {
                MasterPassword = "myMasterPassword123$",
                Name = "Juan 12345 6789"
            };
            _PasswordManager.AddUser(aUser);
        }


        [TestMethod]
        public void AddUserWithUsernameContainingBlankSpacesAtTheStart()
        {
            User aUser = new User()
            {
                MasterPassword = "myMasterPassword123$",
                Name = "      Juan123456789"
            };
            Assert.IsTrue(_PasswordManager.AddUser(aUser));
            Assert.IsTrue(_PasswordManager.HasUser("Juan123456789"));
        }

        [TestMethod]
        public void AddUserWithUsernameContainingLotsOfBlankSpacesAtTheStart()
        {
            User aUser = new User()
            {
                MasterPassword = "myMasterPassword123$",
                Name = "                                                                   Juan123456789"
            };
            Assert.IsTrue(_PasswordManager.AddUser(aUser));
            Assert.IsTrue(_PasswordManager.HasUser("Juan123456789"));
        }

        [TestMethod]
        public void AddUserWithUsernameContainingBlankSpacesAtTheEnd()
        {
            User aUser = new User()
            {
                MasterPassword = "myMasterPassword123$",
                Name = "Juan123456789      "
            };
            Assert.IsTrue(_PasswordManager.AddUser(aUser));
            Assert.IsTrue(_PasswordManager.HasUser("Juan123456789"));
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
            _PasswordManager.LogIn(myUser.Name, myUser.MasterPassword);
            Assert.AreEqual(myUser.Name, _PasswordManager.CurrentUser.Name);
        }

        [TestMethod]
        [ExpectedException(typeof(ExceptionIncorrectMasterPassword))]
        public void ValidateAndSetCurrentUserWithWrongPassword()
        {
            _PasswordManager.LogIn(myUser.Name, "NotThePasswordSir");
        }

        [TestMethod]
        [ExpectedException(typeof(ExceptionUserDoesNotExist))]
        public void ValidateAndSetCurrentUserWithWrongName()
        {
            _PasswordManager.LogIn("ThisIsNotTheName", myUser.MasterPassword);
        }

        [TestMethod]
        public void ValidateAndSetCurrentUserWithUsernameContainingBlankSpacesAtTheStart()
        {
            _PasswordManager.LogIn("    JuanP", myUser.MasterPassword);
            Assert.AreEqual(myUser.Name, _PasswordManager.CurrentUser.Name);
        }

        [TestMethod]
        public void ValidateAndSetCurrentUserWithUsernameContainingBlankSpacesAtTheEnd()
        {
            _PasswordManager.LogIn("JuanP     ", myUser.MasterPassword);
            Assert.AreEqual(myUser.Name, _PasswordManager.CurrentUser.Name);
        }

        [TestMethod]
        [ExpectedException(typeof(ExceptionUserDoesNotExist))]
        public void ValidateAndSetCurrentUserWithUsernameWronglyContainingBlankSpacesBetweenCharacters()
        {
            _PasswordManager.LogIn("Ju a nP", myUser.MasterPassword);
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
        public void AUserInUsersWithAccessArray()
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
            Assert.AreEqual(aUser, aUserPasswordPair.GetUsersWithAccessArray()[0]);
        }

        [TestMethod]
        public void AUserPasswordPairInSharedPasswordsArray()
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
            Assert.AreEqual(1, aUser.GetSharedUserPasswordPairs().Length);
            Assert.AreEqual(aUserPasswordPair, aUser.GetSharedUserPasswordPairs()[0]);
        }

        [TestMethod]
        [ExpectedException(typeof(ExceptionUserPasswordPairIsNotSharedWithAnyone))]
        public void UserPasswordPairHasNotBeenShared()
        {
            _PasswordManager.CurrentUser = myUser;
            UserPasswordPair aUserPasswordPair = LoadTestCategoryToMyUserWithAUserPasswordPair();

            aUserPasswordPair.GetUsersWithAccessArray();
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

            _PasswordManager.UnsharePassword(aUserPasswordPair, "JuanPa");
        }

        private UserPasswordPair LoadTestCategoryToMyUserWithAUserPasswordPair()
        {
            var aCategory = new NormalCategory()
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

        [TestMethod]
        public void GettingAllUsersWhitJustOne()
        {
            var allUsers = _PasswordManager.GetUsers();
            Assert.AreEqual(1, allUsers.Length);
            Assert.AreEqual(myUser, allUsers[0]);
        }

        [TestMethod]
        public void GettingAllUsersWithManyOnManager()
        {
            var aUser = new User()
            {
                Name = "User2",
                MasterPassword = "AMasterPassword123$"
            };
            var anotherUser = new User()
            {
                Name = "User3",
                MasterPassword = "AMasterPassword123$"
            };

            _PasswordManager.AddUser(aUser);
            _PasswordManager.AddUser(anotherUser);

            var allUsers = _PasswordManager.GetUsers();
            Assert.AreEqual(3, allUsers.Length);
        }
    }
}