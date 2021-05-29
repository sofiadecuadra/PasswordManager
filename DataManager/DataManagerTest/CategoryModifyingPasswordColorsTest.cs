using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataManagerDomain;

namespace DataManagerTest
{
    [TestClass]
    public class CategoryModifyingPasswordColorsTest
    {
        private NormalCategory aCategory;
        private User aUser;

        [TestInitialize]
        public void Initialize()
        {
            aUser = new User();
            aCategory = new NormalCategory()
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
                Password = "myPassword12345#$%",
                Notes = "myNotes",
                Username = "myUsername",
                Site = "mySite",
                Category = aCategory,
            };

            aCategory.AddUserPasswordPair(aUserPasswordPair);

            UserPasswordPair newUserPasswordPair = new UserPasswordPair()
            {
                Password = "myPassword!#32#$%",
                Notes = "myNotes",
                Username = "myUsername",
                Site = "mySite",
                Category = aCategory,
            };

            Assert.IsTrue(aCategory.ModifyUserPasswordPair(aUserPasswordPair, newUserPasswordPair));
            Assert.AreEqual(1, aCategory.User.GetDarkGreenUserPasswordPairs().Length);
            Assert.AreEqual(1, aCategory.DarkGreenUserPasswordPairsQuantity);
        }

        [TestMethod]
        public void ModifyDarkGreenUserPasswordPairToALightGreenOne()
        {
            UserPasswordPair aUserPasswordPair = new UserPasswordPair()
            {
                Password = "myPassword12345#$%",
                Notes = "myNotes",
                Username = "myUsername",
                Site = "mySite",
                Category = aCategory,
            };

            aCategory.AddUserPasswordPair(aUserPasswordPair);

            UserPasswordPair newUserPasswordPair = new UserPasswordPair()
            {
                Password = "myPassword12345",
                Notes = "myNotes",
                Username = "myUsername",
                Site = "mySite",
                Category = aCategory,
            };

            Assert.IsTrue(aCategory.ModifyUserPasswordPair(aUserPasswordPair, newUserPasswordPair));
            Assert.AreEqual(0, aCategory.User.GetDarkGreenUserPasswordPairs().Length);
            Assert.AreEqual(1, aCategory.User.GetLightGreenUserPasswordPairs().Length);
            Assert.AreEqual(0, aCategory.DarkGreenUserPasswordPairsQuantity);
            Assert.AreEqual(1, aCategory.LightGreenUserPasswordPairsQuantity);
        }

        [TestMethod]
        public void ModifyDarkGreenUserPasswordPairToAnOrangeOne()
        {
            UserPasswordPair aUserPasswordPair = new UserPasswordPair()
            {
                Password = "myPassword12345#$%",
                Notes = "myNotes",
                Username = "myUsername",
                Site = "mySite",
                Category = aCategory,
            };

            aCategory.AddUserPasswordPair(aUserPasswordPair);

            UserPasswordPair newUserPasswordPair = new UserPasswordPair()
            {
                Password = "myPassword",
                Notes = "myNotes",
                Username = "myUsername",
                Site = "mySite",
                Category = aCategory,
            };

            Assert.IsTrue(aCategory.ModifyUserPasswordPair(aUserPasswordPair, newUserPasswordPair));
            Assert.AreEqual(0, aCategory.User.GetDarkGreenUserPasswordPairs().Length);
            Assert.AreEqual(1, aCategory.User.GetOrangeUserPasswordPairs().Length);
            Assert.AreEqual(0, aCategory.DarkGreenUserPasswordPairsQuantity);
            Assert.AreEqual(1, aCategory.OrangeUserPasswordPairsQuantity);
        }

