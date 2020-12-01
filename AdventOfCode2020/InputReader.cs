using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace AdventOfCode2020
{
    public static class InputReader
    {
        public static async Task<int[]> ReadLinesAsIntegersAsync(string filename)
        {
            var lines = await File.ReadAllTextAsync(filename);
            return lines
                .Split('\r', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries)
                .Select(x => Convert.ToInt32(x))
                .ToArray();
        }
    }
}