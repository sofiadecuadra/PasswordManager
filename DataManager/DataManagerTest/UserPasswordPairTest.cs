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
        private DataManager DataManager;

        [TestInitialize]
        public void Initialize()
        {
            DataManager = new DataManager();
            aUser = new User()
            {
                Username = "Fernanda",
                MasterPassword = "password",
            };
            DataManager.AddUser(aUser);
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

        [TestCleanup]
        public void Cleanup()
        {
            using (var dbContext = new DataManagerContext())
            {
                dbContext.Users.RemoveRange(dbContext.Users);
                dbContext.Categories.RemoveRange(dbContext.Categories);
                dbContext.CreditCards.RemoveRange(dbContext.CreditCards);
                dbContext.SaveChanges();
            }
        }
    }
}
