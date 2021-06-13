using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataManagerDomain;

namespace DataManagerTest
{
    [TestClass]
    public class CategoryToStringTest
    {
        private Category aCategory;
        private User aUser;
        private DataManager DataManager;

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
        public void CategoryToString()
        {
            Assert.AreEqual(aCategory.ToString(), "category");
        }

        [TestCleanup]
        public void Cleanup()
        {
            using (var dbContext = new DataManagerContext())
            {
                dbContext.Users.RemoveRange(dbContext.Users);
                dbContext.Categories.RemoveRange(dbContext.Categories);
                dbContext.SaveChanges();
            }
        }
    }
}