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
            Assert.AreEqual(1, aCategory.User.GetDarkGreenUserPasswordPairs().Length);
            Assert.AreEqual(1, aCategory.DarkGreenUserPasswordPairsQuantity);
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
            Assert.AreEqual(1, aCategory.User.GetLightGreenUserPasswordPairs().Length);
            Assert.AreEqual(1, aCategory.LightGreenUserPasswordPairsQuantity);
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
            Assert.AreEqual(1, aCategory.User.GetOrangeUserPasswordPairs().Length);
            Assert.AreEqual(1, aCategory.OrangeUserPasswordPairsQuantity);
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
            Assert.AreEqual(1, aCategory.User.GetRedUserPasswordPairs().Length);
            Assert.AreEqual(1, aCategory.RedUserPasswordPairsQuantity);
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
            Assert.AreEqual(1, aCategory.User.GetYellowUserPasswordPairs().Length);
            Assert.AreEqual(1, aCategory.YellowUserPasswordPairsQuantity);
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

        [TestMethod]
        public void PasswordAppearedInADataBreach()
        {
            IDataBreachesFormatter dataBreaches = new TextBoxDataBreaches()
            {
                txtDataBreaches = "MYpassword@#12345"
            };
            aUser.CheckDataBreaches(dataBreaches);
            Tuple<bool, bool, bool> suggestionsTakenIntoAccount = aUser.PasswordImprovementSuggestionsAreTakenIntoAccount("MYpassword@#12345");
            Assert.IsTrue(suggestionsTakenIntoAccount.Item1);
            Assert.IsTrue(suggestionsTakenIntoAccount.Item2);
            Assert.IsFalse(suggestionsTakenIntoAccount.Item3);
        }
    }
}