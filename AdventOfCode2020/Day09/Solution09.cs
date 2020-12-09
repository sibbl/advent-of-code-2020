using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdventOfCode2020.Extensions;

namespace AdventOfCode2020.Day09
{
    public static class Solution09
    {
        private static Task<IEnumerable<long>> ReadInputAsync() => InputReader.ReadLinesAsLongsAsync("Day09/input.txt");

        private static bool TryFindInvalidNumber(long[] numbers, int preambleLength, out long value, out int index)
        {
            var numbersArray = numbers.ToArray();

            for (var i = preambleLength; i < numbersArray.Length; i++)
            {
                var window = numbersArray[(i - preambleLength)..i];
                value = numbersArray[i];
                if (window.TryFindFirstTwoAddends(value, out _, out _) == false)
                {
                    index = i;
                    return true;
                }
            }

            value = default;
            index = default;
            return false;
        }

        #region Problem One

        public static async Task<long> ProblemOneAsync(IEnumerable<long> numbers = null, int preambleLength = 25)
        {
            numbers ??= await ReadInputAsync();

            var numbersArray = numbers.ToArray();

            if (TryFindInvalidNumber(numbersArray, preambleLength, out var value, out _))
            {
                return value;
            }

            return -1;
        }

        #endregion


        #region Problem Two

        public static async Task<long> ProblemTwoAsync(IEnumerable<long> numbers = null, int preambleLength = 25)
        {
            numbers ??= await ReadInputAsync();

            var numbersArray = numbers.ToArray();
            if (TryFindInvalidNumber(numbersArray, preambleLength, out var value, out var index) == false)
            {
                return -1;
            }

            for (var i = 0; i < index; i++)
            {
                for (var j = i + 1; j < index; j++)
                {
                    var window = numbersArray[i..j];

                    if (window.Sum() == value)
                    {
                        return window.Min() + window.Max();
                    }
                }
            }

            return -1;
        }

        #endregion
    }
}
