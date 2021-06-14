using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataManagerDomain;
using System;

namespace DataManagerTest
{
    [TestClass]
    public class AddingUserPaswordPairsInCategoryTest
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
        [ExpectedException(typeof(ExceptionExistingUserPasswordPair))]
        public void AddExistingdUserPasswordPair()
        {
            UserPasswordPair aUserPasswordPair = new UserPasswordPair()
            {
                Category = aCategory,
                Password = "thisIsAPassword",
                Notes = "these are my notes",
                Username = "myUserName",
                Site = "mySite",
            };

            _ = aCategory.AddUserPasswordPair(aUserPasswordPair);

            UserPasswordPair anotherUserPasswordPair = new UserPasswordPair()
            {
                Category = aCategory,
                Password = "myPassword",
                Notes = "Heello notes",
                Username = "myUserName",
                Site = "mySite",
            };

            aCategory.AddUserPasswordPair(anotherUserPasswordPair);
        }

        [TestMethod]
        public void AddUserPasswordPairToSameSiteButDifferentUsername()
        {
            UserPasswordPair aUserPasswordPair = new UserPasswordPair()
            {
                Category = aCategory,
                Password = "thisIsAPassword",
                Notes = "these are my notes",
                Username = "myUserName1",
                Site = "mySite1",
            };

            aCategory.AddUserPasswordPair(aUserPasswordPair);

            UserPasswordPair anotherUserPasswordPair = new UserPasswordPair()
            {
                Category = aCategory,
                Password = "thisIsAPassword",
                Notes = "these are my notes",
                Username = "myUserName2",
                Site = "mySite1",
            };

            Assert.IsTrue(aCategory.AddUserPasswordPair(anotherUserPasswordPair));
            Assert.AreEqual(2, aCategory.GetUserPasswordsPairs().Length);
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
        [ExpectedException(typeof(ExceptionIncorrectLength))]
        public void AddUserPasswordPairWithNotesLengthGreaterThan250()
        {
            string aNote = GenerateNoteText();

            UserPasswordPair aUserPasswordPair = new UserPasswordPair()
            {
                Category = aCategory,
                Password = "password",
                Notes = aNote,
                Username = "myUsername",
                Site = "mySite",
            };

            aCategory.AddUserPasswordPair(aUserPasswordPair);
        }

        [TestMethod]
        [ExpectedException(typeof(ExceptionIncorrectLength))]
        public void AddUserPasswordPairWithPasswordLengthGreaterThan25()
        {
            UserPasswordPair aUserPasswordPair = new UserPasswordPair()
            {
                Category = aCategory,
                Password = "passwordHasInvalidLengthAndMustntBeUsed",
                Notes = "these are my notes",
                Username = "myUsername",
                Site = "mySite",
            };

            aCategory.AddUserPasswordPair(aUserPasswordPair);
        }

        [TestMethod]
        [ExpectedException(typeof(ExceptionIncorrectLength))]
        public void AddUserPasswordPairWithPasswordLengthLessThan5()
        {
            UserPasswordPair aUserPasswordPair = new UserPasswordPair()
            {
                Category = aCategory,
                Password = "pass",
                Notes = "these are my notes",
                Username = "myUsername",
                Site = "mySite",
            };

            aCategory.AddUserPasswordPair(aUserPasswordPair);
        }

        [TestMethod]
        [ExpectedException(typeof(ExceptionIncorrectLength))]
        public void AddUserPasswordPairWithSiteLengthGreaterThan25()
        {
            UserPasswordPair aUserPasswordPair = new UserPasswordPair()
            {
                Category = aCategory,
                Password = "password",
                Notes = "these are my notes",
                Username = "myUsername",
                Site = "This site has an invalid length, so it mustnt be used",
            };

            aCategory.AddUserPasswordPair(aUserPasswordPair);
        }

        [TestMethod]
        [ExpectedException(typeof(ExceptionIncorrectLength))]
        public void AddUserPasswordPairWithSiteLengthLessThan3()
        {
            UserPasswordPair aUserPasswordPair = new UserPasswordPair()
            {
                Category = aCategory,
                Password = "password",
                Notes = "these are my notes",
                Username = "myUsername",
                Site = "no",
            };

            aCategory.AddUserPasswordPair(aUserPasswordPair);
        }

        [TestMethod]
        [ExpectedException(typeof(ExceptionIncorrectLength))]
        public void AddUserPasswordPairWithUsernameLengthGreaterThan25()
        {
            UserPasswordPair aUserPasswordPair = new UserPasswordPair()
            {
                Category = aCategory,
                Password = "thisIsAPassword",
                Notes = "these are my notes",
                Username = "myUsernameHasInvalidLength",
                Site = "mySite",
            };

            aCategory.AddUserPasswordPair(aUserPasswordPair);
        }

        [TestMethod]
        [ExpectedException(typeof(ExceptionIncorrectLength))]
        public void AddUserPasswordPairWithUsernameLengthLessThan5()
        {
            UserPasswordPair aUserPasswordPair = new UserPasswordPair()
            {
                Category = aCategory,
                Password = "thisIsAPassword",
                Notes = "these are my notes",
                Username = "bad",
                Site = "mySite",
            };

            aCategory.AddUserPasswordPair(aUserPasswordPair);
        }

        [TestMethod]
        public void AddValidRedUserPasswordPair()
        {
            UserPasswordPair aUserPasswordPair = new UserPasswordPair()
            {
                Category = aCategory,
                Password = "myPass",
                Notes = "these are my notes",
                Username = "myUserName",
                Site = "mySite",
            };

            Assert.IsTrue(aCategory.AddUserPasswordPair(aUserPasswordPair));
            Assert.AreEqual(1, aCategory.GetUserPasswordsPairs().Length);
            Assert.AreEqual(1, aCategory.User.GetUserPasswordPairsOfASpecificColor(PasswordStrengthType.Red).Length);
            Assert.AreEqual(1, aCategory.GetUserPasswordPairsOfASpecificColorQuantity(PasswordStrengthType.Red));
        }

        [TestMethod]
        public void AddValidOrangeUserPasswordPair()
        {
            UserPasswordPair aUserPasswordPair = new UserPasswordPair()
            {
                Category = aCategory,
                Password = "myPassword",
                Notes = "these are my notes",
                Username = "myUserName",
                Site = "mySite",
            };

            Assert.IsTrue(aCategory.AddUserPasswordPair(aUserPasswordPair));
            Assert.AreEqual(1, aCategory.GetUserPasswordsPairs().Length);
            Assert.AreEqual(1, aCategory.User.GetUserPasswordPairsOfASpecificColor(PasswordStrengthType.Orange).Length);
            Assert.AreEqual(1, aCategory.GetUserPasswordPairsOfASpecificColorQuantity(PasswordStrengthType.Orange));
        }

        [TestMethod]
        public void AddValidYellowUserPasswordPair()
        {
            UserPasswordPair aUserPasswordPair = new UserPasswordPair()
            {
                Category = aCategory,
                Password = "MYPASSWORD12345",
                Notes = "these are my notes",
                Username = "myUserName",
                Site = "mySite",
            };

            Assert.IsTrue(aCategory.AddUserPasswordPair(aUserPasswordPair));
            Assert.AreEqual(1, aCategory.GetUserPasswordsPairs().Length);
            Assert.AreEqual(1, aCategory.User.GetUserPasswordPairsOfASpecificColor(PasswordStrengthType.Yellow).Length);
            Assert.AreEqual(1, aCategory.GetUserPasswordPairsOfASpecificColorQuantity(PasswordStrengthType.Yellow));
        }

        [TestMethod]
        public void AddValidLightGreenUserPasswordPair()
        {
            UserPasswordPair aUserPasswordPair = new UserPasswordPair()
            {
                Category = aCategory,
                Password = "MYpassword1234512",
                Notes = "these are my notes",
                Username = "myUserName",
                Site = "mySite",
            };

            Assert.IsTrue(aCategory.AddUserPasswordPair(aUserPasswordPair));
            Assert.AreEqual(1, aCategory.GetUserPasswordsPairs().Length);
            Assert.AreEqual(1, aCategory.User.GetUserPasswordPairsOfASpecificColor(PasswordStrengthType.LightGreen).Length);
            Assert.AreEqual(1, aCategory.GetUserPasswordPairsOfASpecificColorQuantity(PasswordStrengthType.LightGreen));
        }

        [TestMethod]
        public void AddValidDarkGreenUserPasswordPair()
        {
            UserPasswordPair aUserPasswordPair = new UserPasswordPair()
            {
                Category = aCategory,
                Password = "MYpassword@#12345",
                Notes = "these are my notes",
                Username = "myUserName",
                Site = "mySite",
            };

            Assert.IsTrue(aCategory.AddUserPasswordPair(aUserPasswordPair));
            Assert.AreEqual(1, aCategory.GetUserPasswordsPairs().Length);
            Assert.AreEqual(1, aCategory.User.GetUserPasswordPairsOfASpecificColor(PasswordStrengthType.DarkGreen).Length);
            Assert.AreEqual(1, aCategory.GetUserPasswordPairsOfASpecificColorQuantity(PasswordStrengthType.DarkGreen));
        }

        [TestMethod]
        public void AllPasswordImprovementSuggestionsAreTakenIntoAccount()
        {
            Tuple<bool, bool, bool> suggestionsTakenIntoAccount = aUser.PasswordImprovementSuggestionsAreTakenIntoAccount("MYpassword1234512");
            Assert.IsTrue(suggestionsTakenIntoAccount.Item1);
            Assert.IsTrue(suggestionsTakenIntoAccount.Item2);
            Assert.IsTrue(suggestionsTakenIntoAccount.Item3);
        }

        [TestMethod]
        public void PasswordIsNotSecure()
        {
            Tuple<bool, bool, bool> suggestionsTakenIntoAccount = aUser.PasswordImprovementSuggestionsAreTakenIntoAccount("myPassword");
            Assert.IsFalse(suggestionsTakenIntoAccount.Item1);
            Assert.IsTrue(suggestionsTakenIntoAccount.Item2);
            Assert.IsTrue(suggestionsTakenIntoAccount.Item3);
        }

        [TestMethod]
        public void PasswordIsDuplicated()
        {
            UserPasswordPair aUserPasswordPair = new UserPasswordPair()
            {
                Category = aCategory,
                Password = "MYpassword1234512",
                Notes = "these are my notes",
                Username = "myUserName",
                Site = "mySite",
            };
            aCategory.AddUserPasswordPair(aUserPasswordPair);
            Tuple<bool, bool, bool> suggestionsTakenIntoAccount = aUser.PasswordImprovementSuggestionsAreTakenIntoAccount("MYpassword1234512");
            Assert.IsTrue(suggestionsTakenIntoAccount.Item1);
            Assert.IsFalse(suggestionsTakenIntoAccount.Item2);
            Assert.IsTrue(suggestionsTakenIntoAccount.Item3);
        }

        //[TestMethod]
        //public void PasswordAppearedInADataBreach()
        //{
        //    IDataBreachesFormatter dataBreaches = new TextBoxDataBreaches()
        //    {
        //        txtDataBreaches = "MYpassword@#12345"
        //    };
        //    aUser.CheckDataBreaches(dataBreaches);
        //    Tuple<bool, bool, bool> suggestionsTakenIntoAccount = aUser.PasswordImprovementSuggestionsAreTakenIntoAccount("MYpassword@#12345");
        //    Assert.IsTrue(suggestionsTakenIntoAccount.Item1);
        //    Assert.IsTrue(suggestionsTakenIntoAccount.Item2);
        //    Assert.IsFalse(suggestionsTakenIntoAccount.Item3);
        //}

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