using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataManagerDomain;

namespace DataManagerTest
{
    [TestClass]
    public class SystemTest
    {
        DataManager DataManager;
        User myUser;

        [TestInitialize]
        public void Initialize()
        {
            DataManager = new DataManager();
            myUser = new User()
            {
                MasterPassword = "myMasterPassword123$",
                Username = "JuanP"
            };
            DataManager.AddUser(myUser);
        }

        [TestMethod]
        public void AddValidUserToSystem()
        {
            User aUser = new User()
            {
                MasterPassword = "myMasterPassword123$",
                Username = "JuanPa"
            };
            DataManager.AddUser(aUser);
            Assert.IsTrue(DataManager.HasUser(aUser.Username));
        }

        [TestMethod]
        [ExpectedException(typeof(ExceptionUserAlreadyExists))]
        public void AddExistingUserToSystem()
        {
            User aUser = new User()
            {
                MasterPassword = "myMasterPassword123$",
                Username = "JuanPa"
            };
            DataManager.AddUser(aUser);

            User otherUser = new User()
            {
                MasterPassword = "aMasterPassword123$",
                Username = "JuanPa"
            };
            DataManager.AddUser(otherUser);
        }

        [TestMethod]
        [ExpectedException(typeof(ExceptionIncorrectLength))]
        public void AddUserWithNameTooShort()
        {
            User aUser = new User()
            {
                MasterPassword = "myMasterPassword123$",
                Username = "Juan"
            };
            DataManager.AddUser(aUser);
        }

        [TestMethod]
        [ExpectedException(typeof(ExceptionIncorrectLength))]
        public void AddUserWithNameTooLong()
        {
            User aUser = new User()
            {
                MasterPassword = "myMasterPassword123$",
                Username = "Juan1234567890123456789012"
            };
            DataManager.AddUser(aUser);
        }

        [TestMethod]
        [ExpectedException(typeof(ExceptionUsernameContainsSpaces))]
        public void AddUserWithUsernameContainingBlankSpacesBetweenCharacters()
        {
            User aUser = new User()
            {
                MasterPassword = "myMasterPassword123$",
                Username = "Juan 12345 6789"
            };
            DataManager.AddUser(aUser);
        }


        [TestMethod]
        public void AddUserWithUsernameContainingBlankSpacesAtTheStart()
        {
            User aUser = new User()
            {
                MasterPassword = "myMasterPassword123$",
                Username = "      Juan123456789"
            };
            DataManager.AddUser(aUser);
            Assert.IsTrue(DataManager.HasUser("juan123456789"));
        }

        [TestMethod]
        public void AddUserWithUsernameContainingLotsOfBlankSpacesAtTheStart()
        {
            User aUser = new User()
            {
                MasterPassword = "myMasterPassword123$",
                Username = "                                                                   Juan123456789"
            };
            DataManager.AddUser(aUser);
            Assert.IsTrue(DataManager.HasUser("juan123456789"));
        }

        [TestMethod]
        public void AddUserWithUsernameContainingBlankSpacesAtTheEnd()
        {
            User aUser = new User()
            {
                MasterPassword = "myMasterPassword123$",
                Username = "Juan123456789      "
            };
            DataManager.AddUser(aUser);
            Assert.IsTrue(DataManager.HasUser("juan123456789"));
        }

        [TestMethod]
        public void ValidateUserCorrectly()
        {
            DataManager.ValidateUser("juanp", "myMasterPassword123$");
        }

        [TestMethod]
        public void ValidateUserNotInLowerCorrectly()
        {
            DataManager.ValidateUser("JuanP", "myMasterPassword123$");
        }

        [TestMethod]
        [ExpectedException(typeof(ExceptionIncorrectMasterPassword))]
        public void ValidateUserWithIncorrectPassword()
        {
            DataManager.ValidateUser("juanp", "NotThePassword");
        }

        [TestMethod]
        [ExpectedException(typeof(ExceptionUserDoesNotExist))]
        public void ValidateNonExistingUser()
        {
            DataManager.ValidateUser("NotTheUser", "myMasterPassword123$");
        }

