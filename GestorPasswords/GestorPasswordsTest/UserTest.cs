using GestorPasswordsDominio;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace GestorPasswordsTest
{
    [TestClass]
    public class UserTest
    {
        [TestMethod]
        [ExpectedException(typeof(ExceptionIncorrectMasterPassword))]
        public void IncorrectMasterPassword()
        {
            User aUser = new User()
            {
                MasterPassword = "myPassword"
            };
            string currentPassword = "aWrongPassword";
            string newPassword = "myNewPassword";
            aUser.ChangeMasterPassword(currentPassword, newPassword);
        }

        [TestMethod]
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
    }
}
