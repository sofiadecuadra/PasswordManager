using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataManagerDomain;

namespace DataManagerTest
{
    [TestClass]
    public class CategoryModifyingPasswordColorsTest
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
        public void ModifyDarkGreenUserPasswordPairToADarkGreenOne()
        {
            UserPasswordPair aUserPasswordPair = new UserPasswordPair()
            {
                Category = aCategory,
                Password = "myPassword12345#$%",
                Notes = "myNotes",
                Username = "myUsername",
                Site = "mySite",
            };

            aCategory.AddUserPasswordPair(aUserPasswordPair);

            UserPasswordPair newUserPasswordPair = new UserPasswordPair()
            {
                Category = aCategory,
                Password = "myPassword!#32#$%",
                Notes = "myNotes",
                Username = "myUsername",
                Site = "mySite",
            };

            Assert.IsTrue(aCategory.ModifyUserPasswordPair(aUserPasswordPair, newUserPasswordPair));
            Assert.AreEqual(1, aCategory.User.GetUserPasswordPairsOfASpecificColor(PasswordStrengthType.DarkGreen).Length);
            Assert.AreEqual(1, aCategory.GetUserPasswordPairsOfASpecificColorQuantity(PasswordStrengthType.DarkGreen));
        }

        [TestMethod]
        public void ModifyDarkGreenUserPasswordPairToALightGreenOne()
        {
            UserPasswordPair aUserPasswordPair = new UserPasswordPair()
            {
                Category = aCategory,
                Password = "myPassword12345#$%",
                Notes = "myNotes",
                Username = "myUsername",
                Site = "mySite",
            };

            aCategory.AddUserPasswordPair(aUserPasswordPair);

            UserPasswordPair newUserPasswordPair = new UserPasswordPair()
            {
                Category = aCategory,
                Password = "myPassword12345",
                Notes = "myNotes",
                Username = "myUsername",
                Site = "mySite",
            };

            Assert.IsTrue(aCategory.ModifyUserPasswordPair(aUserPasswordPair, newUserPasswordPair));
            Assert.AreEqual(0, aCategory.User.GetUserPasswordPairsOfASpecificColor(PasswordStrengthType.DarkGreen).Length);
            Assert.AreEqual(1, aCategory.User.GetUserPasswordPairsOfASpecificColor(PasswordStrengthType.LightGreen).Length);
            Assert.AreEqual(0, aCategory.GetUserPasswordPairsOfASpecificColorQuantity(PasswordStrengthType.DarkGreen));
            Assert.AreEqual(1, aCategory.GetUserPasswordPairsOfASpecificColorQuantity(PasswordStrengthType.LightGreen));
        }

        [TestMethod]
        public void ModifyDarkGreenUserPasswordPairToAnOrangeOne()
        {
            UserPasswordPair aUserPasswordPair = new UserPasswordPair()
            {
                Category = aCategory,
                Password = "myPassword12345#$%",
                Notes = "myNotes",
                Username = "myUsername",
                Site = "mySite",
            };

            aCategory.AddUserPasswordPair(aUserPasswordPair);

            UserPasswordPair newUserPasswordPair = new UserPasswordPair()
            {
                Category = aCategory,
                Password = "myPassword",
                Notes = "myNotes",
                Username = "myUsername",
                Site = "mySite",
            };

            Assert.IsTrue(aCategory.ModifyUserPasswordPair(aUserPasswordPair, newUserPasswordPair));
            Assert.AreEqual(0, aCategory.User.GetUserPasswordPairsOfASpecificColor(PasswordStrengthType.DarkGreen).Length);
            Assert.AreEqual(1, aCategory.User.GetUserPasswordPairsOfASpecificColor(PasswordStrengthType.Orange).Length);
            Assert.AreEqual(0, aCategory.GetUserPasswordPairsOfASpecificColorQuantity(PasswordStrengthType.DarkGreen));
            Assert.AreEqual(1, aCategory.GetUserPasswordPairsOfASpecificColorQuantity(PasswordStrengthType.Orange));
        }

