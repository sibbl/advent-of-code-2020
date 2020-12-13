using System.Threading.Tasks;
using AdventOfCode2020.Day13;
using Xunit;

namespace AdventOfCode2020.Tests
{
    public class Day13
    {
        private static readonly string[] WebsiteSample = { "939", "7,13,x,x,59,x,31,19" };

        [Fact]
        public async Task ProblemOne_ReturnsExpectedResult_WhenEnteringSampleFromWebsite()
        {
            var output = await Solution13.ProblemOneAsync(WebsiteSample);
            Assert.Equal(295, output);
        }

        [Theory]
        [InlineData(1068781, "7,13,x,x,59,x,31,19")]
        [InlineData(3417, "17,x,13,19")]
        [InlineData(754018, "67,7,59,61")]
        [InlineData(779210, "67,x,7,59,61")]
        [InlineData(1261476, "67,7,x,59,61")]
        [InlineData(1202161486, "1789,37,47,1889")]
        public async Task ProblemTwo_ReturnsExpectedResult_WhenEnteringSampleFromWebsite(long expected, string busIds)
        {
            var input = new[] { string.Empty, busIds };
            var output = await Solution13.ProblemTwoAsync(input);
            Assert.Equal(expected, output);
        }
    }
}