        [TestMethod]
        public void SetCurrentUserCorrectly()
        {
            DataManager.CurrentUser = myUser;
            Assert.AreEqual(myUser.Username, DataManager.CurrentUser.Username);
        }

        [TestMethod]
        [ExpectedException(typeof(ExceptionUserDoesNotExist))]
        public void SetCurrentUserThatDoesNotExist()
        {
            User aUser = new User()
            {
                MasterPassword = "myMasterPassword123$",
                Username = "JuanPa"
            };

            DataManager.CurrentUser = aUser;
        }

        [TestMethod]
        public void ValidateAndSetCurrentUserCorrectly()
        {
            DataManager.LogIn(myUser.Username, myUser.MasterPassword);
            Assert.AreEqual(myUser.Username, DataManager.CurrentUser.Username);
        }

        [TestMethod]
        [ExpectedException(typeof(ExceptionIncorrectMasterPassword))]
        public void ValidateAndSetCurrentUserWithWrongPassword()
        {
            DataManager.LogIn(myUser.Username, "NotThePasswordSir");
        }

        [TestMethod]
        [ExpectedException(typeof(ExceptionUserDoesNotExist))]
        public void ValidateAndSetCurrentUserWithWrongName()
        {
            DataManager.LogIn("ThisIsNotTheName", myUser.MasterPassword);
        }

        [TestMethod]
        public void ValidateAndSetCurrentUserWithUsernameContainingBlankSpacesAtTheStart()
        {
            DataManager.LogIn("    JuanP", myUser.MasterPassword);
            Assert.AreEqual(myUser.Username, DataManager.CurrentUser.Username);
        }

        [TestMethod]
        public void ValidateAndSetCurrentUserWithUsernameContainingBlankSpacesAtTheEnd()
        {
            DataManager.LogIn("JuanP     ", myUser.MasterPassword);
            Assert.AreEqual(myUser.Username, DataManager.CurrentUser.Username);
        }

        [TestMethod]
        [ExpectedException(typeof(ExceptionUserDoesNotExist))]
        public void ValidateAndSetCurrentUserWithUsernameWronglyContainingBlankSpacesBetweenCharacters()
        {
            DataManager.LogIn("Ju a nP", myUser.MasterPassword);
        }

        [TestMethod]
        public void ShareValidPassword()
        {
            DataManager.CurrentUser = myUser;
            var aUser = new User()
            {
                MasterPassword = "myMasterPassword123$",
                Username = "JuanPa"
            };
            DataManager.AddUser(aUser);
            UserPasswordPair aUserPasswordPair = LoadTestCategoryToMyUserWithAUserPasswordPair();

            DataManager.SharePassword(aUserPasswordPair, aUser);
            Assert.IsTrue(DataManager.FindUser(aUser.Username).HasSharedPasswordOf(aUserPasswordPair));
            Assert.IsTrue(aUserPasswordPair.HasAccess(aUser.Username));
        }

        [TestMethod]
        [ExpectedException(typeof(ExceptionUserDoesNotExist))]
        public void ShareValidPasswordToUserThatDoesNotExist()
        {
            DataManager.CurrentUser = myUser;
            UserPasswordPair aUserPasswordPair = LoadTestCategoryToMyUserWithAUserPasswordPair();
            User aUser = new User()
            {
                MasterPassword = "myMasterPassword123$",
                Username = "JuanPa"
            };
            DataManager.SharePassword(aUserPasswordPair, aUser);
        }

        [TestMethod]
        public void AddUserInUsersWithAccessArray()
        {
            var aUser = new User()
            {
                MasterPassword = "myMasterPassword123$",
                Username = "JuanPa"
            };
            DataManager.CurrentUser = myUser;
            DataManager.AddUser(aUser);
            UserPasswordPair aUserPasswordPair = LoadTestCategoryToMyUserWithAUserPasswordPair();

            DataManager.SharePassword(aUserPasswordPair, aUser);
            Assert.AreEqual(aUser.Username, aUserPasswordPair.GetUsersWithAccessArray()[0].Username);
        }

