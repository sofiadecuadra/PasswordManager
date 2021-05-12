using GestorPasswordsDominio;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace GestorPasswordsTest
{
    [TestClass]
    public class UserPasswordPairTest
    {
        private NormalCategory aCategory;
        private User aUser;

        [TestInitialize]
        public void Initialize()
        {
            aUser = new User();
            aCategory = new NormalCategory()
            {
                User = aUser,
                Name = "Category"
            };
            aUser.AddCategory(aCategory);
        }

        [TestMethod]
        public void UserPasswordPairTestToString()
        {
            UserPasswordPair aUserPasswordPair = new UserPasswordPair()
            {
                Password = "myPassword",
                Notes = "these are my notes",
                Username = "myUserName",
                Site = "mySite",
                Category = aCategory,
            };
            Assert.AreEqual(aUserPasswordPair.ToString(), "[category] [mysite] [myusername]");
        }

        [TestMethod]
        public void GettingLastModifiedDate()
        {
            UserPasswordPair aUserPasswordPair = new UserPasswordPair()
            {
                Password = "myPassword",
                Notes = "these are my notes",
                Username = "myUserName",
                Site = "mySite",
                Category = aCategory,
            };

            Assert.AreEqual(DateTime.Now, aUserPasswordPair.LastModifiedDate);
        }
    }
}
