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

        private static int NumberOfLowers { get; set; }
        private static int NumberOfUppers { get; set; }
        private static int NumberOfDigits { get; set; }
        private static int NumberOfSymbols { get; set; }

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

                int maxOfLowers = CalculateMaxOfLowers(conditions);
                int minOfLowers = CalculateMinOfLowers(conditions);
                NumberOfLowers = conditions.HasLowerCase ? rand.Next(minOfLowers, maxOfLowers + 1) : 0;

                int maxOfUppers = CalculateMaxOfUppers(conditions);
                int minOfUppers = CalculateMinOfUppers(conditions);
                NumberOfUppers = conditions.HasUpperCase ? rand.Next(minOfUppers, maxOfUppers + 1) : 0;

                int maxOfDigits = CalculateMaxOfDigits(conditions);
                int minOfDigits = CalculateMinOfDigits(conditions);
                NumberOfDigits = conditions.HasDigits ? rand.Next(minOfDigits, maxOfDigits + 1) : 0;

                int maxOfSymbols = CalculateMaxOfSymbols(conditions);
                int minOfSymbols = CalculateMinOfSymbols(conditions);
                NumberOfSymbols = conditions.HasSymbols ? rand.Next(minOfSymbols, maxOfSymbols + 1) : 0;

                for (int i = 0; i < NumberOfLowers; i++)
                {
                    password += lower[rand.Next() % lower.Length];
                }
                for (int i = 0; i < NumberOfUppers; i++)
                {
                    password += upper[rand.Next() % upper.Length];
                }
                for (int i = 0; i < NumberOfDigits; i++)
                {
                    password += digits[rand.Next() % digits.Length];
                }
                for (int i = 0; i < NumberOfSymbols; i++)
                {
                    password += symbols[rand.Next() % symbols.Length];
                }

                password = RandomizeString(password);
            }

            return password;
        }

        private static int CalculateMaxOfLowers(PasswordGenerationConditions conditions)
        {
            //return conditions.Length - conditions.NumberOfConditions + 1 + Convert.ToInt32(conditions.HasLowerCase) - NumberOfLowers;
            return conditions.Length - conditions.NumberOfConditions + 1;
        }

        private static int CalculateMinOfLowers(PasswordGenerationConditions conditions)
        {
            return conditions.NumberOfConditions > 1 ? 1 : conditions.Length;
        }

        private static int CalculateMaxOfUppers(PasswordGenerationConditions conditions)
        {
            //return conditions.Length - conditions.NumberOfConditions + 1;
            //return conditions.Length - NumberOfLowers;
            return conditions.Length - conditions.NumberOfConditions + 1 + Convert.ToInt32(conditions.HasLowerCase) - NumberOfLowers;
        }

        private static int CalculateMinOfUppers(PasswordGenerationConditions conditions)
        {
            int minOfUppers = conditions.Length;

            if (conditions.NumberOfConditions == 2 && conditions.HasLowerCase)
            {
                minOfUppers = conditions.Length - NumberOfLowers;
            }
            else if (conditions.NumberOfConditions > 1)
            {
                minOfUppers = 1;
            }

            return minOfUppers;
        }

        private static int CalculateMaxOfDigits(PasswordGenerationConditions conditions)
        {
            //return conditions.Length - conditions.NumberOfConditions + 1 + Convert.ToInt32(conditions.HasLowerCase) + Convert.ToInt32(conditions.HasUpperCase) - NumberOfLowers - NumberOfUppers;
            return conditions.Length - NumberOfLowers - NumberOfUppers;
        }

        private static int CalculateMinOfDigits(PasswordGenerationConditions conditions)
        {
            int minOfDigits = conditions.Length;

            if ((conditions.NumberOfConditions == 3 && conditions.HasLowerCase && conditions.HasUpperCase) || 
                (conditions.NumberOfConditions == 2 && (conditions.HasLowerCase || conditions.HasUpperCase)))
            {
                minOfDigits = conditions.Length - (NumberOfLowers + NumberOfUppers);
            }
            else if (conditions.NumberOfConditions > 1)
            {
                minOfDigits = 1;
            }

            return minOfDigits;
        }

        private static int CalculateMaxOfSymbols(PasswordGenerationConditions conditions)
        {
            //return conditions.Length - conditions.NumberOfConditions + 1 + Convert.ToInt32(conditions.HasLowerCase) + Convert.ToInt32(conditions.HasUpperCase) + Convert.ToInt32(conditions.HasDigits) - NumberOfLowers - NumberOfUppers - NumberOfDigits;
            return conditions.Length - NumberOfLowers - NumberOfUppers - NumberOfDigits;
        }

        private static int CalculateMinOfSymbols(PasswordGenerationConditions conditions)
        {
            return conditions.Length - (NumberOfLowers + NumberOfUppers + NumberOfDigits);
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
