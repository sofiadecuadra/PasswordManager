using Microsoft.VisualStudio.TestTools.UnitTesting;
using GestorPasswordsDominio;
using System;

namespace GestorPasswordsTest
{
    [TestClass]
    public class ValidityWhenModifyingCreditCardInCategoryTest
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
        [ExpectedException(typeof(ExceptionCreditCardHasExpired))]
        public void ModifyExpirationDateOfCreditCardToAnInvalidOne()
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
                ExpirationDate = new DateTime(2018, 12, 25),
                Category = aCategory,
            };

            _ = aCategory.ModifyCreditCard(aCreditCard, newCreditCard);
        }

        [TestMethod]
        public void ModifyExpirationDateOfCreditCardToAValidOne()
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
                ExpirationDate = new DateTime(2025, 12, 25),
                Category = aCategory,
            };

            Assert.IsTrue(aCategory.ModifyCreditCard(aCreditCard, newCreditCard));
        }


        [TestMethod]
        [ExpectedException(typeof(ExceptionIncorrectLength))]
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
        [ExpectedException(typeof(ExceptionIncorrectLength))]
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
        [ExpectedException(typeof(ExceptionIncorrectLength))]
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
        [ExpectedException(typeof(ExceptionIncorrectLength))]
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
        [ExpectedException(typeof(ExceptionIncorrectLength))]
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
            string aNote = GenerateNoteText();

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

        private static string GenerateNoteText()
        {
            string aNote = "";

            for (int i = 0; i <= 251; i++)
            {
                aNote += "a";
            }

            return aNote;
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
            Assert.AreEqual(0, aCategory.GetCreditCards().Length);
            Assert.AreEqual(1, otherCategory.GetCreditCards().Length);
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
    }
}
