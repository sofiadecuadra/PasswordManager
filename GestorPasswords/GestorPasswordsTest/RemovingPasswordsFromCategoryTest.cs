using Microsoft.VisualStudio.TestTools.UnitTesting;
using GestorPasswordsDominio;
using System;

namespace GestorPasswordsTest
{
    [TestClass]
    public class RemovingPasswordsFromCategoryTest
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
        public void RemoveCreditCardNormally()
        {
            CreditCard aCreditCard = new CreditCard()
            {
                Number = "1234567891234567",
                Type = "Visa",
                Name = "Visa Gold",
                Code = "234",
                Notes = "",
                ExpirationDate = new DateTime(2023, 12, 25),
                Category = aCategory,
            };

            aCategory.AddCreditCard(aCreditCard);
            Assert.IsTrue(aCategory.RemoveCreditCard(aCreditCard.Number));
            Assert.IsFalse(aUser.CreditCardNumberExists(aCreditCard.Number));
            Assert.AreEqual(0, aCategory.GetCreditCards().Length);

        }

        [TestMethod]
        [ExpectedException(typeof(ExceptionCreditCardDoesNotExist))]
        public void RemoveCreditCardThatDoesNotExist()
        {
            CreditCard aCreditCard = new CreditCard()
            {
                Number = "1234567891234567",
                Type = "Visa",
                Name = "Visa Gold",
                Code = "234",
                Notes = "",
                ExpirationDate = new DateTime(2023, 12, 25),
                Category = aCategory,
            };
            aCategory.RemoveCreditCard(aCreditCard.Number);
        }

        [TestMethod]
        public void RemoveDarkGreenUserPasswordPair()
        {
            UserPasswordPair aUserPasswordPair = new UserPasswordPair()
            {
                Password = "myPassword12345@$%",
                Notes = "these are my notes",
                Username = "myUserName",
                Site = "mySite",
                Category = aCategory,
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
                Password = "thisIsAPassword",
                Notes = "these are my notes",
                Username = "myUserName",
                Site = "mySite",
                Category = aCategory,
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
                Password = "myPassword12345",
                Notes = "these are my notes",
                Username = "myUserName",
                Site = "mySite",
                Category = aCategory,
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
                Password = "mypassword",
                Notes = "these are my notes",
                Username = "myUserName",
                Site = "mySite",
                Category = aCategory,
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
                Password = "mypass",
                Notes = "these are my notes",
                Username = "myUserName",
                Site = "mySite",
                Category = aCategory,
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
                Password = "thisIsAPassword",
                Notes = "these are my notes",
                Username = "myUserName",
                Site = "mySite",
                Category = aCategory,
            };

            aCategory.RemoveUserPasswordPair(aUserPasswordPair);
        }

        [TestMethod]
        public void RemoveYellowUserPasswordPair()
        {
            UserPasswordPair aUserPasswordPair = new UserPasswordPair()
            {
                Password = "mypassword12345",
                Notes = "these are my notes",
                Username = "myUserName",
                Site = "mySite",
                Category = aCategory,
            };

            aCategory.AddUserPasswordPair(aUserPasswordPair);

            Assert.IsTrue(aCategory.RemoveUserPasswordPair(aUserPasswordPair));
            Assert.IsFalse(aCategory.UserPasswordPairAlredyExistsInCategory(aUserPasswordPair.Username, aUserPasswordPair.Site));
            Assert.AreEqual(0, aCategory.User.GetYellowUserPasswordPairs().Length);
            Assert.AreEqual(0, aCategory.YellowUserPasswordPairsQuantity);
        }
    }
}