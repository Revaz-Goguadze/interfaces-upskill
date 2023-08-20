using System;

namespace ArrayExtensions
{
    /// <summary>
    /// Class of the additional operations with array.
    /// </summary>
    public static class ArrayExtension
    {
        /// <summary>
        /// Returns new array of elements that contain expected digit from source array.
        /// </summary>
        /// <param name="source">Source array.</param>
        /// <param name="digit">Expected digit.</param>
        /// <returns>Array of elements that contain expected digit.</returns>
        /// <exception cref="ArgumentNullException">Thrown when array is null.</exception>
        /// <exception cref="ArgumentException">Thrown when array is empty.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when digit value is out of range (0..9).</exception>
        /// <example>
        /// {1, 2, 3, 4, 5, 6, 7, 68, 69, 70, 15, 17}  => { 7, 70, 17 } for digit = 7.
        /// </example>
        public static int[] FilterByDigit(this int[]? source, int digit)
        {
            if (digit is < 0 or > 9)
            {
                throw new ArgumentOutOfRangeException(nameof(digit), "Сan not be less than zero or more then 9.");
            }

            CheckForNull(source!);

            List<int> result = new List<int>();

            for (var i = 0; i < source!.Length; i++)
            {
                var item = source[i];
                if (IsMatch(item))
                {
                    result.Add(item);
                }
            }

            return result.ToArray();

            bool IsMatch(int value)
            {
                long longValue = value;

                if (digit == 0 && longValue == 0)
                {
                    return true;
                }

                longValue = (longValue < 0) ? -longValue : longValue;

                for (; longValue != 0; longValue /= 10)
                {
                    if (longValue % 10 == digit)
                    {
                        return true;
                    }
                }

                return false;
            }
        }

        /// <summary>
        /// Returns new array that contains only palindromic numbers from source array.
        /// </summary>
        /// <param name="source">Source array.</param>
        /// <returns>Array of elements that are palindromic numbers.</returns>
        /// <exception cref="ArgumentNullException">Throw when array is null.</exception>
        /// <exception cref="ArgumentException">Throw when array is empty.</exception>
        /// <example>
        /// {12345, 1111111112, 987654, 56, 1111111, -1111, 1, 1233321, 70, 15, 123454321}  => { 1111111, 123321, 123454321 }
        /// {56, -1111111112, 987654, 56, 890, -1111, 543, 1233}  => {  }.
        /// </example>
        public static int[] FilterByPalindromic(this int[]? source)
        {
            CheckForNull(source!);

            List<int> result = new List<int>();

            for (var i = 0; i < source!.Length; i++)
            {
                var item = source[i];
                if (IsMatch(item))
                {
                    result.Add(item);
                }
            }

            return result.ToArray();

            bool IsMatch(int value)
            {
                long longValue = value;

                int div = (int)Math.Pow(10, GetNumLength(value) - 1);

                // ReSharper disable once LoopVariableIsNeverChangedInsideLoop
                while (value != 0)
                {
                    long firstDigit = longValue / div;
                    long lastDigit = longValue % 10;

                    if ((firstDigit != lastDigit) || (longValue < 0))
                    {
                        return false;
                    }

                    longValue = (longValue % div) / 10;
                    div /= 100;
                }

                return true;
            }

            int GetNumLength(int num)
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

        /// <summary>
        /// Check souse array for nul adn empty.
        /// </summary>
        /// <param name="source">Source array.</param>
        /// <exception cref="ArgumentNullException">Throw when array is null.</exception>
        /// <exception cref="ArgumentException">Throw when array is empty.</exception>
        private static void CheckForNull(int[] source)
        {
            if (source is null)
            {
                throw new ArgumentNullException(nameof(source), "Array is null");
            }

            if (source.Length == 0)
            {
                throw new ArgumentException("Array is empty", nameof(source));
            }
        }
    }
}
