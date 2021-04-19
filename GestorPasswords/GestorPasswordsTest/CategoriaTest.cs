﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
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
            TarjetaCredito tarjetaCredito = new TarjetaCredito();
            Assert.IsTrue(unaCategoria.AgregarTarjetaCredito(tarjetaCredito));
        }
    }
}
