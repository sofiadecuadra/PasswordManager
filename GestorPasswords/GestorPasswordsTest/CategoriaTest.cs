using Microsoft.VisualStudio.TestTools.UnitTesting;
using GestorPasswordsDominio;
using System;

namespace GestorPasswordsTest
{
    [TestClass]
    public class CategoriaTest
    {
        private Categoria unaCategoria;
        private TarjetaCredito unaTarjetaCredito;

        [TestInitialize]
        public void Initialize()
        {
            unaCategoria = new Categoria();
            unaTarjetaCredito = new TarjetaCredito()
            {
                numero = "1234567891234567",
                tipo = "Visa",
                nombre = "Visa Gold",
                codigo = "234",
            };
        }   
        
        [TestMethod]
        public void AgregarTarjetaCreditoValida()
        {
            Assert.IsTrue(unaCategoria.AgregarTarjetaCredito(unaTarjetaCredito));
        }

        [TestMethod]
        public void NumeroTarjetaCreditoContieneMenosDe16Digitos()
        {
            unaTarjetaCredito.numero = "12345678912";
            Assert.IsFalse(unaCategoria.AgregarTarjetaCredito(unaTarjetaCredito));
        }

        [TestMethod]
        public void NumeroTarjetaCreditoNoContieneSoloDigitos()
        {
            unaTarjetaCredito.numero = "1234567891fjk567";
            Assert.IsFalse(unaCategoria.AgregarTarjetaCredito(unaTarjetaCredito));
        }

        [TestMethod]
        public void TipoTarjetaCreditoConLargoMenorA3Caracteres()
        {
            unaTarjetaCredito.tipo = "Vi";
            Assert.IsFalse(unaCategoria.AgregarTarjetaCredito(unaTarjetaCredito));
        }

        [TestMethod]
        public void TipoTarjetaCreditoConLargoMayorA25Caracteres()
        {
            unaTarjetaCredito.tipo = "VisaVisaVisaVisaVisaVisaVisa";
            Assert.IsFalse(unaCategoria.AgregarTarjetaCredito(unaTarjetaCredito));
        }
        
        [TestMethod]
        public void NombreTarjetaCreditoConLargoMenorA3Caracteres()
        {
            unaTarjetaCredito.nombre = "Vi";
            Assert.IsFalse(unaCategoria.AgregarTarjetaCredito(unaTarjetaCredito));
        }

        [TestMethod]
        public void NombreTarjetaCreditoConLargoMayorA25Caracteres()
        {
            unaTarjetaCredito.nombre = "Visa Gold Visa Gold Visa Gold Visa Gold";
            Assert.IsFalse(unaCategoria.AgregarTarjetaCredito(unaTarjetaCredito));
        }

        [TestMethod]
        public void CodigoTarjetaCreditoConLargoMenorA3Caracteres()
        {
            unaTarjetaCredito.codigo = "12";
            Assert.IsFalse(unaCategoria.AgregarTarjetaCredito(unaTarjetaCredito));
        }

        [TestMethod]
        public void CodigoTarjetaCreditoConLargoMayorA4Caracteres()
        {
            unaTarjetaCredito.codigo = "12121";
            Assert.IsFalse(unaCategoria.AgregarTarjetaCredito(unaTarjetaCredito));
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
            Assert.IsFalse(unaCategoria.AgregarTarjetaCredito(unaTarjetaCredito));
        }
    }
}