        [TestMethod]
        public void ModifyDarkGreenUserPasswordPairToARedOne()
        {
            UserPasswordPair aUserPasswordPair = new UserPasswordPair()
            {
                Password = "myPassword12345#$%",
                Notes = "myNotes",
                Username = "myUsername",
                Site = "mySite",
                Category = aCategory,
            };

            aCategory.AddUserPasswordPair(aUserPasswordPair);

            UserPasswordPair newUserPasswordPair = new UserPasswordPair()
            {
                Password = "myPass",
                Notes = "myNotes",
                Username = "myUsername",
                Site = "mySite",
                Category = aCategory,
            };

            Assert.IsTrue(aCategory.ModifyUserPasswordPair(aUserPasswordPair, newUserPasswordPair));
            Assert.AreEqual(0, aCategory.User.GetDarkGreenUserPasswordPairs().Length);
            Assert.AreEqual(1, aCategory.User.GetRedUserPasswordPairs().Length);
            Assert.AreEqual(0, aCategory.DarkGreenUserPasswordPairsQuantity);
            Assert.AreEqual(1, aCategory.RedUserPasswordPairsQuantity);
        }


        [TestMethod]
        public void ModifyDarkGreenUserPasswordPairToAYellowOne()
        {
            UserPasswordPair aUserPasswordPair = new UserPasswordPair()
            {
                Password = "myPassword12345#$%",
                Notes = "myNotes",
                Username = "myUsername",
                Site = "mySite",
                Category = aCategory,
            };

            aCategory.AddUserPasswordPair(aUserPasswordPair);

            UserPasswordPair newUserPasswordPair = new UserPasswordPair()
            {
                Password = "mypassword12345",
                Notes = "myNotes",
                Username = "myUsername",
                Site = "mySite",
                Category = aCategory,
            };

            Assert.IsTrue(aCategory.ModifyUserPasswordPair(aUserPasswordPair, newUserPasswordPair));
            Assert.AreEqual(0, aCategory.User.GetDarkGreenUserPasswordPairs().Length);
            Assert.AreEqual(1, aCategory.User.GetYellowUserPasswordPairs().Length);
            Assert.AreEqual(0, aCategory.DarkGreenUserPasswordPairsQuantity);
            Assert.AreEqual(1, aCategory.YellowUserPasswordPairsQuantity);
        }

        [TestMethod]
        public void ModifyLightGreenUserPasswordPairToADarkGreenOne()
        {
            UserPasswordPair aUserPasswordPair = new UserPasswordPair()
            {
                Password = "myPassword12345",
                Notes = "myNotes",
                Username = "myUsername",
                Site = "mySite",
                Category = aCategory,
            };

            aCategory.AddUserPasswordPair(aUserPasswordPair);

            UserPasswordPair newUserPasswordPair = new UserPasswordPair()
            {
                Password = "myPassword12345#$%",
                Notes = "myNotes",
                Username = "myUsername",
                Site = "mySite",
                Category = aCategory,
            };

            Assert.IsTrue(aCategory.ModifyUserPasswordPair(aUserPasswordPair, newUserPasswordPair));
            Assert.AreEqual(0, aCategory.User.GetLightGreenUserPasswordPairs().Length);
            Assert.AreEqual(1, aCategory.User.GetDarkGreenUserPasswordPairs().Length);
            Assert.AreEqual(0, aCategory.LightGreenUserPasswordPairsQuantity);
            Assert.AreEqual(1, aCategory.DarkGreenUserPasswordPairsQuantity);
        }

        [TestMethod]
        public void ModifyLightGreenUserPasswordPairToALightGreenOne()
        {
            UserPasswordPair aUserPasswordPair = new UserPasswordPair()
            {
                Password = "myPassword12345",
                Notes = "myNotes",
                Username = "myUsername",
                Site = "mySite",
                Category = aCategory,
            };

            aCategory.AddUserPasswordPair(aUserPasswordPair);

            UserPasswordPair newUserPasswordPair = new UserPasswordPair()
            {
                Password = "myPassword54321",
                Notes = "myNotes",
                Username = "myUsername",
                Site = "mySite",
                Category = aCategory,
            };

            Assert.IsTrue(aCategory.ModifyUserPasswordPair(aUserPasswordPair, newUserPasswordPair));
            Assert.AreEqual(1, aCategory.User.GetLightGreenUserPasswordPairs().Length);
            Assert.AreEqual(1, aCategory.LightGreenUserPasswordPairsQuantity);
        }

