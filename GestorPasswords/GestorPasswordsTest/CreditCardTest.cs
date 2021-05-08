using GestorPasswordsDominio;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace GestorPasswordsTest
{
    [TestClass]
    public class CreditCardTest
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
    }
}


