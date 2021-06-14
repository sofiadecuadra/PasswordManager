using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text.RegularExpressions;

namespace DataManagerDomain
{
    public class User
    {
        private string masterPassword { get; set; }
        public string MasterPassword
        {
            //get { return DecryptMasterPassword(); }
            get; set;
            //set
            //{
            //    masterPassword = ValidateAndEncryptMasterPassword(value);
            //}
        }
        private string username { get; set; }
        public string Username
        {
            get { return username; }
            set { username = ValidUserName(value.Trim()); }
        }
        public List<UserPasswordPair> SharedPasswords { get; private set; }
        public List<Category> Categories { get; set; }
        public List<DataBreach> DataBreaches { get; private set; }
        public string PublicKey { get; private set; }
        public string PrivateKey { get; private set; }

        public User()
        {
            Categories = new List<Category>();
            DataBreaches = new List<DataBreach>();
            SharedPasswords = new List<UserPasswordPair>();
            var keys = Encrypter.GenerateKeys();
            PublicKey = keys.Item2;
            PrivateKey = keys.Item1;
        }

        private string DecryptMasterPassword()
        {
            return Encrypter.Decrypt(masterPassword, PrivateKey);
        }

        private string ValidateAndEncryptMasterPassword(string password)
        {
            if (!IsBetween5And25Characters(password))
            {
                string errorMessage = $"The password should be between 5 and 25 characters but is: {password.Length} charachterslong";
                throw new ExceptionIncorrectLength(errorMessage);
            }
            return Encrypter.Encrypt(password, PublicKey);
        }

        public override string ToString()
        {
            return Username;
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
            AddStrengthReportOfASpecificColor(listWithStrengthReport, PasswordStrengthType.Red);
            AddStrengthReportOfASpecificColor(listWithStrengthReport, PasswordStrengthType.Orange);
            AddStrengthReportOfASpecificColor(listWithStrengthReport, PasswordStrengthType.Yellow);
            AddStrengthReportOfASpecificColor(listWithStrengthReport, PasswordStrengthType.LightGreen);
            AddStrengthReportOfASpecificColor(listWithStrengthReport, PasswordStrengthType.DarkGreen);
            return listWithStrengthReport.ToArray();
        }

        private void AddStrengthReportOfASpecificColor(List<Tuple<PasswordStrengthType, int>> listWithStrengthReport, PasswordStrengthType strengthType)
        {
            using (var dbContext = new DataManagerContext())
            {
                int count = dbContext.UserPasswordPairs.Where(userPasswordPair => userPasswordPair.PasswordStrength == strengthType && userPasswordPair.Category.User.Username == Username).Count();
                listWithStrengthReport.Add(new Tuple<PasswordStrengthType, int>(strengthType, count));
            }
        }

        private void AddDataBreach(DataBreach aDataBreach)
        {
            if (aDataBreach.LeakedCreditCards.Count > 0 || aDataBreach.LeakedUserPasswordPairs.Count > 0)
            {
                using (var dbContext = new DataManagerContext())
                {
                    dbContext.DataBreaches.Add(aDataBreach);
                    dbContext.SaveChanges();
                }
            }
        }

        public UserPasswordPair[] GetUserPasswordPairsOfASpecificColor(PasswordStrengthType aColorGroup)
        {
            using (var dbContext = new DataManagerContext())
            {
                var passwords = dbContext.UserPasswordPairs
                    .Where(userPasswordPair => userPasswordPair.PasswordStrength == aColorGroup && userPasswordPair.Category.User.Username == Username)
                    .Include(userPasswordPair => userPasswordPair.Category);
                return passwords.ToArray();
            }
        }

        public bool ChangeMasterPassword(string currentPassword, string newPassword)
        {
            if (!PasswordsMatch(currentPassword, MasterPassword))
            {
                throw new ExceptionIncorrectMasterPassword("The password entered by the user did not match the master password");
            }
            using (var dbContext = new DataManagerContext())
            {
                MasterPassword = newPassword;
                dbContext.Entry(this).State = EntityState.Modified;
                dbContext.SaveChanges();
            }
            return true;
        }

