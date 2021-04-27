using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using GestorPasswordsDominio;

namespace GestorPasswordsTest
{
    [TestClass]
    public class SystemTest
    {
        [TestMethod]
        public void AddValidUserToSystem()
        {
            PasswordManager _PasswordManager= new PasswordManager();
            User myUser = new User() { 
                MasterPassword = "myMasterPassword123$",
                Name = "Juan"
            };
            Assert.IsTrue(_PasswordManager.AddUser(myUser));
            Assert.IsTrue(_PasswordManager.HasUser(myUser.Name));
        }
    }
}
