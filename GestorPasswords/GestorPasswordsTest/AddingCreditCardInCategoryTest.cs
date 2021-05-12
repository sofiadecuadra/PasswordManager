using Microsoft.VisualStudio.TestTools.UnitTesting;
using GestorPasswordsDominio;
using System;

namespace GestorPasswordsTest
{
    [TestClass]
    public class AddingCreditCardInCategoryTest
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
        [ExpectedException(typeof(ExceptionIncorrectLength))]
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
        [ExpectedException(typeof(ExceptionIncorrectLength))]
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
        [ExpectedException(typeof(ExceptionIncorrectLength))]
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
        [ExpectedException(typeof(ExceptionIncorrectLength))]
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
        [ExpectedException(typeof(ExceptionIncorrectLength))]
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
            Assert.AreEqual(1, aCategory.GetCreditCards().Length);
        }

        [TestMethod]
        [ExpectedException(typeof(ExceptionIncorrectLength))]
        public void AddCreditCardWithNumberLengthDifferentThan16()
        {
            CreditCard aCreditCard = new CreditCard()
            {
                Number = "12345678912345",
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
        [ExpectedException(typeof(ExceptionIncorrectLength))]
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
        [ExpectedException(typeof(ExceptionIncorrectLength))]
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
        [ExpectedException(typeof(ExceptionCreditCardHasExpired))]
        public void AddExpiredCreditCard()
        {
            CreditCard aCreditCard = new CreditCard()
            {
                Number = "1234567891234567",
                Type = "Visa",
                Name = "Visa Gold",
                Code = "234",
                Notes = "",
                ExpirationDate = new DateTime(2020, 12, 25),
                Category = aCategory,
            };
            aCategory.AddCreditCard(aCreditCard);
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
            Assert.AreEqual(1, aCategory.GetCreditCards().Length);
        }
    }
}