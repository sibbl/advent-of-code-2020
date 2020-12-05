using System;
using System.Threading.Tasks;
using AdventOfCode2020.Day05;
using Xunit;

namespace AdventOfCode2020.Tests
{
    public class Day05
    {
        [Theory]
        [InlineData("BFFFBBFRRR", 567)]
        [InlineData("FFFBBBFRRR", 119)]
        [InlineData("BBFFBBFRLL", 820)]
        public async Task ProblemOne_ReturnsExpectedResult_WhenEnteringSampleFromWebsite(string input, int expectedSeatId)
        {
            var seatId = await Solution05.ProblemOneAsync(new []{  input });
            Assert.Equal(expectedSeatId, seatId);
        }

        [Theory]
        [InlineData(@"BFFFBBFRRR
BFFFBBFRLR", 566)]
        [InlineData(@"FFFBBBFRRR
FFFBBBFRLR", 118)]
        public async Task ProblemTwo_ReturnsExpectedResult_WhenEnteringSelfBuiltSample(string input, int missingSeatId)
        {
            var output = await Solution05.ProblemTwoAsync(input.Split('\r', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries));
            Assert.Equal(missingSeatId, output);
        }
    }
}
 