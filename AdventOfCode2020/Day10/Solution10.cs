using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdventOfCode2020.Extensions;

namespace AdventOfCode2020.Day10
{
    public static class Solution10
    {
        private static Task<IEnumerable<long>> ReadInputAsync() => InputReader.ReadLinesAsLongsAsync("Day10/input.txt");

        private static long[] GetOrderedAdaptersIncludingOutletAndDevice(IEnumerable<long> numbers)
        {
            var sortedAdapterJoltages = numbers.OrderBy(x => x).ToList();
            sortedAdapterJoltages.Insert(0, 0);
            sortedAdapterJoltages.Add(sortedAdapterJoltages.Last() + 3);
            return sortedAdapterJoltages.ToArray();
        }

        #region Problem One

        public static async Task<long> ProblemOneAsync(IEnumerable<long> numbers = null)
        {
            numbers ??= await ReadInputAsync();

            var sortedAdapterJoltages = GetOrderedAdaptersIncludingOutletAndDevice(numbers);

            var diffOneCount = 0;
            var diffThreeCount = 0;
            for (var i = 1; i < sortedAdapterJoltages.Length; i++)
            {
                switch (sortedAdapterJoltages[i] - sortedAdapterJoltages[i - 1])
                {
                    case 1:
                        diffOneCount++;
                        break;
                    case 3:
                        diffThreeCount++;
                        break;
                }
            }

            return diffOneCount * diffThreeCount;
        }

        #endregion


        #region Problem Two

        public static async Task<long> ProblemTwoAsync(IEnumerable<long> numbers = null)
        {
            numbers ??= await ReadInputAsync();

            var sortedAdapterJoltages = GetOrderedAdaptersIncludingOutletAndDevice(numbers);

            var possiblePathsFromAdapter = new long[sortedAdapterJoltages.Length];
            possiblePathsFromAdapter[0] = 1;
            foreach (var i in Enumerable.Range(1, sortedAdapterJoltages.Length - 1))
            {
                foreach (var j in Enumerable.Range(0, i))
                {
                    if (sortedAdapterJoltages[i] - sortedAdapterJoltages[j] <= 3)
                    {
                        possiblePathsFromAdapter[i] += possiblePathsFromAdapter[j];
                    }
                }
            }
            return possiblePathsFromAdapter[0];
        }

        #endregion
    }
}
