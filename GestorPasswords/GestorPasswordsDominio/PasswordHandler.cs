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
        private const int MIN_PASSWORD_SIZE = 5;
        private const int MAX_PASSWORD_SIZE = 25;

        public static PasswordStrengthType PasswordStrength(String passwordToCheck)
        {
            if (PasswordSizeOutSideBoundaries(passwordToCheck))
            {
                throw new ExceptionIncorrectLength($"The password length must be between 5 and 25, but it's current length is: {passwordToCheck.Length}");
            }
            if (ContainsLessThan8Characters(passwordToCheck))
            {
                return PasswordStrengthType.Red;
            }
            if (ContainsBetween8And14Characters(passwordToCheck))
            {
                return PasswordStrengthType.Orange;
            }
            if (ContainsJustUpperAndLowerCaseSymbolsAndNumbers(passwordToCheck))
            {
                return PasswordStrengthType.DarkGreen;
            }

            bool isLightGreen = ContainsJustUpperAndLowerCase(passwordToCheck)
                            || ContainsJustUpperAndLowerCaseAndSymbolsOrNumbers(passwordToCheck)
                            || ContainsJustNumbersSymbolsAndUpperOrLowerCase(passwordToCheck);
            if (isLightGreen)
            {
                return PasswordStrengthType.LightGreen;
            }

            /*bool isYellow = ContainsJustUpperOrLowerCase(passwordToCheck)
                            || ContainsJustSymbolsAndNumbers(passwordToCheck)
                            || ContainsJustUpperOrLowerCaseAndSymbolsOrNumbers(passwordToCheck)
                            || ContainsJustSymbolsOrNumbers(passwordToCheck);
            if (isYellow)
            {*/
                return PasswordStrengthType.Yellow;
            /*}

            return PasswordStrengthType.Red;*/
        }

        private static bool PasswordSizeOutSideBoundaries(string passwordToCheck)
        {
            return passwordToCheck.Length < MIN_PASSWORD_SIZE || passwordToCheck.Length > MAX_PASSWORD_SIZE;
        }

        private static bool ContainsJustNumbersSymbolsAndUpperOrLowerCase(string passwordToCheck)
        {
            return Regex.IsMatch(passwordToCheck, @"(?=^.{14,}$)((?=.*\d+)(?=.*\W+))(?![.\n])(?=.*([A-Z]|[a-z])+).*$");
        }

        /*private static bool ContainsJustSymbolsOrNumbers(string passwordToCheck)
        {
            return Regex.IsMatch(passwordToCheck, @"(?=^.{14,}$)((?=.*((\d)|(\W))+)).*$");
        }*/

        /*private static bool ContainsJustUpperOrLowerCaseAndSymbolsOrNumbers(string passwordToCheck)
        {
            return Regex.IsMatch(passwordToCheck, @"(?=^.{14,}$)((?=.*((\d)|(\W))+))(?![.\n])(?=.*(([A-Z])|([a-z]))+).*$");
        }*/

        /*private static bool ContainsJustSymbolsAndNumbers(string passwordToCheck)
        {
            return Regex.IsMatch(passwordToCheck, @"(?=^.{14,}$)((?=.*\d+)(?=.*\W+))(?![.\n]).*$");
        }*/

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

        /*private static bool ContainsJustUpperOrLowerCase(string passwordToCheck)
        {
            return Regex.IsMatch(passwordToCheck, @"^[A-Za-z\s]+$");
        }*/

        private static bool ContainsLessThan8Characters(string passwordToCheck)
        {
            return passwordToCheck.Length < 8;
        }

        private static bool ContainsBetween8And14Characters(string passwordToCheck)
        {
            return passwordToCheck.Length <= 14;
        }

        private static Random rand;

        public static String GenerateRandomPassword(PasswordGenerationConditions conditions)
        {
            String password = "";

            if (ConditionsAreValid(conditions))
            {
                rand = new Random();
                int randomizer = rand.Next(0, 4);

                password = AddMustHaveCharacters(conditions);

                int counter = 0;
                while (counter < NumberOfCharactersToAdd(conditions))
                {
                    if (CouldAddLower(conditions, randomizer))
                    {
                        password += AddLower();
                        counter++;
                    }
                    else if (CouldAddUpper(conditions, randomizer))
                    {
                        password += AddUpper();
                        counter++;
                    }
                    else if (CouldAddDigit(conditions, randomizer))
                    {
                        password += AddDigit();
                        counter++;
                    }
                    else if (CouldAddSymbol(conditions, randomizer))
                    {
                        password += AddSymbol();
                        counter++;
                    }

                    randomizer = rand.Next(0, 4);
                }

                password = RandomizeString(password);
            }

            return password;
        }

        private static int NumberOfCharactersToAdd(PasswordGenerationConditions conditions)
        {
            return conditions.Length - conditions.NumberOfConditions;
        }

        private static bool CouldAddSymbol(PasswordGenerationConditions conditions, int randomizer)
        {
            return randomizer == 3 && conditions.HasSymbols;
        }

        private static bool CouldAddDigit(PasswordGenerationConditions conditions, int randomizer)
        {
            return randomizer == 2 && conditions.HasDigits;
        }

        private static bool CouldAddUpper(PasswordGenerationConditions conditions, int randomizer)
        {
            return randomizer == 1 && conditions.HasUpperCase;
        }

        private static bool CouldAddLower(PasswordGenerationConditions conditions, int randomizer)
        {
            return randomizer == 0 && conditions.HasLowerCase;
        }

        private static char AddLower()
        {
            string lower = "abcdefghijklmnopqrstuvwxyz";

            return lower[rand.Next(0, lower.Length)];
        }

        private static char AddUpper()
        {
            string upper = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

            return upper[rand.Next(0, upper.Length)];
        }

        private static char AddDigit()
        {
            string digits = "0123456789";

            return digits[rand.Next(0, digits.Length)];
        }

        private static char AddSymbol()
        {
            string symbols = " !\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~";

            return symbols[rand.Next(0, symbols.Length)];
        }

        private static string AddMustHaveCharacters(PasswordGenerationConditions conditions)
        {
            string password = "";
            string lower = "abcdefghijklmnopqrstuvwxyz";
            string upper = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string digits = "0123456789";
            string symbols = " !\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~";

            if (conditions.HasLowerCase)
            {
                password += lower[rand.Next(0, lower.Length)];
            }
            if (conditions.HasUpperCase)
            {
                password += upper[rand.Next(0, upper.Length)];
            }
            if (conditions.HasDigits)
            {
                password += digits[rand.Next(0, digits.Length)];
            }
            if (conditions.HasSymbols)
            {
                password += symbols[rand.Next(0, symbols.Length)];
            }


            return password;
        }

        private static bool ConditionsAreValid(PasswordGenerationConditions conditions)
        {
            if (conditions.Length < MIN_PASSWORD_SIZE || conditions.Length > MAX_PASSWORD_SIZE)
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
