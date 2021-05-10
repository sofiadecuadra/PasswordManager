using GestorPasswordsDominio;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace GestorPasswordsTest
{
    [TestClass]
    public class UserTest
    {
        private User aUser;

        [TestInitialize]
        public void Initialize()
        {
            aUser = new User()
            {
                MasterPassword = "myPassword"
            };
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
            Assert.IsTrue(aUser.ChangeMasterPassword(currentPassword, newPassword));
        }

        [TestMethod]
        public void AddUserPasswordPairsInDifferentCategoriesAndGetPasswordsStrengthReport()
        {
            Category aCategory = new Category()
            {
                User = aUser,
                Name = "myCategory"
            };
            aUser.AddCategory(aCategory);

            UserPasswordPair aRedUserPasswordPair = new UserPasswordPair()
            {
                Password = "myPass",
                Notes = "these are my notes",
                Username = "myUserName1",
                Site = "mySite1",
                Category = aCategory,
            };
            aCategory.AddUserPasswordPair(aRedUserPasswordPair);

            UserPasswordPair aYellowUserPasswordPair = new UserPasswordPair()
            {
                Password = "MYPASSWORD12345",
                Notes = "these are my notes",
                Username = "myUserName2",
                Site = "mySite2",
                Category = aCategory,
            };
            aCategory.AddUserPasswordPair(aYellowUserPasswordPair);

            UserPasswordPair aDarkGreenUserPasswordPair = new UserPasswordPair()
            {
                Password = "MYpassword@#12345",
                Notes = "these are my notes",
                Username = "myUserName3",
                Site = "mySite3",
                Category = aCategory,
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
                Password = "myPassword",
                Notes = "these are my notes",
                Username = "myUserName4",
                Site = "mySite4",
                Category = aCategory,
            };
            aCategory.AddUserPasswordPair(anOrangeUserPasswordPair);

            UserPasswordPair aLightGreenUserPasswordPair = new UserPasswordPair()
            {
                Password = "MYpassword1234512",
                Notes = "these are my notes",
                Username = "myUserName5",
                Site = "mySite5",
                Category = aCategory,
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
            User aUser = new User()
            {
                MasterPassword = "myPassword"
            };

            Category aCategory = new Category()
            {
                User = aUser,
                Name = "myCategory"
            };

            Assert.IsTrue(aUser.AddCategory(aCategory));
            Assert.AreEqual(1, aUser.GetCategories().Length);
        }

        [TestMethod]
        [ExpectedException(typeof(ExceptionCategoryHasInvalidNameLength))]
        public void AddCategoryWithLengthLessThan3()
        {
            User aUser = new User()
            {
                MasterPassword = "myPassword"
            };

            Category aCategory = new Category()
            {
                User = aUser,
                Name = "my"
            };

            aUser.AddCategory(aCategory);
        }

        [TestMethod]
        [ExpectedException(typeof(ExceptionCategoryHasInvalidNameLength))]
        public void AddCategoryWithLengthGreaterThan15()
        {
            User aUser = new User()
            {
                MasterPassword = "myPassword"
            };

            Category aCategory = new Category()
            {
                User = aUser,
                Name = "myCategoryNameIsInvalid"
            };

            aUser.AddCategory(aCategory);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void AddExistingCategory()
        {
            User aUser = new User()
            {
                MasterPassword = "myPassword"
            };

            Category aCategory = new Category()
            {
                User = aUser,
                Name = "myCategory"
            };

            aUser.AddCategory(aCategory);

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
            User aUser = new User()
            {
                MasterPassword = "myPassword"
            };

            Category aCategory = new Category()
            {
                User = aUser,
                Name = "myCategory"
            };

            aUser.AddCategory(aCategory);

            Assert.IsTrue(aUser.ModifyCategory(aCategory, "newName"));
            Assert.AreEqual("newname", aCategory.Name);
        }

        [TestMethod]
        [ExpectedException(typeof(ExceptionCategoryNotExists))]
        public void ModifyCategoryThatDoesNotExist()
        {
            User aUser = new User()
            {
                MasterPassword = "myPassword"
            };

            Category aCategory = new Category()
            {
                User = aUser,
                Name = "myCategory"
            };

            aUser.ModifyCategory(aCategory, "newName");
        }

        [TestMethod]
        [ExpectedException(typeof(ExceptionCategoryHasInvalidNameLength))]
        public void ModifyCategoryWithNewLengthLessThan3()
        {
            User aUser = new User()
            {
                MasterPassword = "myPassword"
            };

            Category aCategory = new Category()
            {
                User = aUser,
                Name = "myCategory"
            };

            aUser.AddCategory(aCategory);

            aUser.ModifyCategory(aCategory, "no");
        }

        [TestMethod]
        [ExpectedException(typeof(ExceptionCategoryHasInvalidNameLength))]
        public void ModifyCategoryWithNewLengthGreaterThan15()
        {
            User aUser = new User()
            {
                MasterPassword = "myPassword"
            };

            Category aCategory = new Category()
            {
                User = aUser,
                Name = "myCategory"
            };

            aUser.AddCategory(aCategory);

            aUser.ModifyCategory(aCategory, "thisIsAnInvalidLength");
        }

        [TestMethod]
        [ExpectedException(typeof(ExceptionCategoryAlreadyExists))]
        public void ModifyCategoryToAnExistingName()
        {
            User aUser = new User()
            {
                MasterPassword = "myPassword"
            };

            Category aCategory = new Category()
            {
                User = aUser,
                Name = "myCategory"
            };
            aUser.AddCategory(aCategory);

            Category otherCategory = new Category()
            {
                User = aUser,
                Name = "otherCategory"
            };
            aUser.AddCategory(otherCategory);

            aUser.ModifyCategory(otherCategory, "myCategory");
        }

        [TestMethod]
        public void ModifyCategoryNameToItsOwnName()
        {
            User aUser = new User()
            {
                MasterPassword = "myPassword"
            };

            Category aCategory = new Category()
            {
                User = aUser,
                Name = "myCategory"
            };
            aUser.AddCategory(aCategory);

            Assert.IsFalse(aUser.ModifyCategory(aCategory, "myCategory"));
        }

        [TestMethod]
        public void AddCreditCardToCategoryAndGetCreditCardslist()
        {
            Category aCategory = new Category()
            {
                User = aUser,
                Name = "myCategory"
            };
            aUser.AddCategory(aCategory);

            CreditCard aCreditCard = new CreditCard()
            {
                Category = aCategory,
                Name = "VISA",
                Type = "Visa Gold",
                Number = "1234567891234567",
                Code = "123",
                ExpirationDate = DateTime.Now,
                Notes = "Notes"
            };
            aCategory.AddCreditCard(aCreditCard);

            Assert.AreEqual(1, aUser.GetCreditCards().Length);
        }

        [TestMethod]
        public void RetriveExistingUserPasswordPair()
        {
            var aCategory = new Category()
            {
                User = aUser,
                Name = "myCategory"
            };
            var aUserPasswordPair = new UserPasswordPair()
            {
                Password = "thisIsAPassword",
                Notes = "these are my notes",
                Username = "myUserName",
                Site = "mySite",
                Category = aCategory,
            };

            aCategory.AddUserPasswordPair(aUserPasswordPair);
            aUser.AddCategory(aCategory);

            Assert.AreEqual(aUser.FindUserPasswordPair(aUserPasswordPair.Username, aUserPasswordPair.Site), aUserPasswordPair);
        }

        [TestMethod]
        [ExpectedException(typeof(ExceptionUserPasswordPairDoesNotExist))]
        public void RetriveNonExistingUserPasswordPair()
        {
            var aCategory = new Category()
            {
                User = aUser,
                Name = "myCategory"
            };
            var aUserPasswordPair = new UserPasswordPair()
            {
                Password = "thisIsAPassword",
                Notes = "these are my notes",
                Username = "myUserName",
                Site = "mySite",
                Category = aCategory,
            };

            aUser.AddCategory(aCategory);

            aUser.FindUserPasswordPair(aUserPasswordPair.Username, aUserPasswordPair.Site);
        }

        [TestMethod]
        public void ACreditCardOfUserAppearedInDataBreaches()
        {
            var aCategory = new Category()
            {
                User = aUser,
                Name = "myCategory"
            };

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

            aUser.AddCategory(aCategory);
            aCategory.AddCreditCard(aCreditCard);
            aCategory.AddCreditCard(anotherCreditCard);

            IDataBreachesFormatter dataBreaches = new TextBoxDataBreaches()
            {
                txtDataBreaches = "1234 5678 9123 4567"
            };

            List <CreditCard> expectedCreditCardList = new List<CreditCard>();
            expectedCreditCardList.Add(aCreditCard);

            CollectionAssert.AreEquivalent(aUser.CheckDataBreaches(dataBreaches).Item2, expectedCreditCardList);
        }


        [TestMethod]
        public void TwoCreditCardsOfUserAppearedInDataBreaches()
        {
            var aCategory = new Category()
            {
                User = aUser,
                Name = "myCategory"
            };

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

            aUser.AddCategory(aCategory);
            aCategory.AddCreditCard(aCreditCard);
            aCategory.AddCreditCard(anotherCreditCard);

            IDataBreachesFormatter dataBreaches = new TextBoxDataBreaches()
            {
                txtDataBreaches = "1234 5678 9123 4567\n1234 5678 9123 4222"
            };

            List<CreditCard> expectedCreditCardList = new List<CreditCard>();
            expectedCreditCardList.Add(aCreditCard);
            expectedCreditCardList.Add(anotherCreditCard);

            CollectionAssert.AreEquivalent(aUser.CheckDataBreaches(dataBreaches).Item2, expectedCreditCardList);
        }

        [TestMethod]
        public void APasswordOfUserAppearedInDataBreaches()
        {
            var aCategory = new Category()
            {
                User = aUser,
                Name = "myCategory"
            };

            UserPasswordPair aUserPasswordPair = new UserPasswordPair()
            {
                Password = "thisIsAPassword",
                Notes = "these are my notes",
                Username = "myUserName",
                Site = "mySite",
                Category = aCategory,
            };

            UserPasswordPair anotherUserPasswordPair = new UserPasswordPair()
            {
                Password = "thisIsAnotherPassword",
                Notes = "these are my notes",
                Username = "anotherUserName",
                Site = "mySite",
                Category = aCategory,
            };

            aUser.AddCategory(aCategory);
            aCategory.AddUserPasswordPair(aUserPasswordPair);
            aCategory.AddUserPasswordPair(anotherUserPasswordPair);

            IDataBreachesFormatter dataBreaches = new TextBoxDataBreaches()
            {
                txtDataBreaches = "thisIsAPassword"
            };

            List<UserPasswordPair> expectedUserPasswordPairList = new List<UserPasswordPair>();
            expectedUserPasswordPairList.Add(aUserPasswordPair);

            CollectionAssert.AreEquivalent(aUser.CheckDataBreaches(dataBreaches).Item1, expectedUserPasswordPairList);
        }

        [TestMethod]
        public void APasswordAndACreditCardOfUserAppearedInDataBreaches()
        {
            var aCategory = new Category()
            {
                User = aUser,
                Name = "myCategory"
            };

            UserPasswordPair aUserPasswordPair = new UserPasswordPair()
            {
                Password = "thisIsAPassword",
                Notes = "these are my notes",
                Username = "myUserName",
                Site = "mySite",
                Category = aCategory,
            };

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

            aUser.AddCategory(aCategory);
            aCategory.AddUserPasswordPair(aUserPasswordPair);
            aCategory.AddCreditCard(aCreditCard);

            IDataBreachesFormatter dataBreaches = new TextBoxDataBreaches()
            {
                txtDataBreaches = "thisIsAPassword\nthisIsAnotherPassword\n1234 5678 9123 4567"
            };

            List<CreditCard> expectedCreditCardList = new List<CreditCard>();
            expectedCreditCardList.Add(aCreditCard);

            List<UserPasswordPair> expectedUserPasswordPairList = new List<UserPasswordPair>();
            expectedUserPasswordPairList.Add(aUserPasswordPair);

            CollectionAssert.AreEquivalent(aUser.CheckDataBreaches(dataBreaches).Item1, expectedUserPasswordPairList);
            CollectionAssert.AreEquivalent(aUser.CheckDataBreaches(dataBreaches).Item2, expectedCreditCardList);
        }

        [TestMethod]
        public void SamePasswordAppearedMoreThanOnceInDataBreaches()
        {
            var aCategory = new Category()
            {
                User = aUser,
                Name = "myCategory"
            };

            UserPasswordPair aUserPasswordPair = new UserPasswordPair()
            {
                Password = "thisIsAPassword",
                Notes = "these are my notes",
                Username = "myUserName",
                Site = "mySite",
                Category = aCategory,
            };

            aUser.AddCategory(aCategory);
            aCategory.AddUserPasswordPair(aUserPasswordPair);

            IDataBreachesFormatter dataBreaches = new TextBoxDataBreaches()
            {
                txtDataBreaches = "thisIsAPassword\nthisIsAPassword\n1234 5678 9123 4567"
            };

            List<UserPasswordPair> expectedUserPasswordPairList = new List<UserPasswordPair>();
            expectedUserPasswordPairList.Add(aUserPasswordPair);

            CollectionAssert.AreEquivalent(aUser.CheckDataBreaches(dataBreaches).Item1, expectedUserPasswordPairList);
        }

        [TestMethod]
        public void SameCreditCardAppearedMoreThanOnceInDataBreaches()
        {
            var aCategory = new Category()
            {
                User = aUser,
                Name = "myCategory"
            };
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

            aUser.AddCategory(aCategory);
            aCategory.AddCreditCard(aCreditCard);

            IDataBreachesFormatter dataBreaches = new TextBoxDataBreaches()
            {
                txtDataBreaches = "thisIsAPassword\n1234 5678 9123 4567\n1234 5678 9123 4567"
            };

            List<CreditCard> expectedCreditCardList = new List<CreditCard>();
            expectedCreditCardList.Add(aCreditCard);

            CollectionAssert.AreEquivalent(aUser.CheckDataBreaches(dataBreaches).Item2, expectedCreditCardList);
        }

        [TestMethod]
        public void PasswordsOfUserAppearedInDataBreaches()
        {
            var aCategory = new Category()
            {
                User = aUser,
                Name = "myCategory"
            };

            UserPasswordPair aUserPasswordPair = new UserPasswordPair()
            {
                Password = "thisIsAPassword",
                Notes = "these are my notes",
                Username = "myUserName",
                Site = "mySite",
                Category = aCategory,
            };

            UserPasswordPair anotherUserPasswordPair = new UserPasswordPair()
            {
                Password = "thisIsAnotherPassword",
                Notes = "these are my notes",
                Username = "anotherUserName",
                Site = "mySite",
                Category = aCategory,
            };

            aUser.AddCategory(aCategory);
            aCategory.AddUserPasswordPair(aUserPasswordPair);
            aCategory.AddUserPasswordPair(anotherUserPasswordPair);

            IDataBreachesFormatter dataBreaches = new TextBoxDataBreaches()
            {
                txtDataBreaches = "thisIsAPassword\nthisIsAnotherPassword"
            };

            List<UserPasswordPair> expectedUserPasswordPairList = new List<UserPasswordPair>();
            expectedUserPasswordPairList.Add(aUserPasswordPair);
            expectedUserPasswordPairList.Add(anotherUserPasswordPair);

            CollectionAssert.AreEquivalent(aUser.CheckDataBreaches(dataBreaches).Item1, expectedUserPasswordPairList);
        }

        [TestMethod]
        public void MultiplePasswordsAndCreditCardsOfUserAppearedInDataBreaches()
        {
            var aCategory = new Category()
            {
                User = aUser,
                Name = "myCategory"
            };

            UserPasswordPair aUserPasswordPair = new UserPasswordPair()
            {
                Password = "thisIsAPassword",
                Notes = "these are my notes",
                Username = "myUserName",
                Site = "mySite",
                Category = aCategory,
            };

            UserPasswordPair anotherUserPasswordPair = new UserPasswordPair()
            {
                Password = "thisIsAnotherPassword",
                Notes = "these are my notes",
                Username = "anotherUserName",
                Site = "mySite",
                Category = aCategory,
            };

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

            aUser.AddCategory(aCategory);

            aCategory.AddUserPasswordPair(aUserPasswordPair);
            aCategory.AddUserPasswordPair(anotherUserPasswordPair);

            aCategory.AddCreditCard(aCreditCard);
            aCategory.AddCreditCard(anotherCreditCard);

            IDataBreachesFormatter dataBreaches = new TextBoxDataBreaches()
            {
                txtDataBreaches = "thisIsAPassword\n1234 5678 9123 4222\nHello\nthisIsAnotherPassword\n1234 5678 9123 4567\n"
            };

            List<UserPasswordPair> expectedUserPasswordPairList = new List<UserPasswordPair>();
            expectedUserPasswordPairList.Add(aUserPasswordPair);
            expectedUserPasswordPairList.Add(anotherUserPasswordPair);

            List<CreditCard> expectedCreditCardList = new List<CreditCard>();
            expectedCreditCardList.Add(aCreditCard);
            expectedCreditCardList.Add(anotherCreditCard);

            CollectionAssert.AreEquivalent(aUser.CheckDataBreaches(dataBreaches).Item1, expectedUserPasswordPairList);
            CollectionAssert.AreEquivalent(aUser.CheckDataBreaches(dataBreaches).Item2, expectedCreditCardList);
        }

        [TestMethod]
        public void NoPasswordsOrCreditCardsOfUserAppearedInDataBreaches()
        {
            var aCategory = new Category()
            {
                User = aUser,
                Name = "myCategory"
            };

            UserPasswordPair aUserPasswordPair = new UserPasswordPair()
            {
                Password = "thisIsAPassword",
                Notes = "these are my notes",
                Username = "myUserName",
                Site = "mySite",
                Category = aCategory,
            };

            UserPasswordPair anotherUserPasswordPair = new UserPasswordPair()
            {
                Password = "thisIsAnotherPassword",
                Notes = "these are my notes",
                Username = "anotherUserName",
                Site = "mySite",
                Category = aCategory,
            };

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

            aUser.AddCategory(aCategory);

            aCategory.AddUserPasswordPair(aUserPasswordPair);
            aCategory.AddUserPasswordPair(anotherUserPasswordPair);

            aCategory.AddCreditCard(aCreditCard);
            aCategory.AddCreditCard(anotherCreditCard);

            IDataBreachesFormatter dataBreaches = new TextBoxDataBreaches()
            {
                txtDataBreaches = "Sof\n1234 5678 2333 4222\nHello\nthisPassword\n1235 5665 9123 4567\n"
            };

            List<UserPasswordPair> expectedUserPasswordPairList = new List<UserPasswordPair>();

            List<CreditCard> expectedCreditCardList = new List<CreditCard>();

            CollectionAssert.AreEquivalent(aUser.CheckDataBreaches(dataBreaches).Item1, expectedUserPasswordPairList);
            CollectionAssert.AreEquivalent(aUser.CheckDataBreaches(dataBreaches).Item2, expectedCreditCardList);
        }

        [TestMethod]
        public void PasswordUsedInMultipleSitesOfUserAppearedInDataBreaches()
        {
            var aCategory = new Category()
            {
                User = aUser,
                Name = "myCategory"
            };

            UserPasswordPair aUserPasswordPair = new UserPasswordPair()
            {
                Password = "thisIsAPassword",
                Notes = "these are my notes",
                Username = "myUserName",
                Site = "mySite",
                Category = aCategory,
            };

            UserPasswordPair anotherUserPasswordPair = new UserPasswordPair()
            {
                Password = "thisIsAPassword",
                Notes = "these are my notes",
                Username = "anotherUserName",
                Site = "myOtherSite",
                Category = aCategory,
            };

            aUser.AddCategory(aCategory);
            aCategory.AddUserPasswordPair(aUserPasswordPair);
            aCategory.AddUserPasswordPair(anotherUserPasswordPair);

            IDataBreachesFormatter dataBreaches = new TextBoxDataBreaches()
            {
                txtDataBreaches = "thisIsAPassword"
            };

            List<UserPasswordPair> expectedUserPasswordPairList = new List<UserPasswordPair>();
            expectedUserPasswordPairList.Add(aUserPasswordPair);
            expectedUserPasswordPairList.Add(anotherUserPasswordPair);

            CollectionAssert.AreEquivalent(aUser.CheckDataBreaches(dataBreaches).Item1, expectedUserPasswordPairList);
        }

        [TestMethod]
        public void GetAllPasswordPairsWithOnlyOneInside()
        {
            var aUserPasswordPair = LoadTestCategoryToMyUserWithAUserPasswordPair();
            UserPasswordPair[] allUserPasswordPairs = aUser.GetUserPasswordPairs();
            Assert.AreEqual(1, allUserPasswordPairs.Length);
            Assert.AreEqual(aUserPasswordPair, allUserPasswordPairs[0]);
        }

        private UserPasswordPair LoadTestCategoryToMyUserWithAUserPasswordPair()
        {
            var aCategory = new Category()
            {
                Name = "aCategory",
                User = aUser
            };
            var aUserPasswordPair = new UserPasswordPair()
            {
                Password = "thisIsAPassword",
                Notes = "these are my notes",
                Username = "myUserName",
                Site = "mySite",
                Category = aCategory,
            };
            aUser.AddCategory(aCategory);

            aCategory.AddUserPasswordPair(aUserPasswordPair);
            return aUserPasswordPair;
        }
    }
}
