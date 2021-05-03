using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorPasswordsDominio
{
    public class PasswordGenerationConditions
    {
        private int length;
        public int Length {
            get { return length; }
            set {
                length = value;
                CalulateNumberOfConditions();
            } 
        }

        private bool hasUpperCase;

        public bool HasUpperCase
        {
            get { return hasUpperCase; }
            set
            {
                hasUpperCase = value;
                CalulateNumberOfConditions();
            }
        }

        private bool hasLowerCase;

        public bool HasLowerCase
        {
            get { return hasLowerCase; }
            set
            {
                hasLowerCase = value;
                CalulateNumberOfConditions();
            }
        }

        private bool hasDigits;

        public bool HasDigits
        {
            get { return hasDigits; }
            set
            {
                hasDigits = value;
                CalulateNumberOfConditions();
            }
        }

        private bool hasSymbols;

        public bool HasSymbols
        {
            get { return hasSymbols; }
            set
            {
                hasSymbols = value;
                CalulateNumberOfConditions();
            }
        }

        public int NumberOfConditions { get; private set; }

        private void CalulateNumberOfConditions()
        {
            NumberOfConditions = Convert.ToInt32(HasLowerCase) + Convert.ToInt32(HasUpperCase) + Convert.ToInt32(HasDigits) + Convert.ToInt32(HasSymbols);
        }
    }

}