        [TestMethod]
        public void ModifyDarkGreenUserPasswordPairToARedOne()
        {
            UserPasswordPair aUserPasswordPair = new UserPasswordPair()
            {
                Category = aCategory,
                Password = "myPassword12345#$%",
                Notes = "myNotes",
                Username = "myUsername",
                Site = "mySite",
            };

            aCategory.AddUserPasswordPair(aUserPasswordPair);

            UserPasswordPair newUserPasswordPair = new UserPasswordPair()
            {
                Category = aCategory,
                Password = "myPass",
                Notes = "myNotes",
                Username = "myUsername",
                Site = "mySite",
            };

            Assert.IsTrue(aCategory.ModifyUserPasswordPair(aUserPasswordPair, newUserPasswordPair));
            Assert.AreEqual(0, aCategory.User.GetUserPasswordPairsOfASpecificColor(PasswordStrengthType.DarkGreen).Length);
            Assert.AreEqual(1, aCategory.User.GetUserPasswordPairsOfASpecificColor(PasswordStrengthType.Red).Length);
            Assert.AreEqual(0, aCategory.GetUserPasswordPairsOfASpecificColorQuantity(PasswordStrengthType.DarkGreen));
            Assert.AreEqual(1, aCategory.GetUserPasswordPairsOfASpecificColorQuantity(PasswordStrengthType.Red));
        }


        [TestMethod]
        public void ModifyDarkGreenUserPasswordPairToAYellowOne()
        {
            UserPasswordPair aUserPasswordPair = new UserPasswordPair()
            {
                Category = aCategory,
                Password = "myPassword12345#$%",
                Notes = "myNotes",
                Username = "myUsername",
                Site = "mySite",
            };

            aCategory.AddUserPasswordPair(aUserPasswordPair);

            UserPasswordPair newUserPasswordPair = new UserPasswordPair()
            {
                Category = aCategory,
                Password = "mypassword12345",
                Notes = "myNotes",
                Username = "myUsername",
                Site = "mySite",
            };

            Assert.IsTrue(aCategory.ModifyUserPasswordPair(aUserPasswordPair, newUserPasswordPair));
            Assert.AreEqual(0, aCategory.User.GetUserPasswordPairsOfASpecificColor(PasswordStrengthType.DarkGreen).Length);
            Assert.AreEqual(1, aCategory.User.GetUserPasswordPairsOfASpecificColor(PasswordStrengthType.Yellow).Length);
            Assert.AreEqual(0, aCategory.GetUserPasswordPairsOfASpecificColorQuantity(PasswordStrengthType.DarkGreen));
            Assert.AreEqual(1, aCategory.GetUserPasswordPairsOfASpecificColorQuantity(PasswordStrengthType.Yellow));
        }

        [TestMethod]
        public void ModifyLightGreenUserPasswordPairToADarkGreenOne()
        {
            UserPasswordPair aUserPasswordPair = new UserPasswordPair()
            {
                Category = aCategory,
                Password = "myPassword12345",
                Notes = "myNotes",
                Username = "myUsername",
                Site = "mySite",
            };

            aCategory.AddUserPasswordPair(aUserPasswordPair);

            UserPasswordPair newUserPasswordPair = new UserPasswordPair()
            {
                Category = aCategory,
                Password = "myPassword12345#$%",
                Notes = "myNotes",
                Username = "myUsername",
                Site = "mySite",
            };

            Assert.IsTrue(aCategory.ModifyUserPasswordPair(aUserPasswordPair, newUserPasswordPair));
            Assert.AreEqual(0, aCategory.User.GetUserPasswordPairsOfASpecificColor(PasswordStrengthType.LightGreen).Length);
            Assert.AreEqual(1, aCategory.User.GetUserPasswordPairsOfASpecificColor(PasswordStrengthType.DarkGreen).Length);
            Assert.AreEqual(0, aCategory.GetUserPasswordPairsOfASpecificColorQuantity(PasswordStrengthType.LightGreen));
            Assert.AreEqual(1, aCategory.GetUserPasswordPairsOfASpecificColorQuantity(PasswordStrengthType.DarkGreen));
        }

