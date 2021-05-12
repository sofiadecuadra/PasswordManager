using System;

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

        public string NumberFormatted
        {
            get { return FormatNumber(Number); }
        }

        public NormalCategory Category { get; set; }

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

        public static string FormatNumber(string creditCardNumber)
        {
            creditCardNumber = RemoveAllBlankSpaces(creditCardNumber);
            return AddBlankSpacesAfter4Characters(creditCardNumber);
        }

        private static string AddBlankSpacesAfter4Characters(string creditCardNumber)
        {
            creditCardNumber = AddFirstBlankSpace(creditCardNumber);
            creditCardNumber = AddSecondBlankSpace(creditCardNumber);
            creditCardNumber = AddThirdBlankSpace(creditCardNumber);
            return creditCardNumber;
        }

        private const int POSTITION_TO_INSERT_FIRST_BLANK_SPACE = 4;
        private static string AddFirstBlankSpace(string creditCardNumber)
        {
            if (creditCardNumber.Length > POSTITION_TO_INSERT_FIRST_BLANK_SPACE)
            {
                creditCardNumber = creditCardNumber.Insert(POSTITION_TO_INSERT_FIRST_BLANK_SPACE, " ");
            }
            return creditCardNumber;
        }

        private const int POSTITION_TO_INSERT_SECOND_BLANK_SPACE = 9;
        private static string AddSecondBlankSpace(string creditCardNumber)
        {
            if (creditCardNumber.Length > POSTITION_TO_INSERT_SECOND_BLANK_SPACE)
            {
                creditCardNumber = creditCardNumber.Insert(POSTITION_TO_INSERT_SECOND_BLANK_SPACE, " ");
            }
            return creditCardNumber;
        }

        private const int POSTITION_TO_INSERT_THIRD_BLANK_SPACE = 14;
        private static string AddThirdBlankSpace(string creditCardNumber)
        {
            if (creditCardNumber.Length > POSTITION_TO_INSERT_THIRD_BLANK_SPACE)
            {
                creditCardNumber = creditCardNumber.Insert(POSTITION_TO_INSERT_THIRD_BLANK_SPACE, " ");
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

        public override string ToString()
        {
            return "[" + Name + "] [" + Type + "] [" + FormatNumber(Number) + "]";
        }
    }
}
