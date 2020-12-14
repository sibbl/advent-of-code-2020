using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using AdventOfCode2020.Extensions;

namespace AdventOfCode2020.Day14
{
    public static class Solution14
    {
        private static Task<IEnumerable<string>> ReadInputAsync() => InputReader.ReadLinesAsync("Day14/input.txt");

        private static readonly Regex ParseRegex = new Regex(@"(mask\s*=\s*(?<Mask>[01X]{36}))|(mem\[(?<Address>\d+)\]\s*=\s*(?<Value>\d+))");

        private record Mask(string Raw, long WithOnes, long WithZeroes)
        {
            public Mask(string input) : this(
                input,
                Convert.ToInt64(input.Replace('X', '1'), 2),
                Convert.ToInt64(input.Replace('X', '0'), 2)
            )
            { }
        }
        private record MemoryAssignment(long Address, long Value);

        private record Block(Mask Mask, List<MemoryAssignment> Assignments);

        private static List<Block> Parse(IEnumerable<string> lines)
        {
            var result = new List<Block>();
            Block currentBlock = null;
            foreach (var line in lines)
            {
                var match = ParseRegex.Match(line);
                if (match.Groups.TryGetValue("Mask", out var maskGroup) && maskGroup.Success)
                {
                    if (currentBlock != null)
                    {
                        result.Add(currentBlock);
                    }

                    currentBlock = new Block(new Mask(maskGroup.Value), new List<MemoryAssignment>());
                }
                else if (currentBlock != null)
                {
                    var address = long.Parse(match.Groups["Address"].Value);
                    var value = long.Parse(match.Groups["Value"].Value);
                    var item = new MemoryAssignment(address, value);
                    currentBlock.Assignments.Add(item);

                }
            }
            if (currentBlock != null)
            {
                result.Add(currentBlock);
            }

            return result;
        }

        #region Problem One

        public static async Task<long> ProblemOneAsync(IEnumerable<string> lines = null)
        {
            lines ??= await ReadInputAsync();

            var instructions = Parse(lines);
            var memory = new Dictionary<long, long>();
            foreach (var (mask, memoryAssignments) in instructions)
            {
                foreach (var (address, value) in memoryAssignments)
                {
                    memory[address] = value & mask.WithOnes | mask.WithZeroes;
                }
            }

            return memory.Values.Sum();
        }

        #endregion

        #region Problem Two
        
        public static async Task<long> ProblemTwoAsync(IEnumerable<string> lines = null)
        {
            lines ??= await ReadInputAsync();

            var instructions = Parse(lines);
            var memory = new Dictionary<long, long>();
            foreach (var (mask, memoryAssignments) in instructions)
            {
                var floatingIndexes = mask.Raw
                    .Select((c, i) => new { c, i })
                    .Where(x => x.c == 'X')
                    .Select(x => x.i)
                    .ToList();

                foreach (var (address, value) in memoryAssignments)
                {
                    var addressWithMask = (address | mask.WithOnes).ToBinaryString(mask.Raw.Length);

                    foreach (var i in Enumerable.Range(0, (int)Math.Pow(2, floatingIndexes.Count)))
                    {
                        var combinationAddress = i.ToBinaryString(floatingIndexes.Count)
                            .ToCharArray()
                            .Select((c, i) => (Value: c, Index: floatingIndexes[i]))
                            .Aggregate(addressWithMask.ToCharArray(),
                                (array, item) =>
                                {
                                    array[item.Index] = item.Value;
                                    return array;
                                },
                                result => result.ToLongFromBinary());

                        memory[combinationAddress] = value;
                    }


                }

            }

            return memory.Values.Sum();
        }

        #endregion
    }
}
