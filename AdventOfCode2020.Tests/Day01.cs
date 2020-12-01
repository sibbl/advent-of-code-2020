using AdventOfCode2020.Day01;
using System.Threading.Tasks;
using Xunit;

namespace AdventOfCode2020.Tests
{
    public class Day01
    {
        [Theory]
        [InlineData(new[] { 1721, 979, 366, 299, 675, 1456 }, 514579)]
        public async Task ProblemOne_ReturnsExpectedResult_WhenEnteringSampleFromWebsite(int[] input, int expectedOutput)
        {
            var output = await Solution01.ProblemOneAsync(input);
            Assert.Equal(expectedOutput, output);
        }
    }
}
