using Microsoft.VisualStudio.TestTools.UnitTesting;
using GestorPasswordsDominio;
using System;

namespace GestorPasswordsTest
{
    [TestClass]
    public class CategoriaTest
    {
        private Categoria aCategory;
        private TarjetaCredito unaTarjetaCredito;
        Usuario aUser;

        [TestInitialize]
        public void Initialize()
        {
            aUser = new Usuario();
            aCategory = new Categoria()
            {
                User = aUser
            };
            unaTarjetaCredito = new TarjetaCredito()
            {
                number = "1234567891234567",
                type = "Visa",
                name = "Visa Gold",
                code = "234",
                notes = ""
            };
            aUser.listOfCategories.Add(aCategory);
        }   
        
        [TestMethod]
        public void AgregarTarjetaCreditoValida()
        {
            Assert.IsTrue(aCategory.AddCreditCard(unaTarjetaCredito));
        }

        [TestMethod]
        public void NumeroTarjetaCreditoContieneMenosDe16Digitos()
        {
            unaTarjetaCredito.number = "12345678912";
            Assert.IsFalse(aCategory.AddCreditCard(unaTarjetaCredito));
        }

        [TestMethod]
        public void NumeroTarjetaCreditoNoContieneSoloDigitos()
        {
            unaTarjetaCredito.number = "1234567891fjk567";
            Assert.IsFalse(aCategory.AddCreditCard(unaTarjetaCredito));
        }

        [TestMethod]
        public void TipoTarjetaCreditoConLargoMenorA3Caracteres()
        {
            unaTarjetaCredito.type = "Vi";
            Assert.IsFalse(aCategory.AddCreditCard(unaTarjetaCredito));
        }

        [TestMethod]
        public void TipoTarjetaCreditoConLargoMayorA25Caracteres()
        {
            unaTarjetaCredito.type = "VisaVisaVisaVisaVisaVisaVisa";
            Assert.IsFalse(aCategory.AddCreditCard(unaTarjetaCredito));
        }
        
        [TestMethod]
        public void NombreTarjetaCreditoConLargoMenorA3Caracteres()
        {
            unaTarjetaCredito.name = "Vi";
            Assert.IsFalse(aCategory.AddCreditCard(unaTarjetaCredito));
        }

        [TestMethod]
        public void NombreTarjetaCreditoConLargoMayorA25Caracteres()
        {
            unaTarjetaCredito.name = "Visa Gold Visa Gold Visa Gold Visa Gold";
            Assert.IsFalse(aCategory.AddCreditCard(unaTarjetaCredito));
        }

        [TestMethod]
        public void CodigoTarjetaCreditoConLargoMenorA3Caracteres()
        {
            unaTarjetaCredito.code = "12";
            Assert.IsFalse(aCategory.AddCreditCard(unaTarjetaCredito));
        }

        [TestMethod]
        public void CodigoTarjetaCreditoConLargoMayorA4Caracteres()
        {
            unaTarjetaCredito.code = "12121";
            Assert.IsFalse(aCategory.AddCreditCard(unaTarjetaCredito));
        }


        [TestMethod]
        public void NotasTarjetaCreditoConLargoMayorA250Caracteres()
        {
            string notas = "";
            for(int i=0; i < 260; i++)
            {
                notas += "a";
            }
            unaTarjetaCredito.notes = notas;
            Assert.IsFalse(aCategory.AddCreditCard(unaTarjetaCredito));
        }

        [TestMethod]
        public void AgregarNumeroTarjetaCreditoYaExistente()
        {
            TarjetaCredito unaTarjetaCredito2 = new TarjetaCredito()
            {
                number = "1234567891234567",
                type = "Visa",
                name = "Visa Gold",
                code = "234",
                notes = ""
            };

            aCategory.AddCreditCard(unaTarjetaCredito2);
            Assert.IsFalse(aCategory.AddCreditCard(unaTarjetaCredito));
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
