﻿using DataManagerDomain;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace DataManagerTest
{
    [TestClass]
    public class RemovingCreditCardsFromCategoryTest
    {
        private Category aCategory;
        private User aUser;
        private DataManager DataManager;
        private CreditCard aCreditCard;

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
            aCreditCard = new CreditCard()
            {
                Category = aCategory,
                Number = "1234567891234567",
                Type = "Visa",
                Name = "Visa Gold",
                Code = "234",
                Notes = "",
                ExpirationDate = new DateTime(2023, 12, 25),
            };
        }

        [TestMethod]
        public void RemoveCreditCardNormally()
        {
            aCategory.AddCreditCard(aCreditCard);
            aCategory.RemoveCreditCard(aCreditCard);
            Assert.IsFalse(aUser.CreditCardNumberExists(aCreditCard.Number));
            Assert.AreEqual(0, aCategory.GetCreditCards().Length);
        }

        [TestMethod]
        [ExpectedException(typeof(ExceptionCreditCardDoesNotExist))]
        public void RemoveCreditCardThatDoesNotExist()
        {
            aCategory.RemoveCreditCard(aCreditCard);
        }

        //[TestMethod]
        //public void RemoveCreditThatAppearedInADataBreach()
        //{
        //    aCategory.AddCreditCard(aCreditCard);

        //    IDataBreachesFormatter dataBreaches = new TxtFileDataBreaches()
        //    {
        //        txtDataBreaches = "1234 5678 9123 4567"
        //    };
        //    DataBreach aDataBreach = aUser.CheckDataBreaches(dataBreaches);
        //    Assert.IsTrue(aCategory.RemoveCreditCard(aCreditCard));
        //    Assert.IsTrue(aDataBreach.LeakedCreditCardsOfUser.Count == 0);
        //}

        [TestCleanup]
        public void Cleanup()
        {
            using (var dbContext = new DataManagerContext())
            {
                dbContext.Users.RemoveRange(dbContext.Users);
                dbContext.Categories.RemoveRange(dbContext.Categories);
                dbContext.CreditCards.RemoveRange(dbContext.CreditCards);
                dbContext.SaveChanges();
            }
        }
    }
}
