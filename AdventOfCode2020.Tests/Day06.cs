using System.Threading.Tasks;
using AdventOfCode2020.Day06;
using Xunit;

namespace AdventOfCode2020.Tests
{
    public class Day06
    {
        [Theory]
        [InlineData(3, "abc")]
        [InlineData(3, "a", "b", "c")]
        [InlineData(3, "ab", "ac")]
        [InlineData(1, "a", "a", "a", "a")]
        [InlineData(1, "b")]
        public async Task ProblemOne_ReturnsExpectedResult_WhenEnteringSampleFromWebsite(int answeredQuestions, params string[] lines)
        {
            var output = await Solution06.ProblemOneAsync(new []{  lines });
            Assert.Equal(answeredQuestions, output);
        }

        [Theory]
        [InlineData(3, "abc")]
        [InlineData(0, "a", "b", "c")]
        [InlineData(1, "ab", "ac")]
        [InlineData(1, "a", "a", "a", "a")]
        [InlineData(1, "b")]
        public async Task ProblemTwo_ReturnsExpectedResult_WhenEnteringSampleFromWebsite(int answeredQuestions, params string[] lines)
        {
            var output = await Solution06.ProblemTwoAsync(new[] { lines });
            Assert.Equal(answeredQuestions, output);
        }
    }
}
 