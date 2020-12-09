using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdventOfCode2020.Day04
{
    public static class Solution04
    {
        private static Task<IEnumerable<IEnumerable<string>>> ReadInputAsync() => InputReader.ReadBlocksBetweenEmptyLinesAsync("Day04/input.txt");

        #region Problem One

        public static async Task<long> ProblemOneAsync(IEnumerable<IEnumerable<string>> blocks = null)
        {
            blocks ??= await ReadInputAsync();
            return blocks.Select(Passport.ParseFromLines).Count(passport => passport.HasNecessaryFields());
        }

        #endregion

        #region Problem Two

        public static async Task<long> ProblemTwoAsync(IEnumerable<IEnumerable<string>> blocks = null)
        {
            blocks ??= await ReadInputAsync();
            return blocks.Select(Passport.ParseFromLines).Count(passport => passport.IsValid());
        }

        #endregion
    }
}
