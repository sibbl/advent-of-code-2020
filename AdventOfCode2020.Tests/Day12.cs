using System.Threading.Tasks;
using AdventOfCode2020.Day12;
using Xunit;

namespace AdventOfCode2020.Tests
{
    public class Day12
    {
        private static readonly string[] WebsiteSample = { "F10", "N3", "F7", "R90", "F11" };

        [Fact]
        public async Task ProblemOne_ReturnsExpectedResult_WhenEnteringSampleFromWebsite()
        {
            var output = await Solution12.ProblemOneAsync(WebsiteSample);
            Assert.Equal(25, output);
        }

        [Fact]
        public async Task ProblemTwo_ReturnsExpectedResult_WhenEnteringSampleFromWebsite()
        {
            var output = await Solution12.ProblemTwoAsync(WebsiteSample);
            Assert.Equal(286, output);
        }
    }
}
