using System.Collections.Generic;
using System.Threading.Tasks;
using AdventOfCode2020.Day16;
using Xunit;

namespace AdventOfCode2020.Tests
{
    public class Day16
    {
        private static readonly IEnumerable<IEnumerable<string>> WebsiteSample = new[]{
            new []
            {
                "class: 1-3 or 5-7",
                "row: 6-11 or 33-44",
                "seat: 13-40 or 45-50"
            },
            new []
            {
                "your ticket:",
                "7,1,14"
            },
            new []
            {
                "nearby tickets:",
                "7,3,47",
                "40,4,50",
                "55,2,20",
                "38,6,12"
            }
        };

        [Fact]
        public async Task ProblemOne_ReturnsExpectedResult_WhenEnteringSampleFromWebsite()
        {
            var output = await Solution16.ProblemOneAsync(WebsiteSample);
            Assert.Equal(71, output);
        }
        private static readonly IEnumerable<IEnumerable<string>> DepartureSample = new[]{
            new []
            {
                "class: 1-3 or 5-7",
                "departure row: 6-11 or 33-44",
                "departure seat: 13-40 or 45-50"
            },
            new []
            {
                "your ticket:",
                "7,1,14"
            },
            new []
            {
                "nearby tickets:",
                "7,3,47",
                "40,4,50",
                "55,2,20",
                "38,6,12"
            }
        };

        [Fact]
        public async Task ProblemTwo_ReturnsExpectedResult_WhenEnteringSampleFromWebsite()
        {
            var output = await Solution16.ProblemTwoAsync(DepartureSample);
            Assert.Equal(98, output);
        }
    }
}
