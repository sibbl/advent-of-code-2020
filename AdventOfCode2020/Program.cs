using System;
using System.Threading.Tasks;
using AdventOfCode2020.Day01;

namespace AdventOfCode2020
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            await DayOneProblemOne();
            await DayOneProblemTwo();
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
    }
}
