using System;

namespace DataManagerDomain
{
    public class PasswordGenerationConditions
    {
        private int length;
        public int Length
        {
            get { return length; }
            set
            {
                length = value;
            }
        }
        private bool hasUpperCase;
        public bool HasUpperCase
        {
            get { return hasUpperCase; }
            set
            {
                hasUpperCase = value;
            }
        }
        private bool hasLowerCase;
        public bool HasLowerCase
        {
            get { return hasLowerCase; }
            set
            {
                hasLowerCase = value;
            }
        }
        private bool hasDigits;
        public bool HasDigits
        {
            get { return hasDigits; }
            set
            {
                hasDigits = value;
            }
        }
        private bool hasSymbols;
        public bool HasSymbols
        {
            get { return hasSymbols; }
            set
            {
                hasSymbols = value;
            }
        }
        public int NumberOfConditions
        {
            get { return CalulateNumberOfConditions(); }
        }

        private int CalulateNumberOfConditions()
        {
            return Convert.ToInt32(HasLowerCase) + Convert.ToInt32(HasUpperCase) + Convert.ToInt32(HasDigits) + Convert.ToInt32(HasSymbols);
        }
    }
}
