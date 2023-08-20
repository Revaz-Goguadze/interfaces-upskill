using System;
using FilterByPredicate;

namespace FilterByPalindromic
{
    /// <summary>
    /// Palindrome predicate.
    /// </summary>
    public class ByPalindromicPredicate : IPredicate
    {
        /// <inheritdoc/>
        public bool IsMatch(int number)
        {
            int div = (int)Math.Pow(10, GetNumLength(number) - 1);

            while (number != 0)
            {
                int firstDigit = number / div;
                int lastDigit = number % 10;

                if ((firstDigit != lastDigit) || (number < 0))
                {
                    return false;
                }

                number = (number % div) / 10;
                div /= 100;
            }

            return true;
        }

        private static int GetNumLength(int num)
        {
            int length = 0;
            while (num != 0)
            {
                num /= 10;
                length++;
            }

            return length;
        }
    }
}