        [TestMethod]
        public void ModifyLightGreenUserPasswordPairToAnOrangeOne()
        {
            UserPasswordPair aUserPasswordPair = new UserPasswordPair()
            {
                Password = "myPassword12345",
                Notes = "myNotes",
                Username = "myUsername",
                Site = "mySite",
                Category = aCategory,
            };

            aCategory.AddUserPasswordPair(aUserPasswordPair);

            UserPasswordPair newUserPasswordPair = new UserPasswordPair()
            {
                Password = "myPassword",
                Notes = "myNotes",
                Username = "myUsername",
                Site = "mySite",
                Category = aCategory,
            };

            Assert.IsTrue(aCategory.ModifyUserPasswordPair(aUserPasswordPair, newUserPasswordPair));
            Assert.AreEqual(0, aCategory.User.GetLightGreenUserPasswordPairs().Length);
            Assert.AreEqual(1, aCategory.User.GetOrangeUserPasswordPairs().Length);
            Assert.AreEqual(0, aCategory.LightGreenUserPasswordPairsQuantity);
            Assert.AreEqual(1, aCategory.OrangeUserPasswordPairsQuantity);
        }

        [TestMethod]
        public void ModifyLightGreenUserPasswordPairToARedOne()
        {
            UserPasswordPair aUserPasswordPair = new UserPasswordPair()
            {
                Password = "myPassword12345",
                Notes = "myNotes",
                Username = "myUsername",
                Site = "mySite",
                Category = aCategory,
            };

            aCategory.AddUserPasswordPair(aUserPasswordPair);

            UserPasswordPair newUserPasswordPair = new UserPasswordPair()
            {
                Password = "myPass",
                Notes = "myNotes",
                Username = "myUsername",
                Site = "mySite",
                Category = aCategory,
            };

            Assert.IsTrue(aCategory.ModifyUserPasswordPair(aUserPasswordPair, newUserPasswordPair));
            Assert.AreEqual(0, aCategory.User.GetLightGreenUserPasswordPairs().Length);
            Assert.AreEqual(1, aCategory.User.GetRedUserPasswordPairs().Length);
            Assert.AreEqual(0, aCategory.LightGreenUserPasswordPairsQuantity);
            Assert.AreEqual(1, aCategory.RedUserPasswordPairsQuantity);
        }

        [TestMethod]
        public void ModifyLightGreenUserPasswordPairToAYellowOne()
        {
            UserPasswordPair aUserPasswordPair = new UserPasswordPair()
            {
                Password = "myPassword12345",
                Notes = "myNotes",
                Username = "myUsername",
                Site = "mySite",
                Category = aCategory,
            };

            aCategory.AddUserPasswordPair(aUserPasswordPair);

            UserPasswordPair newUserPasswordPair = new UserPasswordPair()
            {
                Password = "mypassword12345",
                Notes = "myNotes",
                Username = "myUsername",
                Site = "mySite",
                Category = aCategory,
            };

            Assert.IsTrue(aCategory.ModifyUserPasswordPair(aUserPasswordPair, newUserPasswordPair));
            Assert.AreEqual(0, aCategory.User.GetLightGreenUserPasswordPairs().Length);
            Assert.AreEqual(1, aCategory.User.GetYellowUserPasswordPairs().Length);
            Assert.AreEqual(0, aCategory.LightGreenUserPasswordPairsQuantity);
            Assert.AreEqual(1, aCategory.YellowUserPasswordPairsQuantity);
        }

