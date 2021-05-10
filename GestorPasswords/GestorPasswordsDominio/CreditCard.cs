using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace GestorPasswordsDominio
{
    public class CreditCard
    {
        private string number;
        public string Number
        {
            get { return number; }
            set {
                HideNumber = NumberHiding(value);
                number = RemoveAllBlankSpaces(value);
            }
        }
        public string HideNumber { get; private set; }
        public string Type { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string Notes { get; set; }
        private DateTime expirationDate;
        public DateTime ExpirationDate
        {
            get { return expirationDate; }
            set
            {
                int lastDayOfMonth = DateTime.DaysInMonth(value.Year, value.Month);
                expirationDate = new DateTime (value.Year, value.Month, lastDayOfMonth);
            }
        }
        public Category Category { get; set; }

        override
        public string ToString()
        {
            return $"[{Name}] [{Type}] [{AddBlankSpacesAfter4Characters(Number)}]";
        }

        public static string FormatNumber(string creditCardNumber)
        {
            creditCardNumber = RemoveAllBlankSpaces(creditCardNumber);
            return AddBlankSpacesAfter4Characters(creditCardNumber);
        }

        private static string AddBlankSpacesAfter4Characters(string creditCardNumber)
        {
            if (creditCardNumber.Length >= 5)
            {
                creditCardNumber = creditCardNumber.Insert(4, " ");
            }
            if (creditCardNumber.Length >= 10)
            {
                creditCardNumber = creditCardNumber.Insert(9, " ");
            }
            if (creditCardNumber.Length >= 15)
            {
                creditCardNumber = creditCardNumber.Insert(14, " ");
            }

            return creditCardNumber;
        }

        private static string RemoveAllBlankSpaces(string creditCardNumber)
        {
            return creditCardNumber.Replace(" ", string.Empty);
        }

        private const int LAST_4_DIGITS_START_POSITION = 15;
        private string NumberHiding(string creditCardNumber)
        {
            string formattedNumber = FormatNumber(creditCardNumber);
            string last4digits = formattedNumber.Substring(LAST_4_DIGITS_START_POSITION);
            return "XXXX XXXX XXXX " + last4digits;
        }

        public bool CreditCardDataIsValid()
        {
            if (!LengthBetween3And25(Name))
            {
                throw new ExceptionCreditCardHasInvalidNameLength($"The name's length must be between 3 and 25, but it's current length is: {Name.Length}");
            }
            if (!LengthBetween3And25(Type))
            {
                throw new ExceptionCreditCardHasInvalidTypeLength($"The type's length must be between 3 and 25, but it's current length is:  {Type.Length}");
            }
            if (!ContainNumericCharactersOnly(Number))
            {
                throw new ExceptionCreditCardDoesNotContainOnlyDigits($"The number must contain numeric characters only, but it is: {Number}");
            }
            if (!CreditCardNumberHasValidLength())
            {
                throw new ExceptionCreditCardHasInvalidNumberLength($"The credit card number must contain 16 digits, but currently it has: {Number.Length}");
            }
            if (!CodeHasValidLength())
            {
                throw new ExceptionCreditCardHasInvalidCodeLength($"The code's length must be between 3 and 4, but it's current length is: {Code.Length}");
            }
            if (!ContainNumericCharactersOnly(Code))
            {
                throw new ExceptionCreditCardCodeHasNonNumericCharacters($"The code must contain numeric characters only, but it is: {Code}");
            }
            if (!NotesHaveValidLength())
            {
                throw new ExceptionCreditCardHasInvalidNotesLength($"The notes' length must be up to 250, but it's current length is: {Notes.Length}");
            }
            if (CreditCardHasExpired())
            {
                throw new ExceptionCreditCardHasExpired($"The credit card must be valid, but it has expired in {ExpirationDate.Month}  / {ExpirationDate.Year}");
            }
            return true;
        }

        private static bool LengthBetween3And25(string stringToCheck)
        {
            return stringToCheck.Length >= 3 && stringToCheck.Length <= 25;
        }

        private bool CodeHasValidLength()
        {
            return Code.Length == 3 || Code.Length == 4;
        }

        private static bool ContainNumericCharactersOnly(string stringToCheck)
        {
            return Regex.IsMatch(stringToCheck, @"^[0-9]+$");
        }

        private bool CreditCardNumberHasValidLength()
        {
            return Number.Length == 16;
        }

        private bool NotesHaveValidLength()
        {
            return Notes.Length <= 250;
        }

        private bool CreditCardHasExpired()
        {
            return ExpirationDate < DateTime.Now;
        }

    }
}
