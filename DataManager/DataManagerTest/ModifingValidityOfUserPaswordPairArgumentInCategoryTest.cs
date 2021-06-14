
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataManagerDomain;

namespace DataManagerTest
{
    [TestClass]
    public class ModifingValidityOfUserPaswordPairArgumentInCategoryTest
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

        private static string GenerateNoteText()
        {
            string aNote = "";

            for (int i = 0; i <= 251; i++)
            {
                aNote += "a";
            }

            return aNote;
        }

        [TestMethod]
        public void ModifyPasswordOfUserPasswordPairToAValidOneAndNotChangingCategory()
        {
            UserPasswordPair aUserPasswordPair = new UserPasswordPair()
            {
                Category = aCategory,
                Password = "password",
                Notes = "myNotes",
                Username = "myUsername",
                Site = "mySite",
            };

            aCategory.AddUserPasswordPair(aUserPasswordPair);

            UserPasswordPair newUserPasswordPair = new UserPasswordPair()
            {
                Category = aCategory,
                Password = "newPassword",
                Notes = "myNotes",
                Username = "myUsername",
                Site = "mySite",
            };

            Assert.IsTrue(aCategory.ModifyUserPasswordPair(aUserPasswordPair, newUserPasswordPair));
            Assert.AreEqual(1, aCategory.GetUserPasswordsPairs().Length);
        }

        [TestMethod]
        public void ModifyPasswordOfUserPasswordPairToAValidOneAndChangingCategory()
        {
            UserPasswordPair aUserPasswordPair = new UserPasswordPair()
            {
                Category = aCategory,
                Password = "password",
                Notes = "myNotes",
                Username = "myUsername",
                Site = "mySite",
            };

            aCategory.AddUserPasswordPair(aUserPasswordPair);

            Category otherCategory = new Category()
            {
                User = aUser,
                Name = "otherCategory"
            };

            aUser.AddCategory(otherCategory);

            UserPasswordPair newUserPasswordPair = new UserPasswordPair()
            {
                Category = otherCategory,
                Password = "newPassword",
                Notes = "myNotes",
                Username = "myUsername",
                Site = "mySite",
            };

            Assert.IsTrue(aCategory.ModifyUserPasswordPair(aUserPasswordPair, newUserPasswordPair));
            Assert.AreEqual(0, aCategory.GetUserPasswordsPairs().Length);
            Assert.AreEqual(1, otherCategory.GetUserPasswordsPairs().Length);

        }

        [TestMethod]
        public void ModifyPasswordOfUserPasswordPairToAValidOneChangingCategoryAndNotThePassword()
        {
            Category anotherCategory = new Category()
            {
                User = aUser,
                Name = "anotherCategory"
            };
            aUser.AddCategory(anotherCategory);

            UserPasswordPair aUserPasswordPair = new UserPasswordPair()
            {
                Category = aCategory,
                Password = "password",
                Notes = "myNotes",
                Username = "myUsername",
                Site = "mySite",
            };
            aCategory.AddUserPasswordPair(aUserPasswordPair);

            UserPasswordPair newUserPasswordPair = new UserPasswordPair()
            {
                Category = anotherCategory,
                Password = "password",
                Notes = "myNotes",
                Username = "myUsername",
                Site = "mySite",
            };

            Assert.IsTrue(aCategory.ModifyUserPasswordPair(aUserPasswordPair, newUserPasswordPair));
            Assert.AreEqual(0, aCategory.GetUserPasswordsPairs().Length);
            Assert.AreEqual(1, anotherCategory.GetUserPasswordsPairs().Length);
        }

        [TestMethod]
        public void ModifyUsernameOfUserPasswordPairToAValidOne()
        {
            UserPasswordPair aUserPasswordPair = new UserPasswordPair()
            {
                Category = aCategory,
                Password = "password",
                Notes = "myNotes",
                Username = "myUsername",
                Site = "mySite",
            };

            aCategory.AddUserPasswordPair(aUserPasswordPair);

            UserPasswordPair newUserPasswordPair = new UserPasswordPair()
            {
                Category = aCategory,
                Password = "password",
                Notes = "myNotes",
                Username = "newUsername",
                Site = "mySite",
            };

            Assert.IsTrue(aCategory.ModifyUserPasswordPair(aUserPasswordPair, newUserPasswordPair));
        }

