using System.Linq;
using System.Threading.Tasks;
using AdventOfCode2020.Day17;
using Xunit;

namespace AdventOfCode2020.Tests
{
    public class Day17
    {
        private static readonly string[] WebsiteSample = {
            ".#.",
            "..#",
            "###",
        };

        [Fact]
        public async Task ProblemOne_ReturnsExpectedResult_WhenEnteringSampleFromWebsite()
        {
            var output = await Solution17.ProblemOneAsync(WebsiteSample.Select(x => x.ToCharArray()));
            Assert.Equal(112, output);
        }

        [Fact]
        public async Task ProblemTwo_ReturnsExpectedResult_WhenEnteringSampleFromWebsite()
        {
            var output = await Solution17.ProblemTwoAsync(WebsiteSample.Select(x => x.ToCharArray()));
            Assert.Equal(848, output);
        }
    }
}
