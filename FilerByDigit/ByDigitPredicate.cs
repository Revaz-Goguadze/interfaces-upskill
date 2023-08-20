using System;
using FilterByPredicate;

namespace FilterByDigit
{
    /// <summary>
    /// Predicate that determines the presence of some digit in integer.
    /// </summary>
    public class ByDigitPredicate : IPredicate
    {
        private int digit;

        /// <summary>
        /// Gets or sets a digit.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when Digit more than 9 or less than 0.</exception>
        public int Digit
        {
            get => this.digit;
            set => this.digit = (value is < 0 or > 9) ? throw new ArgumentOutOfRangeException(nameof(value), "Сan not be less than zero or more then 9.") : value;
        }

        /// <inheritdoc/>
        public bool IsMatch(int number)
        {
            long longNumber = number;

            if (this.digit == 0 && longNumber == 0)
            {
                return true;
            }

            longNumber = (longNumber < 0) ? -longNumber : longNumber;

            for (; longNumber != 0; longNumber /= 10)
            {
                if (longNumber % 10 == this.digit)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