        [TestMethod]
        public void ModifyLightGreenUserPasswordPairToALightGreenOne()
        {
            UserPasswordPair aUserPasswordPair = new UserPasswordPair()
            {
                Category = aCategory,
                Password = "myPassword12345",
                Notes = "myNotes",
                Username = "myUsername",
                Site = "mySite",
            };

            aCategory.AddUserPasswordPair(aUserPasswordPair);

            UserPasswordPair newUserPasswordPair = new UserPasswordPair()
            {
                Category = aCategory,
                Password = "myPassword54321",
                Notes = "myNotes",
                Username = "myUsername",
                Site = "mySite",
            };

            Assert.IsTrue(aCategory.ModifyUserPasswordPair(aUserPasswordPair, newUserPasswordPair));
            Assert.AreEqual(1, aCategory.User.GetUserPasswordPairsOfASpecificColor(PasswordStrengthType.LightGreen).Length);
            Assert.AreEqual(1, aCategory.GetUserPasswordPairsOfASpecificColorQuantity(PasswordStrengthType.LightGreen));
        }

        [TestMethod]
        public void ModifyLightGreenUserPasswordPairToAnOrangeOne()
        {
            UserPasswordPair aUserPasswordPair = new UserPasswordPair()
            {
                Category = aCategory,
                Password = "myPassword12345",
                Notes = "myNotes",
                Username = "myUsername",
                Site = "mySite",
            };

            aCategory.AddUserPasswordPair(aUserPasswordPair);

            UserPasswordPair newUserPasswordPair = new UserPasswordPair()
            {
                Category = aCategory,
                Password = "myPassword",
                Notes = "myNotes",
                Username = "myUsername",
                Site = "mySite",
            };

            Assert.IsTrue(aCategory.ModifyUserPasswordPair(aUserPasswordPair, newUserPasswordPair));
            Assert.AreEqual(0, aCategory.User.GetUserPasswordPairsOfASpecificColor(PasswordStrengthType.LightGreen).Length);
            Assert.AreEqual(1, aCategory.User.GetUserPasswordPairsOfASpecificColor(PasswordStrengthType.Orange).Length);
            Assert.AreEqual(0, aCategory.GetUserPasswordPairsOfASpecificColorQuantity(PasswordStrengthType.LightGreen));
            Assert.AreEqual(1, aCategory.GetUserPasswordPairsOfASpecificColorQuantity(PasswordStrengthType.Orange));
        }

        [TestMethod]
        public void ModifyLightGreenUserPasswordPairToARedOne()
        {
            UserPasswordPair aUserPasswordPair = new UserPasswordPair()
            {
                Category = aCategory,
                Password = "myPassword12345",
                Notes = "myNotes",
                Username = "myUsername",
                Site = "mySite",
            };

            aCategory.AddUserPasswordPair(aUserPasswordPair);

            UserPasswordPair newUserPasswordPair = new UserPasswordPair()
            {
                Category = aCategory,
                Password = "myPass",
                Notes = "myNotes",
                Username = "myUsername",
                Site = "mySite",
            };

            Assert.IsTrue(aCategory.ModifyUserPasswordPair(aUserPasswordPair, newUserPasswordPair));
            Assert.AreEqual(0, aCategory.User.GetUserPasswordPairsOfASpecificColor(PasswordStrengthType.LightGreen).Length);
            Assert.AreEqual(1, aCategory.User.GetUserPasswordPairsOfASpecificColor(PasswordStrengthType.Red).Length);
            Assert.AreEqual(0, aCategory.GetUserPasswordPairsOfASpecificColorQuantity(PasswordStrengthType.LightGreen));
            Assert.AreEqual(1, aCategory.GetUserPasswordPairsOfASpecificColorQuantity(PasswordStrengthType.Red));
        }

