using GestorPasswordsDominio;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace GestorPasswordsTest
{
    [TestClass]
    public class UserTest
    {
        [TestMethod]
        [ExpectedException(typeof(ExceptionIncorrectMasterPassword))]
        public void IncorrectMasterPassword()
        {
            User aUser = new User()
            {
                MasterPassword = "myPassword"
            };
            string currentPassword = "aWrongPassword";
            string newPassword = "myNewPassword";
            aUser.ChangeMasterPassword(currentPassword, newPassword);
        }
    }
}
