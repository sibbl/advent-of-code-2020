using System;
using System.Linq;
using System.Threading.Tasks;

namespace AdventOfCode2020.Day01
{
    public static class Solution01
    {
        private static async Task<int[]> ReadInputAsync() => (await InputReader.ReadLinesAsIntegersAsync("Day01/input.txt")).ToArray();

        #region Problem One

        public static async Task<int> ProblemOneAsync(int[] input = null)
        {
            input ??= await ReadInputAsync();
            for (var i = 0; i < input.Length; i++)
            {
                for (var j = i + 1; j < input.Length; j++)
                {
                    var sum = input[i] + input[j];
                    if (sum == 2020)
                    {
                        return input[i] * input[j];
                    }
                }
            }

            throw new Exception("No solution found");
        }

        #endregion

        #region Problem Two

        public static async Task<int> ProblemTwoAsync(int[] input = null)
        {
            input ??= await ReadInputAsync();
            for (var i = 0; i < input.Length; i++)
            {
                for (var j = i + 1; j < input.Length; j++)
                {
                    var partialSum = input[i] + input[j];

                    for (var k = j + 1; k < input.Length; k++)
                    {
                        var sum = partialSum + input[k];
                        if (sum == 2020)
                        {
                            return input[i] * input[j] * input[k];
                        }
                    }
                }
            }

            throw new Exception("No solution found");
        }

        #endregion
    }
}