        [TestMethod]
        public void ModifyLightGreenUserPasswordPairToAYellowOne()
        {
            UserPasswordPair aUserPasswordPair = new UserPasswordPair()
            {
                Category = aCategory,
                Password = "myPassword12345",
                Notes = "myNotes",
                Username = "myUsername",
                Site = "mySite",
            };

            aCategory.AddUserPasswordPair(aUserPasswordPair);

            UserPasswordPair newUserPasswordPair = new UserPasswordPair()
            {
                Category = aCategory,
                Password = "mypassword12345",
                Notes = "myNotes",
                Username = "myUsername",
                Site = "mySite",
            };

            Assert.IsTrue(aCategory.ModifyUserPasswordPair(aUserPasswordPair, newUserPasswordPair));
            Assert.AreEqual(0, aCategory.User.GetUserPasswordPairsOfASpecificColor(PasswordStrengthType.LightGreen).Length);
            Assert.AreEqual(1, aCategory.User.GetUserPasswordPairsOfASpecificColor(PasswordStrengthType.Yellow).Length);
            Assert.AreEqual(0, aCategory.GetUserPasswordPairsOfASpecificColorQuantity(PasswordStrengthType.LightGreen));
            Assert.AreEqual(1, aCategory.GetUserPasswordPairsOfASpecificColorQuantity(PasswordStrengthType.Yellow));
        }

        [TestMethod]
        public void ModifyOrangeUserPasswordPairToADarkGreenOne()
        {
            UserPasswordPair aUserPasswordPair = new UserPasswordPair()
            {
                Category = aCategory,
                Password = "myPassword",
                Notes = "myNotes",
                Username = "myUsername",
                Site = "mySite",
            };

            aCategory.AddUserPasswordPair(aUserPasswordPair);

            UserPasswordPair newUserPasswordPair = new UserPasswordPair()
            {
                Category = aCategory,
                Password = "myPassword!@#$34@&^",
                Notes = "myNotes",
                Username = "myUsername",
                Site = "mySite",
            };

            Assert.IsTrue(aCategory.ModifyUserPasswordPair(aUserPasswordPair, newUserPasswordPair));
            Assert.AreEqual(0, aCategory.User.GetUserPasswordPairsOfASpecificColor(PasswordStrengthType.Orange).Length);
            Assert.AreEqual(1, aCategory.User.GetUserPasswordPairsOfASpecificColor(PasswordStrengthType.DarkGreen).Length);
            Assert.AreEqual(0, aCategory.GetUserPasswordPairsOfASpecificColorQuantity(PasswordStrengthType.Orange));
            Assert.AreEqual(1, aCategory.GetUserPasswordPairsOfASpecificColorQuantity(PasswordStrengthType.DarkGreen));
        }

        [TestMethod]
        public void ModifyOrangeUserPasswordPairToALightGreenOne()
        {
            UserPasswordPair aUserPasswordPair = new UserPasswordPair()
            {
                Category = aCategory,
                Password = "myPassword",
                Notes = "myNotes",
                Username = "myUsername",
                Site = "mySite",
            };

            aCategory.AddUserPasswordPair(aUserPasswordPair);

            UserPasswordPair newUserPasswordPair = new UserPasswordPair()
            {
                Category = aCategory,
                Password = "myPassword!@#$!@&^",
                Notes = "myNotes",
                Username = "myUsername",
                Site = "mySite",
            };

            Assert.IsTrue(aCategory.ModifyUserPasswordPair(aUserPasswordPair, newUserPasswordPair));
            Assert.AreEqual(0, aCategory.User.GetUserPasswordPairsOfASpecificColor(PasswordStrengthType.Orange).Length);
            Assert.AreEqual(1, aCategory.User.GetUserPasswordPairsOfASpecificColor(PasswordStrengthType.LightGreen).Length);
            Assert.AreEqual(0, aCategory.GetUserPasswordPairsOfASpecificColorQuantity(PasswordStrengthType.Orange));
            Assert.AreEqual(1, aCategory.GetUserPasswordPairsOfASpecificColorQuantity(PasswordStrengthType.LightGreen));
        }

