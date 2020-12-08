using System.Threading.Tasks;
using AdventOfCode2020.Day08;
using Xunit;

namespace AdventOfCode2020.Tests
{
    public class Day08
    {
        private static readonly string[] WebsiteBrokenLoopSample =
        {
            "nop +0",
            "acc +1",
            "jmp +4",
            "acc +3",
            "jmp -3",
            "acc -99",
            "acc +1",
            "jmp -4",
            "acc +6"
        };

        private static readonly string[] WebsiteFixedTerminatingSample =
        {
            "nop +0",
            "acc +1",
            "jmp +4",
            "acc +3",
            "jmp -3",
            "acc -99",
            "acc +1",
            "nop -4",
            "acc +6"
        };

        [Fact]
        public async Task ProblemOne_DetectsLoop_WhenEnteringLoopSampleFromWebsite()
        {
            var output = await Solution08.ProblemOneAsync(WebsiteBrokenLoopSample);
            Assert.Equal(5, output);
        }

        [Fact]
        public async Task ProblemOne_TerminatesAndReturnsResult_WhenEnteringTerminatingSampleFromWebsite()
        {
            var output = await Solution08.ProblemOneAsync(WebsiteFixedTerminatingSample);
            Assert.Equal(8, output);
        }

        [Fact]
        public async Task ProblemTwo_ReturnsTerminatingResult_WhenEnteringLoopSampleFromWebsite()
        {
            var output = await Solution08.ProblemTwoAsync(WebsiteBrokenLoopSample);
            Assert.Equal(8, output);
        }
    }
}
 