using Microsoft.VisualStudio.TestTools.UnitTesting;
using GestorPasswordsDominio;
using System;

namespace GestorPasswordsTest
{
    [TestClass]
    public class ManipuladorPasswordTest
    {
        [TestMethod]
        public void EsPasswordDebil()
        {
            Assert.AreEqual(TipoFortaleza.Rojo, ManipuladorPassword.FortalezaDePassword("hola"));
        }
    }
}
