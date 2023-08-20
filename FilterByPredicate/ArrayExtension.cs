using System;
using System.Collections.Generic;

namespace FilterByPredicate
{
    /// <summary>
    /// Returns new array of elements that contain elements that correspond given predicate only.
    /// </summary>
    public static class ArrayExtension
    {
        /// <summary>
        /// Returns new array of elements that contain elements that correspond given predicate only.
        /// </summary>
        /// <param name="source">Source array.</param>
        /// <param name="predicate">Predicate.</param>
        /// <returns>Array of elements that correspond given predicate only.</returns>
        /// <exception cref="ArgumentNullException">Thrown when array is null.</exception>
        /// <exception cref="ArgumentException">Thrown when array is empty.</exception>
        /// <exception cref="ArgumentNullException">Thrown when predicate is null.</exception>
        public static int[] Select(this int[]? source, IPredicate? predicate)
        {
            if (predicate == null)
            {
                throw new ArgumentNullException(nameof(predicate));
            }

            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            if (source.Length == 0)
            {
                throw new ArgumentException("Array cannot be empty", nameof(source));
            }

            List<int> result = new List<int>();

            for (var i = 0; i < source.Length; i++)
            {
                var item = source[i];
                if (predicate.IsMatch(item))
                {
                    result.Add(item);
                }
            }

            return result.ToArray();
        }
    }
}
