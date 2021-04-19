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
            tarjetaCredito = new TarjetaCredito();
        }   
        
        [TestMethod]
        public void AgregarTarjetaCreditoValida()
        {
            tarjetaCredito.numero = "1234567891234567";
            tarjetaCredito.tipo = "Visa";
            tarjetaCredito.nombre = "Visa Gold";
            Assert.IsTrue(unaCategoria.AgregarTarjetaCredito(tarjetaCredito));
        }

        [TestMethod]
        public void NumeroTarjetaCreditoContieneMenosDe16Digitos()
        {
            tarjetaCredito.numero = "12345678912";
            tarjetaCredito.tipo = "Visa";
            tarjetaCredito.nombre = "Visa Gold";
            Assert.IsFalse(unaCategoria.AgregarTarjetaCredito(tarjetaCredito));
        }

        [TestMethod]
        public void NumeroTarjetaCreditoNoContieneSoloDigitos()
        {
            tarjetaCredito.numero = "1234567891fjk567";
            tarjetaCredito.tipo = "Visa";
            tarjetaCredito.nombre = "Visa Gold";
            Assert.IsFalse(unaCategoria.AgregarTarjetaCredito(tarjetaCredito));
        }

        [TestMethod]
        public void TipoTarjetaCreditoConLargoMenorA3Caracteres()
        {
            tarjetaCredito.numero = "1234567891234567";
            tarjetaCredito.tipo = "Vi";
            tarjetaCredito.nombre = "Visa Gold";
            Assert.IsFalse(unaCategoria.AgregarTarjetaCredito(tarjetaCredito));
        }

        [TestMethod]
        public void TipoTarjetaCreditoConLargoMayorA25Caracteres()
        {
            tarjetaCredito.numero = "1234567891234567";
            tarjetaCredito.tipo = "VisaVisaVisaVisaVisaVisaVisa";
            tarjetaCredito.nombre = "Visa Gold";
            Assert.IsFalse(unaCategoria.AgregarTarjetaCredito(tarjetaCredito));
        }
        
        [TestMethod]
        public void NombreTarjetaCreditoConLargoMenorA3Caracteres()
        {
            tarjetaCredito.numero = "1234567891234567";
            tarjetaCredito.tipo = "Visa";
            tarjetaCredito.nombre = "Vi";
            Assert.IsFalse(unaCategoria.AgregarTarjetaCredito(tarjetaCredito));
        }

        [TestMethod]
        public void NombreTarjetaCreditoConLargoMayorA25Caracteres()
        {
            tarjetaCredito.numero = "1234567891234567";
            tarjetaCredito.tipo = "Visa";
            tarjetaCredito.nombre = "Visa Gold Visa Gold Visa Gold Visa Gold";
            Assert.IsFalse(unaCategoria.AgregarTarjetaCredito(tarjetaCredito));
        }

        [TestMethod]
        public void CodigoTarjetaConLargoMenorA3Caracteres()
        {
            tarjetaCredito.numero = "1234567891234567";
            tarjetaCredito.tipo = "Visa";
            tarjetaCredito.nombre = "Visa Gold";
            tarjetaCredito.codigo = "12";
            Assert.IsFalse(unaCategoria.AgregarTarjetaCredito(tarjetaCredito));
        }
    }
}
