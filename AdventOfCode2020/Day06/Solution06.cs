using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdventOfCode2020.Day06
{
    public static class Solution06
    {
        private static Task<IEnumerable<IEnumerable<string>>> ReadInputAsync() => InputReader.ReadBlocksBetweenEmptyLinesAsync("Day06/input.txt");


        #region Problem One

        public static async Task<int> ProblemOneAsync(IEnumerable<IEnumerable<string>> blocks = null)
        {
            blocks ??= await ReadInputAsync();
            return blocks.Sum(CountUniqueCharactersInLines);
        }

        private static int CountUniqueCharactersInLines(IEnumerable<string> lines)
            => lines
                .SelectMany(line => line)
                .Distinct()
                .Count();

        #endregion

        #region Problem Two

        public static async Task<int> ProblemTwoAsync(IEnumerable<IEnumerable<string>> blocks = null)
        {
            blocks ??= await ReadInputAsync();
            return blocks.Sum(CountSameAnsweredQuestions);
        }

        private static int CountSameAnsweredQuestions(IEnumerable<string> block)
            => block
                .Aggregate("abcdefghijklmnopqrstuvwxyz",
                    (current, value) =>
                        new string(current.Intersect(value).ToArray()))
                .Length;

        #endregion
    }
}
