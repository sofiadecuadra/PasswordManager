using DataManagerDomain;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace DataManagerTest
{
    [TestClass]
    public class RemovingCreditCardsFromCategoryTest
    {
        private NormalCategory aCategory;
        private User aUser;
        private CreditCard aCreditCard;

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

            aCreditCard = new CreditCard()
            {
                Number = "1234567891234567",
                Type = "Visa",
                Name = "Visa Gold",
                Code = "234",
                Notes = "",
                ExpirationDate = new DateTime(2023, 12, 25),
                Category = aCategory,
            };
        }

        [TestMethod]
        public void RemoveCreditCardNormally()
        {
            aCategory.AddCreditCard(aCreditCard);
            Assert.IsTrue(aCategory.RemoveCreditCard(aCreditCard));
            Assert.IsFalse(aUser.CreditCardNumberExists(aCreditCard.Number));
            Assert.AreEqual(0, aCategory.GetCreditCards().Length);
        }

        [TestMethod]
        [ExpectedException(typeof(ExceptionCreditCardDoesNotExist))]
        public void RemoveCreditCardThatDoesNotExist()
        {
            aCategory.RemoveCreditCard(aCreditCard);
        }

        [TestMethod]
        public void RemoveCreditThatAppeardInADataBreach()
        {
            aCategory.AddCreditCard(aCreditCard);

            IDataBreachesFormatter dataBreaches = new TxtFileDataBreaches()
            {
                txtDataBreaches = "1234 5678 9123 4567"
            };
            DataBreach aDataBreach = aUser.CheckDataBreaches(dataBreaches);
            Assert.IsTrue(aCategory.RemoveCreditCard(aCreditCard));
            Assert.IsTrue(aDataBreach.LeakedCreditCardsOfUser.Count == 0);
        }
    }
}
