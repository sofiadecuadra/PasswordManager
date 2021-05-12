using Microsoft.VisualStudio.TestTools.UnitTesting;
using GestorPasswordsDominio;
using System;

namespace GestorPasswordsTest
{
    [TestClass]
    public class ModifingValidityOfUserPaswordPairArgumentInCategoryTest
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
                Password = "password",
                Notes = "myNotes",
                Username = "myUsername",
                Site = "mySite",
                Category = aCategory,
            };

            aCategory.AddUserPasswordPair(aUserPasswordPair);

            UserPasswordPair newUserPasswordPair = new UserPasswordPair()
            {
                Password = "newPassword",
                Notes = "myNotes",
                Username = "myUsername",
                Site = "mySite",
                Category = aCategory,
            };

            Assert.IsTrue(aCategory.ModifyUserPasswordPair(aUserPasswordPair, newUserPasswordPair));
            Assert.AreEqual(1, aCategory.GetUserPasswordsPairs().Length);
        }

        [TestMethod]
        public void ModifyPasswordOfUserPasswordPairToAValidOneAndChangingCategory()
        {
            UserPasswordPair aUserPasswordPair = new UserPasswordPair()
            {
                Password = "password",
                Notes = "myNotes",
                Username = "myUsername",
                Site = "mySite",
                Category = aCategory,
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
                Password = "newPassword",
                Notes = "myNotes",
                Username = "myUsername",
                Site = "mySite",
                Category = otherCategory,
            };

            Assert.IsTrue(aCategory.ModifyUserPasswordPair(aUserPasswordPair, newUserPasswordPair));
            Assert.AreEqual(0, aCategory.GetUserPasswordsPairs().Length);
            Assert.AreEqual(1, otherCategory.GetUserPasswordsPairs().Length);

        }

        [TestMethod]
        public void ModifyUsernameOfUserPasswordPairToAValidOne()
        {
            UserPasswordPair aUserPasswordPair = new UserPasswordPair()
            {
                Password = "password",
                Notes = "myNotes",
                Username = "myUsername",
                Site = "mySite",
                Category = aCategory,
            };

            aCategory.AddUserPasswordPair(aUserPasswordPair);

            UserPasswordPair newUserPasswordPair = new UserPasswordPair()
            {
                Password = "password",
                Notes = "myNotes",
                Username = "newUsername",
                Site = "mySite",
                Category = aCategory,
            };

            Assert.IsTrue(aCategory.ModifyUserPasswordPair(aUserPasswordPair, newUserPasswordPair));
        }

        [TestMethod]
        [ExpectedException(typeof(ExceptionIncorrectLength))]
        public void ModifyUsernameOfUserPasswordPairToAnInvalidOne()
        {
            UserPasswordPair aUserPasswordPair = new UserPasswordPair()
            {
                Password = "password",
                Notes = "myNotes",
                Username = "myUsername",
                Site = "mySite",
                Category = aCategory,
            };

            aCategory.AddUserPasswordPair(aUserPasswordPair);

            UserPasswordPair newUserPasswordPair = new UserPasswordPair()
            {
                Password = "password",
                Notes = "myNotes",
                Username = "no",
                Site = "mySite",
                Category = aCategory,
            };

            _ = aCategory.ModifyUserPasswordPair(aUserPasswordPair, newUserPasswordPair);
        }

        [TestMethod]
        public void ModifySiteOfUserPasswordPairToAValidOne()
        {
            UserPasswordPair aUserPasswordPair = new UserPasswordPair()
            {
                Password = "password",
                Notes = "myNotes",
                Username = "myUsername",
                Site = "mySite",
                Category = aCategory,
            };

            aCategory.AddUserPasswordPair(aUserPasswordPair);

            UserPasswordPair newUserPasswordPair = new UserPasswordPair()
            {
                Password = "password",
                Notes = "myNotes",
                Username = "myUsername",
                Site = "newSite",
                Category = aCategory,
            };

            Assert.IsTrue(aCategory.ModifyUserPasswordPair(aUserPasswordPair, newUserPasswordPair));
        }

        [TestMethod]
        [ExpectedException(typeof(ExceptionIncorrectLength))]
        public void ModifySiteOfUserPasswordPairToAnInvalidOne()
        {
            UserPasswordPair aUserPasswordPair = new UserPasswordPair()
            {
                Password = "password",
                Notes = "myNotes",
                Username = "myUsername",
                Site = "mySite",
                Category = aCategory,
            };

            aCategory.AddUserPasswordPair(aUserPasswordPair);

            UserPasswordPair newUserPasswordPair = new UserPasswordPair()
            {
                Password = "password",
                Notes = "myNotes",
                Username = "myUsername",
                Site = "n",
                Category = aCategory,
            };

            _ = aCategory.ModifyUserPasswordPair(aUserPasswordPair, newUserPasswordPair);
        }

        [TestMethod]
        public void ModifyNotesOfUserPasswordPairToAValidOne()
        {
            UserPasswordPair aUserPasswordPair = new UserPasswordPair()
            {
                Password = "password",
                Notes = "myNotes",
                Username = "myUsername",
                Site = "mySite",
                Category = aCategory,
            };

            aCategory.AddUserPasswordPair(aUserPasswordPair);

            UserPasswordPair newUserPasswordPair = new UserPasswordPair()
            {
                Password = "password",
                Notes = "newNotes",
                Username = "myUsername",
                Site = "mySite",
                Category = aCategory,
            };

            Assert.IsTrue(aCategory.ModifyUserPasswordPair(aUserPasswordPair, newUserPasswordPair));
        }

        [TestMethod]
        [ExpectedException(typeof(ExceptionIncorrectLength))]
        public void ModifyNotesOfUserPasswordPairToAnInvalidOne()
        {
            UserPasswordPair aUserPasswordPair = new UserPasswordPair()
            {
                Password = "password",
                Notes = "myNotes",
                Username = "myUsername",
                Site = "mySite",
                Category = aCategory,
            };

            aCategory.AddUserPasswordPair(aUserPasswordPair);

            string aNote = GenerateNoteText();

            UserPasswordPair newUserPasswordPair = new UserPasswordPair()
            {
                Password = "password",
                Notes = aNote,
                Username = "myUsername",
                Site = "mySite",
                Category = aCategory,
            };

            _ = aCategory.ModifyUserPasswordPair(aUserPasswordPair, newUserPasswordPair);
        }
    }
}