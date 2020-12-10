using System.Threading.Tasks;
using AdventOfCode2020.Day10;
using Xunit;

namespace AdventOfCode2020.Tests
{
    public class Day10
    {
        private static readonly long[] WebsiteSampleOne = {
            16, 10, 15, 5, 1, 11, 7, 19, 6, 12, 4
        };
        private static readonly long[] WebsiteSampleTwo = {
            28, 33, 18, 42, 31, 14, 46, 20, 48, 47, 24, 23, 49, 45, 19, 38, 39, 11, 1, 32, 25, 35, 8, 17, 7, 9, 4, 2, 34, 10, 3
        };

        [Fact]
        public async Task ProblemOne_ReturnsExpectedResult_WhenEnteringSampleOneFromWebsite()
        {
            var output = await Solution10.ProblemOneAsync(WebsiteSampleOne);
            Assert.Equal(7 * 5, output);
        }
        [Fact]
        public async Task ProblemOne_ReturnsExpectedResult_WhenEnteringSampleTwoFromWebsite()
        {
            var output = await Solution10.ProblemOneAsync(WebsiteSampleTwo);
            Assert.Equal(22 * 10, output);
        }

        [Fact]
        public async Task ProblemTwo_ReturnsExpectedResult_WhenEnteringSampleOneFromWebsite()
        {
            var output = await Solution10.ProblemTwoAsync(WebsiteSampleOne);
            Assert.Equal(8, output);
        }

        [Fact]
        public async Task ProblemTwo_ReturnsExpectedResult_WhenEnteringSampleTwoFromWebsite()
        {
            var output = await Solution10.ProblemTwoAsync(WebsiteSampleTwo);
            Assert.Equal(19208, output);
        }
    }
}
