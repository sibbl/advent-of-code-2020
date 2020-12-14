using System.Threading.Tasks;
using AdventOfCode2020.Day14;
using Xunit;

namespace AdventOfCode2020.Tests
{
    public class Day14
    {
        private static readonly string[] WebsiteSampleOne = {
            "mask = XXXXXXXXXXXXXXXXXXXXXXXXXXXXX1XXXX0X",
            "mem[8] = 11",
            "mem[7] = 101",
            "mem[8] = 0"
        };
        private static readonly string[] WebsiteSampleTwo = {
            "mask = 000000000000000000000000000000X1001X",
            "mem[42] = 100",
            "mask = 00000000000000000000000000000000X0XX",
            "mem[26] = 1"
        };

        [Fact]
        public async Task ProblemOne_ReturnsExpectedResult_WhenEnteringSampleFromWebsite()
        {
            var output = await Solution14.ProblemOneAsync(WebsiteSampleOne);
            Assert.Equal(165, output);
        }

        [Fact]
        public async Task ProblemTwo_ReturnsExpectedResult_WhenEnteringSampleFromWebsite()
        {
            var output = await Solution14.ProblemTwoAsync(WebsiteSampleTwo);
            Assert.Equal(208, output);
        }
    }
}
