using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataManagerDomain;

namespace DataManagerTest
{
    [TestClass]
    public class RemovingPasswordsFromCategoryTest
    {
        private DataManager DataManager;
        private Category aCategory;
        private User aUser;

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

            aCategory.RemoveUserPasswordPair(aUserPasswordPair);

            Assert.IsFalse(aCategory.UserPasswordPairAlredyExistsInCategory(aUserPasswordPair));
            Assert.AreEqual(0, aCategory.User.GetUserPasswordPairsOfASpecificColor(PasswordStrengthType.DarkGreen).Length);
            Assert.AreEqual(0, aCategory.GetUserPasswordPairsOfASpecificColorQuantity(PasswordStrengthType.DarkGreen));
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

            aCategory.RemoveUserPasswordPair(aUserPasswordPair);

            Assert.IsFalse(aCategory.UserPasswordPairAlredyExistsInCategory(aUserPasswordPair));
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

            aCategory.RemoveUserPasswordPair(aUserPasswordPair);

            Assert.IsFalse(aCategory.UserPasswordPairAlredyExistsInCategory(aUserPasswordPair));
            Assert.AreEqual(0, aCategory.User.GetUserPasswordPairsOfASpecificColor(PasswordStrengthType.LightGreen).Length);
            Assert.AreEqual(0, aCategory.GetUserPasswordPairsOfASpecificColorQuantity(PasswordStrengthType.LightGreen));
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

            aCategory.RemoveUserPasswordPair(aUserPasswordPair);

            Assert.IsFalse(aCategory.UserPasswordPairAlredyExistsInCategory(aUserPasswordPair));
            Assert.AreEqual(0, aCategory.User.GetUserPasswordPairsOfASpecificColor(PasswordStrengthType.Orange).Length);
            Assert.AreEqual(0, aCategory.GetUserPasswordPairsOfASpecificColorQuantity(PasswordStrengthType.Orange));
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

            aCategory.RemoveUserPasswordPair(aUserPasswordPair);

            Assert.IsFalse(aCategory.UserPasswordPairAlredyExistsInCategory(aUserPasswordPair));
            Assert.AreEqual(0, aCategory.User.GetUserPasswordPairsOfASpecificColor(PasswordStrengthType.Red).Length);
            Assert.AreEqual(0, aCategory.GetUserPasswordPairsOfASpecificColorQuantity(PasswordStrengthType.Red));
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

            aCategory.RemoveUserPasswordPair(aUserPasswordPair);

            Assert.IsFalse(aCategory.UserPasswordPairAlredyExistsInCategory(aUserPasswordPair));
            Assert.AreEqual(0, aCategory.User.GetUserPasswordPairsOfASpecificColor(PasswordStrengthType.Yellow).Length);
            Assert.AreEqual(0, aCategory.GetUserPasswordPairsOfASpecificColorQuantity(PasswordStrengthType.Yellow));
        }

        [TestCleanup]
        public void Cleanup()
        {
            using (var dbContext = new DataManagerContext())
            {
                dbContext.Users.RemoveRange(dbContext.Users);
                dbContext.Categories.RemoveRange(dbContext.Categories);
                dbContext.UserPasswordPairs.RemoveRange(dbContext.UserPasswordPairs);
                dbContext.SaveChanges();
            }
        }
    }
}