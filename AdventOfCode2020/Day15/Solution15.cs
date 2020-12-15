using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdventOfCode2020.Day15
{
    public static class Solution15
    {
        private static Task<string> ReadInputAsync() => InputReader.ReadFileContent("Day15/input.txt");

        private record LastSpokenInfo(int PrevSpokenTurnIndex, int BeforePrevSpokenTurnIndex)
        {
            public int Difference => PrevSpokenTurnIndex - BeforePrevSpokenTurnIndex;
        }

        private class MemoryGame
        {
            private readonly Dictionary<long, LastSpokenInfo> _memory = new();
            private readonly long[] _input;

            public MemoryGame(string input)
            {
                _input = input.Split(',', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries)
                    .Select(long.Parse)
                    .ToArray();
            }

            public long PlayUntil(long iterations)
            {
                int i;
                var lastNumber = 0L;

                for (i = 0; i < _input.Length; i++)
                {
                    lastNumber = _input[i];
                    _memory[lastNumber] = new LastSpokenInfo(i, i);
                }

                for (i = _input.Length; i < iterations; i++)
                {
                    if (_memory.TryGetValue(lastNumber, out var lastIndex))
                    {
                        lastNumber = lastIndex.Difference;
                    }

                    _memory[lastNumber] = new(i,
                        _memory.ContainsKey(lastNumber) ? _memory[lastNumber].PrevSpokenTurnIndex : i
                    );
                }

                return lastNumber;
            }
        }

        #region Problem One

        public static async Task<long> ProblemOneAsync(string input = null)
        {
            input ??= await ReadInputAsync();
            return new MemoryGame(input).PlayUntil(2020);
        }

        #endregion

        #region Problem Two

        public static async Task<long> ProblemTwoAsync(string input = null)
        {
            input ??= await ReadInputAsync();
            return new MemoryGame(input).PlayUntil(30000000);
        }

        #endregion
    }
}
