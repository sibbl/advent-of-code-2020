using System;
using System.Threading.Tasks;

await PrintSolution(1, 1, () => AdventOfCode2020.Day01.Solution01.ProblemOneAsync());
await PrintSolution(1, 2, () => AdventOfCode2020.Day01.Solution01.ProblemTwoAsync());
await PrintSolution(2, 1, () => AdventOfCode2020.Day02.Solution02.ProblemOneAsync());
await PrintSolution(2, 2, () => AdventOfCode2020.Day02.Solution02.ProblemTwoAsync());
await PrintSolution(3, 1, () => AdventOfCode2020.Day03.Solution03.ProblemOneAsync());
await PrintSolution(3, 2, () => AdventOfCode2020.Day03.Solution03.ProblemTwoAsync());
await PrintSolution(4, 1, () => AdventOfCode2020.Day04.Solution04.ProblemOneAsync());
await PrintSolution(4, 2, () => AdventOfCode2020.Day04.Solution04.ProblemTwoAsync());
await PrintSolution(5, 1, () => AdventOfCode2020.Day05.Solution05.ProblemOneAsync());
await PrintSolution(5, 2, () => AdventOfCode2020.Day05.Solution05.ProblemTwoAsync());
await PrintSolution(6, 1, () => AdventOfCode2020.Day06.Solution06.ProblemOneAsync());
await PrintSolution(6, 2, () => AdventOfCode2020.Day06.Solution06.ProblemTwoAsync());
await PrintSolution(7, 1, () => AdventOfCode2020.Day07.Solution07.ProblemOneAsync());
await PrintSolution(7, 2, () => AdventOfCode2020.Day07.Solution07.ProblemTwoAsync());
await PrintSolution(8, 1, () => AdventOfCode2020.Day08.Solution08.ProblemOneAsync());
await PrintSolution(8, 2, () => AdventOfCode2020.Day08.Solution08.ProblemTwoAsync());
await PrintSolution(9, 1, () => AdventOfCode2020.Day09.Solution09.ProblemOneAsync());
await PrintSolution(9, 2, () => AdventOfCode2020.Day09.Solution09.ProblemTwoAsync());
await PrintSolution(10, 1, () => AdventOfCode2020.Day10.Solution10.ProblemOneAsync());
await PrintSolution(10, 2, () => AdventOfCode2020.Day10.Solution10.ProblemTwoAsync());
await PrintSolution(11, 1, () => AdventOfCode2020.Day11.Solution11.ProblemOneAsync());
await PrintSolution(11, 2, () => AdventOfCode2020.Day11.Solution11.ProblemTwoAsync());
await PrintSolution(12, 1, () => AdventOfCode2020.Day12.Solution12.ProblemOneAsync());
await PrintSolution(12, 2, () => AdventOfCode2020.Day12.Solution12.ProblemTwoAsync());
await PrintSolution(13, 1, () => AdventOfCode2020.Day13.Solution13.ProblemOneAsync());
await PrintSolution(13, 2, () => AdventOfCode2020.Day13.Solution13.ProblemTwoAsync());

static async Task PrintSolution(int day, int problem, Func<Task<long>> solutionFunc)
{
    var output = await solutionFunc();
    Console.WriteLine($"Day {day}, Problem {problem}: {output}");
};