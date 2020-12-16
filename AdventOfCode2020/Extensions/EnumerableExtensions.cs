using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2020.Extensions
{
    public static class EnumerableExtensions
    {
        /// <summary>
        /// Finds two distinct addends in the list, which add up to the target sum.
        /// </summary>
        /// <param name="enumerable">List to find addends in</param>
        /// <param name="targetSum">Target sum to find two addends for</param>
        /// <param name="addendOne">Addend occurring first</param>
        /// <param name="addendTwo">Addend occurring last</param>
        /// <returns>True if two addends were found, false if not</returns>
        public static bool TryFindFirstTwoAddends(this IEnumerable<long> enumerable, long targetSum, out long addendOne, out long addendTwo)
        {
            var array = enumerable.ToArray();

            for (var i = 0; i < array.Length; i++)
            {
                for (var j = i + 1; j < array.Length; j++)
                {
                    var sum = (dynamic)array[i] + array[j];
                    if (sum == targetSum)
                    {
                        addendOne = array[i];
                        addendTwo = array[j];
                        return true;
                    }
                }
            }

            addendOne = addendTwo = default;
            return false;
        }

        public static long Multiply(this IEnumerable<long> enumerable)
            => enumerable.Aggregate(1L, (a, b) => a * b);
        public static long Multiply<T>(this IEnumerable<T> enumerable, Func<T, long> filter)
            => enumerable.Select(filter).Aggregate(1L, (a, b) => a * b);
        public static long Multiply<T>(this IEnumerable<T> enumerable, Func<T, int, long> filter)
            => enumerable.Select(filter).Aggregate(1L, (a, b) => a * b);
    }
}
