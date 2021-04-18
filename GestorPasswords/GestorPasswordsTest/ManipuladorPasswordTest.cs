﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
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

        [TestMethod]
        public void PasswordConLargoEntre8Y14Caracteres()
        {
            Assert.AreEqual(TipoFortaleza.Naranja, ManipuladorPassword.FortalezaDePassword("holamundoesto"));
        }

        [TestMethod]
        public void PasswordConLargoMayorA14CaracteresSoloMinusculas()
        {
            Assert.AreEqual(TipoFortaleza.Amarillo, ManipuladorPassword.FortalezaDePassword("holamundoestoesunapass"));
        }

        [TestMethod]
        public void PasswordConLargoMayorA14CaracteresSoloMayusculas()
        {
            Assert.AreEqual(TipoFortaleza.Amarillo, ManipuladorPassword.FortalezaDePassword("holamundoestoesnapass"));
        }
    }
}