        public bool PasswordsMatch(string currentPassword, string masterPassword)
        {
            return currentPassword == masterPassword;
        }

        public Category[] GetCategories()
        {
            using (var dbContext = new DataManagerContext())
            {
                var passwords = dbContext.Categories.Where(category => category.User.Username == Username).Include(category => category.User);
                return passwords.ToArray();
            }
        }

        public bool AddCategory(Category aCategory)
        {
            bool categoryAdded = false;
            if (CategoryIsValid(aCategory.Name))
            {
                AddCategoryToCollection(aCategory);
                categoryAdded = true;
            }
            return categoryAdded;
        }

        private bool CategoryIsValid(string categoryName)
        {
            if (!CategoryNameHasValidLength(categoryName))
            {
                throw new ExceptionIncorrectLength("The category length must be between 3 and 15, but it's current length is " + categoryName.Length);
            }
            if (CategoryExists(categoryName))
            {
                throw new ExceptionCategoryAlreadyExists("The category " + categoryName + " already exists");
            }
            return true;
        }

        private static bool CategoryNameHasValidLength(string categoryName)
        {
            return categoryName.Length >= 3 && categoryName.Length <= 15;
        }

        private void AddCategoryToCollection(Category aCategory)
        {
            using (var dbContext = new DataManagerContext())
            {
                dbContext.Users.Attach(aCategory.User);
                dbContext.Categories.Add(aCategory);
                dbContext.SaveChanges();
            }
        }

        public bool ModifyCategory(Category aCategory, string newName)
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

        private bool CategoryCouldBeModified(Category aCategory, string newName)
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

        private void CheckIfOldCategoryExists(Category aCategory)
        {
            if (!CategoryExists(aCategory.Name))
            {
                throw new ExceptionCategoryNotExists("The category does not exist");
            }
        }

        private bool CategoryExists(string newName)
        {
            using (var dbContext = new DataManagerContext())
            {
                Category categorySelected = dbContext.Categories
                    .Where(category => category.User.Username == Username && category.Name == newName)
                    .FirstOrDefault();
                return categorySelected != null;
            }
        }

        private void CheckIfNewNameAlreadyExists(string newName)
        {
            if (CategoryExists(newName))
            {
                throw new ExceptionCategoryAlreadyExists("The category already exists");
            }
        }

        private static bool NewNameIsDifferentFromOldName(Category aCategory, string newName)
        {
            return aCategory.Name != newName;
        }

        private void UpdateCategory(Category aCategory, string newName)
        {
            using (var dbContext = new DataManagerContext())
            {
                aCategory.Name = newName;
                dbContext.Entry(aCategory).State = EntityState.Modified;
                dbContext.SaveChanges();
            }
        }

        public CreditCard[] GetCreditCards()
        {
            using (var dbContext = new DataManagerContext())
            {
                var categories = dbContext.CreditCards.Where(creditCard => creditCard.Category.User.Username == Username)
                    .Include(creditCard => creditCard.Category)
                    .OrderBy(creditCard => creditCard.Category.Name);
                return categories.ToArray();
            }
        }

        public bool CreditCardNumberExists(string creditCardNumber)
        {
            using (var dbContext = new DataManagerContext())
            {
                var category = dbContext.CreditCards.FirstOrDefault(creditCard => creditCard.Category.User.Username == Username && creditCard.Number == creditCardNumber);
                return category != null;
            }
        }

        public UserPasswordPair[] GetUserPasswordPairs()
        {
            using (var dbContext = new DataManagerContext())
            {
                var passwords = dbContext.UserPasswordPairs.Where(password => password.Category.User.Username == Username).Include(userPasswordPair => userPasswordPair.Category).OrderBy(userPasswordPair => userPasswordPair.Category.Name);
                return passwords.ToArray();
            }
        }

