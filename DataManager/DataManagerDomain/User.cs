using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text.RegularExpressions;

namespace DataManagerDomain
{
    public class User
    {
        public string EncryptedMasterPassword { get; set; }
        private string masterPassword;
        public string MasterPassword
        {
            get { return DecryptMasterPassword(); }
            set
            {
                masterPassword = ValidateAndEncryptMasterPassword(value);
                EncryptedMasterPassword = masterPassword;
            }
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

        public override string ToString()
        {
            return Username;
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

        private static bool IsBetween5And25Characters(string value)
        {
            return value.Length >= 5 && value.Length <= 25;
        }

        private string DecryptMasterPassword()
        {
            return Encrypter.Decrypt(EncryptedMasterPassword, PrivateKey);
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
                int count = dbContext.UserPasswordPairs
                    .Where(userPasswordPair => userPasswordPair.PasswordStrength == strengthType && userPasswordPair.Category.User.Username == Username)
                    .Count();
                listWithStrengthReport.Add(new Tuple<PasswordStrengthType, int>(strengthType, count));
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

        public void ChangeMasterPassword(string currentPassword, string newPassword)
        {
            CheckIfCurrentPasswordIsCorrect(currentPassword);
            using (var dbContext = new DataManagerContext())
            {
                MasterPassword = newPassword;
                dbContext.Entry(this).State = EntityState.Modified;
                dbContext.SaveChanges();
            }
        }

        private void CheckIfCurrentPasswordIsCorrect(string currentPassword)
        {
            if (!PasswordsMatch(currentPassword, MasterPassword))
            {
                throw new ExceptionIncorrectMasterPassword("The password entered by the user did not match the master password");
            }
        }

        public bool PasswordsMatch(string currentPassword, string masterPassword)
        {
            return currentPassword == masterPassword;
        }

        public Category[] GetCategories()
        {
            using (var dbContext = new DataManagerContext())
            {
                var passwords = dbContext.Categories
                    .Where(category => category.User.Username == Username)
                    .Include(category => category.User);
                return passwords.ToArray();
            }
        }

        public void AddCategory(Category aCategory)
        {
            if (CategoryIsValid(aCategory.Name))
            {
                AddCategoryToCollection(aCategory);
            }
        }

        private bool CategoryIsValid(string categoryName)
        {
            CheckCategoryLength(categoryName);
            CheckIfCategoryExists(categoryName);
            return true;
        }

        private static void CheckCategoryLength(string categoryName)
        {
            if (!CategoryNameHasValidLength(categoryName))
            {
                throw new ExceptionIncorrectLength("The category length must be between 3 and 15, but it's current length is " + categoryName.Length);
            }
        }

        private void CheckIfCategoryExists(string categoryName)
        {
            if (CategoryExists(categoryName))
            {
                throw new ExceptionCategoryAlreadyExists("The category " + categoryName + " already exists");
            }
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

        public void ModifyCategory(Category aCategory, string newName)
        {
            newName = newName.Trim().ToLower();
            if (CategoryCouldBeModified(aCategory, newName))
            {
                UpdateCategory(aCategory, newName);
            }
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
                var categories = dbContext.CreditCards
                    .Where(creditCard => creditCard.Category.User.Username == Username)
                    .Include(creditCard => creditCard.Category)
                    .OrderBy(creditCard => creditCard.Category.Name);
                return categories.ToArray();
            }
        }

        public bool CreditCardNumberExists(string creditCardNumber)
        {
            using (var dbContext = new DataManagerContext())
            {
                var creditCardSelected = dbContext.CreditCards.
                    FirstOrDefault(creditCard => creditCard.Category.User.Username == Username && creditCard.Number == creditCardNumber);
                return creditCardSelected != null;
            }
        }

        public UserPasswordPair[] GetUserPasswordPairs()
        {
            using (var dbContext = new DataManagerContext())
            {
                var passwords = dbContext.UserPasswordPairs
                    .Where(password => password.Category.User.Username == Username)
                    .Include(userPasswordPair => userPasswordPair.Category)
                    .Include(userPasswordPair => userPasswordPair.Category.User)
                    .OrderBy(userPasswordPair => userPasswordPair.Category.Name);
                return passwords.ToArray();
            }
        }

        public bool UserPasswordPairExists(UserPasswordPair aUserPasswordPair)
        {
            using (var dbContext = new DataManagerContext())
            {
                var password = dbContext.UserPasswordPairs
                    .FirstOrDefault(userPasswordPair => userPasswordPair.Category.User.Username == Username && userPasswordPair.Username == aUserPasswordPair.Username && userPasswordPair.Site == aUserPasswordPair.Site);
                return password != null;
            }
        }

        public UserPasswordPair[] GetSharedUserPasswordPairs()
        {
            using (var dbContext = new DataManagerContext())
            {
                var userSelected = dbContext.Users
                    .Include(user => user.SharedPasswords)
                    .FirstOrDefault(user => user.Username == Username);
                return userSelected.SharedPasswords.ToArray();
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
                    .Exists(password => {
                        dbContext.Entry(password).Reference(pass => pass.Category).Load();
                        dbContext.Entry(password.Category).Reference(category => category.User).Load();
                        return password.Password == aUserPasswordPair.Password;
                    });
            }
        }

        private void AddDataBreach(DataBreach aDataBreach)
        {
            using (var dbContext = new DataManagerContext())
            {
                dbContext.Users.Attach(aDataBreach.User);
                dbContext.DataBreaches.Add(aDataBreach);
                dbContext.SaveChanges();
            }   
        }

        public DataBreach[] GetDataBreaches()
        {
            using (var dbContext = new DataManagerContext())
            {
                return dbContext.DataBreaches
                    .Where(dataBreach => dataBreach.User.Username == Username)
                    .Include(dataBreach => dataBreach.LeakedUserPasswordPairsOfUser)
                    .Include(dataBreach => dataBreach.LeakedCreditCardsOfUser)
                    .Include(dataBreach => dataBreach.LeakedPasswords)
                    .Include(dataBreach => dataBreach.LeakedCreditCards)
                    .ToArray();
            }
        }

        public DataBreach CheckDataBreaches(IDataBreachesFormatter dataBreachInput)
        {
            string[] leakedData = dataBreachInput.ConvertToArray();
            DataBreach dataBreach = CreateDataBreach();
            if (DataBreachIsEmpty(leakedData))
            {
                return dataBreach;
            }
            else
            {
                AddDataBreach(dataBreach);
                CheckDataBreachDataProvided(leakedData, dataBreach);
                return FindDataBreach(dataBreach);
            }
        }

        private DataBreach CreateDataBreach()
        {
            return new DataBreach()
            {
                User = this
            };
        }

        private static bool DataBreachIsEmpty(string[] leakedData)
        {
            return leakedData.Length == 0 || (leakedData.Length == 1 && leakedData[0].Trim() == "");
        }

        private void CheckDataBreachDataProvided(string[] leakedData, DataBreach dataBreach)
        {
            foreach (string element in leakedData)
            {
                string dataToCheck = element.Trim();
                if (!DataIsEmpty(dataToCheck))
                {
                    if (ItsACreditCard(dataToCheck))
                    {
                        AddLeakedCreditCard(dataBreach, dataToCheck);
                    }
                    else
                    {
                        AddLeakedPassword(dataBreach, dataToCheck);
                    }
                }
            }
        }

        private static bool DataIsEmpty(string dataToCheck)
        {
            return dataToCheck == "";
        }

        private void AddLeakedCreditCard(DataBreach dataBreach, string dataToCheck)
        {
            LeakedCreditCard aLeakedCreditCard = new LeakedCreditCard()
            {
                Number = dataToCheck
            };
            dataBreach.AddLeakedCreditCard(aLeakedCreditCard);

            CreditCard aLeakedCreditCardOfUser = CreditCardThatAppeardInDataBreaches(dataToCheck);
            if (aLeakedCreditCardOfUser != null && !dataBreach.LeakedCreditCardsOfUser.Contains(aLeakedCreditCardOfUser))
            {
                dataBreach.AddLeakedCreditCardOfUser(aLeakedCreditCardOfUser);
            }
        }

        private void AddLeakedPassword(DataBreach dataBreach, string dataToCheck)
        {
            LeakedPassword aLeakedPassword = new LeakedPassword()
            {
                Password = dataToCheck
            };
            dataBreach.AddLeakedUserPasswordPair(aLeakedPassword);

            List<UserPasswordPair> leakedPasswordsOfUser = GetUserPasswordPairWhosePasswordAppearedInDataBreaches(dataToCheck);
            foreach (UserPasswordPair pair in leakedPasswordsOfUser)
            {
                if (!dataBreach.LeakedUserPasswordPairsOfUser.Contains(pair))
                {
                    dataBreach.AddLeakedUserPasswordPairOfUser(pair);
                }
            }
        }

        public DataBreach FindDataBreach(DataBreach aDataBreach)
        {
            using (var dbContext = new DataManagerContext())
            {
                var dataBreachSelected = dbContext.DataBreaches
                    .Include(dataBreach => dataBreach.LeakedUserPasswordPairsOfUser)
                    .Include(dataBreach => dataBreach.LeakedCreditCardsOfUser)
                    .Include(dataBreach => dataBreach.LeakedUserPasswordPairsOfUser.Select(leakedUserPasswordPair => leakedUserPasswordPair.Category))
                    .Include(dataBreach => dataBreach.LeakedCreditCardsOfUser.Select(leakedCreditCard => leakedCreditCard.Category))
                    .FirstOrDefault(dataBreach => dataBreach.Id == aDataBreach.Id); 
                return dataBreachSelected;
            }
        }

        public (List<UserPasswordPair>, List<UserPasswordPair>) GetModifiedAndNotModifiedLeakedPasswords(DataBreach aDataBreach)
        {
            List<UserPasswordPair> notModifiedPasswords = new List<UserPasswordPair>();
            List<UserPasswordPair> modifiedPasswords = new List<UserPasswordPair>();
            using (var dbContext = new DataManagerContext())
            {
                var dataBreachSelected = dbContext.DataBreaches
                    .Include(dataBreach => dataBreach.LeakedUserPasswordPairsOfUser)
                    .Include(dataBreach => dataBreach.LeakedUserPasswordPairsOfUser.Select(leakedUserPasswordPair => leakedUserPasswordPair.Category))
                    .FirstOrDefault(dataBreach => dataBreach.Id == aDataBreach.Id);
                foreach (UserPasswordPair pair in dataBreachSelected.LeakedUserPasswordPairsOfUser)
                {
                    if (dataBreachSelected.PasswordWasModified(pair))
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
        }

        public List<CreditCard> GetLeakedCreditCards(DataBreach aDataBreach)
        {
            using (var dbContext = new DataManagerContext())
            {
                var dataBreachSelected = dbContext.DataBreaches
                    .Include(dataBreach => dataBreach.LeakedCreditCardsOfUser)
                    .Include(dataBreach => dataBreach.LeakedCreditCardsOfUser.Select(leakedCreditCard => leakedCreditCard.Category))
                    .FirstOrDefault(dataBreach => dataBreach.Id == aDataBreach.Id);
                return dataBreachSelected.LeakedCreditCardsOfUser;
            }
        }

        private CreditCard CreditCardThatAppeardInDataBreaches(string creditCardNumber)
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
            return aCategory.CreditCardInCategoryThatAppearedInDataBreaches(creditCardNumber);
        }

        private List<UserPasswordPair> GetUserPasswordPairWhosePasswordAppearedInDataBreaches(string aPassword)
        {
            List<UserPasswordPair> userPasswordPairList = new List<UserPasswordPair>();
            foreach (Category category in Categories)
            {
                UserPasswordPair[] userPasswordPairListInCategory = GetUserPasswordPairInCategoryWhosePasswordAppearedInDataBreaches(category, aPassword);
                foreach (UserPasswordPair element in userPasswordPairListInCategory)
                {
                    userPasswordPairList.Add(element);
                }
            }
            return userPasswordPairList;
        }

        private UserPasswordPair[] GetUserPasswordPairInCategoryWhosePasswordAppearedInDataBreaches(Category aCategory, string aPassword)
        {
            return aCategory.GetUserPasswordPairInCategoryWhosePasswordAppearedInDataBreaches(aPassword);
        }

        public Tuple<bool, bool, bool> PasswordImprovementSuggestionsAreTakenIntoAccount(string aPassword)
        {
            string passwordTrimed = aPassword.Trim();
            bool passwordIsStrong = PasswordIsStrong(passwordTrimed);
            bool passwordIsNotDuplicated = !PasswordIsDuplicated(passwordTrimed);
            bool passwordHasNotAppearedInDataBreaches = !PasswordHasAppearedInADataBreach(passwordTrimed);
            return new Tuple<bool, bool, bool>(passwordIsStrong, passwordIsNotDuplicated, passwordHasNotAppearedInDataBreaches);
        }

        public bool PasswordIsStrong(string aPassword)
        {
            bool passwordIsStrong = false;
            PasswordStrengthType passwordStrengthType = PasswordHandler.PasswordStrength(aPassword);
            if (PasswordIsLightOrDarkGreen(passwordStrengthType))
            {
                passwordIsStrong = true;
            }
            return passwordIsStrong;
        }

        private static bool PasswordIsLightOrDarkGreen(PasswordStrengthType passwordStrengthType)
        {
            return passwordStrengthType.Equals(PasswordStrengthType.LightGreen) || passwordStrengthType.Equals(PasswordStrengthType.DarkGreen);
        }

        private bool PasswordIsDuplicated(string aPassword)
        {
            bool passwordIsDuplicated = false;
            foreach (UserPasswordPair aPair in GetUserPasswordPairs())
            {
                if (aPair.Password.Equals(aPassword))
                {
                    passwordIsDuplicated = true;
                }
            }
            return passwordIsDuplicated;
        }

        private bool PasswordHasAppearedInADataBreach(string aPassword)
        {
            bool passwordHasAppearedInADataBreach = false;
            using (var dbContext = new DataManagerContext())
            {
                var userSelected = dbContext.Users
                    .Include(user => user.DataBreaches)
                    .FirstOrDefault(user => user.Username == Username);
                foreach (DataBreach aDataBreach in userSelected.DataBreaches)
                {
                    if (aDataBreach.PasswordAppearedInDataBreach(aPassword))
                    {
                        passwordHasAppearedInADataBreach = true;
                    }
                }
                return passwordHasAppearedInADataBreach;
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
    }
}
