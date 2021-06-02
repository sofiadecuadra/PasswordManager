using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace DataManagerDomain
{
    public class User
    {
        private string masterPassword;
        public string MasterPassword
        {
            get { return masterPassword; }
            set
            {
                masterPassword = ValidMasterPassword(value);
            }
        }
        private string name;
        public string Name
        {
            get { return name; }
            set { name = ValidUserName(value.Trim()); }
        }
        private SpecialCategory sharedPasswords;
        private SortedList<string, NormalCategory> categories;
        private List<UserPasswordPair> redUserPasswordPairs;
        private List<UserPasswordPair> orangeUserPasswordPairs;
        private List<UserPasswordPair> yellowUserPasswordPairs;
        private List<UserPasswordPair> lightGreenUserPasswordPairs;
        private List<UserPasswordPair> darkGreenUserPasswordPairs;
        public List <DataBreach> DataBreaches { get; private set; }

        public User()
        {
            categories = new SortedList<string, NormalCategory>();
            redUserPasswordPairs = new List<UserPasswordPair>();
            orangeUserPasswordPairs = new List<UserPasswordPair>();
            yellowUserPasswordPairs = new List<UserPasswordPair>();
            lightGreenUserPasswordPairs = new List<UserPasswordPair>();
            darkGreenUserPasswordPairs = new List<UserPasswordPair>();
            DataBreaches = new List<DataBreach>();
            sharedPasswords = new SpecialCategory()
            {
                User = this,
            };
        }

        private static string ValidMasterPassword(string password)
        {
            if (!IsBetween5And25Characters(password))
            {
                string errorMessage = $"The password should be between 5 and 25 characters but is: {password.Length} charachterslong";
                throw new ExceptionIncorrectLength(errorMessage);
            }
            return password;
        }

        private static bool IsBetween5And25Characters(string value)
        {
            return value.Length >= 5 && value.Length <= 25;
        }

        private static string ValidUserName(string value)
        {
            CheckUsernameLength(value);
            CheckUsernameContent(value);
            return value.ToLower();
        }

        private static void CheckUsernameLength(string value)
        {
            if (!IsBetween5And25Characters(value))
            {
                string errorMessage = $"The provided user name should be between 5 and 25 characters but is: {value.Length} charachterslong";
                throw new ExceptionIncorrectLength(errorMessage);
            }
        }

        private static void CheckUsernameContent(string value)
        {
            if (HasBlankSpace(value))
            {
                string errorMessage = $"The username must not contain any blank spaces";
                throw new ExceptionUsernameContainsSpaces(errorMessage);
            }
        }

        private static bool HasBlankSpace(string value)
        {
            return value.Contains(" ");
        }

        public Tuple<PasswordStrengthType, int>[] GetPasswordsStrengthReport()
        {
            List<Tuple<PasswordStrengthType, int>> listWithStrengthReport = new List<Tuple<PasswordStrengthType, int>>();
            AddRedPasswordsStrengthReport(listWithStrengthReport);
            AddOrangePasswordsStrengthReport(listWithStrengthReport);
            AddYellowPasswordsStrengthReport(listWithStrengthReport);
            AddLightGreenPasswordsStrengthReport(listWithStrengthReport);
            AddDarkGreenPasswordsStrengthReport(listWithStrengthReport);
            return listWithStrengthReport.ToArray();
        }

        private void AddDataBreach(DataBreach aDataBreach)
        {
            if (aDataBreach.LeakedData[0]!="")
            {
                DataBreaches.Add(aDataBreach);
            }
        }

        private void AddRedPasswordsStrengthReport(List<Tuple<PasswordStrengthType, int>> listWithStrengthReport)
        {
            listWithStrengthReport.Add(new Tuple<PasswordStrengthType, int>(PasswordStrengthType.Red, redUserPasswordPairs.Count));
        }

        private void AddOrangePasswordsStrengthReport(List<Tuple<PasswordStrengthType, int>> listWithStrengthReport)
        {
            listWithStrengthReport.Add(new Tuple<PasswordStrengthType, int>(PasswordStrengthType.Orange, orangeUserPasswordPairs.Count));
        }

        private void AddYellowPasswordsStrengthReport(List<Tuple<PasswordStrengthType, int>> listWithStrengthReport)
        {
            listWithStrengthReport.Add(new Tuple<PasswordStrengthType, int>(PasswordStrengthType.Yellow, yellowUserPasswordPairs.Count));
        }

        private void AddLightGreenPasswordsStrengthReport(List<Tuple<PasswordStrengthType, int>> listWithStrengthReport)
        {
            listWithStrengthReport.Add(new Tuple<PasswordStrengthType, int>(PasswordStrengthType.LightGreen, lightGreenUserPasswordPairs.Count));
        }

        private void AddDarkGreenPasswordsStrengthReport(List<Tuple<PasswordStrengthType, int>> listWithStrengthReport)
        {
            listWithStrengthReport.Add(new Tuple<PasswordStrengthType, int>(PasswordStrengthType.DarkGreen, darkGreenUserPasswordPairs.Count));
        }

        public UserPasswordPair[] GetUserPasswordPairsOfASpecificColor(PasswordStrengthType aColorGroup)
        {
            UserPasswordPair[] arrayToReturn = new UserPasswordPair[1];
            if (aColorGroup == PasswordStrengthType.Red)
            {
                arrayToReturn = GetRedUserPasswordPairs();
            }
            if (aColorGroup == PasswordStrengthType.Orange)
            {
                arrayToReturn = GetOrangeUserPasswordPairs();
            }
            if (aColorGroup == PasswordStrengthType.Yellow)
            {
                arrayToReturn = GetYellowUserPasswordPairs();
            }
            if (aColorGroup == PasswordStrengthType.LightGreen)
            {
                arrayToReturn = GetLightGreenUserPasswordPairs();
            }
            if (aColorGroup == PasswordStrengthType.DarkGreen)
            {
                arrayToReturn = GetDarkGreenUserPasswordPairs();
            }
            return arrayToReturn;
        }

        public UserPasswordPair[] GetRedUserPasswordPairs()
        {
            UserPasswordPair[] redUserPasswordPairsArray = new UserPasswordPair[redUserPasswordPairs.Count];
            redUserPasswordPairs.CopyTo(redUserPasswordPairsArray);
            return redUserPasswordPairsArray;
        }

        public UserPasswordPair[] GetOrangeUserPasswordPairs()
        {
            UserPasswordPair[] orangeUserPasswordPairsArray = new UserPasswordPair[orangeUserPasswordPairs.Count];
            orangeUserPasswordPairs.CopyTo(orangeUserPasswordPairsArray);
            return orangeUserPasswordPairsArray;
        }

        public UserPasswordPair[] GetYellowUserPasswordPairs()
        {
            UserPasswordPair[] yellowUserPasswordPairsArray = new UserPasswordPair[yellowUserPasswordPairs.Count];
            yellowUserPasswordPairs.CopyTo(yellowUserPasswordPairsArray);
            return yellowUserPasswordPairsArray;
        }

        public UserPasswordPair[] GetLightGreenUserPasswordPairs()
        {
            UserPasswordPair[] lightGreenUserPasswordPairsArray = new UserPasswordPair[lightGreenUserPasswordPairs.Count];
            lightGreenUserPasswordPairs.CopyTo(lightGreenUserPasswordPairsArray);
            return lightGreenUserPasswordPairsArray;
        }

        public UserPasswordPair[] GetDarkGreenUserPasswordPairs()
        {
            UserPasswordPair[] darkGreenUserPasswordPairsArray = new UserPasswordPair[darkGreenUserPasswordPairs.Count];
            darkGreenUserPasswordPairs.CopyTo(darkGreenUserPasswordPairsArray);
            return darkGreenUserPasswordPairsArray;
        }

        public void AddRedUserPasswordPair(UserPasswordPair aRedUserPasswordPair)
        {
            redUserPasswordPairs.Add(aRedUserPasswordPair);
        }

        public void AddOrangeUserPasswordPair(UserPasswordPair anOrangeUserPasswordPair)
        {
            orangeUserPasswordPairs.Add(anOrangeUserPasswordPair);
        }

        public void AddYellowUserPasswordPair(UserPasswordPair aYellowUserPasswordPair)
        {
            yellowUserPasswordPairs.Add(aYellowUserPasswordPair);
        }

        public void AddLightGreenUserPasswordPair(UserPasswordPair aLightGreenUserPasswordPair)
        {
            lightGreenUserPasswordPairs.Add(aLightGreenUserPasswordPair);
        }

        public void AddDarkGreenUserPasswordPair(UserPasswordPair aDarkGreenUserPasswordPair)
        {
            darkGreenUserPasswordPairs.Add(aDarkGreenUserPasswordPair);
        }

        public void DeleteRedUserPasswordPair(UserPasswordPair aRedUserPasswordPair)
        {
            redUserPasswordPairs.Remove(aRedUserPasswordPair);
        }

        public void DeleteOrangeUserPasswordPair(UserPasswordPair anOrangeUserPasswordPair)
        {
            orangeUserPasswordPairs.Remove(anOrangeUserPasswordPair);
        }

        public void DeleteYellowUserPasswordPair(UserPasswordPair aYellowUserPasswordPair)
        {
            yellowUserPasswordPairs.Remove(aYellowUserPasswordPair);
        }

        public void DeleteLightGreenUserPasswordPair(UserPasswordPair aYellowUserPasswordPair)
        {
            lightGreenUserPasswordPairs.Remove(aYellowUserPasswordPair);
        }

        public void DeleteDarkGreenUserPasswordPair(UserPasswordPair aDarkGreenUserPasswordPair)
        {
            darkGreenUserPasswordPairs.Remove(aDarkGreenUserPasswordPair);
        }

        public bool ChangeMasterPassword(string currentPassword, string newPassword)
        {
            if (!PasswordsMatch(currentPassword, MasterPassword))
            {
                throw new ExceptionIncorrectMasterPassword("The password entered by the user did not match the master password");
            }
            MasterPassword = newPassword;
            return true;
        }

        public bool PasswordsMatch(string currentPassword, string masterPassword)
        {
            return currentPassword == masterPassword;
        }

        public NormalCategory[] GetCategories()
        {
            IList<NormalCategory> allCategories = categories.Values;
            return allCategories.ToArray();
        }

        public bool AddCategory(NormalCategory aCategory)
        {
            bool categoryAdded = false;
            if (CategoryIsValid(aCategory.Name))
            {
                AddCategoryToCollection(aCategory);
                categoryAdded = true;
            }
            return categoryAdded;
        }

        private static bool CategoryIsValid(string categoryName)
        {
            if (!CategoryNameHasValidLength(categoryName))
            {
                throw new ExceptionIncorrectLength("The category length must be between 3 and 15, but it's current length is " + categoryName.Length);
            }
            return true;
        }

        private static bool CategoryNameHasValidLength(string categoryName)
        {
            return categoryName.Length >= 3 && categoryName.Length <= 15;
        }

        private void AddCategoryToCollection(NormalCategory aCategory)
        {
            categories.Add(aCategory.Name, aCategory);
        }

        public bool ModifyCategory(NormalCategory aCategory, string newName)
        {
            bool categoryModified = false;
            newName = newName.Trim().ToLower();
            if (CategoryCouldBeModified(aCategory, newName))
            {
                UpdateCategory(aCategory, newName);
                categoryModified = true;
            }
            return categoryModified;
        }

        private bool CategoryCouldBeModified(NormalCategory aCategory, string newName)
        {
            CheckIfOldCategoryExists(aCategory);
            bool couldBeModified = false;
            if (NewNameIsDifferentFromOldName(aCategory, newName))
            {
                CheckIfNewNameAlreadyExists(newName);
                couldBeModified = CategoryIsValid(newName);
            }
            return couldBeModified;
        }

        private void CheckIfOldCategoryExists(NormalCategory aCategory)
        {
            if (!CategoryExists(aCategory.Name))
            {
                throw new ExceptionCategoryNotExists("The category does not exist");
            }
        }

        private bool CategoryExists(string aCategoryName)
        {
            return categories.ContainsKey(aCategoryName);
        }

        private void CheckIfNewNameAlreadyExists(string newName)
        {
            if (CategoryExists(newName))
            {
                throw new ExceptionCategoryAlreadyExists("The category already exists");
            }
        }

        private static bool NewNameIsDifferentFromOldName(NormalCategory aCategory, string newName)
        {
            return aCategory.Name != newName;
        }

        private void UpdateCategory(NormalCategory aCategory, string newName)
        {
            RemoveCategoryFromCategoriesCollection(aCategory);
            aCategory.Name = newName;
            AddCategoryToCollection(aCategory);
        }

        private void RemoveCategoryFromCategoriesCollection(NormalCategory aCategory)
        {
            categories.Remove(aCategory.Name);
        }

        public CreditCard[] GetCreditCards()
        {
            List<CreditCard> allCreditCards = new List<CreditCard>();
            foreach (NormalCategory category in this.GetCategories())
            {
                allCreditCards.AddRange(category.GetCreditCards());
            }
            return allCreditCards.ToArray();
        }

        public bool CreditCardNumberExists(string creditCardNumber)
        {
            bool creditCardExists = false;
            foreach (KeyValuePair<string, NormalCategory> pair in categories)
            {
                if (CreditCardExistsInCategory(pair.Value, creditCardNumber))
                {
                    creditCardExists = true;
                }
            }
            return creditCardExists;
        }

        private static bool CreditCardExistsInCategory(NormalCategory aCategory, string creditCardNumber)
        {
            return aCategory.CreditCardNumberAlreadyExistsInCategory(creditCardNumber);
        }

        public UserPasswordPair[] GetUserPasswordPairs()
        {
            List<UserPasswordPair> allUserPasswordPairs = new List<UserPasswordPair>();
            foreach (var category in GetCategories())
            {
                allUserPasswordPairs.AddRange(category.GetUserPasswordsPairs());
            }
            return allUserPasswordPairs.ToArray();
        }

        public bool UserPasswordPairExists(string username, string site)
        {
            bool pairExists = false;
            foreach (KeyValuePair<string, NormalCategory> pair in categories)
            {
                if (UserPasswordPairExistsInCategory(pair.Value, username, site))
                {
                    pairExists = true;
                }
            }
            return pairExists;
        }

        private static bool UserPasswordPairExistsInCategory(NormalCategory aCategory, string username, string site)
        {
            return aCategory.UserPasswordPairAlredyExistsInCategory(username, site);
        }

        public UserPasswordPair[] GetSharedUserPasswordPairs()
        {
            return sharedPasswords.GetUserPasswordsPairs();
        }

        internal void AddSharedUserPasswordPair(UserPasswordPair passwordToShare)
        {
            sharedPasswords.AddUserPasswordPair(passwordToShare);
        }

        internal void UnshareUserPasswordPair(UserPasswordPair passwordToStopSharing)
        {
            sharedPasswords.RemoveUserPasswordPair(passwordToStopSharing);
        }

        public bool HasSharedPasswordOf(string username, string site)
        {
            return sharedPasswords.UserPasswordPairAlredyExistsInCategory(username, site);
        }

        public UserPasswordPair FindUserPasswordPair(string username, string site)
        {
            UserPasswordPair userPasswordPair = null;
            foreach (KeyValuePair<string, NormalCategory> pair in categories)
            {
                if (UserPasswordPairExistsInCategory(pair.Value, username, site))
                {
                    userPasswordPair = pair.Value.FindUserPasswordPair(username, site);
                    break;
                }
            }
            return userPasswordPair != null ? userPasswordPair : throw new ExceptionUserPasswordPairDoesNotExist("The User-Password Pair does not exist");
        }

        public DataBreach CheckDataBreaches(IDataBreachesFormatter dataBreachInput)
        {
            string[] leakedData = dataBreachInput.ConvertToArray();
            DataBreach dataBreach = new DataBreach()
            {
                LeakedData = leakedData
            };
            foreach (string element in leakedData)
            {
                if (ItsACreditCard(element.Trim()))
                {
                    CreditCard aLeakedCreditCardOfUser = ReturnCreditCardThatAppeardInDataBreaches(element.Trim());
                    if (aLeakedCreditCardOfUser != null && !dataBreach.LeakedCreditCardsOfUser.Contains(aLeakedCreditCardOfUser))
                    {
                        dataBreach.AddLeakedCreditCard(aLeakedCreditCardOfUser);
                    }
                }
                else
                {
                    List<UserPasswordPair> leakedPasswordsOfUser = ReturnListOfUserPasswordPairWhosePasswordAppearedInDataBreaches(element.Trim());
                    foreach (UserPasswordPair pair in leakedPasswordsOfUser)
                    {
                        if (!dataBreach.LeakedUserPasswordPairsOfUser.Contains(pair))
                        {
                            dataBreach.AddLeakedUserPasswordPair(pair);
                        }
                    }
                }
            }
            AddDataBreach(dataBreach);
            return dataBreach;
        }

        public (List <UserPasswordPair>, List<UserPasswordPair>) GetModifiedAndNotModifiedLeakedPasswords(DataBreach aDataBreach)
        {
            List<UserPasswordPair> notModifiedPasswords = new List<UserPasswordPair>();
            List<UserPasswordPair> modifiedPasswords = new List<UserPasswordPair>();
            foreach(UserPasswordPair pair in aDataBreach.LeakedUserPasswordPairsOfUser)
            {
                if (aDataBreach.PasswordWasModified(pair))
                {
                    modifiedPasswords.Add(pair);
                }
                else
                {
                    notModifiedPasswords.Add(pair);
                }
            }
            return (notModifiedPasswords, modifiedPasswords);
        }

        public void RemoveCreditCardFromDataBreaches(CreditCard aCreditCard)
        {
            foreach (DataBreach element in DataBreaches)
            {
                element.RemoveCreditCard(aCreditCard);
            }
        }

        private bool ItsACreditCard(string element)
        {
            bool itsACreditCard = true;
            string[] dataToCheck = element.Split(' ');
            if (dataToCheck.Length != 4)
            {
                itsACreditCard = false;
            }
            else
            {
                foreach (string item in dataToCheck)
                {
                    if (!ContainsOnlyDigits(item) || !LengthIsFour(item))
                    {
                        itsACreditCard = false;
                        break;
                    }
                }
            }
            return itsACreditCard;
        }

        private bool ContainsOnlyDigits(string element)
        {
            return Regex.IsMatch(element, @"^[0-9]+$");
        }

        private bool LengthIsFour(string element)
        {
            return element.Length == 4;
        }

        private CreditCard ReturnCreditCardThatAppeardInDataBreaches(string creditCardNumber)
        {
            CreditCard creditCard = null;
            foreach (KeyValuePair<string, NormalCategory> pair in categories)
            {
                string creditCardNumberWithoutBlankSpace = creditCardNumber.Replace(" ", string.Empty);
                creditCard = ReturnCreditCardInCategoryThatAppeardInDataBreaches(pair.Value, creditCardNumberWithoutBlankSpace);
                if (creditCard != null)
                {
                    break;
                }
            }
            return creditCard;
        }

        private CreditCard ReturnCreditCardInCategoryThatAppeardInDataBreaches(NormalCategory aCategory, string creditCardNumber)
        {
            return aCategory.ReturnCreditCardInCategoryThatAppearedInDataBreaches(creditCardNumber);
        }

        private List<UserPasswordPair> ReturnListOfUserPasswordPairWhosePasswordAppearedInDataBreaches(string aPassword)
        {
            List<UserPasswordPair> userPasswordPairList = new List<UserPasswordPair>();
            foreach (KeyValuePair<string, NormalCategory> pair in categories)
            {
                List<UserPasswordPair> userPasswordPairListInCategory = ReturnListOfUserPasswordPairInCategoryWhosePasswordAppearedInDataBreaches(pair.Value, aPassword);
                foreach (UserPasswordPair element in userPasswordPairListInCategory)
                {
                    userPasswordPairList.Add(element);
                }
            }
            return userPasswordPairList;
        }

        private List<UserPasswordPair> ReturnListOfUserPasswordPairInCategoryWhosePasswordAppearedInDataBreaches(NormalCategory aCategory, string aPassword)
        {
            return aCategory.ReturnListOfUserPasswordPairInCategoryWhosePasswordAppearedInDataBreaches(aPassword);
        }
    }
}