        public bool UserPasswordPairExists(UserPasswordPair aUserPasswordPair)
        {
            using (var dbContext = new DataManagerContext())
            {
                var password = dbContext.UserPasswordPairs.FirstOrDefault(userPasswordPair => userPasswordPair.Category.User.Username == Username && userPasswordPair.Username == aUserPasswordPair.Username && userPasswordPair.Site == aUserPasswordPair.Site);
                return password != null;
            }
        }

        private static bool UserPasswordPairExistsInCategory(Category aCategory, UserPasswordPair aUserPasswordPair)
        {
            return aCategory.UserPasswordPairAlredyExistsInCategory(aUserPasswordPair);
        }

        public UserPasswordPair[] GetSharedUserPasswordPairs()
        {
            using (var dbContext = new DataManagerContext())
            {
                var userSelected = dbContext.Users
                    .Include(user => user.SharedPasswords).
                    FirstOrDefault(user => user.Username == Username);
                return userSelected.SharedPasswords.ToArray();
            }
        }

        internal void AddSharedUserPasswordPair(UserPasswordPair passwordToShare)
        {
            using (var dbContext = new DataManagerContext())
            {
                var userSelected = dbContext.Users
                    .Include(user => user.SharedPasswords)
                    .FirstOrDefault(user => user.Username == Username);
                userSelected.SharedPasswords.Add(passwordToShare);
                dbContext.SaveChanges();
            }
        }

        internal void UnshareUserPasswordPair(UserPasswordPair passwordToStopSharing)
        {
            using (var dbContext = new DataManagerContext())
            {
                var userSelected = dbContext.Users
                    .Include(user => user.SharedPasswords)
                    .FirstOrDefault(user => user.Username == Username);
                userSelected.SharedPasswords.Remove(passwordToStopSharing);
                //dbContext.Entry(passwordToStopSharing).State = EntityState.Deleted;
                dbContext.SaveChanges();
            }
        }

        public bool HasSharedPasswordOf(UserPasswordPair aUserPasswordPair)
        {
            using (var dbContext = new DataManagerContext())
            {
                var userSelected = dbContext.Users
                    .Include(user => user.SharedPasswords)
                    .FirstOrDefault(user => user.Username == Username);
                return userSelected.SharedPasswords
                    .Exists(password => password.Password == aUserPasswordPair.Password);
            }
        }

        public DataBreach CheckDataBreaches(IDataBreachesFormatter dataBreachInput)
        {
            string[] leakedData = dataBreachInput.ConvertToArray();
            DataBreach dataBreach = new DataBreach();
            foreach (string element in leakedData)
            {
                string dataToCheck = element.Trim();
                if (dataToCheck != "")
                {
                    if (ItsACreditCard(dataToCheck))
                    {
                        dataBreach.AddLeakedCreditCard(dataToCheck);
                        CreditCard aLeakedCreditCardOfUser = ReturnCreditCardThatAppeardInDataBreaches(dataToCheck);
                        if (aLeakedCreditCardOfUser != null && !dataBreach.LeakedCreditCardsOfUser.Contains(aLeakedCreditCardOfUser))
                        {
                            dataBreach.AddLeakedCreditCardOfUser(aLeakedCreditCardOfUser);
                        }
                    }
                    else
                    {
                        dataBreach.AddLeakedUserPasswordPair(dataToCheck);
                        List<UserPasswordPair> leakedPasswordsOfUser = ReturnListOfUserPasswordPairWhosePasswordAppearedInDataBreaches(dataToCheck);
                        foreach (UserPasswordPair pair in leakedPasswordsOfUser)
                        {
                            if (!dataBreach.LeakedUserPasswordPairsOfUser.Contains(pair))
                            {
                                dataBreach.AddLeakedUserPasswordPairOfUser(pair);
                            }
                        }
                    }
                }
            }
            AddDataBreach(dataBreach);
            return dataBreach;
        }

