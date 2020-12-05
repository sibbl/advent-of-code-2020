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
        {
            var binaryLine = line.ReplaceCharactersInString(BitReplacementMap);
            var row = binaryLine[..7].ToIntegerFromBinary();
            var column = binaryLine[7..].ToIntegerFromBinary();
            return row * 8 + column;
        }

        #region Problem One

        public static async Task<int> ProblemOneAsync(IEnumerable<string> lines = null)
        {
            lines ??= await ReadInputAsync();
            return lines.Select(CalculateSeatId).Max();
        }

        #endregion

        #region Problem Two

        public static async Task<int> ProblemTwoAsync(IEnumerable<string> lines = null)
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