        [TestMethod]
        public void AddUserPasswordPairInSharedPasswordsArray()
        {
            DataManager.CurrentUser = myUser;
            var aUser = new User()
            {
                MasterPassword = "myMasterPassword123$",
                Username = "JuanPa"
            };
            DataManager.AddUser(aUser);
            UserPasswordPair aUserPasswordPair = LoadTestCategoryToMyUserWithAUserPasswordPair();

            DataManager.SharePassword(aUserPasswordPair, aUser);
            Assert.AreEqual(1, aUser.GetSharedUserPasswordPairs().Length);
            using (var dbContext = new DataManagerContext())
            {
                var user = aUser.GetSharedUserPasswordPairs()[0];
                dbContext.UserPasswordPairs.Attach(user);
                dbContext.Entry(user).Reference(upp => upp.Category).Load();
                dbContext.Entry(user.Category).Reference(category => category.User).Load();
                Assert.AreEqual(aUserPasswordPair.Password, user.Password);
            }
            Assert.AreEqual(aUserPasswordPair.Site, aUser.GetSharedUserPasswordPairs()[0].Site);
            Assert.AreEqual(aUserPasswordPair.Username, aUser.GetSharedUserPasswordPairs()[0].Username);
        }

        [TestMethod]
        [ExpectedException(typeof(ExceptionUserPasswordPairIsNotSharedWithAnyone))]
        public void UserPasswordPairHasNotBeenShared()
        {
            DataManager.CurrentUser = myUser;
            UserPasswordPair aUserPasswordPair = LoadTestCategoryToMyUserWithAUserPasswordPair();

            aUserPasswordPair.GetUsersWithAccessArray();
        }

        [TestMethod]
        public void UnsharePassword()
        {
            var aUser = new User()
            {
                MasterPassword = "myMasterPassword123$",
                Username = "JuanPa"
            };
            DataManager.CurrentUser = myUser;
            DataManager.AddUser(aUser);
            UserPasswordPair aUserPasswordPair = LoadTestCategoryToMyUserWithAUserPasswordPair();

            DataManager.SharePassword(aUserPasswordPair, aUser);

            DataManager.UnsharePassword(aUserPasswordPair, aUser);

            Assert.IsFalse(DataManager.FindUser(aUser.Username).HasSharedPasswordOf(aUserPasswordPair));
            Assert.IsFalse(aUserPasswordPair.HasAccess(aUser.Username));
        }

        [TestMethod]
        [ExpectedException(typeof(ExceptionUserDoesNotExist))]
        public void UnsharePasswordToUserThatDoesNotExist()
        {
            DataManager.CurrentUser = myUser;
            UserPasswordPair aUserPasswordPair = LoadTestCategoryToMyUserWithAUserPasswordPair();
            User aUser = new User()
            {
                MasterPassword = "myMasterPassword123$",
                Username = "JuanPa"
            };
            DataManager.UnsharePassword(aUserPasswordPair, aUser);
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
                Category = aCategory,
                Password = "thisIsAPassword",
                Notes = "these are my notes",
                Username = "myUserName",
                Site = "mySite",
            };
            myUser.AddCategory(aCategory);

            aCategory.AddUserPasswordPair(aUserPasswordPair);
            return aUserPasswordPair;
        }

        [TestMethod]
        public void GettingAllUsersWithJustOne()
        {
            var allUsers = DataManager.GetUsers();
            Assert.AreEqual(1, allUsers.Length);
            Assert.AreEqual(myUser.Username, allUsers[0].Username);
        }

        [TestMethod]
        public void GettingAllUsersWithManyOnManager()
        {
            var aUser = new User()
            {
                Username = "User2",
                MasterPassword = "AMasterPassword123$"
            };
            var anotherUser = new User()
            {
                Username = "User3",
                MasterPassword = "AMasterPassword123$"
            };

            DataManager.AddUser(aUser);
            DataManager.AddUser(anotherUser);

            var allUsers = DataManager.GetUsers();
            Assert.AreEqual(3, allUsers.Length);
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