        [TestMethod]
        public void ModifyOrangeUserPasswordPairToAnOrangeOne()
        {
            UserPasswordPair aUserPasswordPair = new UserPasswordPair()
            {
                Category = aCategory,
                Password = "myPassword",
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
            Assert.AreEqual(1, aCategory.User.GetUserPasswordPairsOfASpecificColor(PasswordStrengthType.Orange).Length);
            Assert.AreEqual(1, aCategory.GetUserPasswordPairsOfASpecificColorQuantity(PasswordStrengthType.Orange));
        }

        [TestMethod]
        public void ModifyOrangeUserPasswordPairToARedOne()
        {
            UserPasswordPair aUserPasswordPair = new UserPasswordPair()
            {
                Category = aCategory,
                Password = "myPassword",
                Notes = "myNotes",
                Username = "myUsername",
                Site = "mySite",
            };

            aCategory.AddUserPasswordPair(aUserPasswordPair);

            UserPasswordPair newUserPasswordPair = new UserPasswordPair()
            {
                Category = aCategory,
                Password = "myPass",
                Notes = "myNotes",
                Username = "myUsername",
                Site = "mySite",
            };

            Assert.IsTrue(aCategory.ModifyUserPasswordPair(aUserPasswordPair, newUserPasswordPair));
            Assert.AreEqual(0, aCategory.User.GetUserPasswordPairsOfASpecificColor(PasswordStrengthType.Orange).Length);
            Assert.AreEqual(1, aCategory.User.GetUserPasswordPairsOfASpecificColor(PasswordStrengthType.Red).Length);
            Assert.AreEqual(0, aCategory.GetUserPasswordPairsOfASpecificColorQuantity(PasswordStrengthType.Orange));
            Assert.AreEqual(1, aCategory.GetUserPasswordPairsOfASpecificColorQuantity(PasswordStrengthType.Red));
        }

        [TestMethod]
        public void ModifyOrangeUserPasswordPairToAYellowOne()
        {
            UserPasswordPair aUserPasswordPair = new UserPasswordPair()
            {
                Category = aCategory,
                Password = "myPassword",
                Notes = "myNotes",
                Username = "myUsername",
                Site = "mySite",
            };

            aCategory.AddUserPasswordPair(aUserPasswordPair);

            UserPasswordPair newUserPasswordPair = new UserPasswordPair()
            {
                Category = aCategory,
                Password = "mypassword123456",
                Notes = "myNotes",
                Username = "myUsername",
                Site = "mySite",
            };

            Assert.IsTrue(aCategory.ModifyUserPasswordPair(aUserPasswordPair, newUserPasswordPair));
            Assert.AreEqual(0, aCategory.User.GetUserPasswordPairsOfASpecificColor(PasswordStrengthType.Orange).Length);
            Assert.AreEqual(1, aCategory.User.GetUserPasswordPairsOfASpecificColor(PasswordStrengthType.Yellow).Length);
            Assert.AreEqual(0, aCategory.GetUserPasswordPairsOfASpecificColorQuantity(PasswordStrengthType.Orange));
            Assert.AreEqual(1, aCategory.GetUserPasswordPairsOfASpecificColorQuantity(PasswordStrengthType.Yellow));
        }

        [TestMethod]
        public void ModifyRedUserPasswordPairToADarkGreenOne()
        {
            UserPasswordPair aUserPasswordPair = new UserPasswordPair()
            {
                Category = aCategory,
                Password = "myPass",
                Notes = "myNotes",
                Username = "myUsername",
                Site = "mySite",
            };

            aCategory.AddUserPasswordPair(aUserPasswordPair);

            UserPasswordPair newUserPasswordPair = new UserPasswordPair()
            {
                Category = aCategory,
                Password = "newPassword@!12345",
                Notes = "myNotes",
                Username = "myUsername",
                Site = "mySite",
            };

            Assert.IsTrue(aCategory.ModifyUserPasswordPair(aUserPasswordPair, newUserPasswordPair));
            Assert.AreEqual(0, aCategory.User.GetUserPasswordPairsOfASpecificColor(PasswordStrengthType.Red).Length);
            Assert.AreEqual(1, aCategory.User.GetUserPasswordPairsOfASpecificColor(PasswordStrengthType.DarkGreen).Length);
            Assert.AreEqual(0, aCategory.GetUserPasswordPairsOfASpecificColorQuantity(PasswordStrengthType.Red));
            Assert.AreEqual(1, aCategory.GetUserPasswordPairsOfASpecificColorQuantity(PasswordStrengthType.DarkGreen));
        }

        [TestMethod]
        public void ModifyRedUserPasswordPairToALightGreenOne()
        {
            UserPasswordPair aUserPasswordPair = new UserPasswordPair()
            {
                Category = aCategory,
                Password = "myPass",
                Notes = "myNotes",
                Username = "myUsername",
                Site = "mySite",
            };

            aCategory.AddUserPasswordPair(aUserPasswordPair);

            UserPasswordPair newUserPasswordPair = new UserPasswordPair()
            {
                Category = aCategory,
                Password = "newPassword12345",
                Notes = "myNotes",
                Username = "myUsername",
                Site = "mySite",
            };

            Assert.IsTrue(aCategory.ModifyUserPasswordPair(aUserPasswordPair, newUserPasswordPair));
            Assert.AreEqual(0, aCategory.User.GetUserPasswordPairsOfASpecificColor(PasswordStrengthType.Red).Length);
            Assert.AreEqual(1, aCategory.User.GetUserPasswordPairsOfASpecificColor(PasswordStrengthType.LightGreen).Length);
            Assert.AreEqual(0, aCategory.GetUserPasswordPairsOfASpecificColorQuantity(PasswordStrengthType.Red));
            Assert.AreEqual(1, aCategory.GetUserPasswordPairsOfASpecificColorQuantity(PasswordStrengthType.LightGreen));
        }

        [TestMethod]
        public void ModifyRedUserPasswordPairToAnOrangeOne()
        {
            UserPasswordPair aUserPasswordPair = new UserPasswordPair()
            {
                Category = aCategory,
                Password = "myPass",
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
            Assert.AreEqual(0, aCategory.User.GetUserPasswordPairsOfASpecificColor(PasswordStrengthType.Red).Length);
            Assert.AreEqual(1, aCategory.User.GetUserPasswordPairsOfASpecificColor(PasswordStrengthType.Orange).Length);
            Assert.AreEqual(0, aCategory.GetUserPasswordPairsOfASpecificColorQuantity(PasswordStrengthType.Red));
            Assert.AreEqual(1, aCategory.GetUserPasswordPairsOfASpecificColorQuantity(PasswordStrengthType.Orange));
        }

        [TestMethod]
        public void ModifyRedUserPasswordPairToARedOne()
        {
            UserPasswordPair aUserPasswordPair = new UserPasswordPair()
            {
                Category = aCategory,
                Password = "myPass",
                Notes = "myNotes",
                Username = "myUsername",
                Site = "mySite",
            };

            aCategory.AddUserPasswordPair(aUserPasswordPair);

            UserPasswordPair newUserPasswordPair = new UserPasswordPair()
            {
                Category = aCategory,
                Password = "newPass",
                Notes = "myNotes",
                Username = "myUsername",
                Site = "mySite",
            };

            Assert.IsTrue(aCategory.ModifyUserPasswordPair(aUserPasswordPair, newUserPasswordPair));
            Assert.AreEqual(1, aCategory.User.GetUserPasswordPairsOfASpecificColor(PasswordStrengthType.Red).Length);
            Assert.AreEqual(1, aCategory.GetUserPasswordPairsOfASpecificColorQuantity(PasswordStrengthType.Red));
        }

        [TestMethod]
        public void ModifyRedUserPasswordPairToAYellowOne()
        {
            UserPasswordPair aUserPasswordPair = new UserPasswordPair()
            {
                Category = aCategory,
                Password = "myPass",
                Notes = "myNotes",
                Username = "myUsername",
                Site = "mySite",
            };

            aCategory.AddUserPasswordPair(aUserPasswordPair);

            UserPasswordPair newUserPasswordPair = new UserPasswordPair()
            {
                Category = aCategory,
                Password = "newpassword1234",
                Notes = "myNotes",
                Username = "myUsername",
                Site = "mySite",
            };

            Assert.IsTrue(aCategory.ModifyUserPasswordPair(aUserPasswordPair, newUserPasswordPair));
            Assert.AreEqual(0, aCategory.User.GetUserPasswordPairsOfASpecificColor(PasswordStrengthType.Red).Length);
            Assert.AreEqual(1, aCategory.User.GetUserPasswordPairsOfASpecificColor(PasswordStrengthType.Yellow).Length);
            Assert.AreEqual(0, aCategory.GetUserPasswordPairsOfASpecificColorQuantity(PasswordStrengthType.Red));
            Assert.AreEqual(1, aCategory.GetUserPasswordPairsOfASpecificColorQuantity(PasswordStrengthType.Yellow));
        }

        [TestMethod]
        public void ModifyYellowUserPasswordPairToADarkGreenOne()
        {
            UserPasswordPair aUserPasswordPair = new UserPasswordPair()
            {
                Category = aCategory,
                Password = "password1234567",
                Notes = "myNotes",
                Username = "myUsername",
                Site = "mySite",
            };

            aCategory.AddUserPasswordPair(aUserPasswordPair);

            UserPasswordPair newUserPasswordPair = new UserPasswordPair()
            {
                Category = aCategory,
                Password = "myPassword12345!@$",
                Notes = "myNotes",
                Username = "myUsername",
                Site = "mySite",
            };

            Assert.IsTrue(aCategory.ModifyUserPasswordPair(aUserPasswordPair, newUserPasswordPair));
            Assert.AreEqual(0, aCategory.User.GetUserPasswordPairsOfASpecificColor(PasswordStrengthType.Yellow).Length);
            Assert.AreEqual(1, aCategory.User.GetUserPasswordPairsOfASpecificColor(PasswordStrengthType.DarkGreen).Length);
            Assert.AreEqual(0, aCategory.GetUserPasswordPairsOfASpecificColorQuantity(PasswordStrengthType.Yellow));
            Assert.AreEqual(1, aCategory.GetUserPasswordPairsOfASpecificColorQuantity(PasswordStrengthType.DarkGreen));
        }


        [TestMethod]
        public void ModifyYellowUserPasswordPairToALightGreenOne()
        {
            UserPasswordPair aUserPasswordPair = new UserPasswordPair()
            {
                Category = aCategory,
                Password = "password1234567",
                Notes = "myNotes",
                Username = "myUsername",
                Site = "mySite",
            };

            aCategory.AddUserPasswordPair(aUserPasswordPair);

            UserPasswordPair newUserPasswordPair = new UserPasswordPair()
            {
                Category = aCategory,
                Password = "myPassword12345",
                Notes = "myNotes",
                Username = "myUsername",
                Site = "mySite",
            };

            Assert.IsTrue(aCategory.ModifyUserPasswordPair(aUserPasswordPair, newUserPasswordPair));
            Assert.AreEqual(0, aCategory.User.GetUserPasswordPairsOfASpecificColor(PasswordStrengthType.Yellow).Length);
            Assert.AreEqual(1, aCategory.User.GetUserPasswordPairsOfASpecificColor(PasswordStrengthType.LightGreen).Length);
            Assert.AreEqual(0, aCategory.GetUserPasswordPairsOfASpecificColorQuantity(PasswordStrengthType.Yellow));
            Assert.AreEqual(1, aCategory.GetUserPasswordPairsOfASpecificColorQuantity(PasswordStrengthType.LightGreen));
        }

        [TestMethod]
        public void ModifyYellowUserPasswordPairToAnOrangeOne()
        {
            UserPasswordPair aUserPasswordPair = new UserPasswordPair()
            {
                Category = aCategory,
                Password = "password1234567",
                Notes = "myNotes",
                Username = "myUsername",
                Site = "mySite",
            };

            aCategory.AddUserPasswordPair(aUserPasswordPair);

            UserPasswordPair newUserPasswordPair = new UserPasswordPair()
            {
                Category = aCategory,
                Password = "myPassword12",
                Notes = "myNotes",
                Username = "myUsername",
                Site = "mySite",
            };

            Assert.IsTrue(aCategory.ModifyUserPasswordPair(aUserPasswordPair, newUserPasswordPair));
            Assert.AreEqual(0, aCategory.User.GetUserPasswordPairsOfASpecificColor(PasswordStrengthType.Yellow).Length);
            Assert.AreEqual(1, aCategory.User.GetUserPasswordPairsOfASpecificColor(PasswordStrengthType.Orange).Length);
            Assert.AreEqual(0, aCategory.GetUserPasswordPairsOfASpecificColorQuantity(PasswordStrengthType.Yellow));
            Assert.AreEqual(1, aCategory.GetUserPasswordPairsOfASpecificColorQuantity(PasswordStrengthType.Orange));
        }

        [TestMethod]
        public void ModifyYellowUserPasswordPairToARedOne()
        {
            UserPasswordPair aUserPasswordPair = new UserPasswordPair()
            {
                Category = aCategory,
                Password = "password1234567",
                Notes = "myNotes",
                Username = "myUsername",
                Site = "mySite",
            };

            aCategory.AddUserPasswordPair(aUserPasswordPair);

            UserPasswordPair newUserPasswordPair = new UserPasswordPair()
            {
                Category = aCategory,
                Password = "myPass",
                Notes = "myNotes",
                Username = "myUsername",
                Site = "mySite",
            };

            Assert.IsTrue(aCategory.ModifyUserPasswordPair(aUserPasswordPair, newUserPasswordPair));
            Assert.AreEqual(0, aCategory.User.GetUserPasswordPairsOfASpecificColor(PasswordStrengthType.Yellow).Length);
            Assert.AreEqual(1, aCategory.User.GetUserPasswordPairsOfASpecificColor(PasswordStrengthType.Red).Length);
            Assert.AreEqual(0, aCategory.GetUserPasswordPairsOfASpecificColorQuantity(PasswordStrengthType.Yellow));
            Assert.AreEqual(1, aCategory.GetUserPasswordPairsOfASpecificColorQuantity(PasswordStrengthType.Red));
        }

        [TestMethod]
        public void ModifyYellowUserPasswordPairToAYellowOne()
        {
            UserPasswordPair aUserPasswordPair = new UserPasswordPair()
            {
                Category = aCategory,
                Password = "password1234567",
                Notes = "myNotes",
                Username = "myUsername",
                Site = "mySite",
            };

            aCategory.AddUserPasswordPair(aUserPasswordPair);

            UserPasswordPair newUserPasswordPair = new UserPasswordPair()
            {
                Category = aCategory,
                Password = "password7654321",
                Notes = "myNotes",
                Username = "myUsername",
                Site = "mySite",
            };

            Assert.IsTrue(aCategory.ModifyUserPasswordPair(aUserPasswordPair, newUserPasswordPair));
            Assert.AreEqual(1, aCategory.User.GetUserPasswordPairsOfASpecificColor(PasswordStrengthType.Yellow).Length);
            Assert.AreEqual(1, aCategory.GetUserPasswordPairsOfASpecificColorQuantity(PasswordStrengthType.Yellow));
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