        [TestMethod]
        [ExpectedException(typeof(ExceptionIncorrectLength))]
        public void ModifyUsernameOfUserPasswordPairToAnInvalidOne()
        {
            UserPasswordPair aUserPasswordPair = new UserPasswordPair()
            {
                Category = aCategory,
                Password = "password",
                Notes = "myNotes",
                Username = "myUsername",
                Site = "mySite",
            };

            aCategory.AddUserPasswordPair(aUserPasswordPair);

            UserPasswordPair newUserPasswordPair = new UserPasswordPair()
            {
                Category = aCategory,
                Password = "password",
                Notes = "myNotes",
                Username = "no",
                Site = "mySite",
            };

            _ = aCategory.ModifyUserPasswordPair(aUserPasswordPair, newUserPasswordPair);
        }

        [TestMethod]
        public void ModifySiteOfUserPasswordPairToAValidOne()
        {
            UserPasswordPair aUserPasswordPair = new UserPasswordPair()
            {
                Category = aCategory,
                Password = "password",
                Notes = "myNotes",
                Username = "myUsername",
                Site = "mySite",
            };

            aCategory.AddUserPasswordPair(aUserPasswordPair);

            UserPasswordPair newUserPasswordPair = new UserPasswordPair()
            {
                Category = aCategory,
                Password = "password",
                Notes = "myNotes",
                Username = "myUsername",
                Site = "newSite",
            };

            Assert.IsTrue(aCategory.ModifyUserPasswordPair(aUserPasswordPair, newUserPasswordPair));
        }

        [TestMethod]
        [ExpectedException(typeof(ExceptionIncorrectLength))]
        public void ModifySiteOfUserPasswordPairToAnInvalidOne()
        {
            UserPasswordPair aUserPasswordPair = new UserPasswordPair()
            {
                Category = aCategory,
                Password = "password",
                Notes = "myNotes",
                Username = "myUsername",
                Site = "mySite",
            };

            aCategory.AddUserPasswordPair(aUserPasswordPair);

            UserPasswordPair newUserPasswordPair = new UserPasswordPair()
            {
                Category = aCategory,
                Password = "password",
                Notes = "myNotes",
                Username = "myUsername",
                Site = "n",
            };

            _ = aCategory.ModifyUserPasswordPair(aUserPasswordPair, newUserPasswordPair);
        }

        [TestMethod]
        public void ModifyNotesOfUserPasswordPairToAValidOne()
        {
            UserPasswordPair aUserPasswordPair = new UserPasswordPair()
            {
                Category = aCategory,
                Password = "password",
                Notes = "myNotes",
                Username = "myUsername",
                Site = "mySite",
            };

            aCategory.AddUserPasswordPair(aUserPasswordPair);

            UserPasswordPair newUserPasswordPair = new UserPasswordPair()
            {
                Category = aCategory,
                Password = "password",
                Notes = "newNotes",
                Username = "myUsername",
                Site = "mySite",
            };

            Assert.IsTrue(aCategory.ModifyUserPasswordPair(aUserPasswordPair, newUserPasswordPair));
        }

        [TestMethod]
        [ExpectedException(typeof(ExceptionIncorrectLength))]
        public void ModifyNotesOfUserPasswordPairToAnInvalidOne()
        {
            UserPasswordPair aUserPasswordPair = new UserPasswordPair()
            {
                Category = aCategory,
                Password = "password",
                Notes = "myNotes",
                Username = "myUsername",
                Site = "mySite",
            };

            aCategory.AddUserPasswordPair(aUserPasswordPair);

            string aNote = GenerateNoteText();

            UserPasswordPair newUserPasswordPair = new UserPasswordPair()
            {
                Category = aCategory,
                Password = "password",
                Notes = aNote,
                Username = "myUsername",
                Site = "mySite",
            };

            _ = aCategory.ModifyUserPasswordPair(aUserPasswordPair, newUserPasswordPair);
        }

        [TestMethod]
        [ExpectedException(typeof(ExceptionExistingUserPasswordPair))]
        public void ModifyUserPasswordPairToOneThatAlreadyExistsInUser()
        {
            UserPasswordPair aUserPasswordPair = new UserPasswordPair()
            {
                Category = aCategory,
                Password = "password",
                Notes = "myNotes",
                Username = "myUsername",
                Site = "mySite",
            };
            aCategory.AddUserPasswordPair(aUserPasswordPair);

            UserPasswordPair newUserPasswordPair = new UserPasswordPair()
            {
                Category = aCategory,
                Password = "otherPassword",
                Notes = "myNotes",
                Username = "myUsername",
                Site = "myOtherSite",
            };

            UserPasswordPair anotherUserPasswordPair = new UserPasswordPair()
            {
                Category = aCategory,
                Password = "otherPassword",
                Notes = "myNotes",
                Username = "myUsername",
                Site = "myOtherSite",
            };
            aCategory.AddUserPasswordPair(anotherUserPasswordPair);

            _ = aCategory.ModifyUserPasswordPair(aUserPasswordPair, newUserPasswordPair);
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