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
                numero = "1234567891234567",
                tipo = "Visa",
                nombre = "Visa Gold",
                codigo = "234",
                notas = ""
            };
            aUser.listOfCategories.Add(aCategory);
        }   
        
        [TestMethod]
        public void AgregarTarjetaCreditoValida()
        {
            Assert.IsTrue(aCategory.AgregarTarjetaCredito(unaTarjetaCredito));
        }

        [TestMethod]
        public void NumeroTarjetaCreditoContieneMenosDe16Digitos()
        {
            unaTarjetaCredito.numero = "12345678912";
            Assert.IsFalse(aCategory.AgregarTarjetaCredito(unaTarjetaCredito));
        }

        [TestMethod]
        public void NumeroTarjetaCreditoNoContieneSoloDigitos()
        {
            unaTarjetaCredito.numero = "1234567891fjk567";
            Assert.IsFalse(aCategory.AgregarTarjetaCredito(unaTarjetaCredito));
        }

        [TestMethod]
        public void TipoTarjetaCreditoConLargoMenorA3Caracteres()
        {
            unaTarjetaCredito.tipo = "Vi";
            Assert.IsFalse(aCategory.AgregarTarjetaCredito(unaTarjetaCredito));
        }

        [TestMethod]
        public void TipoTarjetaCreditoConLargoMayorA25Caracteres()
        {
            unaTarjetaCredito.tipo = "VisaVisaVisaVisaVisaVisaVisa";
            Assert.IsFalse(aCategory.AgregarTarjetaCredito(unaTarjetaCredito));
        }
        
        [TestMethod]
        public void NombreTarjetaCreditoConLargoMenorA3Caracteres()
        {
            unaTarjetaCredito.nombre = "Vi";
            Assert.IsFalse(aCategory.AgregarTarjetaCredito(unaTarjetaCredito));
        }

        [TestMethod]
        public void NombreTarjetaCreditoConLargoMayorA25Caracteres()
        {
            unaTarjetaCredito.nombre = "Visa Gold Visa Gold Visa Gold Visa Gold";
            Assert.IsFalse(aCategory.AgregarTarjetaCredito(unaTarjetaCredito));
        }

        [TestMethod]
        public void CodigoTarjetaCreditoConLargoMenorA3Caracteres()
        {
            unaTarjetaCredito.codigo = "12";
            Assert.IsFalse(aCategory.AgregarTarjetaCredito(unaTarjetaCredito));
        }

        [TestMethod]
        public void CodigoTarjetaCreditoConLargoMayorA4Caracteres()
        {
            unaTarjetaCredito.codigo = "12121";
            Assert.IsFalse(aCategory.AgregarTarjetaCredito(unaTarjetaCredito));
        }


        [TestMethod]
        public void NotasTarjetaCreditoConLargoMayorA250Caracteres()
        {
            string notas = "";
            for(int i=0; i < 260; i++)
            {
                notas += "a";
            }
            unaTarjetaCredito.notas = notas;
            Assert.IsFalse(aCategory.AgregarTarjetaCredito(unaTarjetaCredito));
        }

        [TestMethod]
        public void AgregarNumeroTarjetaCreditoYaExistente()
        {
            TarjetaCredito unaTarjetaCredito2 = new TarjetaCredito()
            {
                numero = "1234567891234567",
                tipo = "Visa",
                nombre = "Visa Gold",
                codigo = "234",
                notas = ""
            };

            aCategory.AgregarTarjetaCredito(unaTarjetaCredito2);
            Assert.IsFalse(aCategory.AgregarTarjetaCredito(unaTarjetaCredito));
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
