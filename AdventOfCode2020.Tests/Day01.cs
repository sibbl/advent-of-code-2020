using AdventOfCode2020.Day01;
using System.Threading.Tasks;
using Xunit;

namespace AdventOfCode2020.Tests
{
    public class Day01
    {
        [Theory]
        [InlineData(new long[] { 1721, 979, 366, 299, 675, 1456 }, 514579)]
        public async Task ProblemOne_ReturnsExpectedResult_WhenEnteringSampleFromWebsite(long[] input, long expectedOutput)
        {
            var output = await Solution01.ProblemOneAsync(input);
            Assert.Equal(expectedOutput, output);
        }

        [Theory]
        [InlineData(new long[] { 1721, 979, 366, 299, 675, 1456 }, 241861950)]
        public async Task ProblemTwo_ReturnsExpectedResult_WhenEnteringSampleFromWebsite(long[] input, long expectedOutput)
        {
            var output = await Solution01.ProblemTwoAsync(input);
            Assert.Equal(expectedOutput, output);
        }
    }
}
