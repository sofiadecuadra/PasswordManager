using Microsoft.VisualStudio.TestTools.UnitTesting;
using GestorPasswordsDominio;
using System;

namespace GestorPasswordsTest
{
    [TestClass]
    public class CategoriaTest
    {
        [TestMethod]
        public void AgregarTarjetaCreditoValida()
        {
            Categoria unaCategoria = new Categoria();
            TarjetaCredito tarjetaCredito = new TarjetaCredito()
            {
                numero = "1234567891234567",
                tipo = "Visa"
            };
            Assert.IsTrue(unaCategoria.AgregarTarjetaCredito(tarjetaCredito));
        }

        [TestMethod]
        public void NumeroTarjetaCreditoContieneMenosDe16Digitos()
        {
            Categoria unaCategoria = new Categoria();
            TarjetaCredito tarjetaCredito = new TarjetaCredito()
            {
                numero = "12345678912",
                tipo = "Visa"
            };
            Assert.IsFalse(unaCategoria.AgregarTarjetaCredito(tarjetaCredito));
        }

        [TestMethod]
        public void NumeroTarjetaCreditoNoContieneSoloDigitos()
        {
            Categoria unaCategoria = new Categoria();
            TarjetaCredito tarjetaCredito = new TarjetaCredito()
            {
                numero = "12345678912hgjfl",
                tipo = "Visa"
            };
            Assert.IsFalse(unaCategoria.AgregarTarjetaCredito(tarjetaCredito));
        }

        [TestMethod]
        public void TipoTarjetaCreditoConLargoMenorA3()
        {
            Categoria unaCategoria = new Categoria();
            TarjetaCredito tarjetaCredito = new TarjetaCredito()
            {
                numero = "1234567891234567",
                tipo = "Vi"
            };
            Assert.IsFalse(unaCategoria.AgregarTarjetaCredito(tarjetaCredito));
        }

        [TestMethod]
        public void TipoTarjetaCreditoConLargoMayorA25()
        {
            Categoria unaCategoria = new Categoria();
            TarjetaCredito tarjetaCredito = new TarjetaCredito()
            {
                numero = "1234567891234567",
                tipo = "VisaVisaVisaVisaVisaVisaVisa"
            };
            Assert.IsFalse(unaCategoria.AgregarTarjetaCredito(tarjetaCredito));
        }
        
        [TestMethod]
        public void NombreTarjetaCreditoConLargoMenorA3()
        {
            Categoria unaCategoria = new Categoria();
            TarjetaCredito tarjetaCredito = new TarjetaCredito()
            {
                numero = "1234567891234567",
                tipo = "Visa",
                nombre = "Vi"
            };
            Assert.IsFalse(unaCategoria.AgregarTarjetaCredito(tarjetaCredito));
        }


    }
}
