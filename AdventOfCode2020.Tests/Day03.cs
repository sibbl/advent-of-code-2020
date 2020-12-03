using System;
using System.Collections.Generic;
using System.Linq;
using AdventOfCode2020.Day03;
using System.Threading.Tasks;
using Xunit;

namespace AdventOfCode2020.Tests
{
    public class Day03
    {
        private static readonly IEnumerable<IEnumerable<char>> TestInput = @"..##.......
#...#...#..
.#....#..#.
..#.#...#.#
.#...##..#.
..#.##.....
.#.#.#....#
.#........#
#.##...#...
#...##....#
.#..#...#.#".Split('\r', StringSplitOptions.TrimEntries).Select(x => x.ToCharArray());

        [Fact]
        public async Task ProblemOne_ReturnsExpectedResult_WhenEnteringSampleFromWebsite()
        {
            var output = await Solution03.ProblemOneAsync(TestInput);
            Assert.Equal(7, output);
        }

        [Fact]
        public async Task ProblemTwo_ReturnsExpectedResult_WhenEnteringSampleFromWebsite()
        {
            var output = await Solution03.ProblemTwoAsync(TestInput);
            Assert.Equal(336, output);
        }
    }
}
