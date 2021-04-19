using Microsoft.VisualStudio.TestTools.UnitTesting;
using GestorPasswordsDominio;
using System;

namespace GestorPasswordsTest
{
    [TestClass]
    public class CategoriaTest
    {
        private Categoria unaCategoria;
        private TarjetaCredito tarjetaCredito;

        [TestInitialize]
        public void Initialize()
        {
            unaCategoria = new Categoria();
            tarjetaCredito = new TarjetaCredito()
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
            Assert.IsTrue(unaCategoria.AgregarTarjetaCredito(tarjetaCredito));
        }

        [TestMethod]
        public void NumeroTarjetaCreditoContieneMenosDe16Digitos()
        {
            tarjetaCredito.numero = "12345678912";
            Assert.IsFalse(unaCategoria.AgregarTarjetaCredito(tarjetaCredito));
        }

        [TestMethod]
        public void NumeroTarjetaCreditoNoContieneSoloDigitos()
        {
            tarjetaCredito.numero = "1234567891fjk567";
            Assert.IsFalse(unaCategoria.AgregarTarjetaCredito(tarjetaCredito));
        }

        [TestMethod]
        public void TipoTarjetaCreditoConLargoMenorA3Caracteres()
        {
            tarjetaCredito.tipo = "Vi";
            Assert.IsFalse(unaCategoria.AgregarTarjetaCredito(tarjetaCredito));
        }

        [TestMethod]
        public void TipoTarjetaCreditoConLargoMayorA25Caracteres()
        {
            tarjetaCredito.tipo = "VisaVisaVisaVisaVisaVisaVisa";
            Assert.IsFalse(unaCategoria.AgregarTarjetaCredito(tarjetaCredito));
        }
        
        [TestMethod]
        public void NombreTarjetaCreditoConLargoMenorA3Caracteres()
        {
            tarjetaCredito.nombre = "Vi";
            Assert.IsFalse(unaCategoria.AgregarTarjetaCredito(tarjetaCredito));
        }

        [TestMethod]
        public void NombreTarjetaCreditoConLargoMayorA25Caracteres()
        {
            tarjetaCredito.nombre = "Visa Gold Visa Gold Visa Gold Visa Gold";
            Assert.IsFalse(unaCategoria.AgregarTarjetaCredito(tarjetaCredito));
        }

        [TestMethod]
        public void CodigoTarjetaCreditoConLargoMenorA3Caracteres()
        {
            tarjetaCredito.codigo = "12";
            Assert.IsFalse(unaCategoria.AgregarTarjetaCredito(tarjetaCredito));
        }

        [TestMethod]
        public void CodigoTarjetaCreditoConLargoMayorA4Caracteres()
        {
            tarjetaCredito.codigo = "12121";
            Assert.IsFalse(unaCategoria.AgregarTarjetaCredito(tarjetaCredito));
        }


    }
}
