using DataManagerDomain;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace DataManagerTest
{
    [TestClass]
    public class UserPasswordPairTest
    {
        private Category aCategory;
        private User aUser;

        [TestInitialize]
        public void Initialize()
        {
            aUser = new User();
            aCategory = new Category()
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
                Category = aCategory,
                Password = "myPassword",
                Notes = "these are my notes",
                Username = "myUserName",
                Site = "mySite",
            };
            Assert.AreEqual(aUserPasswordPair.ToString(), "[category] [mysite] [myusername]");
        }

        [TestMethod]
        public void GettingLastModifiedDate()
        {
            UserPasswordPair aUserPasswordPair = new UserPasswordPair()
            {
                Category = aCategory,
                Password = "myPassword",
                Notes = "these are my notes",
                Username = "myUserName",
                Site = "mySite",
            };

            Assert.AreEqual(DateTime.Now.ToString("yyyyMMddhhmmss"), 
                aUserPasswordPair.LastModifiedDate.ToString("yyyyMMddhhmmss"));
        }
    }
}
