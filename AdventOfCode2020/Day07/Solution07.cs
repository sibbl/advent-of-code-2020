using System.Collections.Generic;
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

        private static bool IsOrHasMyColoredBag(Dictionary<string, Dictionary<string, int>> bags, string color)
            => bags[color].ContainsKey(MyBagColor) || bags[color].Keys.Any(childColor => IsOrHasMyColoredBag(bags, childColor));

        public static async Task<long> ProblemOneAsync(IEnumerable<string> lines = null)
        {
            lines ??= await ReadInputAsync();

            var bags = BagsWithChildren(lines);
            return bags.Keys.Count(color => IsOrHasMyColoredBag(bags, color));
        }

        #endregion


        #region Problem Two

        private static int SumBagsOfColorsRecursively(Dictionary<string, Dictionary<string, int>> bags, string color)
            => bags[color].Sum(line => line.Value * (1 + SumBagsOfColorsRecursively(bags, line.Key)));

        public static async Task<long> ProblemTwoAsync(IEnumerable<string> lines = null)
        {
            lines ??= await ReadInputAsync();

            return SumBagsOfColorsRecursively(BagsWithChildren(lines), MyBagColor);
        }

        #endregion
    }
}
