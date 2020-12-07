using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AdventOfCode2020.Day07
{
    public static class Solution07
    {
        private const string MyBagColor = "shiny gold";

        private static Task<IEnumerable<string>> ReadInputAsync() => InputReader.ReadLinesAsync("Day07/input.txt");

        private static readonly Regex LineParseRegex = new(@"(?<Color>.*?) bags contain(?: (?<Bag>\d+ .*?) bags?[,.])*");

        private record Bag(string Color, IDictionary<string, int> Children);

        private static Dictionary<string, Dictionary<string, int>> BagsWithChildren(IEnumerable<string> lines)
        {
            return lines
                .Select(line => LineParseRegex.Match(line))
                .ToDictionary(
                    match => match.Groups["Color"].Value,
                    match => match.Groups["Bag"].Captures
                        .Select(capture => capture.Value.Split(new[] { ' ' }, 2))
                        .ToDictionary(
                            splitCaptureValue => splitCaptureValue[1],
                            splitCaptureValue => int.Parse(splitCaptureValue[0])
                        )
                );
        }


        #region Problem One

        private static bool IsOrHasColoredBag(Dictionary<string, Dictionary<string, int>> bags, string color)
            => bags[color].ContainsKey(MyBagColor) || bags[color].Keys.Any(color => IsOrHasColoredBag(bags, color));

        public static async Task<int> ProblemOneAsync(IEnumerable<string> lines = null)
        {
            lines ??= await ReadInputAsync();

            var bags = BagsWithChildren(lines);
            return bags.Keys.Count(color => IsOrHasColoredBag(bags, color));
        }

        #endregion


        #region Problem Two

        private static int SumBagsOfColorsRecursively(Dictionary<string, Dictionary<string, int>> bags, string color)
            => bags[color].Sum(line => line.Value * (1 + SumBagsOfColorsRecursively(bags, line.Key)));

        public static async Task<int> ProblemTwoAsync(IEnumerable<string> lines = null)
        {
            lines ??= await ReadInputAsync();

            return SumBagsOfColorsRecursively(BagsWithChildren(lines), MyBagColor);
        }


        #endregion
    }
}
