using System;
using System.Threading.Tasks;
using AdventOfCode2020.Day01;
using AdventOfCode2020.Day02;

namespace AdventOfCode2020
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            await DayOneProblemOne();
            await DayOneProblemTwo();
            await DayTwoProblemOne();
            await DayTwoProblemTwo();
        }

        private static async Task DayOneProblemOne()
        {
            var output = await Solution01.ProblemOneAsync();
            Console.WriteLine($"Day 1, Problem 1: {output}");
        }

        private static async Task DayOneProblemTwo()
        {
            var output = await Solution01.ProblemTwoAsync();
            Console.WriteLine($"Day 1, Problem 2: {output}");
        }

        private static async Task DayTwoProblemOne()
        {
            var output = await Solution02.ProblemOneAsync();
            Console.WriteLine($"Day 2, Problem 1: {output}");
        }

        private static async Task DayTwoProblemTwo()
        {
            var output = await Solution02.ProblemTwoAsync();
            Console.WriteLine($"Day 2, Problem 2: {output}");
        }
    }
}
