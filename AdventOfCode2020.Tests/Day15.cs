using System.Threading.Tasks;
using AdventOfCode2020.Day15;
using Xunit;

namespace AdventOfCode2020.Tests
{
    public class Day15
    {

        [Theory]
        [InlineData("0,3,6", 436)]
        [InlineData("1,3,2", 1)]
        [InlineData("2,1,3", 10)]
        [InlineData("1,2,3", 27)]
        [InlineData("2,3,1", 78)]
        [InlineData("3,2,1", 438)]
        [InlineData("3,1,2", 1836)]
        public async Task ProblemOne_ReturnsExpectedResult_WhenEnteringSamplesFromWebsite(string input, long expectedResult)
        {
            var output = await Solution15.ProblemOneAsync(input);
            Assert.Equal(expectedResult, output);
        }

        [Theory]
        [InlineData("0,3,6", 175594)]
        [InlineData("1,3,2", 2578)]
        [InlineData("2,1,3", 3544142)]
        [InlineData("1,2,3", 261214)]
        [InlineData("2,3,1", 6895259)]
        [InlineData("3,2,1", 18)]
        [InlineData("3,1,2", 362)]
        public async Task ProblemTwo_ReturnsExpectedResult_WhenEnteringSamplesFromWebsite(string input, long expectedResult)
        {
            var output = await Solution15.ProblemTwoAsync(input);
            Assert.Equal(expectedResult, output);
        }
    }
}
