using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataManagerDomain;
using System;

namespace DataManagerTest
{
    [TestClass]
    public class CategoryToStringTest
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
        public void CategoryToString()
        {
            Assert.AreEqual(aCategory.ToString(), "category");
        }
    }
}