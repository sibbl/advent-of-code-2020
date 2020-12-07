using System;
using System.Threading.Tasks;
using AdventOfCode2020.Day01;
using AdventOfCode2020.Day02;
using AdventOfCode2020.Day03;
using AdventOfCode2020.Day04;
using AdventOfCode2020.Day05;
using AdventOfCode2020.Day06;
using AdventOfCode2020.Day07;

await PrintSolution(1, 1, () => Solution01.ProblemOneAsync());
await PrintSolution(1, 2, () => Solution01.ProblemTwoAsync());
await PrintSolution(2, 1, () => Solution02.ProblemOneAsync());
await PrintSolution(2, 2, () => Solution02.ProblemTwoAsync());
await PrintSolution(3, 1, () => Solution03.ProblemOneAsync());
await PrintSolution(3, 2, () => Solution03.ProblemTwoAsync());
await PrintSolution(4, 1, () => Solution04.ProblemOneAsync());
await PrintSolution(4, 2, () => Solution04.ProblemTwoAsync());
await PrintSolution(5, 1, () => Solution05.ProblemOneAsync());
await PrintSolution(5, 2, () => Solution05.ProblemTwoAsync());
await PrintSolution(6, 1, () => Solution06.ProblemOneAsync());
await PrintSolution(6, 2, () => Solution06.ProblemTwoAsync());
await PrintSolution(7, 1, () => Solution07.ProblemOneAsync());
await PrintSolution(7, 2, () => Solution07.ProblemTwoAsync());

static async Task PrintSolution(int day, int problem, Func<Task<int>> solutionFunc)
{
    var output = await solutionFunc();
    Console.WriteLine($"Day {day}, Problem {problem}: {output}");
};
