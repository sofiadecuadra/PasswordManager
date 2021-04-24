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
                ExpirationDate = new DateTime(2023, 12, 25)
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
                ExpirationDate = new DateTime(2023, 12, 25)
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
                ExpirationDate = new DateTime(2023, 12, 25)
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
                ExpirationDate = new DateTime(2023, 12, 25)
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
                ExpirationDate = new DateTime(2023, 12, 25)
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
                ExpirationDate = new DateTime(2023, 12, 25)
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
                ExpirationDate = new DateTime(2023, 12, 25)
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
                ExpirationDate = new DateTime(2023, 12, 25)
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
                ExpirationDate = new DateTime(2023, 12, 25)
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
                ExpirationDate = new DateTime(2023, 12, 25)
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
                ExpirationDate = new DateTime(2023, 12, 25)
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
                ExpirationDate = new DateTime(2023, 12, 25)
            };
            CreditCard anotherCreditCard = new CreditCard()
            {
                Number = "1234567891234567",
                Type = "Visa",
                Name = "Visa Gold",
                Code = "234",
                Notes = "",
                ExpirationDate = new DateTime(2023, 12, 25)
            };
            aCategory.AddCreditCard(aCreditCard);
            aCategory.AddCreditCard(anotherCreditCard);
        }

        [TestMethod]
        public void AddValidUserPasswordPair()
        {
            UserPasswordPair aUserPasswordPair = new UserPasswordPair()
            {
                Password = "thisIsAPassword",
                Notes = "these are my notes",
                Username = "myUserName",
                Site = "mySite",
            };

            Assert.IsTrue(aCategory.AddUserPasswordPair(aUserPasswordPair));
        }

        [TestMethod]
        public void AddUserPasswordPairToSameSiteButDifferentUsername()
        {
            UserPasswordPair aUserPasswordPair = new UserPasswordPair()
            {
                Password = "thisIsAPassword",
                Notes = "these are my notes",
                Username = "myUserName1",
                Site = "mySite1"
            };

            aCategory.AddUserPasswordPair(aUserPasswordPair);

            UserPasswordPair anotherUserPasswordPair = new UserPasswordPair()
            {
                Password = "thisIsAPassword",
                Notes = "these are my notes",
                Username = "myUserName2",
                Site = "mySite1"
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
                Site = "mySite"
            };

            _ = aCategory.AddUserPasswordPair(aUserPasswordPair);

            UserPasswordPair anotherUserPasswordPair = new UserPasswordPair()
            {
                Password = "myPassword",
                Notes = "Heello notes",
                Username = "myUserName",
                Site = "mySite"
            };

            aCategory.AddUserPasswordPair(anotherUserPasswordPair);
        }

        [TestMethod]
        [ExpectedException(typeof(ExceptionUserPasswordPairHasInvalidUsernameLength))]
        public void AdddUserPasswordPairWithUsernameLengthLessThan5()
        {
            UserPasswordPair aUserPasswordPair = new UserPasswordPair()
            {
                Password = "thisIsAPassword",
                Notes = "these are my notes",
                Username = "bad",
                Site = "mySite"
            };

            aCategory.AddUserPasswordPair(aUserPasswordPair);
        }

        [TestMethod]
        [ExpectedException(typeof(ExceptionUserPasswordPairHasInvalidUsernameLength))]
        public void AdddUserPasswordPairWithUsernameLengthGreaterThan25()
        {
            UserPasswordPair aUserPasswordPair = new UserPasswordPair()
            {
                Password = "thisIsAPassword",
                Notes = "these are my notes",
                Username = "myUsernameHasInvalidLength",
                Site = "mySite"
            };

            aCategory.AddUserPasswordPair(aUserPasswordPair);
        }

        [TestMethod]
        [ExpectedException(typeof(ExceptionUserPasswordPairHasInvalidPasswordLength))]
        public void AdddUserPasswordPairWithPasswordLengthLessThan5()
        {
            UserPasswordPair aUserPasswordPair = new UserPasswordPair()
            {
                Password = "pass",
                Notes = "these are my notes",
                Username = "myUsername",
                Site = "mySite"
            };

            aCategory.AddUserPasswordPair(aUserPasswordPair);
        }

        [TestMethod]
        [ExpectedException(typeof(ExceptionUserPasswordPairHasInvalidPasswordLength))]
        public void AdddUserPasswordPairWithPasswordLengthGreaterThan25()
        {
            UserPasswordPair aUserPasswordPair = new UserPasswordPair()
            {
                Password = "passwordHasInvalidLengthAndMustntBeUsed",
                Notes = "these are my notes",
                Username = "myUsername",
                Site = "mySite"
            };

            aCategory.AddUserPasswordPair(aUserPasswordPair);
        }

        [TestMethod]
        [ExpectedException(typeof(ExceptionUserPasswordPairHasInvalidSiteLength))]
        public void AdddUserPasswordPairWithSiteLengthLessThan3()
        {
            UserPasswordPair aUserPasswordPair = new UserPasswordPair()
            {
                Password = "password",
                Notes = "these are my notes",
                Username = "myUsername",
                Site = "no"
            };

            aCategory.AddUserPasswordPair(aUserPasswordPair);
        }

        [TestMethod]
        [ExpectedException(typeof(ExceptionUserPasswordPairHasInvalidSiteLength))]
        public void AdddUserPasswordPairWithSiteLengthGreaterThan25()
        {
            UserPasswordPair aUserPasswordPair = new UserPasswordPair()
            {
                Password = "password",
                Notes = "these are my notes",
                Username = "myUsername",
                Site = "This site has an invalid length, so it mustnt be used"
            };

            aCategory.AddUserPasswordPair(aUserPasswordPair);
        }

        [TestMethod]
        [ExpectedException(typeof(ExceptionUserPasswordPairHasInvalidNotesLength))]
        public void AdddUserPasswordPairWithNotesLengthGreaterThan250()
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
            };

            aCategory.AddUserPasswordPair(aUserPasswordPair);
        }
    }
}
