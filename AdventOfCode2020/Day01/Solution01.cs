using System;
using System.Linq;
using System.Threading.Tasks;
using AdventOfCode2020.Extensions;

namespace AdventOfCode2020.Day01
{
    public static class Solution01
    {
        private static async Task<long[]> ReadInputAsync() => (await InputReader.ReadLinesAsLongsAsync("Day01/input.txt")).ToArray();

        #region Problem One

        public static async Task<long> ProblemOneAsync(long[] input = null)
        {
            input ??= await ReadInputAsync();

            if (input.TryFindFirstTwoAddends(2020, out var addendOne, out var addendTwo))
            {
                return addendOne * addendTwo;
            }

            throw new Exception("No solution found");
        }

        #endregion

        #region Problem Two

        public static async Task<long> ProblemTwoAsync(long[] input = null)
        {
            input ??= await ReadInputAsync();
            for (var i = 0; i < input.Length; i++)
            {
                var addendOne = input[i];

                if (input.TryFindFirstTwoAddends(2020 - addendOne, out var addendTwo, out var addendThree))
                {
                    return addendOne * addendTwo * addendThree;
                }
            }

            throw new Exception("No solution found");
        }

        #endregion
    }
}
