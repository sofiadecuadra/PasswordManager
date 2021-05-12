using System;
using System.Text.RegularExpressions;

namespace GestorPasswordsDominio
{
    public class CreditCard
    {
        private const int LAST_4_DIGITS_START_POSITION = 15;
        private const int MIN_TEXT_FIELD_LENGTH = 3;
        private const int MAX_TEXT_FIELD_LENGTH = 25;
        private const int MAX_NOTES_LENGTH = 250;
        private const int MIN_CODE_LENGTH = 3;
        private const int MAX_CODE_LENGTH = 4;
        private const int CREDIT_CARD_LENGTH = 16;
        private const int POSTITION_TO_INSERT_FIRST_BLANK_SPACE = 4;
        private const int POSTITION_TO_INSERT_SECOND_BLANK_SPACE = 9;
        private const int POSTITION_TO_INSERT_THIRD_BLANK_SPACE = 14;

        private string number;
        public string Number
        {
            get { return number; }
            set
            {
                HideNumber = NumberHiding(value);
                number = RemoveAllBlankSpaces(value);
            }
        }
        public string NumberFormatted
        {
            get { return FormatNumber(Number); }
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
                expirationDate = new DateTime(value.Year, value.Month, lastDayOfMonth);
            }
        }
        public NormalCategory Category { get; set; }

        public override string ToString()
        {
            return $"[{Name}] [{Type}] [{AddBlankSpacesAfter4Characters(Number)}]";
        }

        public static string FormatNumber(string creditCardNumber)
        {
            creditCardNumber = RemoveAllBlankSpaces(creditCardNumber);
            return AddBlankSpacesAfter4Characters(creditCardNumber);
        }

        private static string RemoveAllBlankSpaces(string creditCardNumber)
        {
            return creditCardNumber.Replace(" ", string.Empty);
        }

        private static string AddBlankSpacesAfter4Characters(string creditCardNumber)
        {
            creditCardNumber = AddFirstBlankSpace(creditCardNumber);
            creditCardNumber = AddSecondBlankSpace(creditCardNumber);
            return AddThirdBlankSpace(creditCardNumber);
        }

        private static string AddFirstBlankSpace(string creditCardNumber)
        {
            if (FirstBlankSpaceMustBeAdded(creditCardNumber))
            {
                creditCardNumber = creditCardNumber.Insert(POSTITION_TO_INSERT_FIRST_BLANK_SPACE, " ");
            }
            return creditCardNumber;
        }

        private static bool FirstBlankSpaceMustBeAdded(string creditCardNumber)
        {
            return creditCardNumber.Length > POSTITION_TO_INSERT_FIRST_BLANK_SPACE;
        }

        private static string AddSecondBlankSpace(string creditCardNumber)
        {
            if (SecondBlankSpaceMustBeAdded(creditCardNumber))
            {
                creditCardNumber = creditCardNumber.Insert(POSTITION_TO_INSERT_SECOND_BLANK_SPACE, " ");
            }
            return creditCardNumber;
        }

        private static bool SecondBlankSpaceMustBeAdded(string creditCardNumber)
        {
            return creditCardNumber.Length > POSTITION_TO_INSERT_SECOND_BLANK_SPACE;
        }

        private static string AddThirdBlankSpace(string creditCardNumber)
        {
            if (ThirdBlankSpaceMustBeAdded(creditCardNumber))
            {
                creditCardNumber = creditCardNumber.Insert(POSTITION_TO_INSERT_THIRD_BLANK_SPACE, " ");
            }
            return creditCardNumber;
        }

        private static bool ThirdBlankSpaceMustBeAdded(string creditCardNumber)
        {
            return creditCardNumber.Length > POSTITION_TO_INSERT_THIRD_BLANK_SPACE;
        }

        private string NumberHiding(string creditCardNumber)
        {
            string formattedNumber = FormatNumber(creditCardNumber);
            CheckNumberContent(RemoveAllBlankSpaces(formattedNumber));
            CheckNumberLength(RemoveAllBlankSpaces(formattedNumber));
            string last4digits = formattedNumber.Substring(LAST_4_DIGITS_START_POSITION);
            return "XXXX XXXX XXXX " + last4digits;
        }

        private void CheckNumberContent(string creditCardNumber)
        {
            if (!ContainNumericCharactersOnly(creditCardNumber))
            {
                throw new ExceptionCreditCardDoesNotContainOnlyDigits($"The number must contain numeric characters only, but it is: {creditCardNumber}");
            }
        }

        private void CheckNumberLength(string creditCardNumber)
        {
            if (!CreditCardNumberHasValidLength(creditCardNumber))
            {
                throw new ExceptionIncorrectLength($"The credit card number must contain 16 digits, but currently it has: {creditCardNumber.Length}");
            }
        }

        public bool CreditCardDataIsValid()
        {
            CheckNameLength();
            CheckTypeLength();
            CheckCodeLength();
            CheckCodeContent();
            CheckNotesLength();
            CheckExpirationDate();
            return true;
        }

        private void CheckNameLength()
        {
            if (!LengthValid(Name))
            {
                throw new ExceptionIncorrectLength($"The name's length must be between 3 and 25, but it's current length is: {Name.Length}");
            }
        }

        private static bool LengthValid(string stringToCheck)
        {
            return stringToCheck.Length >= MIN_TEXT_FIELD_LENGTH && stringToCheck.Length <= MAX_TEXT_FIELD_LENGTH;
        }

        private void CheckTypeLength()
        {
            if (!LengthValid(Type))
            {
                throw new ExceptionIncorrectLength($"The type's length must be between 3 and 25, but it's current length is:  {Type.Length}");
            }
        }

        private static bool ContainNumericCharactersOnly(string stringToCheck)
        {
            return Regex.IsMatch(stringToCheck, @"^[0-9]+$");
        }

        private bool CreditCardNumberHasValidLength(string stringToCheck)
        {
            return stringToCheck.Length == CREDIT_CARD_LENGTH;
        }

        private void CheckCodeLength()
        {
            if (!CodeHasValidLength())
            {
                throw new ExceptionIncorrectLength($"The code's length must be between 3 and 4, but it's current length is: {Code.Length}");
            }
        }

        private bool CodeHasValidLength()
        {
            return Code.Length == MIN_CODE_LENGTH || Code.Length == MAX_CODE_LENGTH;
        }

        private void CheckCodeContent()
        {
            if (!ContainNumericCharactersOnly(Code))
            {
                throw new ExceptionCreditCardCodeHasNonNumericCharacters($"The code must contain numeric characters only, but it is: {Code}");
            }
        }

        private void CheckNotesLength()
        {
            if (!NotesHaveValidLength())
            {
                throw new ExceptionIncorrectLength($"The notes' length must be up to 250, but it's current length is: {Notes.Length}");
            }
        }

        private bool NotesHaveValidLength()
        {
            return Notes.Length <= MAX_NOTES_LENGTH;
        }

        private void CheckExpirationDate()
        {
            if (CreditCardHasExpired())
            {
                throw new ExceptionCreditCardHasExpired($"The credit card must be valid, but it has expired in {ExpirationDate.Month}  / {ExpirationDate.Year}");
            }
        }

        private bool CreditCardHasExpired()
        {
            return ExpirationDate < DateTime.Now;
        }
    }
}

