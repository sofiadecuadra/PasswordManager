﻿using GestorPasswordsDominio;
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


        public void AddValidCategory()
        {
            User aUser = new User()
            {
                MasterPassword = "myPassword"
            };

            Category aCategory = new Category()
            {
                User = aUser,
                Name = "myCategory"
            };

            Assert.IsTrue(aUser.AddCategory(aCategory));
        }

        [TestMethod]
        [ExpectedException(typeof(ExceptionCategoryHasInvalidNameLength))]
        public void AddCategoryWithLengthLessThan3()
        {
            User aUser = new User()
            {
                MasterPassword = "myPassword"
            };

            Category aCategory = new Category()
            {
                User = aUser,
                Name = "my"
            };

            aUser.AddCategory(aCategory);
        }

        [TestMethod]
        [ExpectedException(typeof(ExceptionCategoryHasInvalidNameLength))]
        public void AddCategoryWithLengthGreaterThan15()
        {
            User aUser = new User()
            {
                MasterPassword = "myPassword"
            };

            Category aCategory = new Category()
            {
                User = aUser,
                Name = "myCategoryNameIsInvalid"
            };

            aUser.AddCategory(aCategory);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void AddExistingCategory()
        {
            User aUser = new User()
            {
                MasterPassword = "myPassword"
            };

            Category aCategory = new Category()
            {
                User = aUser,
                Name = "myCategory"
            };

            aUser.AddCategory(aCategory);

            Category anotherCategory = new Category()
            {
                User = aUser,
                Name = "myCategory"
            };

            aUser.AddCategory(anotherCategory);
        }

        [TestMethod]
        public void ModifyCategoryNormally()
        {
            User aUser = new User()
            {
                MasterPassword = "myPassword"
            };

            Category aCategory = new Category()
            {
                User = aUser,
                Name = "myCategory"
            };

            aUser.AddCategory(aCategory);

            Assert.IsTrue(aUser.ModifyCategory(aCategory, "newName"));
            Assert.AreEqual("newname", aCategory.Name);
        }

        [TestMethod]
        [ExpectedException(typeof(ExceptionCategoryNotExists))]
        public void ModifyCategoryThatDoesNotExist()
        {
            User aUser = new User()
            {
                MasterPassword = "myPassword"
            };

            Category aCategory = new Category()
            {
                User = aUser,
                Name = "myCategory"
            };

            aUser.ModifyCategory(aCategory, "newName");
        }

        [TestMethod]
        [ExpectedException(typeof(ExceptionCategoryHasInvalidNameLength))]
        public void ModifyCategoryWithNewLengthLessThan3()
        {
            User aUser = new User()
            {
                MasterPassword = "myPassword"
            };

            Category aCategory = new Category()
            {
                User = aUser,
                Name = "myCategory"
            };

            aUser.AddCategory(aCategory);

            aUser.ModifyCategory(aCategory, "no");
        }

        [TestMethod]
        [ExpectedException(typeof(ExceptionCategoryHasInvalidNameLength))]
        public void ModifyCategoryWithNewLengthGreaterThan15()
        {
            User aUser = new User()
            {
                MasterPassword = "myPassword"
            };

            Category aCategory = new Category()
            {
                User = aUser,
                Name = "myCategory"
            };

            aUser.AddCategory(aCategory);

            aUser.ModifyCategory(aCategory, "thisIsAnInvalidLength");
        }
    }
}