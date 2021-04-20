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
                throw new IncorrectLengthException($"Length should be between 5 and 25 characters but is: {passwordToCheck.Length}");
            }
            if (ContainsLessThan8Characters(passwordToCheck)) return PasswordStrengthType.Red;
            if (ContainsBetween8And14Characters(passwordToCheck)) return PasswordStrengthType.Orange;
            if (ContainsJustUpperAndLowerCaseSymbolsAndNumbers(passwordToCheck)) return PasswordStrengthType.DarkGreen;

            bool isLightGreen = ContainsJustUpperAndLowerCase(passwordToCheck) || ContainsJustUpperAndLowerCaseAndSymbolsOrNumbers(passwordToCheck);
            if (isLightGreen) return PasswordStrengthType.LightGreen;
            bool isYellow = ContainsJustUpperOrLowerCase(passwordToCheck)
                            || ContainsJustSymbolsAndNumbers(passwordToCheck)
                            || ContainsJustUpperOrLowerCaseAndSymbolsOrNumbers(passwordToCheck);
            if (isYellow) return PasswordStrengthType.Yellow;

            return PasswordStrengthType.Red;
        }

        private static bool ContainsJustUpperOrLowerCaseAndSymbolsOrNumbers(string passwordToCheck)
        {
            return Regex.IsMatch(passwordToCheck, @"(?=^.{14,}$)((?=.*((\d)|(\W))+))(?![.\n])(?=.*([A-Z])|([a-z])).*$");
        }

        private static bool ContainsJustSymbolsAndNumbers(string passwordToCheck)
        {
            return Regex.IsMatch(passwordToCheck, @"(?=^.{14,}$)((?=.*\d)(?=.*\W+))(?![.\n]).*$");
        }

        private static bool ContainsJustUpperAndLowerCaseAndSymbolsOrNumbers(string passwordToCheck)
        {
            return Regex.IsMatch(passwordToCheck, @"(?=^.{14,}$)((?=.*((\d)|(\W))+))(?![.\n])(?=.*[A-Z])(?=.*[a-z]).*$");
        }

        private static bool ContainsJustUpperAndLowerCaseSymbolsAndNumbers(string passwordToCheck)
        {
            return Regex.IsMatch(passwordToCheck, @"(?=^.{14,}$)((?=.*\d)(?=.*\W+))(?![.\n])(?=.*[A-Z])(?=.*[a-z]).*$");
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
