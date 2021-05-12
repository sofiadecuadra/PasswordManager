using GestorPasswordsDominio;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace GestorPasswordsTest
{
    [TestClass]
    public class CreditCardTest
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
        public void CreditCardToString()
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
            Assert.AreEqual(aCreditCard.ToString(), "[Visa Gold] [Visa] [1234 5678 9123 4567]");
        }
        
        [TestMethod]
        public void FormatCreditCardNumber()
        {
            string creditCardNumber = "1234567891234567";
            Assert.AreEqual("1234 5678 9123 4567", CreditCard.FormatNumber(creditCardNumber));
        }

        [TestMethod]
        public void HideCreditCardNumber()
        {
            NormalCategory aCategory = new NormalCategory()
            {
                Name = "Category",
                User = new User() { MasterPassword = "password", Name = "UserName" }
            };
            CreditCard creditCard = new CreditCard()
            {
                Number = "1234567891234567",
                Type = "Visa Gold",
                Name = "Visa",
                Code = "123",
                Notes = "",
                ExpirationDate = DateTime.Now,
                Category = aCategory
            };
            Assert.AreEqual("XXXX XXXX XXXX 4567", creditCard.HideNumber);
        }
    }
}



        