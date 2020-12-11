using System.Linq;
using System.Threading.Tasks;
using AdventOfCode2020.Day11;
using Xunit;

namespace AdventOfCode2020.Tests
{
    public class Day11
    {
        private static readonly string[] WebsiteSample = {
            "L.LL.LL.LL",
            "LLLLLLL.LL",
            "L.L.L..L..",
            "LLLL.LL.LL",
            "L.LL.LL.LL",
            "L.LLLLL.LL",
            "..L.L.....",
            "LLLLLLLLLL",
            "L.LLLLLL.L",
            "L.LLLLL.LL",
        };

        [Fact]
        public async Task ProblemOne_ReturnsExpectedResult_WhenEnteringSampleFromWebsite()
        {
            var output = await Solution11.ProblemOneAsync(WebsiteSample.Select(x => x.ToCharArray()));
            Assert.Equal(37, output);
        }

        [Fact]
        public async Task ProblemTwo_ReturnsExpectedResult_WhenEnteringSampleFromWebsite()
        {
            var output = await Solution11.ProblemTwoAsync(WebsiteSample.Select(x => x.ToCharArray()));
            Assert.Equal(26, output);
        }
    }
}
