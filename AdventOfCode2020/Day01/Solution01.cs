using System;
using System.Threading.Tasks;

namespace AdventOfCode2020.Day01
{
    public static class Solution01
    {
        private static Task<int[]> ReadInput() => InputReader.ReadLinesAsIntegersAsync("Day01/input.txt");

        public static async Task<int> ProblemOneAsync()
        {
            var input = await ReadInput();
            return await ProblemOneAsync(input);
        }

        public static Task<int> ProblemOneAsync(int[] input)
        {
            for (var i = 0; i < input.Length; i++)
            {
                for (var j = i + 1; j < input.Length; j++)
                {
                    var sum = input[i] + input[j];
                    if (sum == 2020)
                    {
                        return Task.FromResult(input[i] * input[j]);
                    }
                }
            }

            throw new Exception("No solution found");
        }
    }
}
