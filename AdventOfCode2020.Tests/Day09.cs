using System.Threading.Tasks;
using AdventOfCode2020.Day09;
using Xunit;

namespace AdventOfCode2020.Tests
{
    public class Day09
    {
        private static readonly long[] WebsiteSample = {
            35, 20, 15, 25, 47, 40, 62, 55, 65, 95, 102, 117, 150, 182, 127, 219, 299, 277, 309, 576
        };

        [Fact]
        public async Task ProblemOne_ReturnsExpectedResult_WhenEnteringSampleFromWebsite()
        {
            var output = await Solution09.ProblemOneAsync(WebsiteSample, 5);
            Assert.Equal(127, output);
        }

        [Fact]
        public async Task ProblemTwo_ReturnsExpectedResult_WhenEnteringSampleFromWebsite()
        {
            var output = await Solution09.ProblemTwoAsync(WebsiteSample, 5);
            Assert.Equal(62, output);
        }
    }
}