        public (List<UserPasswordPair>, List<UserPasswordPair>) GetModifiedAndNotModifiedLeakedPasswords(DataBreach aDataBreach)
        {
            List<UserPasswordPair> notModifiedPasswords = new List<UserPasswordPair>();
            List<UserPasswordPair> modifiedPasswords = new List<UserPasswordPair>();
            foreach (UserPasswordPair pair in aDataBreach.LeakedUserPasswordPairsOfUser)
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

        public void RemoveUserPasswordPairFromDataBreaches(UserPasswordPair aUserPasswordPair)
        {
            foreach (DataBreach element in DataBreaches)
            {
                element.RemoveUserPasswordPair(aUserPasswordPair);
            }
        }

        public Tuple<bool, bool, bool> PasswordImprovementSuggestionsAreTakenIntoAccount(string aPassword)
        {
            string passwordTrimed = aPassword.Trim();
            bool passwordIsStrong = PasswordIsStrong(passwordTrimed);
            bool passwordIsNotDuplicated = PasswordIsNotDuplicated(passwordTrimed);
            bool passwordHasNotAppearedInDataBreaches = PasswordHasNotAppearedInADataBreach(passwordTrimed);
            return new Tuple<bool, bool, bool>(passwordIsStrong, passwordIsNotDuplicated, passwordHasNotAppearedInDataBreaches);
        }

        public bool PasswordIsStrong(string aPassword)
        {
            bool passwordIsStrong = false;
            PasswordStrengthType passwordStrengthType = PasswordHandler.PasswordStrength(aPassword);
            if (passwordStrengthType.Equals(PasswordStrengthType.LightGreen))
            {
                passwordIsStrong = true;
            }
            if (passwordStrengthType.Equals(PasswordStrengthType.DarkGreen))
            {
                passwordIsStrong = true;
            }
            return passwordIsStrong;
        }

        private bool PasswordIsNotDuplicated(string aPassword)
        {
            bool passwordIsNotDuplicated = true;
            foreach (UserPasswordPair aPair in GetUserPasswordPairs())
            {
                if (aPair.Password.Equals(aPassword))
                {
                    passwordIsNotDuplicated = false;
                }
            }
            return passwordIsNotDuplicated;
        }

        private bool PasswordHasNotAppearedInADataBreach(string aPassword)
        {
            bool passwordHasNotAppearedInADataBreach = true;
            foreach (DataBreach aDataBreach in DataBreaches)
            {
                if (aDataBreach.PasswordAppearedInDataBreach(aPassword))
                {
                    passwordHasNotAppearedInADataBreach = false;
                }
            }
            return passwordHasNotAppearedInADataBreach;
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
            foreach (Category category in Categories)
            {
                string creditCardNumberWithoutBlankSpace = creditCardNumber.Replace(" ", string.Empty);
                creditCard = ReturnCreditCardInCategoryThatAppeardInDataBreaches(category, creditCardNumberWithoutBlankSpace);
                if (creditCard != null)
                {
                    break;
                }
            }
            return creditCard;
        }

        private CreditCard ReturnCreditCardInCategoryThatAppeardInDataBreaches(Category aCategory, string creditCardNumber)
        {
            return aCategory.ReturnCreditCardInCategoryThatAppearedInDataBreaches(creditCardNumber);
        }

        private List<UserPasswordPair> ReturnListOfUserPasswordPairWhosePasswordAppearedInDataBreaches(string aPassword)
        {
            List<UserPasswordPair> userPasswordPairList = new List<UserPasswordPair>();
            foreach (Category category in Categories)
            {
                List<UserPasswordPair> userPasswordPairListInCategory = ReturnListOfUserPasswordPairInCategoryWhosePasswordAppearedInDataBreaches(category, aPassword);
                foreach (UserPasswordPair element in userPasswordPairListInCategory)
                {
                    userPasswordPairList.Add(element);
                }
            }
            return userPasswordPairList;
        }

        private List<UserPasswordPair> ReturnListOfUserPasswordPairInCategoryWhosePasswordAppearedInDataBreaches(Category aCategory, string aPassword)
        {
            return aCategory.ReturnListOfUserPasswordPairInCategoryWhosePasswordAppearedInDataBreaches(aPassword);
        }
    }
}
