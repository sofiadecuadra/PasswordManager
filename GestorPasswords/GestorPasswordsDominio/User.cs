using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace GestorPasswordsDominio
{
    public class User
    {
        public string masterPassword;
        public string MasterPassword {
            get { return masterPassword; }
            set {
                masterPassword = ValidMasterPassword(value);
            }
        }
        private string name;
        private SortedList<string, Category> categoriesList;
        private List<UserPasswordPair> redUserPasswordPairs;
        private List<UserPasswordPair> orangeUserPasswordPairs;
        private List<UserPasswordPair> yellowUserPasswordPairs;
        private List<UserPasswordPair> lightGreenUserPasswordPairs;
        private List<UserPasswordPair> darkGreenUserPasswordPairs;


        public string Name
        {
            get { return name; }
            set { name = ValidUserName(value.Trim()); }
        }

        public Category SharedPasswords { get; private set; }

        private static string ValidMasterPassword(string password)
        {
            if (!isBetween5And25Characters(password))
            {
                string errorMessage = $"The password should be between 5 and 25 characters but is: {password.Length} charachterslong";
                throw new ExceptionIncorrectLength(errorMessage);
            }
            return password;
        }

        private static string ValidUserName(string value)
        {
            if (!isBetween5And25Characters(value))
            {
                string errorMessage = $"The provided user name should be between 5 and 25 characters but is: {value.Length} charachterslong";
                throw new ExceptionIncorrectUserNameLength(errorMessage);
            }
            if (HasBlankSpace(value))
            {
                string errorMessage = $"The username must not contain any blank spaces";
                throw new ExceptionUsernameContainsSpaces(errorMessage);
            }
            return value.ToLower();
        }

        private static bool isBetween5And25Characters(string value)
        {
            return value.Length >= 5 && value.Length <= 25;
        }

        private static bool HasBlankSpace(string value)
        {
            return value.Contains(" ");
        }

        public User()
        {
            categoriesList = new SortedList<string, Category>();
            redUserPasswordPairs = new List<UserPasswordPair>();
            orangeUserPasswordPairs = new List<UserPasswordPair>();
            yellowUserPasswordPairs = new List<UserPasswordPair>();
            lightGreenUserPasswordPairs = new List<UserPasswordPair>();
            darkGreenUserPasswordPairs = new List<UserPasswordPair>();
            SharedPasswords = new Category()
            {
                User = this,
                Name = "Shared Passwords"
            };
        }

        public List<Tuple<string,int, UserPasswordPair[]>> GetPasswordsStrengthReport()
        {
            List<Tuple<string, int, UserPasswordPair[]>> listWithStrengthReport = new List<Tuple<string, int, UserPasswordPair[]>>();

            AddRedPasswordsStrengthReport(listWithStrengthReport);
            AddOrangePasswordsStrengthReport(listWithStrengthReport);
            AddYellowPasswordsStrengthReport(listWithStrengthReport);
            AddLightGreenPasswordsStrengthReport(listWithStrengthReport);
            AddDarkGreenPasswordsStrengthReport(listWithStrengthReport);

            return listWithStrengthReport;
        }

        private void AddRedPasswordsStrengthReport(List<Tuple<string, int, UserPasswordPair[]>> listWithStrengthReport)
        {
            listWithStrengthReport.Add(new Tuple<string, int, UserPasswordPair[]>("Red", redUserPasswordPairs.Count, GetRedUserPasswordPairs()));
        }

        private void AddOrangePasswordsStrengthReport(List<Tuple<string, int, UserPasswordPair[]>> listWithStrengthReport)
        {
            listWithStrengthReport.Add(new Tuple<string, int, UserPasswordPair[]>("Orange", orangeUserPasswordPairs.Count, GetOrangeUserPasswordPairs()));
        }

        private void AddYellowPasswordsStrengthReport(List<Tuple<string, int, UserPasswordPair[]>> listWithStrengthReport)
        {
            listWithStrengthReport.Add(new Tuple<string, int, UserPasswordPair[]>("Yellow", yellowUserPasswordPairs.Count, GetYellowUserPasswordPairs()));
        }

        private void AddLightGreenPasswordsStrengthReport(List<Tuple<string, int, UserPasswordPair[]>> listWithStrengthReport)
        {
            listWithStrengthReport.Add(new Tuple<string, int, UserPasswordPair[]>("Light Green", lightGreenUserPasswordPairs.Count, GetLightGreenUserPasswordPairs()));
        }

        private void AddDarkGreenPasswordsStrengthReport(List<Tuple<string, int, UserPasswordPair[]>> listWithStrengthReport)
        {
            listWithStrengthReport.Add(new Tuple<string, int, UserPasswordPair[]>("Dark Green", darkGreenUserPasswordPairs.Count, GetDarkGreenUserPasswordPairs()));
        }

        public UserPasswordPair[] GetRedUserPasswordPairs()
        {
            UserPasswordPair[] redUserPasswordPairsArray = new UserPasswordPair[redUserPasswordPairs.Count];
            redUserPasswordPairs.CopyTo(redUserPasswordPairsArray);
            return redUserPasswordPairsArray; 
        }

        public void AddRedUserPasswordPair(UserPasswordPair aRedUserPasswordPair)
        {
            redUserPasswordPairs.Add(aRedUserPasswordPair);
        }

        public void DeleteRedUserPasswordPair(UserPasswordPair aRedUserPasswordPair)
        {
            redUserPasswordPairs.Remove(aRedUserPasswordPair);
        }

        public UserPasswordPair[] GetOrangeUserPasswordPairs()
        {
            UserPasswordPair[] orangeUserPasswordPairsArray = new UserPasswordPair[orangeUserPasswordPairs.Count];
            orangeUserPasswordPairs.CopyTo(orangeUserPasswordPairsArray);
            return orangeUserPasswordPairsArray;
        }

        public void AddOrangeUserPasswordPair(UserPasswordPair anOrangeUserPasswordPair)
        {
            orangeUserPasswordPairs.Add(anOrangeUserPasswordPair);
        }
        public void DeleteOrangeUserPasswordPair(UserPasswordPair anOrangeUserPasswordPair)
        {
            orangeUserPasswordPairs.Remove(anOrangeUserPasswordPair);
        }

        public UserPasswordPair[] GetYellowUserPasswordPairs()
        {
            UserPasswordPair[] yellowUserPasswordPairsArray = new UserPasswordPair[yellowUserPasswordPairs.Count];
            yellowUserPasswordPairs.CopyTo(yellowUserPasswordPairsArray);
            return yellowUserPasswordPairsArray;
        }

        public void AddYellowUserPasswordPair(UserPasswordPair aYellowUserPasswordPair)
        {
            yellowUserPasswordPairs.Add(aYellowUserPasswordPair);
        }

        public void DeleteYellowUserPasswordPair(UserPasswordPair aYellowUserPasswordPair)
        {
           yellowUserPasswordPairs.Remove(aYellowUserPasswordPair);
        }

        public UserPasswordPair[] GetLightGreenUserPasswordPairs()
        {
            UserPasswordPair[] lightGreenUserPasswordPairsArray = new UserPasswordPair[lightGreenUserPasswordPairs.Count];
            lightGreenUserPasswordPairs.CopyTo(lightGreenUserPasswordPairsArray);
            return lightGreenUserPasswordPairsArray;
        }

        public void AddLightGreenUserPasswordPair(UserPasswordPair aLightGreenUserPasswordPair)
        {
            lightGreenUserPasswordPairs.Add(aLightGreenUserPasswordPair);
        }

        public void DeleteLightGreenUserPasswordPair(UserPasswordPair aYellowUserPasswordPair)
        {
            lightGreenUserPasswordPairs.Remove(aYellowUserPasswordPair);
        }

        public UserPasswordPair[] GetDarkGreenUserPasswordPairs()
        {
            UserPasswordPair[] darkGreenUserPasswordPairsArray = new UserPasswordPair[darkGreenUserPasswordPairs.Count];
            darkGreenUserPasswordPairs.CopyTo(darkGreenUserPasswordPairsArray);
            return darkGreenUserPasswordPairsArray;
        }

        public void AddDarkGreenUserPasswordPair(UserPasswordPair aDarkGreenUserPasswordPair)
        {
            darkGreenUserPasswordPairs.Add(aDarkGreenUserPasswordPair);
        }
        public void DeleteDarkGreenUserPasswordPair(UserPasswordPair aDarkGreenUserPasswordPair)
        {
            darkGreenUserPasswordPairs.Remove(aDarkGreenUserPasswordPair);
        }

        public bool ChangeMasterPassword(string currentPassword, string newPassword)
        {
            if (!PasswordsMatch(currentPassword, this.MasterPassword))
            {
                throw new ExceptionIncorrectMasterPassword("The password entered by the user did not match the master password");
            }
            this.MasterPassword = newPassword;

            return true;
        }

        public bool PasswordsMatch(string currentPassword, string masterPassword)
        {
            return currentPassword == masterPassword;
        }

        internal void AddSharedUserPasswordPair(UserPasswordPair passwordToShare)
        {
            SharedPasswords.AddUserPasswordPair(passwordToShare);
        }

        internal void UnshareUserPasswordPair(UserPasswordPair passwordToStopSharing)
        {
            SharedPasswords.RemoveUserPasswordPair(passwordToStopSharing);
        }

        public bool AddCategory(Category aCategory)
        {
            bool categoryAdded = false;
            if (CategoryHasValidLength(aCategory.Name))
            {
                AddCategoryToSortedList(aCategory);
                categoryAdded = true;
            }

            return categoryAdded;
        }

        private void AddCategoryToSortedList(Category aCategory)
        {
            this.categoriesList.Add(aCategory.Name, aCategory);
        }

        private static bool CategoryHasValidLength(string categoryName)
        {
            if (categoryName.Length < 3 || categoryName.Length > 15)
            {
                throw new ExceptionCategoryHasInvalidNameLength("The category length must be between 3 and 15, but it's current length is " + categoryName.Length);
            }

            return true;
        }

        public Category[] GetCategories()
        {
            IList<Category> categories = categoriesList.Values;
            return categories.ToArray();
        }

        public bool ModifyCategory(Category aCategory, string newName)
        {
            bool categoryModified = false;
            if (CategoryCouldBeModified(aCategory, newName.ToLower()))
            {
                UpdateCategory(aCategory, newName);
                categoryModified = true;
            }
            return categoryModified;
        }

        private void UpdateCategory(Category aCategory, string newName)
        {
            RemoveCategoryFromCategoriesCollection(aCategory);
            aCategory.Name = newName;
            AddCategoryToSortedList(aCategory);
        }

        private void RemoveCategoryFromCategoriesCollection(Category aCategory)
        {
            this.categoriesList.Remove(aCategory.Name);
        }

        private bool CategoryCouldBeModified(Category aCategory, string newName)
        {
            if (aCategory.Name == newName) return false;

            if (!CategoryExists(aCategory.Name))
            {
                throw new ExceptionCategoryNotExists();
            }

            if (CategoryExists(newName))
            {
                throw new ExceptionCategoryAlreadyExists("The category already exists" );
            }

            return CategoryHasValidLength(newName);
        }

        private bool CategoryExists(string aCategoryName)
        {
            return this.categoriesList.ContainsKey(aCategoryName);
        }

        public bool CreditCardNumberExists(string creditCardNumber)
        {
            bool creditCardExists = false;
            foreach (KeyValuePair<string, Category> pair in this.categoriesList)
            {
                if (CreditCardExistsInCategory(pair.Value, creditCardNumber))
                {
                    creditCardExists = true;
                    break;
                }
            }
            return creditCardExists;
        }

        public bool HasSharedPasswordOf(string username, string site)
        {
            return SharedPasswords.UserPasswordPairAlredyExistsInCategory(username, site);
        }

        private static bool CreditCardExistsInCategory(Category aCategory, string creditCardNumber)
        {
            return aCategory.CreditCardNumberAlreadyExistsInCategory(creditCardNumber);
        }

        public bool UserPasswordPairExists(string username, string site)
        {
            bool pairExists = false;
            foreach (KeyValuePair<string, Category> pair in this.categoriesList)
            {
                if (UserPasswordPairExistsInCategory(pair.Value, username, site))
                {
                    pairExists = true;
                    break;
                }
            }
            return pairExists;
        }
        private static bool UserPasswordPairExistsInCategory(Category aCategory, string username, string site)
        {
            return aCategory.UserPasswordPairAlredyExistsInCategory(username, site);
        }

        public UserPasswordPair FindUserPasswordPair(string username, string site)
        {
            UserPasswordPair userPasswordPair = null;
            foreach (KeyValuePair<string, Category> pair in this.categoriesList)
            {
                if (UserPasswordPairExistsInCategory(pair.Value, username, site))
                {
                    userPasswordPair = pair.Value.FindUserPasswordPair(username, site);
                    break;
                }
            }

            return userPasswordPair != null ? userPasswordPair : throw new ExceptionUserPasswordPairDoesNotExist(); 
        }

        private CreditCard ReturnCreditCardInCategoryThatAppeardInDataBreaches(Category aCategory, string creditCardNumber)
        {
            return aCategory.ReturnCreditCardInCategoryThatAppearedInDataBreaches(creditCardNumber);
        }

        private CreditCard ReturnCreditCardThatAppeardInDataBreaches(string creditCardNumber)
        {
            CreditCard creditCard = null;

            foreach (KeyValuePair<string, Category> pair in this.categoriesList)
            {
                string creditCardNumberWithoutBlankSpace = creditCardNumber.Replace(" ", string.Empty);

                creditCard = ReturnCreditCardInCategoryThatAppeardInDataBreaches(pair.Value, creditCardNumberWithoutBlankSpace);

                if (creditCard!= null)
                {
                    break;
                }
            }
            return creditCard;
        }

        private List<UserPasswordPair> ReturnListOfUserPasswordPairInCategoryWhosePasswordAppearedInDataBreaches(Category aCategory, string aPassword)
        {
            return aCategory.ReturnListOfUserPasswordPairInCategoryWhosePasswordAppearedInDataBreaches(aPassword);
        }

        private List <UserPasswordPair> ReturnListOfUserPasswordPairWhosePasswordAppearedInDataBreaches(string aPassword)
        {
            List<UserPasswordPair> userPasswordPairList = new List<UserPasswordPair>();

            foreach (KeyValuePair<string, Category> pair in this.categoriesList)
            {
                List<UserPasswordPair> userPasswordPairListInCategory = ReturnListOfUserPasswordPairInCategoryWhosePasswordAppearedInDataBreaches(pair.Value, aPassword);

                foreach (UserPasswordPair element in userPasswordPairListInCategory)
                {
                    userPasswordPairList.Add(element);
                }
            }
            return userPasswordPairList;
        }

        private bool ContainsOnlyDigits(string element)
        {
            return Regex.IsMatch(element, @"^[0-9]+$");
        }

        private bool LengthIsFour (string element)
        {
            return element.Length == 4;
        }

        private bool ItsACreditCard(string element)
        {
            string [] dataToCheck = element.Split (' ');

            foreach (string item in dataToCheck)
            {
                if (!ContainsOnlyDigits (item) || !LengthIsFour (item))
                {
                    return false;
                }
            }
            return true;
        }

        public (List <UserPasswordPair>, List <CreditCard>) CheckDataBreaches(IDataBreachesFormatter dataBreaches)
        {
            List<CreditCard> leakedCreditCardsOfUserList = new List<CreditCard>();

            List<UserPasswordPair> leakedPasswordsOfUserList = new List<UserPasswordPair>();

            string [] leakedData = dataBreaches.ConvertToArray();

            foreach (string element in leakedData)
            {
                if (ItsACreditCard(element))
                {
                    CreditCard aLeakedCreditCardOfUser = ReturnCreditCardThatAppeardInDataBreaches(element);

                    if (aLeakedCreditCardOfUser != null)
                    {
                        leakedCreditCardsOfUserList.Add(aLeakedCreditCardOfUser);
                    }
                }
                else
                {
                    List<UserPasswordPair> leakedPasswordsOfUser = ReturnListOfUserPasswordPairWhosePasswordAppearedInDataBreaches(element);

                    foreach (UserPasswordPair pair in leakedPasswordsOfUser)
                    {
                        leakedPasswordsOfUserList.Add(pair);
                    }
                }              
            }
            return (leakedPasswordsOfUserList, leakedCreditCardsOfUserList);
        }

        public UserPasswordPair[] GetUserPasswordPairs()
        {
            List<UserPasswordPair> allUserPasswordPairs = new List<UserPasswordPair>();
            foreach (var category in this.GetCategories())
            {
                allUserPasswordPairs.AddRange(category.GetUserPasswordsPairs());
            }
            return allUserPasswordPairs.ToArray();
        }
    }
}
