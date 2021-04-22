using Microsoft.VisualStudio.TestTools.UnitTesting;
using GestorPasswordsDominio;
using System;

namespace GestorPasswordsTest
{
    [TestClass]
    public class CategoriaTest
    {
        private Categoria aCategory;
        private TarjetaCredito aCreditCard;
        Usuario aUser;

        [TestInitialize]
        public void Initialize()
        {
            aUser = new Usuario();
            aCategory = new Categoria()
            {
                User = aUser
            };
            aCreditCard = new TarjetaCredito()
            {
                Number = "1234567891234567",
                Type = "Visa",
                Name = "Visa Gold",
                Code = "234",
                Notes = ""
            };
            aUser.listOfCategories.Add(aCategory);
        }   
        
        [TestMethod]
        public void AddValidCreditCard()
        {
            Assert.IsTrue(aCategory.AddCreditCard(aCreditCard));
        }

        [TestMethod]
        [ExpectedException(typeof(ExceptionCreditCardHasInvalidNumberLength))]
        public void AddCreditCardWithNumberLengthLessThan16()
        {
            aCreditCard.Number = "12345678912";
            aCategory.AddCreditCard(aCreditCard);
        }

        [TestMethod]
        [ExpectedException(typeof(ExceptionCreditCardDoesNotContainOnlyDigits))]
        public void AddCreditCardThatDoesNotContainOnlyDigits()
        {
            aCreditCard.Number = "1234567891fjk567";
            aCategory.AddCreditCard(aCreditCard);
        }

        [TestMethod]
        [ExpectedException(typeof(ExceptionCreditCardHasInvalidTypeLength))]
        public void AddCreditCardWithTypeLengthLessThan3()
        {
            aCreditCard.Type = "Vi";
            aCategory.AddCreditCard(aCreditCard);
        }

        [TestMethod]
        [ExpectedException(typeof(ExceptionCreditCardHasInvalidTypeLength))]
        public void AddCreditCardWithTypeLengthGreaterThan25()
        {
            aCreditCard.Type = "VisaVisaVisaVisaVisaVisaVisa";
            aCategory.AddCreditCard(aCreditCard);
        }
        
        [TestMethod]
        [ExpectedException(typeof(ExceptionCreditCardHasInvalidNameLength))]
        public void AddCreditCardWithNameLengthLessThan3()
        {
            aCreditCard.Name = "Vi";
            aCategory.AddCreditCard(aCreditCard);
        }

        [TestMethod]
        [ExpectedException(typeof(ExceptionCreditCardHasInvalidNameLength))]
        public void AddCreditCardWithNameLengthGreaterThan25()
        {
            aCreditCard.Name = "Visa Gold Visa Gold Visa Gold Visa Gold";
            aCategory.AddCreditCard(aCreditCard);
        }

        [TestMethod]
        [ExpectedException(typeof(ExceptionCreditCardHasInvalidCodeLength))]
        public void AddCreditCardWithCodeLengthLessThan3()
        {
            aCreditCard.Code = "12";
            aCategory.AddCreditCard(aCreditCard);
        }

        [TestMethod]
        [ExpectedException(typeof(ExceptionCreditCardHasInvalidCodeLength))]
        public void AddCreditCardWithCodeLengthGreaterThan4()
        {
            aCreditCard.Code = "12121";
            aCategory.AddCreditCard(aCreditCard);
        }


        [TestMethod]
        [ExpectedException(typeof(ExceptionCreditCardHasInvalidNotesLength))]
        public void AddCreditCardWithNotesLengthGreaterThan250()
        {
            string notas = "";
            for(int i=0; i <= 251; i++)
            {
                notas += "a";
            }
            aCreditCard.Notes = notas;
            aCategory.AddCreditCard(aCreditCard);
        }

        [TestMethod]
        [ExpectedException(typeof(ExceptionCreditCardNumberAlreadyExistsInUser))]
        public void AddExistingCreditCard()
        {
            TarjetaCredito anotherCreditCard = new TarjetaCredito()
            {
                Number = "1234567891234567",
                Type = "Visa",
                Name = "Visa Gold",
                Code = "234",
                Notes = ""
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
                Site = "mySite"
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