        [TestMethod]
        public void ModifyOrangeUserPasswordPairToADarkGreenOne()
        {
            UserPasswordPair aUserPasswordPair = new UserPasswordPair()
            {
                Password = "myPassword",
                Notes = "myNotes",
                Username = "myUsername",
                Site = "mySite",
                Category = aCategory,
            };

            aCategory.AddUserPasswordPair(aUserPasswordPair);

            UserPasswordPair newUserPasswordPair = new UserPasswordPair()
            {
                Password = "myPassword!@#$34@&^",
                Notes = "myNotes",
                Username = "myUsername",
                Site = "mySite",
                Category = aCategory,
            };

            Assert.IsTrue(aCategory.ModifyUserPasswordPair(aUserPasswordPair, newUserPasswordPair));
            Assert.AreEqual(0, aCategory.User.GetOrangeUserPasswordPairs().Length);
            Assert.AreEqual(1, aCategory.User.GetDarkGreenUserPasswordPairs().Length);
            Assert.AreEqual(0, aCategory.OrangeUserPasswordPairsQuantity);
            Assert.AreEqual(1, aCategory.DarkGreenUserPasswordPairsQuantity);
        }

        [TestMethod]
        public void ModifyOrangeUserPasswordPairToALightGreenOne()
        {
            UserPasswordPair aUserPasswordPair = new UserPasswordPair()
            {
                Password = "myPassword",
                Notes = "myNotes",
                Username = "myUsername",
                Site = "mySite",
                Category = aCategory,
            };

            aCategory.AddUserPasswordPair(aUserPasswordPair);

            UserPasswordPair newUserPasswordPair = new UserPasswordPair()
            {
                Password = "myPassword!@#$!@&^",
                Notes = "myNotes",
                Username = "myUsername",
                Site = "mySite",
                Category = aCategory,
            };

            Assert.IsTrue(aCategory.ModifyUserPasswordPair(aUserPasswordPair, newUserPasswordPair));
            Assert.AreEqual(0, aCategory.User.GetOrangeUserPasswordPairs().Length);
            Assert.AreEqual(1, aCategory.User.GetLightGreenUserPasswordPairs().Length);
            Assert.AreEqual(0, aCategory.OrangeUserPasswordPairsQuantity);
            Assert.AreEqual(1, aCategory.LightGreenUserPasswordPairsQuantity);
        }

