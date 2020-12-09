using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdventOfCode2020.Extensions;

namespace AdventOfCode2020.Day05
{
    public static class Solution05
    {
        private static Task<IEnumerable<string>> ReadInputAsync() => InputReader.ReadLinesAsync("Day05/input.txt");

        private static readonly Dictionary<char, char> BitReplacementMap = new()
        {
            { 'B', '1' },
            { 'F', '0' },
            { 'R', '1' },
            { 'L', '0' }
        };

        private static int CalculateSeatId(string line)
            => line.ReplaceCharactersInString(BitReplacementMap).ToIntegerFromBinary();

        #region Problem One

        public static async Task<long> ProblemOneAsync(IEnumerable<string> lines = null)
        {
            lines ??= await ReadInputAsync();
            return lines.Select(CalculateSeatId).Max();
        }

        #endregion

        #region Problem Two

        public static async Task<long> ProblemTwoAsync(IEnumerable<string> lines = null)
        {
            lines ??= await ReadInputAsync();

            var seatIds = lines
                .Select(CalculateSeatId)
                .OrderBy(seatId => seatId)
                .ToArray();

            return Enumerable.Range(seatIds.First(), seatIds.Last() - seatIds.First())
                .Except(seatIds)
                .First();
        }

        #endregion
    }
}
