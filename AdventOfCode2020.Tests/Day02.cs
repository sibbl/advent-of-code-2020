using AdventOfCode2020.Day02;
using System.Threading.Tasks;
using Xunit;

namespace AdventOfCode2020.Tests
{
    public class Day02
    {
        private const string TestInput = @"1-3 a: abcde
1-3 b: cdefg
2-9 c: ccccccccc";

        [Fact]
        public async Task ProblemOne_ReturnsExpectedResult_WhenEnteringSampleFromWebsite()
        {
            var output = await Solution02.ProblemOneAsync(TestInput);
            Assert.Equal(2, output);
        }

        [Fact]
        public async Task ProblemTwo_ReturnsExpectedResult_WhenEnteringSampleFromWebsite()
        {
            var output = await Solution02.ProblemTwoAsync(TestInput);
            Assert.Equal(1, output);
        }
    }
}
