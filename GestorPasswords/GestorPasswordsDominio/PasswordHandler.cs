using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace GestorPasswordsDominio
{
    public class PasswordHandler
    {
        public static PasswordStrengthType PasswordStrength(String passwordToCheck)
        {
            if (passwordToCheck.Length < 5 || passwordToCheck.Length > 25)
            {
                throw new ExceptionIncorrectLength($"Length should be between 5 and 25 characters but is: {passwordToCheck.Length}");
            }
            if (ContainsLessThan8Characters(passwordToCheck)) return PasswordStrengthType.Red;
            if (ContainsBetween8And14Characters(passwordToCheck)) return PasswordStrengthType.Orange;
            if (ContainsJustUpperAndLowerCaseSymbolsAndNumbers(passwordToCheck)) return PasswordStrengthType.DarkGreen;

            bool isLightGreen = ContainsJustUpperAndLowerCase(passwordToCheck)
                            || ContainsJustUpperAndLowerCaseAndSymbolsOrNumbers(passwordToCheck)
                            || ContainsJustNumbersSymbolsAndUpperOrLowerCase(passwordToCheck);
            if (isLightGreen) return PasswordStrengthType.LightGreen;

            bool isYellow = ContainsJustUpperOrLowerCase(passwordToCheck)
                            || ContainsJustSymbolsAndNumbers(passwordToCheck)
                            || ContainsJustUpperOrLowerCaseAndSymbolsOrNumbers(passwordToCheck)
                            || ContainsJustSymbolsOrNumbers(passwordToCheck);
            if (isYellow) return PasswordStrengthType.Yellow;

            return PasswordStrengthType.Red;
        }

        private static bool ContainsJustNumbersSymbolsAndUpperOrLowerCase(string passwordToCheck)
        {
            return Regex.IsMatch(passwordToCheck, @"(?=^.{14,}$)((?=.*\d+)(?=.*\W+))(?![.\n])(?=.*([A-Z]|[a-z])+).*$");
        }

        private static bool ContainsJustSymbolsOrNumbers(string passwordToCheck)
        {
            return Regex.IsMatch(passwordToCheck, @"(?=^.{14,}$)((?=.*((\d)|(\W))+)).*$");
        }

        private static bool ContainsJustUpperOrLowerCaseAndSymbolsOrNumbers(string passwordToCheck)
        {
            return Regex.IsMatch(passwordToCheck, @"(?=^.{14,}$)((?=.*((\d)|(\W))+))(?![.\n])(?=.*(([A-Z])|([a-z]))+).*$");
        }

        private static bool ContainsJustSymbolsAndNumbers(string passwordToCheck)
        {
            return Regex.IsMatch(passwordToCheck, @"(?=^.{14,}$)((?=.*\d+)(?=.*\W+))(?![.\n]).*$");
        }

        private static bool ContainsJustUpperAndLowerCaseAndSymbolsOrNumbers(string passwordToCheck)
        {
            return Regex.IsMatch(passwordToCheck, @"(?=^.{14,}$)((?=.*((\d)|(\W))+))(?![.\n])(?=.*[A-Z]+)(?=.*[a-z]+).*$");
        }

        private static bool ContainsJustUpperAndLowerCaseSymbolsAndNumbers(string passwordToCheck)
        {
            return Regex.IsMatch(passwordToCheck, @"(?=^.{14,}$)((?=.*\d+)(?=.*\W+))(?![.\n])(?=.*[A-Z]+)(?=.*[a-z]+).*$");
        }

        private static bool ContainsJustUpperAndLowerCase(string passwordToCheck)
        {
            return Regex.IsMatch(passwordToCheck, @"^(?=[a-z]+[A-Z]+|[A-Z]+[a-z]+)[a-zA-Z]{14,25}$");
        }

        private static bool ContainsJustUpperOrLowerCase(string passwordToCheck)
        {
            return Regex.IsMatch(passwordToCheck, @"^[A-Za-z\s]+$");
        }

        private static bool ContainsLessThan8Characters(string passwordToCheck)
        {
            return passwordToCheck.Length < 8;
        }

        private static bool ContainsBetween8And14Characters(string passwordToCheck)
        {
            return passwordToCheck.Length >= 8 && passwordToCheck.Length <= 14;
        }

        public static String GenerateRandomPassword(PasswordGenerationConditions conditions)
        {
            String password = "";

            if (ConditionsAreValid(conditions))
            {
                string lower = "abcdefghijklmnopqrstuvwxyz";
                string upper = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
                string digits = "0123456789";
                string symbols = " !\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~";

                var rand = new Random();

                int numberOfConditions = CalculateNumberOfConditions(conditions);

                int maxOfLowers = conditions.Length - numberOfConditions + 1;
                int minOfLowers = numberOfConditions > 1 ? 1 : conditions.Length;
                int numberOfLowers = conditions.HasLowerCase ? rand.Next(minOfLowers, maxOfLowers + 1) : 0;

                int maxOfUppers = conditions.Length - numberOfConditions + 1 + Convert.ToInt32(conditions.HasLowerCase) - numberOfLowers;
                int minOfUppers = numberOfConditions > 1 ? 1 : conditions.Length;
                int numberOfUppers = conditions.HasUpperCase ? rand.Next(minOfUppers, maxOfUppers + 1) : 0;

                int maxOfDigits = conditions.Length - numberOfConditions + 1 + Convert.ToInt32(conditions.HasLowerCase) + Convert.ToInt32(conditions.HasUpperCase) - numberOfLowers - numberOfUppers;
                int minOfDigits = numberOfConditions > 1 ? 1 : conditions.Length;
                int numberOfDigits = conditions.HasDigits ? rand.Next(minOfDigits, maxOfDigits + 1) : 0;

                int maxOfSymbols = conditions.Length - numberOfConditions + 1 + Convert.ToInt32(conditions.HasLowerCase) + Convert.ToInt32(conditions.HasUpperCase) + Convert.ToInt32(conditions.HasDigits) - numberOfLowers - numberOfUppers - numberOfDigits;
                int minOfSymbols = conditions.Length - (numberOfLowers + numberOfUppers + numberOfDigits);
                int numberOfSymbols = conditions.HasSymbols ? rand.Next(minOfSymbols, maxOfSymbols + 1) : 0;

                for (int i = 0; i < numberOfLowers; i++)
                {
                    password += lower[rand.Next() % lower.Length];
                }
                for (int i = 0; i < numberOfUppers; i++)
                {
                    password += upper[rand.Next() % upper.Length];
                }
                for (int i = 0; i < numberOfDigits; i++)
                {
                    password += digits[rand.Next() % digits.Length];
                }
                for (int i = 0; i < numberOfSymbols; i++)
                {
                    password += symbols[rand.Next() % symbols.Length];
                }

                password = RandomizeString(password);
            }

            return password;
        }

        private static int CalculateNumberOfConditions(PasswordGenerationConditions conditions)
        {
            return Convert.ToInt32(conditions.HasLowerCase) + Convert.ToInt32(conditions.HasUpperCase) + Convert.ToInt32(conditions.HasDigits) + Convert.ToInt32(conditions.HasSymbols);
        }

        private static bool ConditionsAreValid(PasswordGenerationConditions conditions)
        {
            if (conditions.Length < 5 || conditions.Length > 25)
            {
                throw new ExceptionIncorrectLength("The length must be between 5 and 25, and the current length is " + conditions.Length);
            }

            if (!conditions.HasUpperCase && !conditions.HasLowerCase && !conditions.HasDigits && !conditions.HasSymbols)
            {
                throw new ExceptionIncorrectGenerationPasswordType("Must select at least one condition for generation");
            }

            return true;
        }

        private static String RandomizeString(String stringToRandomize)
        {
            var rand = new Random();
            return new string(stringToRandomize.ToCharArray().OrderBy(s => (rand.Next(2) % 2) == 0).ToArray());
        }
    }

    public enum PasswordStrengthType
    {
        Red = 0,
        Orange = 1,
        Yellow = 2,
        LightGreen = 3,
        DarkGreen = 4
    }
}
