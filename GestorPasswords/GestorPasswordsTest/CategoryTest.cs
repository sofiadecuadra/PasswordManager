using Microsoft.VisualStudio.TestTools.UnitTesting;
using GestorPasswordsDominio;
using System;

namespace GestorPasswordsTest
{
    [TestClass]
    public class CategoryTest
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
        public void AddValidCreditCard()
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
            Assert.IsTrue(aCategory.AddCreditCard(aCreditCard));
        }

        [TestMethod]
        public void AddCreditCardWithNumberContainingWhitespaceInBetweenDigits()
        {
            CreditCard aCreditCard = new CreditCard()
            {
                Number = "123    456   789    12345   67",
                Type = "Visa",
                Name = "Visa Gold",
                Code = "234",
                Notes = "",
                ExpirationDate = new DateTime(2023, 12, 25),
                Category = aCategory,
            };
            Assert.IsTrue(aCategory.AddCreditCard(aCreditCard));
        }

        [TestMethod]
        [ExpectedException(typeof(ExceptionCreditCardHasInvalidNumberLength))]
        public void AddCreditCardWithNumberLengthLessThan16()
        {
            CreditCard aCreditCard = new CreditCard()
            {
                Number = "12345678912",
                Type = "Visa",
                Name = "Visa Gold",
                Code = "234",
                Notes = "",
                ExpirationDate = new DateTime(2023, 12, 25),
                Category = aCategory,
            };
            aCategory.AddCreditCard(aCreditCard);
        }

        [TestMethod]
        [ExpectedException(typeof(ExceptionCreditCardDoesNotContainOnlyDigits))]
        public void AddCreditCardThatDoesNotContainOnlyDigits()
        {
            CreditCard aCreditCard = new CreditCard()
            {
                Number = "1234567891fjk567",
                Type = "Visa",
                Name = "Visa Gold",
                Code = "234",
                Notes = "",
                ExpirationDate = new DateTime(2023, 12, 25),
                Category = aCategory,
            };
            aCategory.AddCreditCard(aCreditCard);
        }

        [TestMethod]
        [ExpectedException(typeof(ExceptionCreditCardHasInvalidTypeLength))]
        public void AddCreditCardWithTypeLengthLessThan3()
        {
            CreditCard aCreditCard = new CreditCard()
            {
                Number = "1234567891234567",
                Type = "Vi",
                Name = "Visa Gold",
                Code = "234",
                Notes = "",
                ExpirationDate = new DateTime(2023, 12, 25),
                Category = aCategory,
            };
            aCategory.AddCreditCard(aCreditCard);
        }

        [TestMethod]
        [ExpectedException(typeof(ExceptionCreditCardHasInvalidTypeLength))]
        public void AddCreditCardWithTypeLengthGreaterThan25()
        {
            CreditCard aCreditCard = new CreditCard()
            {
                Number = "1234567891234567",
                Type = "VisaVisaVisaVisaVisaVisaVisa",
                Name = "Visa Gold",
                Code = "234",
                Notes = "",
                ExpirationDate = new DateTime(2023, 12, 25),
                Category = aCategory,
            };
            aCategory.AddCreditCard(aCreditCard);
        }
        
        [TestMethod]
        [ExpectedException(typeof(ExceptionCreditCardHasInvalidNameLength))]
        public void AddCreditCardWithNameLengthLessThan3()
        {
            CreditCard aCreditCard = new CreditCard()
            {
                Number = "1234567891234567",
                Type = "Visa",
                Name = "Vi",
                Code = "234",
                Notes = "",
                ExpirationDate = new DateTime(2023, 12, 25),
                Category = aCategory,
            };
            aCategory.AddCreditCard(aCreditCard);
        }

        [TestMethod]
        [ExpectedException(typeof(ExceptionCreditCardHasInvalidNameLength))]
        public void AddCreditCardWithNameLengthGreaterThan25()
        {
            CreditCard aCreditCard = new CreditCard()
            {
                Number = "1234567891234567",
                Type = "Visa",
                Name = "Visa Gold Visa Gold Visa Gold Visa Gold",
                Code = "234",
                Notes = "",
                ExpirationDate = new DateTime(2023, 12, 25),
                Category = aCategory,
            };
            aCategory.AddCreditCard(aCreditCard);
        }

        [TestMethod]
        [ExpectedException(typeof(ExceptionCreditCardHasInvalidCodeLength))]
        public void AddCreditCardWithCodeLengthLessThan3()
        {
            CreditCard aCreditCard = new CreditCard()
            {
                Number = "1234567891234567",
                Type = "Visa",
                Name = "Visa Gold",
                Code = "12",
                Notes = "",
                ExpirationDate = new DateTime(2023, 12, 25),
                Category = aCategory,
            };
            aCategory.AddCreditCard(aCreditCard);
        }

        [TestMethod]
        [ExpectedException(typeof(ExceptionCreditCardHasInvalidCodeLength))]
        public void AddCreditCardWithCodeLengthGreaterThan4()
        {
            CreditCard aCreditCard = new CreditCard()
            {
                Number = "1234567891234567",
                Type = "Visa",
                Name = "Visa Gold",
                Code = "12121",
                Notes = "",
                ExpirationDate = new DateTime(2023, 12, 25),
                Category = aCategory,
            };
            aCategory.AddCreditCard(aCreditCard);
        }

        [TestMethod]
        [ExpectedException(typeof(ExceptionCreditCardCodeHasNonNumericCharacters))]
        public void AddCreditCardWithCodeThatHasNonNumericCharacters()
        {
            CreditCard aCreditCard = new CreditCard()
            {
                Number = "1234567891234567",
                Type = "Visa",
                Name = "Visa Gold",
                Code = "12A",
                Notes = "",
                ExpirationDate = new DateTime(2023, 12, 25),
                Category = aCategory,
            };
            aCategory.AddCreditCard(aCreditCard);
        }


        [TestMethod]
        [ExpectedException(typeof(ExceptionCreditCardHasInvalidNotesLength))]
        public void AddCreditCardWithNotesLengthGreaterThan250()
        {
            string aNote = "";
            for (int i = 0; i <= 251; i++)
            {
                aNote += "a";
            }

            CreditCard aCreditCard = new CreditCard()
            {
                Number = "1234567891234567",
                Type = "Visa",
                Name = "Visa Gold",
                Code = "234",
                Notes = aNote,
                ExpirationDate = new DateTime(2023, 12, 25),
                Category = aCategory,
            };
            aCategory.AddCreditCard(aCreditCard);
        }

        [TestMethod]
        [ExpectedException(typeof(ExceptionCreditCardNumberAlreadyExistsInUser))]
        public void AddExistingCreditCard()
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
            CreditCard anotherCreditCard = new CreditCard()
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
            aCategory.AddCreditCard(anotherCreditCard);
        }

        [TestMethod]
        public void ModifyCodeOfCreditCardToAValidOneAndWithoutChangingCategory ()
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

            CreditCard newCreditCard = new CreditCard()
            {
                Number = "1234567891234567",
                Type = "Visa",
                Name = "Visa Gold",
                Code = "1234",
                Notes = "",
                ExpirationDate = new DateTime(2023, 12, 25),
                Category = aCategory,
            };

            Assert.IsTrue(aCategory.ModifyCreditCard(aCreditCard, newCreditCard));
        }

        [TestMethod]
        [ExpectedException(typeof(ExceptionCreditCardHasInvalidNumberLength))]
        public void ModifyNumberOfCreditCardToAnInvalidOne()
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

            CreditCard newCreditCard = new CreditCard()
            {
                Number = "12345678912345",
                Type = "Visa",
                Name = "Visa Gold",
                Code = "234",
                Notes = "",
                ExpirationDate = new DateTime(2023, 12, 25),
                Category = aCategory,
            };

            _ = aCategory.ModifyCreditCard(aCreditCard, newCreditCard);
        }

        [TestMethod]
        [ExpectedException(typeof(ExceptionCreditCardHasInvalidTypeLength))]
        public void ModifyTypeOfCreditCardToAnInvalidOne()
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

            CreditCard newCreditCard = new CreditCard()
            {
                Number = "1234567891234567",
                Type = "Vi",
                Name = "Visa Gold",
                Code = "234",
                Notes = "",
                ExpirationDate = new DateTime(2023, 12, 25),
                Category = aCategory,
            };

            _ = aCategory.ModifyCreditCard(aCreditCard, newCreditCard);
        }

        [TestMethod]
        [ExpectedException(typeof(ExceptionCreditCardHasInvalidNameLength))]
        public void ModifyNameOfCreditCardToAnInvalidOne()
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

            CreditCard newCreditCard = new CreditCard()
            {
                Number = "1234567891234567",
                Type = "Visa",
                Name = "Vi",
                Code = "234",
                Notes = "",
                ExpirationDate = new DateTime(2023, 12, 25),
                Category = aCategory,
            };

            _ = aCategory.ModifyCreditCard(aCreditCard, newCreditCard);
        }

        [TestMethod]
        [ExpectedException(typeof(ExceptionCreditCardHasInvalidCodeLength))]
        public void ModifyCodeOfCreditCardToAnInvalidOne()
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

            CreditCard newCreditCard = new CreditCard()
            {
                Number = "1234567891234567",
                Type = "Visa",
                Name = "Visa Gold",
                Code = "2",
                Notes = "",
                ExpirationDate = new DateTime(2023, 12, 25),
                Category = aCategory,
            };



            _ = aCategory.ModifyCreditCard(aCreditCard, newCreditCard);
        }

        [TestMethod]
        [ExpectedException(typeof(ExceptionCreditCardCodeHasNonNumericCharacters))]
        public void ModifyCodeOfCreditCardToOneWithNonNumericCharacters()
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


            CreditCard newCreditCard = new CreditCard()
            {
                Number = "1234567891234567",
                Type = "Visa",
                Name = "Visa Gold",
                Code = "2lj",
                Notes = "",
                ExpirationDate = new DateTime(2023, 12, 25),
                Category = aCategory,
            };
            _ = aCategory.ModifyCreditCard(aCreditCard, newCreditCard);
        }

        [TestMethod]
        [ExpectedException(typeof(ExceptionCreditCardHasInvalidNotesLength))]
        public void ModifyNotesOfCreditCardToAnInvalidOne()
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

            string aNote = "";

            for (int i = 0; i <= 251; i++)
            {
                aNote += "a";
            }

            CreditCard newCreditCard = new CreditCard()
            {
                Number = "1234567891234567",
                Type = "Visa",
                Name = "Visa Gold",
                Code = "234",
                Notes = aNote,
                ExpirationDate = new DateTime(2023, 12, 25),
                Category = aCategory,
            };

            _ = aCategory.ModifyCreditCard(aCreditCard, newCreditCard);
        }

        [TestMethod]
        public void ModifyCategoryOfCreditCard()
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

            Category otherCategory = new Category()
            {
                User = aUser,
                Name = "otherCategory"
            };

            CreditCard newCreditCard = new CreditCard()
            {
                Number = "1234567891234567",
                Type = "Visa",
                Name = "Visa Gold",
                Code = "234",
                Notes = "",
                ExpirationDate = new DateTime(2023, 12, 25),
                Category = otherCategory,
            };

            Assert.IsTrue(aCategory.ModifyCreditCard(aCreditCard, newCreditCard));
        }

        [TestMethod]
        [ExpectedException(typeof(ExceptionCreditCardNumberAlreadyExistsInUser))]
        public void ModifyNumberOfCreditCardToAnExistingOneInUser()
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

            CreditCard anotherCreditCard = new CreditCard()
            {
                Number = "1124567891234567",
                Type = "Visa",
                Name = "Visa Gold",
                Code = "234",
                Notes = "",
                ExpirationDate = new DateTime(2023, 12, 25),
                Category = aCategory,
            };

            aCategory.AddCreditCard(anotherCreditCard);

            CreditCard newCreditCard = new CreditCard()
            {
                Number = "1124567891234567",
                Type = "Visa",
                Name = "Visa Gold",
                Code = "234",
                Notes = "",
                ExpirationDate = new DateTime(2023, 12, 25),
                Category = aCategory,
            };

            _ = aCategory.ModifyCreditCard(aCreditCard, newCreditCard);
        }

        [TestMethod]
        public void ModifyNumberOfCreditCardToAValidOne()
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

            CreditCard newCreditCard = new CreditCard()
            {
                Number = "1234567891234111",
                Type = "Visa",
                Name = "Visa Gold",
                Code = "234",
                Notes = "",
                ExpirationDate = new DateTime(2023, 12, 25),
                Category = aCategory,
            };

            Assert.IsTrue(aCategory.ModifyCreditCard(aCreditCard, newCreditCard));
        }

        [TestMethod]
        public void ModifyTypeOfCreditCardToAValidOne()
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

            CreditCard newCreditCard = new CreditCard()
            {
                Number = "1234567891234567",
                Type = "Itau",
                Name = "Visa Gold",
                Code = "234",
                Notes = "",
                ExpirationDate = new DateTime(2023, 12, 25),
                Category = aCategory,
            };

            Assert.IsTrue(aCategory.ModifyCreditCard(aCreditCard, newCreditCard));
        }


        [TestMethod]
        public void ModifyNameOfCreditCardToAValidOne()
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

            CreditCard newCreditCard = new CreditCard()
            {
                Number = "1234567891234567",
                Type = "Visa",
                Name = "Visa Black",
                Code = "234",
                Notes = "",
                ExpirationDate = new DateTime(2023, 12, 25),
                Category = aCategory,
            };

            Assert.IsTrue(aCategory.ModifyCreditCard(aCreditCard, newCreditCard));
        }

        [TestMethod]
        public void ModifyNotesOfCreditCardToAValidOne()
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

            CreditCard newCreditCard = new CreditCard()
            {
                Number = "1234567891234567",
                Type = "Visa",
                Name = "Visa Gold",
                Code = "234",
                Notes = "aNote",
                ExpirationDate = new DateTime(2023, 12, 25),
                Category = aCategory,
            };

            Assert.IsTrue(aCategory.ModifyCreditCard(aCreditCard, newCreditCard));
        }

        [TestMethod]
        [ExpectedException(typeof(ExceptionCreditCardDoesNotContainOnlyDigits))]
        public void ModifyNumberOfCreditCardToOneWithNonNumericCharacters()
        {
            CreditCard aCreditCard = new CreditCard()
            {
                Number = "1234567hj1234567",
                Type = "Visa",
                Name = "Visa Gold",
                Code = "234",
                Notes = "",
                ExpirationDate = new DateTime(2023, 12, 25),
                Category = aCategory,
            };

            aCategory.AddCreditCard(aCreditCard);

            CreditCard newCreditCard = new CreditCard()
            {
                Number = "1234567891234567",
                Type = "Visa",
                Name = "Visa Gold",
                Code = "234",
                Notes = "aNote",
                ExpirationDate = new DateTime(2023, 12, 25),
                Category = aCategory,
            };

            _ = aCategory.ModifyCreditCard(aCreditCard, newCreditCard);
        }

        [TestMethod]
        public void AddValidRedUserPasswordPair()
        {
            UserPasswordPair aUserPasswordPair = new UserPasswordPair()
            {
                Password = "myPass",
                Notes = "these are my notes",
                Username = "myUserName",
                Site = "mySite",
                Category = aCategory,
            };

            Assert.IsTrue(aCategory.AddUserPasswordPair(aUserPasswordPair));
            Assert.AreEqual(1, aCategory.User.GetRedUserPasswordPairs().Length);
        }

        [TestMethod]
        public void AddValidOrangeUserPasswordPair()
        {
            UserPasswordPair aUserPasswordPair = new UserPasswordPair()
            {
                Password = "myPassword",
                Notes = "these are my notes",
                Username = "myUserName",
                Site = "mySite",
                Category = aCategory,
            };

            Assert.IsTrue(aCategory.AddUserPasswordPair(aUserPasswordPair));
            Assert.AreEqual(1, aCategory.User.GetOrangeUserPasswordPairs().Length);
        }

        [TestMethod]
        public void AddValidYellowUserPasswordPair()
        {
            UserPasswordPair aUserPasswordPair = new UserPasswordPair()
            {
                Password = "MYPASSWORD12345",
                Notes = "these are my notes",
                Username = "myUserName",
                Site = "mySite",
                Category = aCategory,
            };

            Assert.IsTrue(aCategory.AddUserPasswordPair(aUserPasswordPair));
            Assert.AreEqual(1, aCategory.User.GetYellowUserPasswordPairs().Length);
        }

        [TestMethod]
        public void AddValidLightGreenUserPasswordPair()
        {
            UserPasswordPair aUserPasswordPair = new UserPasswordPair()
            {
                Password = "MYpassword1234512",
                Notes = "these are my notes",
                Username = "myUserName",
                Site = "mySite",
                Category = aCategory,
            };

            Assert.IsTrue(aCategory.AddUserPasswordPair(aUserPasswordPair));
            Assert.AreEqual(1, aCategory.User.GetLightGreenUserPasswordPairs().Length);
        }

        [TestMethod]
        public void AddValidDarkGreenUserPasswordPair()
        {
            UserPasswordPair aUserPasswordPair = new UserPasswordPair()
            {
                Password = "MYpassword@#12345",
                Notes = "these are my notes",
                Username = "myUserName",
                Site = "mySite",
                Category = aCategory,
            };

            Assert.IsTrue(aCategory.AddUserPasswordPair(aUserPasswordPair));
            Assert.AreEqual(1, aCategory.User.GetDarkGreenUserPasswordPairs().Length);
        }

        [TestMethod]
        public void AddUserPasswordPairToSameSiteButDifferentUsername()
        {
            UserPasswordPair aUserPasswordPair = new UserPasswordPair()
            {
                Password = "thisIsAPassword",
                Notes = "these are my notes",
                Username = "myUserName1",
                Site = "mySite1",
                Category = aCategory,
            };

            aCategory.AddUserPasswordPair(aUserPasswordPair);

            UserPasswordPair anotherUserPasswordPair = new UserPasswordPair()
            {
                Password = "thisIsAPassword",
                Notes = "these are my notes",
                Username = "myUserName2",
                Site = "mySite1",
                Category = aCategory,
            };

            Assert.IsTrue(aCategory.AddUserPasswordPair(anotherUserPasswordPair));
        }

        [TestMethod]
        [ExpectedException(typeof(ExceptionExistingUserPasswordPair))]
        public void AddExistingdUserPasswordPair()
        {
            UserPasswordPair aUserPasswordPair = new UserPasswordPair()
            {
                Password = "thisIsAPassword",
                Notes = "these are my notes",
                Username = "myUserName",
                Site = "mySite",
                Category = aCategory,
            };

            _ = aCategory.AddUserPasswordPair(aUserPasswordPair);

            UserPasswordPair anotherUserPasswordPair = new UserPasswordPair()
            {
                Password = "myPassword",
                Notes = "Heello notes",
                Username = "myUserName",
                Site = "mySite",
                Category = aCategory,
            };

            aCategory.AddUserPasswordPair(anotherUserPasswordPair);
        }

        [TestMethod]
        [ExpectedException(typeof(ExceptionUserPasswordPairHasInvalidUsernameLength))]
        public void AddUserPasswordPairWithUsernameLengthLessThan5()
        {
            UserPasswordPair aUserPasswordPair = new UserPasswordPair()
            {
                Password = "thisIsAPassword",
                Notes = "these are my notes",
                Username = "bad",
                Site = "mySite",
                Category = aCategory,
            };

            aCategory.AddUserPasswordPair(aUserPasswordPair);
        }

        [TestMethod]
        [ExpectedException(typeof(ExceptionUserPasswordPairHasInvalidUsernameLength))]
        public void AddUserPasswordPairWithUsernameLengthGreaterThan25()
        {
            UserPasswordPair aUserPasswordPair = new UserPasswordPair()
            {
                Password = "thisIsAPassword",
                Notes = "these are my notes",
                Username = "myUsernameHasInvalidLength",
                Site = "mySite",
                Category = aCategory,
            };

            aCategory.AddUserPasswordPair(aUserPasswordPair);
        }

        [TestMethod]
        [ExpectedException(typeof(ExceptionUserPasswordPairHasInvalidPasswordLength))]
        public void AddUserPasswordPairWithPasswordLengthLessThan5()
        {
            UserPasswordPair aUserPasswordPair = new UserPasswordPair()
            {
                Password = "pass",
                Notes = "these are my notes",
                Username = "myUsername",
                Site = "mySite",
                Category = aCategory,
            };

            aCategory.AddUserPasswordPair(aUserPasswordPair);
        }

        [TestMethod]
        [ExpectedException(typeof(ExceptionUserPasswordPairHasInvalidPasswordLength))]
        public void AddUserPasswordPairWithPasswordLengthGreaterThan25()
        {
            UserPasswordPair aUserPasswordPair = new UserPasswordPair()
            {
                Password = "passwordHasInvalidLengthAndMustntBeUsed",
                Notes = "these are my notes",
                Username = "myUsername",
                Site = "mySite",
                Category = aCategory,
            };

            aCategory.AddUserPasswordPair(aUserPasswordPair);
        }

        [TestMethod]
        [ExpectedException(typeof(ExceptionUserPasswordPairHasInvalidSiteLength))]
        public void AddUserPasswordPairWithSiteLengthLessThan3()
        {
            UserPasswordPair aUserPasswordPair = new UserPasswordPair()
            {
                Password = "password",
                Notes = "these are my notes",
                Username = "myUsername",
                Site = "no",
                Category = aCategory,
            };

            aCategory.AddUserPasswordPair(aUserPasswordPair);
        }

        [TestMethod]
        [ExpectedException(typeof(ExceptionUserPasswordPairHasInvalidSiteLength))]
        public void AddUserPasswordPairWithSiteLengthGreaterThan25()
        {
            UserPasswordPair aUserPasswordPair = new UserPasswordPair()
            {
                Password = "password",
                Notes = "these are my notes",
                Username = "myUsername",
                Site = "This site has an invalid length, so it mustnt be used",
                Category = aCategory,
            };

            aCategory.AddUserPasswordPair(aUserPasswordPair);
        }

        [TestMethod]
        [ExpectedException(typeof(ExceptionUserPasswordPairHasInvalidNotesLength))]
        public void AddUserPasswordPairWithNotesLengthGreaterThan250()
        {
            string aNote = "";

            for (int i = 0; i <= 251; i++)
            {
                aNote += "a";
            }

            UserPasswordPair aUserPasswordPair = new UserPasswordPair()
            {
                Password = "password",
                Notes = aNote,
                Username = "myUsername",
                Site = "mySite",
                Category = aCategory,
            };

            aCategory.AddUserPasswordPair(aUserPasswordPair);
        }

        [TestMethod]
        public void ModifyPasswordOfUserPasswordPairToAValidOneAndNotChangingCategory()
        {
            UserPasswordPair aUserPasswordPair = new UserPasswordPair()
            {
                Password = "password",
                Notes = "myNotes",
                Username = "myUsername",
                Site = "mySite",
                Category = aCategory,
            };

            aCategory.AddUserPasswordPair(aUserPasswordPair);

            UserPasswordPair newUserPasswordPair = new UserPasswordPair()
            {
                Password = "newPassword",
                Notes = "myNotes",
                Username = "myUsername",
                Site = "mySite",
                Category = aCategory,
            };

            Assert.IsTrue(aCategory.ModifyUserPasswordPair(aUserPasswordPair, newUserPasswordPair));
        }

        [TestMethod]
        public void ModifyPasswordOfUserPasswordPairToAValidOneAndChangingCategory()
        {
            UserPasswordPair aUserPasswordPair = new UserPasswordPair()
            {
                Password = "password",
                Notes = "myNotes",
                Username = "myUsername",
                Site = "mySite",
                Category = aCategory,
            };

            aCategory.AddUserPasswordPair(aUserPasswordPair);

            Category otherCategory = new Category()
            {
                User = aUser,
                Name = "otherCategory"
            };

            aUser.AddCategory(otherCategory);

            UserPasswordPair newUserPasswordPair = new UserPasswordPair()
            {
                Password = "newPassword",
                Notes = "myNotes",
                Username = "myUsername",
                Site = "mySite",
                Category = otherCategory,
            };

            Assert.IsTrue(aCategory.ModifyUserPasswordPair(aUserPasswordPair, newUserPasswordPair));
        }

        [TestMethod]
        public void ModifyRedUserPasswordPairToAnOrangeOne()
        {
            UserPasswordPair aUserPasswordPair = new UserPasswordPair()
            {
                Password = "myPass",
                Notes = "myNotes",
                Username = "myUsername",
                Site = "mySite",
                Category = aCategory,
            };

            aCategory.AddUserPasswordPair(aUserPasswordPair);

            UserPasswordPair newUserPasswordPair = new UserPasswordPair()
            {
                Password = "newPassword",
                Notes = "myNotes",
                Username = "myUsername",
                Site = "mySite",
                Category = aCategory,
            };

            Assert.IsTrue(aCategory.ModifyUserPasswordPair(aUserPasswordPair, newUserPasswordPair));
            Assert.AreEqual(0, aCategory.User.GetRedUserPasswordPairs().Length);
            Assert.AreEqual(1, aCategory.User.GetOrangeUserPasswordPairs().Length);
        }

        [TestMethod]
        public void ModifyRedUserPasswordPairToAYellowOne()
        {
            UserPasswordPair aUserPasswordPair = new UserPasswordPair()
            {
                Password = "myPass",
                Notes = "myNotes",
                Username = "myUsername",
                Site = "mySite",
                Category = aCategory,
            };

            aCategory.AddUserPasswordPair(aUserPasswordPair);

            UserPasswordPair newUserPasswordPair = new UserPasswordPair()
            {
                Password = "newpassword1234",
                Notes = "myNotes",
                Username = "myUsername",
                Site = "mySite",
                Category = aCategory,
            };

            Assert.IsTrue(aCategory.ModifyUserPasswordPair(aUserPasswordPair, newUserPasswordPair));
            Assert.AreEqual(0, aCategory.User.GetRedUserPasswordPairs().Length);
            Assert.AreEqual(1, aCategory.User.GetYellowUserPasswordPairs().Length);
        }

        [TestMethod]
        public void ModifyRedUserPasswordPairToALightGreenOne()
        {
            UserPasswordPair aUserPasswordPair = new UserPasswordPair()
            {
                Password = "myPass",
                Notes = "myNotes",
                Username = "myUsername",
                Site = "mySite",
                Category = aCategory,
            };

            aCategory.AddUserPasswordPair(aUserPasswordPair);

            UserPasswordPair newUserPasswordPair = new UserPasswordPair()
            {
                Password = "newPassword12345",
                Notes = "myNotes",
                Username = "myUsername",
                Site = "mySite",
                Category = aCategory,
            };

            Assert.IsTrue(aCategory.ModifyUserPasswordPair(aUserPasswordPair, newUserPasswordPair));
            Assert.AreEqual(0, aCategory.User.GetRedUserPasswordPairs().Length);
            Assert.AreEqual(1, aCategory.User.GetLightGreenUserPasswordPairs().Length);
        }

        [TestMethod]
        public void ModifyRedUserPasswordPairToADarkGreenOne()
        {
            UserPasswordPair aUserPasswordPair = new UserPasswordPair()
            {
                Password = "myPass",
                Notes = "myNotes",
                Username = "myUsername",
                Site = "mySite",
                Category = aCategory,
            };

            aCategory.AddUserPasswordPair(aUserPasswordPair);

            UserPasswordPair newUserPasswordPair = new UserPasswordPair()
            {
                Password = "newPassword@!12345",
                Notes = "myNotes",
                Username = "myUsername",
                Site = "mySite",
                Category = aCategory,
            };

            Assert.IsTrue(aCategory.ModifyUserPasswordPair(aUserPasswordPair, newUserPasswordPair));
            Assert.AreEqual(0, aCategory.User.GetRedUserPasswordPairs().Length);
            Assert.AreEqual(1, aCategory.User.GetDarkGreenUserPasswordPairs().Length);
        }

        [TestMethod]
        public void ModifyOrangeUserPasswordPairToARedOne()
        {
            UserPasswordPair aUserPasswordPair = new UserPasswordPair()
            {
                Password = "myPassword",
                Notes = "myNotes",
                Username = "myUsername",
                Site = "mySite",
                Category = aCategory,
            };

            aCategory.AddUserPasswordPair(aUserPasswordPair);

            UserPasswordPair newUserPasswordPair = new UserPasswordPair()
            {
                Password = "myPass",
                Notes = "myNotes",
                Username = "myUsername",
                Site = "mySite",
                Category = aCategory,
            };

            Assert.IsTrue(aCategory.ModifyUserPasswordPair(aUserPasswordPair, newUserPasswordPair));
            Assert.AreEqual(0, aCategory.User.GetOrangeUserPasswordPairs().Length);
            Assert.AreEqual(1, aCategory.User.GetRedUserPasswordPairs().Length);
        }

        [TestMethod]
        public void ModifyOrangeUserPasswordPairToAYellowOne()
        {
            UserPasswordPair aUserPasswordPair = new UserPasswordPair()
            {
                Password = "myPassword",
                Notes = "myNotes",
                Username = "myUsername",
                Site = "mySite",
                Category = aCategory,
            };

            aCategory.AddUserPasswordPair(aUserPasswordPair);

            UserPasswordPair newUserPasswordPair = new UserPasswordPair()
            {
                Password = "mypassword123456",
                Notes = "myNotes",
                Username = "myUsername",
                Site = "mySite",
                Category = aCategory,
            };

            Assert.IsTrue(aCategory.ModifyUserPasswordPair(aUserPasswordPair, newUserPasswordPair));
            Assert.AreEqual(0, aCategory.User.GetOrangeUserPasswordPairs().Length);
            Assert.AreEqual(1, aCategory.User.GetYellowUserPasswordPairs().Length);
        }

        [TestMethod]
        public void ModifyOrangeUserPasswordPairToALightGreenOne()
        {
            UserPasswordPair aUserPasswordPair = new UserPasswordPair()
            {
                Password = "myPassword",
                Notes = "myNotes",
                Username = "myUsername",
                Site = "mySite",
                Category = aCategory,
            };

            aCategory.AddUserPasswordPair(aUserPasswordPair);

            UserPasswordPair newUserPasswordPair = new UserPasswordPair()
            {
                Password = "myPassword!@#$!@&^",
                Notes = "myNotes",
                Username = "myUsername",
                Site = "mySite",
                Category = aCategory,
            };

            Assert.IsTrue(aCategory.ModifyUserPasswordPair(aUserPasswordPair, newUserPasswordPair));
            Assert.AreEqual(0, aCategory.User.GetOrangeUserPasswordPairs().Length);
            Assert.AreEqual(1, aCategory.User.GetLightGreenUserPasswordPairs().Length);
        }

        [TestMethod]
        public void ModifyOrangeUserPasswordPairToADarkGreenOne()
        {
            UserPasswordPair aUserPasswordPair = new UserPasswordPair()
            {
                Password = "myPassword",
                Notes = "myNotes",
                Username = "myUsername",
                Site = "mySite",
                Category = aCategory,
            };

            aCategory.AddUserPasswordPair(aUserPasswordPair);

            UserPasswordPair newUserPasswordPair = new UserPasswordPair()
            {
                Password = "myPassword!@#$34@&^",
                Notes = "myNotes",
                Username = "myUsername",
                Site = "mySite",
                Category = aCategory,
            };

            Assert.IsTrue(aCategory.ModifyUserPasswordPair(aUserPasswordPair, newUserPasswordPair));
            Assert.AreEqual(0, aCategory.User.GetOrangeUserPasswordPairs().Length);
            Assert.AreEqual(1, aCategory.User.GetDarkGreenUserPasswordPairs().Length);
        }

        [TestMethod]
        public void ModifyYellowUserPasswordPairToARedOne()
        {
            UserPasswordPair aUserPasswordPair = new UserPasswordPair()
            {
                Password = "password1234567",
                Notes = "myNotes",
                Username = "myUsername",
                Site = "mySite",
                Category = aCategory,
            };

            aCategory.AddUserPasswordPair(aUserPasswordPair);

            UserPasswordPair newUserPasswordPair = new UserPasswordPair()
            {
                Password = "myPass",
                Notes = "myNotes",
                Username = "myUsername",
                Site = "mySite",
                Category = aCategory,
            };

            Assert.IsTrue(aCategory.ModifyUserPasswordPair(aUserPasswordPair, newUserPasswordPair));
            Assert.AreEqual(0, aCategory.User.GetYellowUserPasswordPairs().Length);
            Assert.AreEqual(1, aCategory.User.GetRedUserPasswordPairs().Length);
        }

        [TestMethod]
        public void ModifyYellowUserPasswordPairToAOrangeOne()
        {
            UserPasswordPair aUserPasswordPair = new UserPasswordPair()
            {
                Password = "password1234567",
                Notes = "myNotes",
                Username = "myUsername",
                Site = "mySite",
                Category = aCategory,
            };

            aCategory.AddUserPasswordPair(aUserPasswordPair);

            UserPasswordPair newUserPasswordPair = new UserPasswordPair()
            {
                Password = "myPassword12",
                Notes = "myNotes",
                Username = "myUsername",
                Site = "mySite",
                Category = aCategory,
            };

            Assert.IsTrue(aCategory.ModifyUserPasswordPair(aUserPasswordPair, newUserPasswordPair));
            Assert.AreEqual(0, aCategory.User.GetYellowUserPasswordPairs().Length);
            Assert.AreEqual(1, aCategory.User.GetOrangeUserPasswordPairs().Length);
        }

        [TestMethod]
        public void ModifyYellowUserPasswordPairToALightGreenOne()
        {
            UserPasswordPair aUserPasswordPair = new UserPasswordPair()
            {
                Password = "password1234567",
                Notes = "myNotes",
                Username = "myUsername",
                Site = "mySite",
                Category = aCategory,
            };

            aCategory.AddUserPasswordPair(aUserPasswordPair);

            UserPasswordPair newUserPasswordPair = new UserPasswordPair()
            {
                Password = "myPassword12345",
                Notes = "myNotes",
                Username = "myUsername",
                Site = "mySite",
                Category = aCategory,
            };

            Assert.IsTrue(aCategory.ModifyUserPasswordPair(aUserPasswordPair, newUserPasswordPair));
            Assert.AreEqual(0, aCategory.User.GetYellowUserPasswordPairs().Length);
            Assert.AreEqual(1, aCategory.User.GetLightGreenUserPasswordPairs().Length);
        }

        [TestMethod]
        public void ModifyYellowUserPasswordPairToADarkGreenOne()
        {
            UserPasswordPair aUserPasswordPair = new UserPasswordPair()
            {
                Password = "password1234567",
                Notes = "myNotes",
                Username = "myUsername",
                Site = "mySite",
                Category = aCategory,
            };

            aCategory.AddUserPasswordPair(aUserPasswordPair);

            UserPasswordPair newUserPasswordPair = new UserPasswordPair()
            {
                Password = "myPassword12345!@$",
                Notes = "myNotes",
                Username = "myUsername",
                Site = "mySite",
                Category = aCategory,
            };

            Assert.IsTrue(aCategory.ModifyUserPasswordPair(aUserPasswordPair, newUserPasswordPair));
            Assert.AreEqual(0, aCategory.User.GetYellowUserPasswordPairs().Length);
            Assert.AreEqual(1, aCategory.User.GetDarkGreenUserPasswordPairs().Length);
        }

        [TestMethod]
        public void ModifyLightGreenUserPasswordPairToARedOne()
        {
            UserPasswordPair aUserPasswordPair = new UserPasswordPair()
            {
                Password = "myPassword12345",
                Notes = "myNotes",
                Username = "myUsername",
                Site = "mySite",
                Category = aCategory,
            };

            aCategory.AddUserPasswordPair(aUserPasswordPair);

            UserPasswordPair newUserPasswordPair = new UserPasswordPair()
            {
                Password = "myPass",
                Notes = "myNotes",
                Username = "myUsername",
                Site = "mySite",
                Category = aCategory,
            };

            Assert.IsTrue(aCategory.ModifyUserPasswordPair(aUserPasswordPair, newUserPasswordPair));
            Assert.AreEqual(0, aCategory.User.GetLightGreenUserPasswordPairs().Length);
            Assert.AreEqual(1, aCategory.User.GetRedUserPasswordPairs().Length);
        }

        [TestMethod]
        public void ModifyLightGreenUserPasswordPairToAnOrangeOne()
        {
            UserPasswordPair aUserPasswordPair = new UserPasswordPair()
            {
                Password = "myPassword12345",
                Notes = "myNotes",
                Username = "myUsername",
                Site = "mySite",
                Category = aCategory,
            };

            aCategory.AddUserPasswordPair(aUserPasswordPair);

            UserPasswordPair newUserPasswordPair = new UserPasswordPair()
            {
                Password = "myPassword",
                Notes = "myNotes",
                Username = "myUsername",
                Site = "mySite",
                Category = aCategory,
            };

            Assert.IsTrue(aCategory.ModifyUserPasswordPair(aUserPasswordPair, newUserPasswordPair));
            Assert.AreEqual(0, aCategory.User.GetLightGreenUserPasswordPairs().Length);
            Assert.AreEqual(1, aCategory.User.GetOrangeUserPasswordPairs().Length);
        }

        [TestMethod]
        public void ModifyLightGreenUserPasswordPairToAYellowOne()
        {
            UserPasswordPair aUserPasswordPair = new UserPasswordPair()
            {
                Password = "myPassword12345",
                Notes = "myNotes",
                Username = "myUsername",
                Site = "mySite",
                Category = aCategory,
            };

            aCategory.AddUserPasswordPair(aUserPasswordPair);

            UserPasswordPair newUserPasswordPair = new UserPasswordPair()
            {
                Password = "mypassword12345",
                Notes = "myNotes",
                Username = "myUsername",
                Site = "mySite",
                Category = aCategory,
            };

            Assert.IsTrue(aCategory.ModifyUserPasswordPair(aUserPasswordPair, newUserPasswordPair));
            Assert.AreEqual(0, aCategory.User.GetLightGreenUserPasswordPairs().Length);
            Assert.AreEqual(1, aCategory.User.GetYellowUserPasswordPairs().Length);
        }

        [TestMethod]
        public void ModifyLightGreenUserPasswordPairToADarkGreenOne()
        {
            UserPasswordPair aUserPasswordPair = new UserPasswordPair()
            {
                Password = "myPassword12345",
                Notes = "myNotes",
                Username = "myUsername",
                Site = "mySite",
                Category = aCategory,
            };

            aCategory.AddUserPasswordPair(aUserPasswordPair);

            UserPasswordPair newUserPasswordPair = new UserPasswordPair()
            {
                Password = "myPassword12345#$%",
                Notes = "myNotes",
                Username = "myUsername",
                Site = "mySite",
                Category = aCategory,
            };

            Assert.IsTrue(aCategory.ModifyUserPasswordPair(aUserPasswordPair, newUserPasswordPair));
            Assert.AreEqual(0, aCategory.User.GetLightGreenUserPasswordPairs().Length);
            Assert.AreEqual(1, aCategory.User.GetDarkGreenUserPasswordPairs().Length);
        }

        [TestMethod]
        public void ModifyDarkGreenUserPasswordPairToARedOne()
        {
            UserPasswordPair aUserPasswordPair = new UserPasswordPair()
            {
                Password = "myPassword12345#$%",
                Notes = "myNotes",
                Username = "myUsername",
                Site = "mySite",
                Category = aCategory,
            };

            aCategory.AddUserPasswordPair(aUserPasswordPair);

            UserPasswordPair newUserPasswordPair = new UserPasswordPair()
            {
                Password = "myPass",
                Notes = "myNotes",
                Username = "myUsername",
                Site = "mySite",
                Category = aCategory,
            };

            Assert.IsTrue(aCategory.ModifyUserPasswordPair(aUserPasswordPair, newUserPasswordPair));
            Assert.AreEqual(0, aCategory.User.GetDarkGreenUserPasswordPairs().Length);
            Assert.AreEqual(1, aCategory.User.GetRedUserPasswordPairs().Length);
        }

        [TestMethod]
        public void ModifyDarkGreenUserPasswordPairToAnOrangeOne()
        {
            UserPasswordPair aUserPasswordPair = new UserPasswordPair()
            {
                Password = "myPassword12345#$%",
                Notes = "myNotes",
                Username = "myUsername",
                Site = "mySite",
                Category = aCategory,
            };

            aCategory.AddUserPasswordPair(aUserPasswordPair);

            UserPasswordPair newUserPasswordPair = new UserPasswordPair()
            {
                Password = "myPassword",
                Notes = "myNotes",
                Username = "myUsername",
                Site = "mySite",
                Category = aCategory,
            };

            Assert.IsTrue(aCategory.ModifyUserPasswordPair(aUserPasswordPair, newUserPasswordPair));
            Assert.AreEqual(0, aCategory.User.GetDarkGreenUserPasswordPairs().Length);
            Assert.AreEqual(1, aCategory.User.GetOrangeUserPasswordPairs().Length);
        }


        [TestMethod]
        public void ModifyDarkGreenUserPasswordPairToAYellowOne()
        {
            UserPasswordPair aUserPasswordPair = new UserPasswordPair()
            {
                Password = "myPassword12345#$%",
                Notes = "myNotes",
                Username = "myUsername",
                Site = "mySite",
                Category = aCategory,
            };

            aCategory.AddUserPasswordPair(aUserPasswordPair);

            UserPasswordPair newUserPasswordPair = new UserPasswordPair()
            {
                Password = "mypassword12345",
                Notes = "myNotes",
                Username = "myUsername",
                Site = "mySite",
                Category = aCategory,
            };

            Assert.IsTrue(aCategory.ModifyUserPasswordPair(aUserPasswordPair, newUserPasswordPair));
            Assert.AreEqual(0, aCategory.User.GetDarkGreenUserPasswordPairs().Length);
            Assert.AreEqual(1, aCategory.User.GetYellowUserPasswordPairs().Length);
        }

        [TestMethod]
        public void ModifyDarkGreenUserPasswordPairToALightGreenOne()
        {
            UserPasswordPair aUserPasswordPair = new UserPasswordPair()
            {
                Password = "myPassword12345#$%",
                Notes = "myNotes",
                Username = "myUsername",
                Site = "mySite",
                Category = aCategory,
            };

            aCategory.AddUserPasswordPair(aUserPasswordPair);

            UserPasswordPair newUserPasswordPair = new UserPasswordPair()
            {
                Password = "myPassword12345",
                Notes = "myNotes",
                Username = "myUsername",
                Site = "mySite",
                Category = aCategory,
            };

            Assert.IsTrue(aCategory.ModifyUserPasswordPair(aUserPasswordPair, newUserPasswordPair));
            Assert.AreEqual(0, aCategory.User.GetDarkGreenUserPasswordPairs().Length);
            Assert.AreEqual(1, aCategory.User.GetLightGreenUserPasswordPairs().Length);
        }

        [TestMethod]
        public void ModifyCategoryOfUserPasswordPairToAValidOneAndNotChangingPassword()
        {
            UserPasswordPair aUserPasswordPair = new UserPasswordPair()
            {
                Password = "password",
                Notes = "myNotes",
                Username = "myUsername",
                Site = "mySite",
                Category = aCategory,
            };

            aCategory.AddUserPasswordPair(aUserPasswordPair);

            Category otherCategory = new Category()
            {
                User = aUser,
                Name = "otherCategory"
            };

            aUser.AddCategory(otherCategory);

            UserPasswordPair newUserPasswordPair = new UserPasswordPair()
            {
                Password = "password",
                Notes = "myNotes",
                Username = "myUsername",
                Site = "mySite",
                Category = otherCategory,
            };

            Assert.IsTrue(aCategory.ModifyUserPasswordPair(aUserPasswordPair, newUserPasswordPair));
        }

        [TestMethod]
        [ExpectedException(typeof(ExceptionUserPasswordPairHasInvalidPasswordLength))]
        public void ModifyPasswordOfUserPasswordPairToAnInvalidOne()
        {
            UserPasswordPair aUserPasswordPair = new UserPasswordPair()
            {
                Password = "password",
                Notes = "myNotes",
                Username = "myUsername",
                Site = "mySite",
                Category = aCategory,
            };

            aCategory.AddUserPasswordPair(aUserPasswordPair);

            UserPasswordPair newUserPasswordPair = new UserPasswordPair()
            {
                Password = "no",
                Notes = "myNotes",
                Username = "myUsername",
                Site = "mySite",
                Category = aCategory,
            };

            _ = aCategory.ModifyUserPasswordPair(aUserPasswordPair, newUserPasswordPair);
        }

        [TestMethod]
        public void ModifyUsernameOfUserPasswordPairToAValidOne()
        {
            UserPasswordPair aUserPasswordPair = new UserPasswordPair()
            {
                Password = "password",
                Notes = "myNotes",
                Username = "myUsername",
                Site = "mySite",
                Category = aCategory,
            };

            aCategory.AddUserPasswordPair(aUserPasswordPair);

            UserPasswordPair newUserPasswordPair = new UserPasswordPair()
            {
                Password = "password",
                Notes = "myNotes",
                Username = "newUsername",
                Site = "mySite",
                Category = aCategory,
            };

            Assert.IsTrue(aCategory.ModifyUserPasswordPair(aUserPasswordPair, newUserPasswordPair));
        }

        [TestMethod]
        [ExpectedException(typeof(ExceptionUserPasswordPairHasInvalidUsernameLength))]
        public void ModifyUsernameOfUserPasswordPairToAnInvalidOne()
        {
            UserPasswordPair aUserPasswordPair = new UserPasswordPair()
            {
                Password = "password",
                Notes = "myNotes",
                Username = "myUsername",
                Site = "mySite",
                Category = aCategory,
            };

            aCategory.AddUserPasswordPair(aUserPasswordPair);

            UserPasswordPair newUserPasswordPair = new UserPasswordPair()
            {
                Password = "password",
                Notes = "myNotes",
                Username = "no",
                Site = "mySite",
                Category = aCategory,
            };

            _ = aCategory.ModifyUserPasswordPair(aUserPasswordPair, newUserPasswordPair);
        }

        [TestMethod]
        public void ModifySiteOfUserPasswordPairToAValidOne()
        {
            UserPasswordPair aUserPasswordPair = new UserPasswordPair()
            {
                Password = "password",
                Notes = "myNotes",
                Username = "myUsername",
                Site = "mySite",
                Category = aCategory,
            };

            aCategory.AddUserPasswordPair(aUserPasswordPair);

            UserPasswordPair newUserPasswordPair = new UserPasswordPair()
            {
                Password = "password",
                Notes = "myNotes",
                Username = "myUsername",
                Site = "newSite",
                Category = aCategory,
            };

            Assert.IsTrue(aCategory.ModifyUserPasswordPair(aUserPasswordPair, newUserPasswordPair));
        }

        [TestMethod]
        [ExpectedException(typeof(ExceptionUserPasswordPairHasInvalidSiteLength))]
        public void ModifySiteOfUserPasswordPairToAnInvalidOne()
        {
            UserPasswordPair aUserPasswordPair = new UserPasswordPair()
            {
                Password = "password",
                Notes = "myNotes",
                Username = "myUsername",
                Site = "mySite",
                Category = aCategory,
            };

            aCategory.AddUserPasswordPair(aUserPasswordPair);

            UserPasswordPair newUserPasswordPair = new UserPasswordPair()
            {
                Password = "password",
                Notes = "myNotes",
                Username = "myUsername",
                Site = "n",
                Category = aCategory,
            };

            _ = aCategory.ModifyUserPasswordPair(aUserPasswordPair, newUserPasswordPair);
        }

        [TestMethod]
        public void ModifyNotesOfUserPasswordPairToAValidOne()
        {
            UserPasswordPair aUserPasswordPair = new UserPasswordPair()
            {
                Password = "password",
                Notes = "myNotes",
                Username = "myUsername",
                Site = "mySite",
                Category = aCategory,
            };

            aCategory.AddUserPasswordPair(aUserPasswordPair);

            UserPasswordPair newUserPasswordPair = new UserPasswordPair()
            {
                Password = "password",
                Notes = "newNotes",
                Username = "myUsername",
                Site = "mySite",
                Category = aCategory,
            };

            Assert.IsTrue(aCategory.ModifyUserPasswordPair(aUserPasswordPair, newUserPasswordPair));
        }

        [TestMethod]
        [ExpectedException(typeof(ExceptionUserPasswordPairHasInvalidNotesLength))]
        public void ModifyNotesOfUserPasswordPairToAnInvalidOne()
        {
            UserPasswordPair aUserPasswordPair = new UserPasswordPair()
            {
                Password = "password",
                Notes = "myNotes",
                Username = "myUsername",
                Site = "mySite",
                Category = aCategory,
            };

            aCategory.AddUserPasswordPair(aUserPasswordPair);

            string aNote = "";

            for (int i = 0; i <= 251; i++)
            {
                aNote += "a";
            }

            UserPasswordPair newUserPasswordPair = new UserPasswordPair()
            {
                Password = "password",
                Notes = aNote,
                Username = "myUsername",
                Site = "mySite",
                Category = aCategory,
            };

            _ = aCategory.ModifyUserPasswordPair(aUserPasswordPair, newUserPasswordPair);
        }

        [TestMethod]
        public void RemoveCreditCardNormally()
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
            Assert.IsTrue(aCategory.RemoveCreditCard(aCreditCard.Number));

            Assert.IsFalse(aUser.CreditCardNumberExists(aCreditCard.Number));
        }

        [TestMethod]
        [ExpectedException(typeof(ExceptionCreditCardDoesNotExist))]
        public void RemoveCreditCardThatDoesNotExist()
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
            aCategory.RemoveCreditCard(aCreditCard.Number);
        }

        [TestMethod]
        public void RemoveExistingUserPasswordPair()
        {
            UserPasswordPair aUserPasswordPair = new UserPasswordPair()
            {
                Password = "thisIsAPassword",
                Notes = "these are my notes",
                Username = "myUserName",
                Site = "mySite",
                Category = aCategory,
            };

            aCategory.AddUserPasswordPair(aUserPasswordPair);

            Assert.IsTrue(aCategory.RemoveUserPasswordPair(aUserPasswordPair));
            Assert.IsFalse(aCategory.UserPasswordPairAlredyExistsInCategory(aUserPasswordPair.Username, aUserPasswordPair.Site));
        }

        [TestMethod]
        [ExpectedException(typeof(ExceptionUserPasswordPairDoesNotExist))]
        public void RemoveUserPasswordPairThatDoesNotExist()
        {
            UserPasswordPair aUserPasswordPair = new UserPasswordPair()
            {
                Password = "thisIsAPassword",
                Notes = "these are my notes",
                Username = "myUserName",
                Site = "mySite",
                Category = aCategory,
            };

            aCategory.RemoveUserPasswordPair(aUserPasswordPair);
        }
    }
}
