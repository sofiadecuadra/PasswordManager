using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataManagerDomain;
using System;

namespace DataManagerTest
{
    [TestClass]
    public class RemovingPasswordsFromCategoryTest
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
        public void RemoveDarkGreenUserPasswordPair()
        {
            UserPasswordPair aUserPasswordPair = new UserPasswordPair()
            {
                Category = aCategory,
                Password = "myPassword12345@$%",
                Notes = "these are my notes",
                Username = "myUserName",
                Site = "mySite",
            };

            aCategory.AddUserPasswordPair(aUserPasswordPair);

            Assert.IsTrue(aCategory.RemoveUserPasswordPair(aUserPasswordPair));
            Assert.IsFalse(aCategory.UserPasswordPairAlredyExistsInCategory(aUserPasswordPair.Username, aUserPasswordPair.Site));
            Assert.AreEqual(0, aCategory.User.GetDarkGreenUserPasswordPairs().Length);
            Assert.AreEqual(0, aCategory.DarkGreenUserPasswordPairsQuantity);
        }

        [TestMethod]
        public void RemoveExistingUserPasswordPair()
        {
            UserPasswordPair aUserPasswordPair = new UserPasswordPair()
            {
                Category = aCategory,
                Password = "thisIsAPassword",
                Notes = "these are my notes",
                Username = "myUserName",
                Site = "mySite",
            };

            aCategory.AddUserPasswordPair(aUserPasswordPair);

            Assert.IsTrue(aCategory.RemoveUserPasswordPair(aUserPasswordPair));
            Assert.IsFalse(aCategory.UserPasswordPairAlredyExistsInCategory(aUserPasswordPair.Username, aUserPasswordPair.Site));
            Assert.AreEqual(0, aCategory.GetUserPasswordsPairs().Length);
        }

        [TestMethod]
        public void RemoveLightGreenUserPasswordPair()
        {
            UserPasswordPair aUserPasswordPair = new UserPasswordPair()
            {
                Category = aCategory,
                Password = "myPassword12345",
                Notes = "these are my notes",
                Username = "myUserName",
                Site = "mySite",
            };

            aCategory.AddUserPasswordPair(aUserPasswordPair);

            Assert.IsTrue(aCategory.RemoveUserPasswordPair(aUserPasswordPair));
            Assert.IsFalse(aCategory.UserPasswordPairAlredyExistsInCategory(aUserPasswordPair.Username, aUserPasswordPair.Site));
            Assert.AreEqual(0, aCategory.User.GetLightGreenUserPasswordPairs().Length);
            Assert.AreEqual(0, aCategory.LightGreenUserPasswordPairsQuantity);
        }

        [TestMethod]
        public void RemoveOrangeUserPasswordPair()
        {
            UserPasswordPair aUserPasswordPair = new UserPasswordPair()
            {
                Category = aCategory,
                Password = "mypassword",
                Notes = "these are my notes",
                Username = "myUserName",
                Site = "mySite",
            };

            aCategory.AddUserPasswordPair(aUserPasswordPair);

            Assert.IsTrue(aCategory.RemoveUserPasswordPair(aUserPasswordPair));
            Assert.IsFalse(aCategory.UserPasswordPairAlredyExistsInCategory(aUserPasswordPair.Username, aUserPasswordPair.Site));
            Assert.AreEqual(0, aCategory.User.GetOrangeUserPasswordPairs().Length);
            Assert.AreEqual(0, aCategory.OrangeUserPasswordPairsQuantity);
        }

        [TestMethod]
        public void RemoveRedUserPasswordPair()
        {
            UserPasswordPair aUserPasswordPair = new UserPasswordPair()
            {
                Category = aCategory,
                Password = "mypass",
                Notes = "these are my notes",
                Username = "myUserName",
                Site = "mySite",
            };

            aCategory.AddUserPasswordPair(aUserPasswordPair);

            Assert.IsTrue(aCategory.RemoveUserPasswordPair(aUserPasswordPair));
            Assert.IsFalse(aCategory.UserPasswordPairAlredyExistsInCategory(aUserPasswordPair.Username, aUserPasswordPair.Site));
            Assert.AreEqual(0, aCategory.User.GetRedUserPasswordPairs().Length);
            Assert.AreEqual(0, aCategory.RedUserPasswordPairsQuantity);
        }

        [TestMethod]
        [ExpectedException(typeof(ExceptionUserPasswordPairDoesNotExist))]
        public void RemoveUserPasswordPairThatDoesNotExist()
        {
            UserPasswordPair aUserPasswordPair = new UserPasswordPair()
            {
                Category = aCategory,
                Password = "thisIsAPassword",
                Notes = "these are my notes",
                Username = "myUserName",
                Site = "mySite",
            };

            aCategory.RemoveUserPasswordPair(aUserPasswordPair);
        }

        [TestMethod]
        public void RemoveYellowUserPasswordPair()
        {
            UserPasswordPair aUserPasswordPair = new UserPasswordPair()
            {
                Category = aCategory,
                Password = "mypassword12345",
                Notes = "these are my notes",
                Username = "myUserName",
                Site = "mySite",
            };

            aCategory.AddUserPasswordPair(aUserPasswordPair);

            Assert.IsTrue(aCategory.RemoveUserPasswordPair(aUserPasswordPair));
            Assert.IsFalse(aCategory.UserPasswordPairAlredyExistsInCategory(aUserPasswordPair.Username, aUserPasswordPair.Site));
            Assert.AreEqual(0, aCategory.User.GetYellowUserPasswordPairs().Length);
            Assert.AreEqual(0, aCategory.YellowUserPasswordPairsQuantity);
        }

        [TestMethod]
        public void RemoveUserPasswordPairThatAppearedInADataBreach()
        {
            UserPasswordPair aUserPasswordPair = new UserPasswordPair()
            {
                Category = aCategory,
                Password = "mypassword12345",
                Notes = "these are my notes",
                Username = "myUserName",
                Site = "mySite",
            };

            aCategory.AddUserPasswordPair(aUserPasswordPair);

            IDataBreachesFormatter dataBreaches = new TxtFileDataBreaches()
            {
                txtDataBreaches = "mypassword12345"
            };
            DataBreach aDataBreach = aUser.CheckDataBreaches(dataBreaches);
            Assert.IsTrue(aCategory.RemoveUserPasswordPair(aUserPasswordPair));
            Assert.IsTrue(aDataBreach.LeakedUserPasswordPairsOfUser.Count == 0);
        }
    }
}