using System;
using System.Threading.Tasks;
using AdventOfCode2020.Day01;
using AdventOfCode2020.Day02;
using AdventOfCode2020.Day03;
using AdventOfCode2020.Day04;
using AdventOfCode2020.Day05;

await DayOneProblemOne();
await DayOneProblemTwo();
await DayTwoProblemOne();
await DayTwoProblemTwo();
await DayThreeProblemOne();
await DayThreeProblemTwo();
await DayFourProblemOne();
await DayFourProblemTwo();
await DayFiveProblemOne();
await DayFiveProblemTwo();

static async Task DayOneProblemOne()
{
    var output = await Solution01.ProblemOneAsync();
    Console.WriteLine($"Day 1, Problem 1: {output}");
}

static async Task DayOneProblemTwo()
{
    var output = await Solution01.ProblemTwoAsync();
    Console.WriteLine($"Day 1, Problem 2: {output}");
}

static async Task DayTwoProblemOne()
{
    var output = await Solution02.ProblemOneAsync();
    Console.WriteLine($"Day 2, Problem 1: {output}");
}

static async Task DayTwoProblemTwo()
{
    var output = await Solution02.ProblemTwoAsync();
    Console.WriteLine($"Day 2, Problem 2: {output}");
}

static async Task DayThreeProblemOne()
{
    var output = await Solution03.ProblemOneAsync();
    Console.WriteLine($"Day 3, Problem 1: {output}");
}

static async Task DayThreeProblemTwo()
{
    var output = await Solution03.ProblemTwoAsync();
    Console.WriteLine($"Day 3, Problem 2: {output}");
}

static async Task DayFourProblemOne()
{
    var output = await Solution04.ProblemOneAsync();
    Console.WriteLine($"Day 4, Problem 1: {output}");
}

static async Task DayFourProblemTwo()
{
    var output = await Solution04.ProblemTwoAsync();
    Console.WriteLine($"Day 4, Problem 2: {output}");
}

static async Task DayFiveProblemOne()
{
    var output = await Solution05.ProblemOneAsync();
    Console.WriteLine($"Day 5, Problem 1: {output}");
}

static async Task DayFiveProblemTwo()
{
    var output = await Solution05.ProblemTwoAsync();
    Console.WriteLine($"Day 5, Problem 2: {output}");
}