        [TestMethod]
        public void ModifyOrangeUserPasswordPairToAnOrangeOne()
        {
            UserPasswordPair aUserPasswordPair = new UserPasswordPair()
            {
                Password = "myPassword",
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
            Assert.AreEqual(1, aCategory.User.GetOrangeUserPasswordPairs().Length);
            Assert.AreEqual(1, aCategory.OrangeUserPasswordPairsQuantity);
        }

        [TestMethod]
        public void ModifyOrangeUserPasswordPairToARedOne()
        {
            UserPasswordPair aUserPasswordPair = new UserPasswordPair()
            {
                Password = "myPassword",
                Notes = "myNotes",
                Username = "myUsername",
                Site = "mySite",
                Category = aCategory,
            };

            aCategory.AddUserPasswordPair(aUserPasswordPair);

            UserPasswordPair newUserPasswordPair = new UserPasswordPair()
            {
                Password = "myPass",
                Notes = "myNotes",
                Username = "myUsername",
                Site = "mySite",
                Category = aCategory,
            };

            Assert.IsTrue(aCategory.ModifyUserPasswordPair(aUserPasswordPair, newUserPasswordPair));
            Assert.AreEqual(0, aCategory.User.GetOrangeUserPasswordPairs().Length);
            Assert.AreEqual(1, aCategory.User.GetRedUserPasswordPairs().Length);
            Assert.AreEqual(0, aCategory.OrangeUserPasswordPairsQuantity);
            Assert.AreEqual(1, aCategory.RedUserPasswordPairsQuantity);
        }

        [TestMethod]
        public void ModifyOrangeUserPasswordPairToAYellowOne()
        {
            UserPasswordPair aUserPasswordPair = new UserPasswordPair()
            {
                Password = "myPassword",
                Notes = "myNotes",
                Username = "myUsername",
                Site = "mySite",
                Category = aCategory,
            };

            aCategory.AddUserPasswordPair(aUserPasswordPair);

            UserPasswordPair newUserPasswordPair = new UserPasswordPair()
            {
                Password = "mypassword123456",
                Notes = "myNotes",
                Username = "myUsername",
                Site = "mySite",
                Category = aCategory,
            };

            Assert.IsTrue(aCategory.ModifyUserPasswordPair(aUserPasswordPair, newUserPasswordPair));
            Assert.AreEqual(0, aCategory.User.GetOrangeUserPasswordPairs().Length);
            Assert.AreEqual(1, aCategory.User.GetYellowUserPasswordPairs().Length);
            Assert.AreEqual(0, aCategory.OrangeUserPasswordPairsQuantity);
            Assert.AreEqual(1, aCategory.YellowUserPasswordPairsQuantity);
        }

        [TestMethod]
        public void ModifyRedUserPasswordPairToADarkGreenOne()
        {
            UserPasswordPair aUserPasswordPair = new UserPasswordPair()
            {
                Password = "myPass",
                Notes = "myNotes",
                Username = "myUsername",
                Site = "mySite",
                Category = aCategory,
            };

            aCategory.AddUserPasswordPair(aUserPasswordPair);

            UserPasswordPair newUserPasswordPair = new UserPasswordPair()
            {
                Password = "newPassword@!12345",
                Notes = "myNotes",
                Username = "myUsername",
                Site = "mySite",
                Category = aCategory,
            };

            Assert.IsTrue(aCategory.ModifyUserPasswordPair(aUserPasswordPair, newUserPasswordPair));
            Assert.AreEqual(0, aCategory.User.GetRedUserPasswordPairs().Length);
            Assert.AreEqual(1, aCategory.User.GetDarkGreenUserPasswordPairs().Length);
            Assert.AreEqual(0, aCategory.RedUserPasswordPairsQuantity);
            Assert.AreEqual(1, aCategory.DarkGreenUserPasswordPairsQuantity);
        }

        [TestMethod]
        public void ModifyRedUserPasswordPairToALightGreenOne()
        {
            UserPasswordPair aUserPasswordPair = new UserPasswordPair()
            {
                Password = "myPass",
                Notes = "myNotes",
                Username = "myUsername",
                Site = "mySite",
                Category = aCategory,
            };

            aCategory.AddUserPasswordPair(aUserPasswordPair);

            UserPasswordPair newUserPasswordPair = new UserPasswordPair()
            {
                Password = "newPassword12345",
                Notes = "myNotes",
                Username = "myUsername",
                Site = "mySite",
                Category = aCategory,
            };

            Assert.IsTrue(aCategory.ModifyUserPasswordPair(aUserPasswordPair, newUserPasswordPair));
            Assert.AreEqual(0, aCategory.User.GetRedUserPasswordPairs().Length);
            Assert.AreEqual(1, aCategory.User.GetLightGreenUserPasswordPairs().Length);
            Assert.AreEqual(0, aCategory.RedUserPasswordPairsQuantity);
            Assert.AreEqual(1, aCategory.LightGreenUserPasswordPairsQuantity);
        }

        [TestMethod]
        public void ModifyRedUserPasswordPairToAnOrangeOne()
        {
            UserPasswordPair aUserPasswordPair = new UserPasswordPair()
            {
                Password = "myPass",
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
            Assert.AreEqual(0, aCategory.User.GetRedUserPasswordPairs().Length);
            Assert.AreEqual(1, aCategory.User.GetOrangeUserPasswordPairs().Length);
            Assert.AreEqual(0, aCategory.RedUserPasswordPairsQuantity);
            Assert.AreEqual(1, aCategory.OrangeUserPasswordPairsQuantity);
        }

        [TestMethod]
        public void ModifyRedUserPasswordPairToARedOne()
        {
            UserPasswordPair aUserPasswordPair = new UserPasswordPair()
            {
                Password = "myPass",
                Notes = "myNotes",
                Username = "myUsername",
                Site = "mySite",
                Category = aCategory,
            };

            aCategory.AddUserPasswordPair(aUserPasswordPair);

            UserPasswordPair newUserPasswordPair = new UserPasswordPair()
            {
                Password = "newPass",
                Notes = "myNotes",
                Username = "myUsername",
                Site = "mySite",
                Category = aCategory,
            };

            Assert.IsTrue(aCategory.ModifyUserPasswordPair(aUserPasswordPair, newUserPasswordPair));
            Assert.AreEqual(1, aCategory.User.GetRedUserPasswordPairs().Length);
            Assert.AreEqual(1, aCategory.RedUserPasswordPairsQuantity);
        }

        [TestMethod]
        public void ModifyRedUserPasswordPairToAYellowOne()
        {
            UserPasswordPair aUserPasswordPair = new UserPasswordPair()
            {
                Password = "myPass",
                Notes = "myNotes",
                Username = "myUsername",
                Site = "mySite",
                Category = aCategory,
            };

            aCategory.AddUserPasswordPair(aUserPasswordPair);

            UserPasswordPair newUserPasswordPair = new UserPasswordPair()
            {
                Password = "newpassword1234",
                Notes = "myNotes",
                Username = "myUsername",
                Site = "mySite",
                Category = aCategory,
            };

            Assert.IsTrue(aCategory.ModifyUserPasswordPair(aUserPasswordPair, newUserPasswordPair));
            Assert.AreEqual(0, aCategory.User.GetRedUserPasswordPairs().Length);
            Assert.AreEqual(1, aCategory.User.GetYellowUserPasswordPairs().Length);
            Assert.AreEqual(0, aCategory.RedUserPasswordPairsQuantity);
            Assert.AreEqual(1, aCategory.YellowUserPasswordPairsQuantity);
        }

        [TestMethod]
        public void ModifyYellowUserPasswordPairToADarkGreenOne()
        {
            UserPasswordPair aUserPasswordPair = new UserPasswordPair()
            {
                Password = "password1234567",
                Notes = "myNotes",
                Username = "myUsername",
                Site = "mySite",
                Category = aCategory,
            };

            aCategory.AddUserPasswordPair(aUserPasswordPair);

            UserPasswordPair newUserPasswordPair = new UserPasswordPair()
            {
                Password = "myPassword12345!@$",
                Notes = "myNotes",
                Username = "myUsername",
                Site = "mySite",
                Category = aCategory,
            };

            Assert.IsTrue(aCategory.ModifyUserPasswordPair(aUserPasswordPair, newUserPasswordPair));
            Assert.AreEqual(0, aCategory.User.GetYellowUserPasswordPairs().Length);
            Assert.AreEqual(1, aCategory.User.GetDarkGreenUserPasswordPairs().Length);
            Assert.AreEqual(0, aCategory.YellowUserPasswordPairsQuantity);
            Assert.AreEqual(1, aCategory.DarkGreenUserPasswordPairsQuantity);
        }


        [TestMethod]
        public void ModifyYellowUserPasswordPairToALightGreenOne()
        {
            UserPasswordPair aUserPasswordPair = new UserPasswordPair()
            {
                Password = "password1234567",
                Notes = "myNotes",
                Username = "myUsername",
                Site = "mySite",
                Category = aCategory,
            };

            aCategory.AddUserPasswordPair(aUserPasswordPair);

            UserPasswordPair newUserPasswordPair = new UserPasswordPair()
            {
                Password = "myPassword12345",
                Notes = "myNotes",
                Username = "myUsername",
                Site = "mySite",
                Category = aCategory,
            };

            Assert.IsTrue(aCategory.ModifyUserPasswordPair(aUserPasswordPair, newUserPasswordPair));
            Assert.AreEqual(0, aCategory.User.GetYellowUserPasswordPairs().Length);
            Assert.AreEqual(1, aCategory.User.GetLightGreenUserPasswordPairs().Length);
            Assert.AreEqual(0, aCategory.YellowUserPasswordPairsQuantity);
            Assert.AreEqual(1, aCategory.LightGreenUserPasswordPairsQuantity);
        }

        [TestMethod]
        public void ModifyYellowUserPasswordPairToAnOrangeOne()
        {
            UserPasswordPair aUserPasswordPair = new UserPasswordPair()
            {
                Password = "password1234567",
                Notes = "myNotes",
                Username = "myUsername",
                Site = "mySite",
                Category = aCategory,
            };

            aCategory.AddUserPasswordPair(aUserPasswordPair);

            UserPasswordPair newUserPasswordPair = new UserPasswordPair()
            {
                Password = "myPassword12",
                Notes = "myNotes",
                Username = "myUsername",
                Site = "mySite",
                Category = aCategory,
            };

            Assert.IsTrue(aCategory.ModifyUserPasswordPair(aUserPasswordPair, newUserPasswordPair));
            Assert.AreEqual(0, aCategory.User.GetYellowUserPasswordPairs().Length);
            Assert.AreEqual(1, aCategory.User.GetOrangeUserPasswordPairs().Length);
            Assert.AreEqual(0, aCategory.YellowUserPasswordPairsQuantity);
            Assert.AreEqual(1, aCategory.OrangeUserPasswordPairsQuantity);
        }

        [TestMethod]
        public void ModifyYellowUserPasswordPairToARedOne()
        {
            UserPasswordPair aUserPasswordPair = new UserPasswordPair()
            {
                Password = "password1234567",
                Notes = "myNotes",
                Username = "myUsername",
                Site = "mySite",
                Category = aCategory,
            };

            aCategory.AddUserPasswordPair(aUserPasswordPair);

            UserPasswordPair newUserPasswordPair = new UserPasswordPair()
            {
                Password = "myPass",
                Notes = "myNotes",
                Username = "myUsername",
                Site = "mySite",
                Category = aCategory,
            };

            Assert.IsTrue(aCategory.ModifyUserPasswordPair(aUserPasswordPair, newUserPasswordPair));
            Assert.AreEqual(0, aCategory.User.GetYellowUserPasswordPairs().Length);
            Assert.AreEqual(1, aCategory.User.GetRedUserPasswordPairs().Length);
            Assert.AreEqual(0, aCategory.YellowUserPasswordPairsQuantity);
            Assert.AreEqual(1, aCategory.RedUserPasswordPairsQuantity);
        }

        [TestMethod]
        public void ModifyYellowUserPasswordPairToAYellowOne()
        {
            UserPasswordPair aUserPasswordPair = new UserPasswordPair()
            {
                Password = "password1234567",
                Notes = "myNotes",
                Username = "myUsername",
                Site = "mySite",
                Category = aCategory,
            };

            aCategory.AddUserPasswordPair(aUserPasswordPair);

            UserPasswordPair newUserPasswordPair = new UserPasswordPair()
            {
                Password = "password7654321",
                Notes = "myNotes",
                Username = "myUsername",
                Site = "mySite",
                Category = aCategory,
            };

            Assert.IsTrue(aCategory.ModifyUserPasswordPair(aUserPasswordPair, newUserPasswordPair));
            Assert.AreEqual(1, aCategory.User.GetYellowUserPasswordPairs().Length);
            Assert.AreEqual(1, aCategory.YellowUserPasswordPairsQuantity);
        }
    }
}