﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using DataManagerDomain;

namespace DataManagerTest
{
    [TestClass]
    public class GetPasswordsOfCertainColorTest
    {
        private NormalCategory aCategory;
        private User aUser;

        [TestInitialize]
        public void Initialize()
        {
            aUser = new User();
            aCategory = new NormalCategory()
            {
                User = aUser,
                Name = "Category"
            };
            aUser.AddCategory(aCategory);
            GenerateAndAddUserPassPairsOfDiferentColors();
        }

        private void GenerateAndAddUserPassPairsOfDiferentColors()
        {
            UserPasswordPair aUserPasswordPair1 = new UserPasswordPair()
            {
                Password = "MYPASSWORD12345",
                Notes = "these are my notes",
                Username = "myUserName1",
                Site = "mySite",
                Category = aCategory,
            };
            UserPasswordPair aUserPasswordPair2 = new UserPasswordPair()
            {
                Password = "myPass",
                Notes = "these are my notes",
                Username = "myUserName2",
                Site = "mySite",
                Category = aCategory,
            };
            UserPasswordPair aUserPasswordPair3 = new UserPasswordPair()
            {
                Password = "myPassword",
                Notes = "these are my notes",
                Username = "myUserName3",
                Site = "mySite",
                Category = aCategory,
            };
            UserPasswordPair aUserPasswordPair4 = new UserPasswordPair()
            {
                Password = "MYpassword1234512",
                Notes = "these are my notes",
                Username = "myUserName4",
                Site = "mySite",
                Category = aCategory,
            };
            UserPasswordPair aUserPasswordPair5 = new UserPasswordPair()
            {
                Password = "MYpassword@#12345",
                Notes = "these are my notes",
                Username = "myUserName5",
                Site = "mySite",
                Category = aCategory,
            };
            aCategory.AddUserPasswordPair(aUserPasswordPair1);
            aCategory.AddUserPasswordPair(aUserPasswordPair2);
            aCategory.AddUserPasswordPair(aUserPasswordPair3);
            aCategory.AddUserPasswordPair(aUserPasswordPair4);
            aCategory.AddUserPasswordPair(aUserPasswordPair5);
        }

        [TestMethod]
        public void GetRedPasswords()
        {
            Assert.AreEqual(1, aUser.GetUserPasswordPairsOfASpecificColor(PasswordStrengthType.Red).Length);
            Assert.AreEqual(aUser.FindUserPasswordPair("myusername2", "mysite"), aUser.GetUserPasswordPairsOfASpecificColor(PasswordStrengthType.Red)[0]);
        }

        [TestMethod]
        public void GetYellowPasswords()
        {
            Assert.AreEqual(1, aUser.GetUserPasswordPairsOfASpecificColor(PasswordStrengthType.Yellow).Length);
            Assert.AreEqual(aUser.FindUserPasswordPair("myusername1", "mysite"), aUser.GetUserPasswordPairsOfASpecificColor(PasswordStrengthType.Yellow)[0]);
        }

        [TestMethod]
        public void GetOrangePasswords()
        {
            Assert.AreEqual(1, aUser.GetUserPasswordPairsOfASpecificColor(PasswordStrengthType.Orange).Length);
            Assert.AreEqual(aUser.FindUserPasswordPair("myusername3", "mysite"), aUser.GetUserPasswordPairsOfASpecificColor(PasswordStrengthType.Orange)[0]);
        }

        [TestMethod]
        public void GetLightGreenPasswords()
        {
            Assert.AreEqual(1, aUser.GetUserPasswordPairsOfASpecificColor(PasswordStrengthType.LightGreen).Length);
            Assert.AreEqual(aUser.FindUserPasswordPair("myusername4", "mysite"), aUser.GetUserPasswordPairsOfASpecificColor(PasswordStrengthType.LightGreen)[0]);
        }

        [TestMethod]
        public void GetDarkGreenPasswords()
        {
            Assert.AreEqual(1, aUser.GetUserPasswordPairsOfASpecificColor(PasswordStrengthType.DarkGreen).Length);
            Assert.AreEqual(aUser.FindUserPasswordPair("myusername5", "mysite"), aUser.GetUserPasswordPairsOfASpecificColor(PasswordStrengthType.DarkGreen)[0]);
        }
    }
}