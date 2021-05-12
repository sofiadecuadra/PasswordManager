﻿using GestorPasswordsDominio;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace GestorPasswordsTest
{
    [TestClass]
    public class CreditCardTest
    {
        private NormalCategory aCategory;
        private User aUser;
        private CreditCard aCreditCard;

        [TestInitialize]
        public void Initialize()
        {
            aUser = new User()
            {
                MasterPassword = "password",
                Name = "UserName"
            };
            aCategory = new NormalCategory()
            {
                User = aUser,
                Name = "Category"
            };
            aCreditCard = new CreditCard()
            {
                Number = "1234567891234567",
                Type = "Visa Gold",
                Name = "Visa",
                Code = "123",
                Notes = "",
                ExpirationDate = new DateTime(2023, 12, 25),
                Category = aCategory
            };

            aUser.AddCategory(aCategory);
        }

        [TestMethod]
        public void CreditCardToString()
        {
            Assert.AreEqual(aCreditCard.ToString(), "[Visa] [Visa Gold] [1234 5678 9123 4567]");
        }

        [TestMethod]
        public void FormatCreditCardNumber()
        {
            var creditCardNumber = "1234567891234567";
            Assert.AreEqual("1234 5678 9123 4567", CreditCard.FormatNumber(creditCardNumber));
        }

        [TestMethod]
        public void HideCreditCardNumber()
        {
            Assert.AreEqual("XXXX XXXX XXXX 4567", aCreditCard.HideNumber);
        }
    }
}



