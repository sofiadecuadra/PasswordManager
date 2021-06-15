using DataManagerDomain;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace DataManagerTest
{
    [TestClass]
    public class UserTest
    {
        private User aUser;
        private Category aCategory;
        private DataManager DataManager;

        [TestInitialize]
        public void Initialize()
        {
            DataManager = new DataManager();
            aUser = new User()
            {
                Username = "Fernanda",
                MasterPassword = "myPassword"
            };
            DataManager.AddUser(aUser);
            aCategory = new Category()
            {
                User = aUser,
                Name = "myCategory"
            };
            aUser.AddCategory(aCategory);
        }

        [TestMethod]
        [ExpectedException(typeof(ExceptionIncorrectMasterPassword))]
        public void IncorrectMasterPassword()
        {
            string currentPassword = "aWrongPassword";
            string newPassword = "myNewPassword";
            aUser.ChangeMasterPassword(currentPassword, newPassword);
        }

        [TestMethod]
        [ExpectedException(typeof(ExceptionIncorrectLength))]
        public void NewMasterPasswordWithLengthUnder5()
        {
            string currentPassword = "myPassword";
            string newPassword = "new";
            aUser.ChangeMasterPassword(currentPassword, newPassword);
        }

        [TestMethod]
        [ExpectedException(typeof(ExceptionIncorrectLength))]
        public void NewMasterPasswordWithLengthOver25()
        {
            string currentPassword = "myPassword";
            string newPassword = "newPasswordnewPasswordnewPassword";
            aUser.ChangeMasterPassword(currentPassword, newPassword);
        }

        [TestMethod]
        public void ChangeMasterPasswordCorrectly()
        {
            string currentPassword = "myPassword";
            string newPassword = "myNewPassword";
            aUser.ChangeMasterPassword(currentPassword, newPassword);
            Assert.AreEqual("myNewPassword", aUser.MasterPassword);
        }

        [TestMethod]
        public void AddUserPasswordPairsInDifferentCategoriesAndGetPasswordsStrengthReport()
        {
            UserPasswordPair aRedUserPasswordPair = new UserPasswordPair()
            {
                Category = aCategory,
                Password = "myPass",
                Notes = "these are my notes",
                Username = "myUserName1",
                Site = "mySite1",
            };
            aCategory.AddUserPasswordPair(aRedUserPasswordPair);

            UserPasswordPair aYellowUserPasswordPair = new UserPasswordPair()
            {
                Category = aCategory,
                Password = "MYPASSWORD12345",
                Notes = "these are my notes",
                Username = "myUserName2",
                Site = "mySite2",
            };
            aCategory.AddUserPasswordPair(aYellowUserPasswordPair);

            UserPasswordPair aDarkGreenUserPasswordPair = new UserPasswordPair()
            {
                Category = aCategory,
                Password = "MYpassword@#12345",
                Notes = "these are my notes",
                Username = "myUserName3",
                Site = "mySite3",
            };
            aCategory.AddUserPasswordPair(aDarkGreenUserPasswordPair);


            Category otherCategory = new Category()
            {
                User = aUser,
                Name = "otherCategory"
            };
            aUser.AddCategory(otherCategory);

            UserPasswordPair anOrangeUserPasswordPair = new UserPasswordPair()
            {
                Category = aCategory,
                Password = "myPassword",
                Notes = "these are my notes",
                Username = "myUserName4",
                Site = "mySite4",
            };
            aCategory.AddUserPasswordPair(anOrangeUserPasswordPair);

            UserPasswordPair aLightGreenUserPasswordPair = new UserPasswordPair()
            {
                Category = aCategory,
                Password = "MYpassword1234512",
                Notes = "these are my notes",
                Username = "myUserName5",
                Site = "mySite5",
            };
            aCategory.AddUserPasswordPair(aLightGreenUserPasswordPair);

            Assert.AreEqual(1, aUser.GetPasswordsStrengthReport()[0].Item2);
            Assert.AreEqual(1, aUser.GetPasswordsStrengthReport()[1].Item2);
            Assert.AreEqual(1, aUser.GetPasswordsStrengthReport()[2].Item2);
            Assert.AreEqual(1, aUser.GetPasswordsStrengthReport()[3].Item2);
            Assert.AreEqual(1, aUser.GetPasswordsStrengthReport()[4].Item2);
        }

        [TestMethod]
        public void AddValidCategory()
        {
            Assert.AreEqual(1, aUser.GetCategories().Length);
        }

        [TestMethod]
        [ExpectedException(typeof(ExceptionIncorrectLength))]
        public void AddCategoryWithLengthLessThan3()
        {
            Category anotherCategory = new Category()
            {
                User = aUser,
                Name = "my"
            };

            aUser.AddCategory(anotherCategory);
        }

        [TestMethod]
        [ExpectedException(typeof(ExceptionIncorrectLength))]
        public void AddCategoryWithLengthGreaterThan15()
        {
            Category anotherCategory = new Category()
            {
                User = aUser,
                Name = "myCategoryNameIsInvalid"
            };

            aUser.AddCategory(anotherCategory);
        }

        [TestMethod]
        [ExpectedException(typeof(ExceptionCategoryAlreadyExists))]
        public void AddExistingCategory()
        {
            Category anotherCategory = new Category()
            {
                User = aUser,
                Name = "myCategory"
            };

            aUser.AddCategory(anotherCategory);
        }

        [TestMethod]
        public void ModifyCategoryNormally()
        {
            aUser.ModifyCategory(aCategory, "newName");
            Assert.AreEqual("newname", aCategory.Name);
        }

        [TestMethod]
        [ExpectedException(typeof(ExceptionCategoryNotExists))]
        public void ModifyCategoryThatDoesNotExist()
        {
            Category anotherCategory = new Category()
            {
                User = aUser,
                Name = "anotherCategory"
            };

            aUser.ModifyCategory(anotherCategory, "newName");
        }

        [TestMethod]
        [ExpectedException(typeof(ExceptionIncorrectLength))]
        public void ModifyCategoryWithNewLengthLessThan3()
        {
            aUser.ModifyCategory(aCategory, "no");
        }

        [TestMethod]
        [ExpectedException(typeof(ExceptionIncorrectLength))]
        public void ModifyCategoryWithNewLengthGreaterThan15()
        {
            aUser.ModifyCategory(aCategory, "thisIsAnInvalidLength");
        }

        [TestMethod]
        [ExpectedException(typeof(ExceptionCategoryAlreadyExists))]
        public void ModifyCategoryToAnExistingName()
        {
            Category anotherCategory = new Category()
            {
                User = aUser,
                Name = "otherCategory"
            };
            aUser.AddCategory(anotherCategory);

            aUser.ModifyCategory(anotherCategory, "myCategory");
        }

        [TestMethod]
        public void ModifyCategoryNameToItsOwnName()
        {
            aUser.ModifyCategory(aCategory, "myCategory");
            Assert.AreEqual("mycategory", aCategory.Name);
        }

        [TestMethod]
        public void AddCreditCardToCategoryAndGetCreditCardslist()
        {
            LoadTestCategoryToMyUserWithACreditCard();
            Assert.AreEqual(1, aUser.GetCreditCards().Length);
        }

        [TestMethod]
        public void ACreditCardOfUserAppearedInTextBoxDataBreaches()
        {
            var aCreditCard = LoadTestCategoryToMyUserWithACreditCard();

            IDataBreachesFormatter dataBreaches = new TextBoxDataBreaches()
            {
                txtDataBreaches = "1234 5678 9123 4567"
            };

            Assert.AreEqual(aUser.CheckDataBreaches(dataBreaches).LeakedCreditCardsOfUser[0].Id, aCreditCard.Id);
        }

        [TestMethod]
        public void MultipleCreditCardsOfUserAppearedInTextBoxDataBreaches()
        {
            var aCreditCard = LoadTestCategoryToMyUserWithACreditCard();
            var anotherCreditCard = LoadTestCategoryToMyUserWithAnotherCreditCard();

            IDataBreachesFormatter dataBreaches = new TextBoxDataBreaches()
            {
                txtDataBreaches = "1234 5678 9123 4567\n1234 5678 9123 4222"
            };

            Assert.AreEqual(aUser.CheckDataBreaches(dataBreaches).LeakedCreditCardsOfUser[0].Id, aCreditCard.Id);
            Assert.AreEqual(aUser.CheckDataBreaches(dataBreaches).LeakedCreditCardsOfUser[1].Id, anotherCreditCard.Id);

        }

        [TestMethod]
        public void APasswordOfUserAppearedInTextBoxDataBreaches()
        {
            var aUserPasswordPair = LoadTestCategoryToMyUserWithAUserPasswordPair();

            IDataBreachesFormatter dataBreaches = new TextBoxDataBreaches()
            {
                txtDataBreaches = "thisIsAPassword"
            };

            Assert.AreEqual(aUser.CheckDataBreaches(dataBreaches).LeakedUserPasswordPairsOfUser[0].Id, aUserPasswordPair.Id);
        }

        [TestMethod]
        public void APasswordAndACreditCardOfUserAppearedInTextBoxDataBreaches()
        {
            var aUserPasswordPair = LoadTestCategoryToMyUserWithAUserPasswordPair();
            var aCreditCard = LoadTestCategoryToMyUserWithACreditCard();

            IDataBreachesFormatter dataBreaches = new TextBoxDataBreaches()
            {
                txtDataBreaches = "thisIsAPassword\nthisIsAnotherPassword\n1234 5678 9123 4567"
            };

            Assert.AreEqual(aUser.CheckDataBreaches(dataBreaches).LeakedCreditCardsOfUser[0].Id, aCreditCard.Id);
            Assert.AreEqual(1, aUser.CheckDataBreaches(dataBreaches).LeakedCreditCardsOfUser.Count);

            Assert.AreEqual(aUser.CheckDataBreaches(dataBreaches).LeakedUserPasswordPairsOfUser[0].Id, aUserPasswordPair.Id);
            Assert.AreEqual(1, aUser.CheckDataBreaches(dataBreaches).LeakedUserPasswordPairsOfUser.Count);
        }

        [TestMethod]
        public void SamePasswordAppearedMoreThanOnceInTextBoxDataBreaches()
        {
            var aUserPasswordPair = LoadTestCategoryToMyUserWithAUserPasswordPair();

            IDataBreachesFormatter dataBreaches = new TextBoxDataBreaches()
            {
                txtDataBreaches = "thisIsAPassword\nthisIsAPassword\n1234 5678 9123 4567"
            };

            List<UserPasswordPair> expectedUserPasswordPairList = new List<UserPasswordPair>();
            expectedUserPasswordPairList.Add(aUserPasswordPair);

            Assert.AreEqual(aUser.CheckDataBreaches(dataBreaches).LeakedUserPasswordPairsOfUser[0].Id, aUserPasswordPair.Id);
            Assert.AreEqual(1, aUser.CheckDataBreaches(dataBreaches).LeakedUserPasswordPairsOfUser.Count);
        }

        [TestMethod]
        public void SameCreditCardAppearedMoreThanOnceInTextBoxDataBreaches()
        {
            var aCreditCard = LoadTestCategoryToMyUserWithACreditCard();

            IDataBreachesFormatter dataBreaches = new TextBoxDataBreaches()
            {
                txtDataBreaches = "thisIsAPassword\n1234 5678 9123 4567\n1234 5678 9123 4567"
            };

            Assert.AreEqual(aUser.CheckDataBreaches(dataBreaches).LeakedCreditCardsOfUser[0].Id, aCreditCard.Id);
            Assert.AreEqual(1, aUser.CheckDataBreaches(dataBreaches).LeakedCreditCardsOfUser.Count);
        }

        [TestMethod]
        public void PasswordsOfUserAppearedInTextBoxDataBreaches()
        {
            var aUserPasswordPair = LoadTestCategoryToMyUserWithAUserPasswordPair();
            var anotherUserPasswordPair = LoadTestCategoryToMyUserWithAnotherUserPasswordPair();

            IDataBreachesFormatter dataBreaches = new TextBoxDataBreaches()
            {
                txtDataBreaches = "thisIsAPassword\nthisIsAnotherPassword"
            };

            Assert.AreEqual(aUser.CheckDataBreaches(dataBreaches).LeakedUserPasswordPairsOfUser[0].Id, aUserPasswordPair.Id);
            Assert.AreEqual(aUser.CheckDataBreaches(dataBreaches).LeakedUserPasswordPairsOfUser[1].Id, anotherUserPasswordPair.Id);
            Assert.AreEqual(2, aUser.CheckDataBreaches(dataBreaches).LeakedUserPasswordPairsOfUser.Count);
        }

        [TestMethod]
        public void PasswordWithBlankSpacesAndOnlyDigitsOfUserAppearedInTextBoxDataBreaches()
        {
            UserPasswordPair aUserPasswordPair = new UserPasswordPair()
            {
                Category = aCategory,
                Password = "4444 555 6666 2323",
                Notes = "these are my notes",
                Username = "myUserName",
                Site = "mySite",
            };

            aCategory.AddUserPasswordPair(aUserPasswordPair);

            IDataBreachesFormatter dataBreaches = new TextBoxDataBreaches()
            {
                txtDataBreaches = "4444 555 6666 2323"
            };

            Assert.AreEqual(aUser.CheckDataBreaches(dataBreaches).LeakedUserPasswordPairsOfUser[0].Id, aUserPasswordPair.Id);
            Assert.AreEqual(1, aUser.CheckDataBreaches(dataBreaches).LeakedUserPasswordPairsOfUser.Count);
        }

        [TestMethod]
        public void PasswordWithBlankSpacesOfUserAppearedInTextBoxDataBreaches()
        {
            UserPasswordPair aUserPasswordPair = new UserPasswordPair()
            {
                Category = aCategory,
                Password = "rfkg s67r sjdh liks",
                Notes = "these are my notes",
                Username = "myUserName",
                Site = "mySite",
            };

            aCategory.AddUserPasswordPair(aUserPasswordPair);

            IDataBreachesFormatter dataBreaches = new TextBoxDataBreaches()
            {
                txtDataBreaches = "rfkg s67r sjdh liks"
            };

            Assert.AreEqual(aUser.CheckDataBreaches(dataBreaches).LeakedUserPasswordPairsOfUser[0].Id, aUserPasswordPair.Id);
            Assert.AreEqual(1, aUser.CheckDataBreaches(dataBreaches).LeakedUserPasswordPairsOfUser.Count);
        }

        [TestMethod]
        public void MultiplePasswordsAndCreditCardsOfUserAppearedInTextBoxDataBreaches()
        {
            var aUserPasswordPair = LoadTestCategoryToMyUserWithAUserPasswordPair();
            var anotherUserPasswordPair = LoadTestCategoryToMyUserWithAnotherUserPasswordPair();

            var aCreditCard = LoadTestCategoryToMyUserWithACreditCard();
            var anotherCreditCard = LoadTestCategoryToMyUserWithAnotherCreditCard();

            IDataBreachesFormatter dataBreaches = new TextBoxDataBreaches()
            {
                txtDataBreaches = "thisIsAPassword\n1234 5678 9123 4222\nHello\nthisIsAnotherPassword\n1234 5678 9123 4567\n"
            };

            Assert.AreEqual(aUser.CheckDataBreaches(dataBreaches).LeakedUserPasswordPairsOfUser[0].Id, aUserPasswordPair.Id);
            Assert.AreEqual(aUser.CheckDataBreaches(dataBreaches).LeakedUserPasswordPairsOfUser[1].Id, anotherUserPasswordPair.Id);
            Assert.AreEqual(2, aUser.CheckDataBreaches(dataBreaches).LeakedUserPasswordPairsOfUser.Count);

            Assert.AreEqual(aUser.CheckDataBreaches(dataBreaches).LeakedCreditCardsOfUser[0].Id, aCreditCard.Id);
            Assert.AreEqual(aUser.CheckDataBreaches(dataBreaches).LeakedCreditCardsOfUser[1].Id, anotherCreditCard.Id);
            Assert.AreEqual(2, aUser.CheckDataBreaches(dataBreaches).LeakedCreditCardsOfUser.Count);
        }

        [TestMethod]
        public void NoPasswordsOrCreditCardsOfUserAppearedInTextBoxDataBreaches()
        {
            var aUserPasswordPair = LoadTestCategoryToMyUserWithAUserPasswordPair();
            var anotherUserPasswordPair = LoadTestCategoryToMyUserWithAnotherUserPasswordPair();

            var aCreditCard = LoadTestCategoryToMyUserWithACreditCard();
            var anotherCreditCard = LoadTestCategoryToMyUserWithAnotherCreditCard();

            IDataBreachesFormatter dataBreaches = new TextBoxDataBreaches()
            {
                txtDataBreaches = "Sof\n1234 5678 2333 4222\nHello\nthisPassword\n1235 5665 9123 4567\n"
            };

            Assert.AreEqual(0, aUser.CheckDataBreaches(dataBreaches).LeakedUserPasswordPairsOfUser.Count);
            Assert.AreEqual(0, aUser.CheckDataBreaches(dataBreaches).LeakedCreditCardsOfUser.Count);
        }

        [TestMethod]
        public void PasswordUsedInMultipleSitesOfUserAppearedInTextBoxDataBreaches()
        {
            var aUserPasswordPair = LoadTestCategoryToMyUserWithAUserPasswordPair();

            UserPasswordPair anotherUserPasswordPair = new UserPasswordPair()
            {
                Category = aCategory,
                Password = "thisIsAPassword",
                Notes = "these are my notes",
                Username = "anotherUserName",
                Site = "myOtherSite",
            };

            aCategory.AddUserPasswordPair(anotherUserPasswordPair);

            IDataBreachesFormatter dataBreaches = new TextBoxDataBreaches()
            {
                txtDataBreaches = "thisIsAPassword"
            };

            Assert.AreEqual(aUser.CheckDataBreaches(dataBreaches).LeakedUserPasswordPairsOfUser[0].Id, aUserPasswordPair.Id);
            Assert.AreEqual(aUser.CheckDataBreaches(dataBreaches).LeakedUserPasswordPairsOfUser[1].Id, anotherUserPasswordPair.Id);
            Assert.AreEqual(2, aUser.CheckDataBreaches(dataBreaches).LeakedUserPasswordPairsOfUser.Count);
        }

        [TestMethod]
        public void ACreditCardOfUserAppearedInTxtFileDataBreaches()
        {
            var aCreditCard = LoadTestCategoryToMyUserWithACreditCard();

            IDataBreachesFormatter dataBreaches = new TxtFileDataBreaches()
            {
                txtDataBreaches = "1234 5678 9123 4567"
            };

            Assert.AreEqual(aUser.CheckDataBreaches(dataBreaches).LeakedCreditCardsOfUser[0].Id, aCreditCard.Id);
        }

        [TestMethod]
        public void MultipleCreditCardsOfUserAppearedInTxtFileDataBreaches()
        {
            var aCreditCard = LoadTestCategoryToMyUserWithACreditCard();
            var anotherCreditCard = LoadTestCategoryToMyUserWithAnotherCreditCard();

            IDataBreachesFormatter dataBreaches = new TxtFileDataBreaches()
            {
                txtDataBreaches = "1234 5678 9123 4567\t1234 5678 9123 4222"
            };

            Assert.AreEqual(aUser.CheckDataBreaches(dataBreaches).LeakedCreditCardsOfUser[0].Id, aCreditCard.Id);
            Assert.AreEqual(aUser.CheckDataBreaches(dataBreaches).LeakedCreditCardsOfUser[1].Id, anotherCreditCard.Id);
        }

        [TestMethod]
        public void APasswordOfUserAppearedInTxtFileDataBreaches()
        {
            var aUserPasswordPair = LoadTestCategoryToMyUserWithAUserPasswordPair();
            var anotherUserPasswordPair = LoadTestCategoryToMyUserWithAnotherUserPasswordPair();

            IDataBreachesFormatter dataBreaches = new TxtFileDataBreaches()
            {
                txtDataBreaches = "thisIsAPassword"
            };

            Assert.AreEqual(aUser.CheckDataBreaches(dataBreaches).LeakedUserPasswordPairsOfUser[0].Id, aUserPasswordPair.Id);
        }

        [TestMethod]
        public void APasswordAndACreditCardOfUserAppearedInTxtFileDataBreaches()
        {
            var aUserPasswordPair = LoadTestCategoryToMyUserWithAUserPasswordPair();
            var aCreditCard = LoadTestCategoryToMyUserWithACreditCard();

            IDataBreachesFormatter dataBreaches = new TxtFileDataBreaches()
            {
                txtDataBreaches = "thisIsAPassword\tthisIsAnotherPassword\t1234 5678 9123 4567"
            };

            Assert.AreEqual(aUser.CheckDataBreaches(dataBreaches).LeakedCreditCardsOfUser[0].Id, aCreditCard.Id);
            Assert.AreEqual(1, aUser.CheckDataBreaches(dataBreaches).LeakedCreditCardsOfUser.Count);

            Assert.AreEqual(aUser.CheckDataBreaches(dataBreaches).LeakedUserPasswordPairsOfUser[0].Id, aUserPasswordPair.Id);
            Assert.AreEqual(1, aUser.CheckDataBreaches(dataBreaches).LeakedUserPasswordPairsOfUser.Count);

        }

        [TestMethod]
        public void SamePasswordAppearedMoreThanOnceInTxtFileDataBreaches()
        {
            var aUserPasswordPair = LoadTestCategoryToMyUserWithAUserPasswordPair();

            IDataBreachesFormatter dataBreaches = new TxtFileDataBreaches()
            {
                txtDataBreaches = "thisIsAPassword\tthisIsAPassword\t1234 5678 9123 4567"
            };

            Assert.AreEqual(aUser.CheckDataBreaches(dataBreaches).LeakedUserPasswordPairsOfUser[0].Id, aUserPasswordPair.Id);
            Assert.AreEqual(1, aUser.CheckDataBreaches(dataBreaches).LeakedUserPasswordPairsOfUser.Count);
        }

        [TestMethod]
        public void SameCreditCardAppearedMoreThanOnceInTxtFileDataBreaches()
        {
            var aCreditCard = LoadTestCategoryToMyUserWithACreditCard();

            IDataBreachesFormatter dataBreaches = new TxtFileDataBreaches()
            {
                txtDataBreaches = "thisIsAPassword\t1234 5678 9123 4567\t1234 5678 9123 4567"
            };

            Assert.AreEqual(aUser.CheckDataBreaches(dataBreaches).LeakedCreditCardsOfUser[0].Id, aCreditCard.Id);
            Assert.AreEqual(1, aUser.CheckDataBreaches(dataBreaches).LeakedCreditCardsOfUser.Count);
        }

        [TestMethod]
        public void PasswordsOfUserAppearedInTxtFileDataBreaches()
        {
            var aUserPasswordPair = LoadTestCategoryToMyUserWithAUserPasswordPair();
            var anotherUserPasswordPair = LoadTestCategoryToMyUserWithAnotherUserPasswordPair();

            IDataBreachesFormatter dataBreaches = new TxtFileDataBreaches()
            {
                txtDataBreaches = "thisIsAPassword\tthisIsAnotherPassword"
            };

            Assert.AreEqual(aUser.CheckDataBreaches(dataBreaches).LeakedUserPasswordPairsOfUser[0].Id, aUserPasswordPair.Id);
            Assert.AreEqual(aUser.CheckDataBreaches(dataBreaches).LeakedUserPasswordPairsOfUser[1].Id, anotherUserPasswordPair.Id);
            Assert.AreEqual(2, aUser.CheckDataBreaches(dataBreaches).LeakedUserPasswordPairsOfUser.Count);
        }

        [TestMethod]
        public void PasswordWithBlankSpacesAndOnlyDigitsOfUserAppearedInTxtFileDataBreaches()
        {
            UserPasswordPair aUserPasswordPair = new UserPasswordPair()
            {
                Category = aCategory,
                Password = "4444 555 6666 2323",
                Notes = "these are my notes",
                Username = "myUserName",
                Site = "mySite",
            };

            aCategory.AddUserPasswordPair(aUserPasswordPair);

            IDataBreachesFormatter dataBreaches = new TxtFileDataBreaches()
            {
                txtDataBreaches = "4444 555 6666 2323"
            };

            Assert.AreEqual(aUser.CheckDataBreaches(dataBreaches).LeakedUserPasswordPairsOfUser[0].Id, aUserPasswordPair.Id);
            Assert.AreEqual(1, aUser.CheckDataBreaches(dataBreaches).LeakedUserPasswordPairsOfUser.Count);
        }

        [TestMethod]
        public void PasswordWithBlankSpacesOfUserAppearedInTxtFileDataBreaches()
        {
            UserPasswordPair aUserPasswordPair = new UserPasswordPair()
            {
                Category = aCategory,
                Password = "rfkg s67r sjdh liks",
                Notes = "these are my notes",
                Username = "myUserName",
                Site = "mySite",
            };

            aCategory.AddUserPasswordPair(aUserPasswordPair);

            IDataBreachesFormatter dataBreaches = new TxtFileDataBreaches()
            {
                txtDataBreaches = "rfkg s67r sjdh liks"
            };

            Assert.AreEqual(aUser.CheckDataBreaches(dataBreaches).LeakedUserPasswordPairsOfUser[0].Id, aUserPasswordPair.Id);
            Assert.AreEqual(1, aUser.CheckDataBreaches(dataBreaches).LeakedUserPasswordPairsOfUser.Count);
        }

        [TestMethod]
        public void MultiplePasswordsAndCreditCardsOfUserAppearedInTxtFileDataBreaches()
        {
            var aUserPasswordPair = LoadTestCategoryToMyUserWithAUserPasswordPair();
            var anotherUserPasswordPair = LoadTestCategoryToMyUserWithAnotherUserPasswordPair();

            var aCreditCard = LoadTestCategoryToMyUserWithACreditCard();
            var anotherCreditCard = LoadTestCategoryToMyUserWithAnotherCreditCard();

            IDataBreachesFormatter dataBreaches = new TxtFileDataBreaches()
            {
                txtDataBreaches = "thisIsAPassword\t1234 5678 9123 4222\tHello\tthisIsAnotherPassword\t1234 5678 9123 4567\t"
            };

            Assert.AreEqual(aUser.CheckDataBreaches(dataBreaches).LeakedUserPasswordPairsOfUser[0].Id, aUserPasswordPair.Id);
            Assert.AreEqual(aUser.CheckDataBreaches(dataBreaches).LeakedUserPasswordPairsOfUser[1].Id, anotherUserPasswordPair.Id);
            Assert.AreEqual(2, aUser.CheckDataBreaches(dataBreaches).LeakedUserPasswordPairsOfUser.Count);

            Assert.AreEqual(aUser.CheckDataBreaches(dataBreaches).LeakedCreditCardsOfUser[0].Id, aCreditCard.Id);
            Assert.AreEqual(aUser.CheckDataBreaches(dataBreaches).LeakedCreditCardsOfUser[1].Id, anotherCreditCard.Id);
            Assert.AreEqual(2, aUser.CheckDataBreaches(dataBreaches).LeakedCreditCardsOfUser.Count);
        }

        [TestMethod]
        public void NoPasswordsOrCreditCardsOfUserAppearedInTxtFileDataBreaches()
        {
            var aUserPasswordPair = LoadTestCategoryToMyUserWithAUserPasswordPair();
            var anotherUserPasswordPair = LoadTestCategoryToMyUserWithAnotherUserPasswordPair();

            var aCreditCard = LoadTestCategoryToMyUserWithACreditCard();
            var anotherCreditCard = LoadTestCategoryToMyUserWithAnotherCreditCard();

            IDataBreachesFormatter dataBreaches = new TxtFileDataBreaches()
            {
                txtDataBreaches = "Sof\t1234 5678 2333 4222\tHello\tthisPassword\t1235 5665 9123 4567\t"
            };

            Assert.AreEqual(0, aUser.CheckDataBreaches(dataBreaches).LeakedUserPasswordPairsOfUser.Count);
            Assert.AreEqual(0, aUser.CheckDataBreaches(dataBreaches).LeakedCreditCardsOfUser.Count);
        }

        [TestMethod]
        public void CheckEmptyDataBreach()
        {
            IDataBreachesFormatter dataBreaches = new TxtFileDataBreaches()
            {
                txtDataBreaches = ""
            };

            aUser.CheckDataBreaches(dataBreaches);

            using (var dbContext = new DataManagerContext())
            {
                var userSelected = dbContext.Users
                    .Include(user => user.DataBreaches)
                    .FirstOrDefault(user => user.Username == aUser.Username);
                Assert.AreEqual(0, userSelected.DataBreaches.Count);
            }
        }

        [TestMethod]
        public void PasswordUsedInMultipleSitesOfUserAppearedInTxtFileDataBreaches()
        {
            var aUserPasswordPair = LoadTestCategoryToMyUserWithAUserPasswordPair();

            UserPasswordPair anotherUserPasswordPair = new UserPasswordPair()
            {
                Category = aCategory,
                Password = "thisIsAPassword",
                Notes = "these are my notes",
                Username = "anotherUserName",
                Site = "myOtherSite",
            };

            aCategory.AddUserPasswordPair(anotherUserPasswordPair);

            IDataBreachesFormatter dataBreaches = new TextBoxDataBreaches()
            {
                txtDataBreaches = "thisIsAPassword"
            };

            Assert.AreEqual(aUser.CheckDataBreaches(dataBreaches).LeakedUserPasswordPairsOfUser[0].Id, aUserPasswordPair.Id);
            Assert.AreEqual(aUser.CheckDataBreaches(dataBreaches).LeakedUserPasswordPairsOfUser[1].Id, anotherUserPasswordPair.Id);
            Assert.AreEqual(2, aUser.CheckDataBreaches(dataBreaches).LeakedUserPasswordPairsOfUser.Count);
        }

        //[TestMethod]
        //public void GetModifiedAndNotModifiedLeakedPasswords()
        //{
        //    var aUserPasswordPair = LoadTestCategoryToMyUserWithAUserPasswordPair();
        //    var anotherUserPasswordPair = LoadTestCategoryToMyUserWithAnotherUserPasswordPair();

        //    IDataBreachesFormatter dataBreach = new TextBoxDataBreaches()
        //    {
        //        txtDataBreaches = "thisIsAPassword\nthisIsAnotherPassword"
        //    };

        //    DataBreach aDataBreach = aUser.CheckDataBreaches(dataBreach);

        //    DateTime fakeDateWhichIsBeforeCurrentDate = new DateTime(DateTime.Now.Year - 1, 12, 31, 5, 10, 20);
        //    aUserPasswordPair.LastModifiedDate = fakeDateWhichIsBeforeCurrentDate;

        //    DateTime fakeDateWhichIsAfterCurrentDate = new DateTime(DateTime.Now.Year + 1, 12, 31, 5, 10, 20);
        //    anotherUserPasswordPair.LastModifiedDate = fakeDateWhichIsAfterCurrentDate;

        //    Assert.AreEqual(aUserPasswordPair.Id, aUser.GetModifiedAndNotModifiedLeakedPasswords(aDataBreach).Item1[0].Id);
        //    Assert.AreEqual(anotherUserPasswordPair.Id, aUser.GetModifiedAndNotModifiedLeakedPasswords(aDataBreach).Item2[0].Id);
        //    Assert.AreEqual(1, aUser.GetModifiedAndNotModifiedLeakedPasswords(aDataBreach).Item1.Count);
        //    Assert.AreEqual(1, aUser.GetModifiedAndNotModifiedLeakedPasswords(aDataBreach).Item2.Count);
        //}

        [TestMethod]
        public void GetAllPasswordPairsWithOnlyOneInside()
        {
            var aUserPasswordPair = LoadTestCategoryToMyUserWithAUserPasswordPair();
            UserPasswordPair[] allUserPasswordPairs = aUser.GetUserPasswordPairs();
            Assert.AreEqual(1, allUserPasswordPairs.Length);
            Assert.AreEqual(aUserPasswordPair.Password, allUserPasswordPairs[0].Password);
            Assert.AreEqual(aUserPasswordPair.Site, allUserPasswordPairs[0].Site);
            Assert.AreEqual(aUserPasswordPair.Username, allUserPasswordPairs[0].Username);

        }

        private UserPasswordPair LoadTestCategoryToMyUserWithAUserPasswordPair()
        {
            var aUserPasswordPair = new UserPasswordPair()
            {
                Category = aCategory,
                Password = "thisIsAPassword",
                Notes = "these are my notes",
                Username = "myUserName",
                Site = "mySite",
            };

            aCategory.AddUserPasswordPair(aUserPasswordPair);
            return aUserPasswordPair;
        }


        private UserPasswordPair LoadTestCategoryToMyUserWithAnotherUserPasswordPair()
        {
            UserPasswordPair anotherUserPasswordPair = new UserPasswordPair()
            {
                Category = aCategory,
                Password = "thisIsAnotherPassword",
                Notes = "these are my notes",
                Username = "anotherUserName",
                Site = "mySite",
            };

            aCategory.AddUserPasswordPair(anotherUserPasswordPair);
            return anotherUserPasswordPair;
        }

        private CreditCard LoadTestCategoryToMyUserWithACreditCard()
        {
            CreditCard aCreditCard = new CreditCard()
            {
                Category = aCategory,
                Number = "1234567891234567",
                Type = "Visa",
                Name = "Visa Gold",
                Code = "234",
                Notes = "",
                ExpirationDate = new DateTime(2023, 12, 25),
            };

            aCategory.AddCreditCard(aCreditCard);
            return aCreditCard;
        }

        private CreditCard LoadTestCategoryToMyUserWithAnotherCreditCard()
        {
            CreditCard anotherCreditCard = new CreditCard()
            {
                Number = "1234567891234222",
                Type = "Visa",
                Name = "Visa Gold",
                Code = "234",
                Notes = "",
                ExpirationDate = new DateTime(2023, 12, 25),
                Category = aCategory,
            };
            aCategory.AddCreditCard(anotherCreditCard);
            return anotherCreditCard;
        }

        [TestCleanup]
        public void Cleanup()
        {
            using (var dbContext = new DataManagerContext())
            {
                dbContext.Users.RemoveRange(dbContext.Users);
                dbContext.Categories.RemoveRange(dbContext.Categories);
                dbContext.UserPasswordPairs.RemoveRange(dbContext.UserPasswordPairs);
                dbContext.CreditCards.RemoveRange(dbContext.CreditCards);
                dbContext.DataBreaches.RemoveRange(dbContext.DataBreaches);
                dbContext.LeakedCreditCards.RemoveRange(dbContext.LeakedCreditCards);
                dbContext.LeakedPasswords.RemoveRange(dbContext.LeakedPasswords);
                dbContext.SaveChanges();
            }
        }
    }
}
