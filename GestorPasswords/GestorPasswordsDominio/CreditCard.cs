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
                expirationDate = new DateTime (value.Year, value.Month, lastDayOfMonth);
            }
        }

        private string DisplayCreditCard()
        {
            string creditCardNumber = "";
            for(int i=1; i<=16; i++)
            {
                creditCardNumber += this.Number[i-1];
                if(i%4 == 0 && i!=16)
                {
                    creditCardNumber += " ";
                }
            }
            return creditCardNumber;
        }
        public NormalCategory Category { get; set; }

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

        override
            public string ToString()
        {
            return AddBlankSpacesAfter4Characters(Number);
        }
    }
}
