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
        private NormalCategory aCategory;

        [TestInitialize]
        public void Initialize()
        {
            aUser = new User()
            {
                MasterPassword = "myPassword"
            };

            aCategory = new NormalCategory()
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
            Assert.IsTrue(aUser.ChangeMasterPassword(currentPassword, newPassword));
        }

        [TestMethod]
        public void AddUserPasswordPairsInDifferentCategoriesAndGetPasswordsStrengthReport()
        {
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


            NormalCategory otherCategory = new NormalCategory()
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
            Assert.AreEqual(1, aUser.GetCategories().Length);
        }

        [TestMethod]
        [ExpectedException(typeof(ExceptionIncorrectLength))]
        public void AddCategoryWithLengthLessThan3()
        {
            NormalCategory anotherCategory = new NormalCategory()
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
            NormalCategory anotherCategory = new NormalCategory()
            {
                User = aUser,
                Name = "myCategoryNameIsInvalid"
            };

            aUser.AddCategory(anotherCategory);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void AddExistingCategory()
        {
            NormalCategory anotherCategory = new NormalCategory()
            {
                User = aUser,
                Name = "myCategory"
            };

            aUser.AddCategory(anotherCategory);
        }

        [TestMethod]
        public void ModifyCategoryNormally()
        {
            Assert.IsTrue(aUser.ModifyCategory(aCategory, "newName"));
            Assert.AreEqual("newname", aCategory.Name);
        }

        [TestMethod]
        [ExpectedException(typeof(ExceptionCategoryNotExists))]
        public void ModifyCategoryThatDoesNotExist()
        {
            NormalCategory anotherCategory = new NormalCategory()
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
            NormalCategory anotherCategory = new NormalCategory()
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
            Assert.IsFalse(aUser.ModifyCategory(aCategory, "myCategory"));
        }

        [TestMethod]
        public void AddCreditCardToCategoryAndGetCreditCardslist()
        {
            LoadTestCategoryToMyUserWithACreditCard();
            Assert.AreEqual(1, aUser.GetCreditCards().Length);
        }

        [TestMethod]
        public void RetriveExistingUserPasswordPair()
        {
            var aUserPasswordPair = LoadTestCategoryToMyUserWithAUserPasswordPair();

            Assert.AreEqual(aUser.FindUserPasswordPair(aUserPasswordPair.Username, aUserPasswordPair.Site), aUserPasswordPair);
        }

        [TestMethod]
        [ExpectedException(typeof(ExceptionUserPasswordPairDoesNotExist))]
        public void RetriveNonExistingUserPasswordPair()
        {
            var aUserPasswordPair = new UserPasswordPair()
            {
                Password = "thisIsAPassword",
                Notes = "these are my notes",
                Username = "myUserName",
                Site = "mySite",
                Category = aCategory,
            };

            aUser.FindUserPasswordPair(aUserPasswordPair.Username, aUserPasswordPair.Site);
        }

        [TestMethod]
        public void ACreditCardOfUserAppearedInDataBreaches()
        {
            var aCreditCard = LoadTestCategoryToMyUserWithACreditCard();

            IDataBreachesFormatter dataBreaches = new TextBoxDataBreaches()
            {
                txtDataBreaches = "1234 5678 9123 4567"
            };

            List <CreditCard> expectedCreditCardList = new List<CreditCard>();
            expectedCreditCardList.Add(aCreditCard);

            CollectionAssert.AreEquivalent(aUser.CheckDataBreaches(dataBreaches).Item2, expectedCreditCardList);
        }

        [TestMethod]
        public void MultipleCreditCardsOfUserAppearedInDataBreaches()
        {
            var aCreditCard = LoadTestCategoryToMyUserWithACreditCard();
            var anotherCreditCard = LoadTestCategoryToMyUserWithAnotherCreditCard();

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
            var aUserPasswordPair = LoadTestCategoryToMyUserWithAUserPasswordPair();
            var anotherUserPasswordPair = LoadTestCategoryToMyUserWithAnotherUserPasswordPair();

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
            var aUserPasswordPair = LoadTestCategoryToMyUserWithAUserPasswordPair();
            var aCreditCard = LoadTestCategoryToMyUserWithACreditCard();


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
            var aUserPasswordPair = LoadTestCategoryToMyUserWithAUserPasswordPair();

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
            var aCreditCard = LoadTestCategoryToMyUserWithACreditCard();

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
            var aUserPasswordPair = LoadTestCategoryToMyUserWithAUserPasswordPair();
            var anotherUserPasswordPair = LoadTestCategoryToMyUserWithAnotherUserPasswordPair();

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
        public void PasswordWithBlankSpacesAndOnlyDigitsOfUserAppearedInDataBreaches()
        {
            UserPasswordPair aUserPasswordPair = new UserPasswordPair()
            {
                Password = "4444 555 6666 2323",
                Notes = "these are my notes",
                Username = "myUserName",
                Site = "mySite",
                Category = aCategory,
            };

            aCategory.AddUserPasswordPair(aUserPasswordPair);

            IDataBreachesFormatter dataBreaches = new TextBoxDataBreaches()
            {
                txtDataBreaches = "4444 555 6666 2323"
            };

            List<UserPasswordPair> expectedUserPasswordPairList = new List<UserPasswordPair>();
            expectedUserPasswordPairList.Add(aUserPasswordPair);

            CollectionAssert.AreEquivalent(aUser.CheckDataBreaches(dataBreaches).Item1, expectedUserPasswordPairList);
        }

        [TestMethod]
        public void PasswordWithBlankSpacesOfUserAppearedInDataBreaches()
        {
            UserPasswordPair aUserPasswordPair = new UserPasswordPair()
            {
                Password = "rfkg s67r sjdh liks",
                Notes = "these are my notes",
                Username = "myUserName",
                Site = "mySite",
                Category = aCategory,
            };

            aCategory.AddUserPasswordPair(aUserPasswordPair);

            IDataBreachesFormatter dataBreaches = new TextBoxDataBreaches()
            {
                txtDataBreaches = "rfkg s67r sjdh liks"
            };

            List<UserPasswordPair> expectedUserPasswordPairList = new List<UserPasswordPair>();
            expectedUserPasswordPairList.Add(aUserPasswordPair);

            CollectionAssert.AreEquivalent(aUser.CheckDataBreaches(dataBreaches).Item1, expectedUserPasswordPairList);
        }

        [TestMethod]
        public void MultiplePasswordsAndCreditCardsOfUserAppearedInDataBreaches()
        {
            var aUserPasswordPair = LoadTestCategoryToMyUserWithAUserPasswordPair();
            var anotherUserPasswordPair = LoadTestCategoryToMyUserWithAnotherUserPasswordPair();

            var aCreditCard = LoadTestCategoryToMyUserWithACreditCard();
            var anotherCreditCard = LoadTestCategoryToMyUserWithAnotherCreditCard();


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
            var aUserPasswordPair = LoadTestCategoryToMyUserWithAUserPasswordPair();
            var anotherUserPasswordPair = LoadTestCategoryToMyUserWithAnotherUserPasswordPair();

            var aCreditCard = LoadTestCategoryToMyUserWithACreditCard();
            var anotherCreditCard = LoadTestCategoryToMyUserWithAnotherCreditCard();

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
            var aUserPasswordPair = LoadTestCategoryToMyUserWithAUserPasswordPair();

            UserPasswordPair anotherUserPasswordPair = new UserPasswordPair()
            {
                Password = "thisIsAPassword",
                Notes = "these are my notes",
                Username = "anotherUserName",
                Site = "myOtherSite",
                Category = aCategory,
            };

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
            var aUserPasswordPair = new UserPasswordPair()
            {
                Password = "thisIsAPassword",
                Notes = "these are my notes",
                Username = "myUserName",
                Site = "mySite",
                Category = aCategory,
            };

            aCategory.AddUserPasswordPair(aUserPasswordPair);
            return aUserPasswordPair;
        }

        private UserPasswordPair LoadTestCategoryToMyUserWithAnotherUserPasswordPair()
        {
            UserPasswordPair anotherUserPasswordPair = new UserPasswordPair()
            {
                Password = "thisIsAnotherPassword",
                Notes = "these are my notes",
                Username = "anotherUserName",
                Site = "mySite",
                Category = aCategory,
            };

            aCategory.AddUserPasswordPair(anotherUserPasswordPair);
            return anotherUserPasswordPair;
        }

        private CreditCard LoadTestCategoryToMyUserWithACreditCard()
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
    }
}
