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
        Usuario unUsuario = new Usuario();

        [TestInitialize]
        public void Initialize()
        {
            aCategory = new Categoria()
            {
                usuario = unUsuario
            };
            unaTarjetaCredito = new TarjetaCredito()
            {
                numero = "1234567891234567",
                tipo = "Visa",
                nombre = "Visa Gold",
                codigo = "234",
                notas = ""
            };
            unUsuario.listaCategorias.Add(aCategory);
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

        // -------------------------------------------------
        // Test para agregar parUsuarioContrasena

        [TestMethod]
        public void AddValidUserPasswordPair()
        {
            UserPasswordPair aUserPasswordPair = new UserPasswordPair();
            Assert.IsTrue(aCategory.AddUserPasswordPair(aUserPasswordPair));
        }

    }
}
