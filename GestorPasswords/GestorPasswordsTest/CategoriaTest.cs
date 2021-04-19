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
            };
            Assert.IsTrue(unaCategoria.AgregarTarjetaCredito(tarjetaCredito));
        }

        [TestMethod]
        public void NumeroTarjetaCreditoContieneMenosDe16Digitos()
        {
            Categoria unaCategoria = new Categoria();
            TarjetaCredito tarjetaCredito = new TarjetaCredito()
            {
                numero = "12345678912"
            };
            Assert.IsFalse(unaCategoria.AgregarTarjetaCredito(tarjetaCredito));
        }

        [TestMethod]
        public void NumeroTarjetaCreditoNoContieneSoloDigitos()
        {
            Categoria unaCategoria = new Categoria();
            TarjetaCredito tarjetaCredito = new TarjetaCredito()
            {
                numero = "12345678912hgjfl"
            };
            Assert.IsFalse(unaCategoria.AgregarTarjetaCredito(tarjetaCredito));
        }

    }
}
