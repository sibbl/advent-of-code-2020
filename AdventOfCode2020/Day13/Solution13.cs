using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdventOfCode2020.Day13
{
    public static class Solution13
    {
        private static Task<IEnumerable<string>> ReadInputAsync() => InputReader.ReadLinesAsync("Day13/input.txt");

        private record Bus(int Id, int Index)
        {
            public static Bus Parse(string input, int index) => new(int.Parse(input), index);
        }

        #region Problem One

        public static async Task<long> ProblemOneAsync(IEnumerable<string> lines = null)
        {
            lines ??= await ReadInputAsync();
            var linesArray = lines.ToArray();
            var timestamp = int.Parse(linesArray[0]);
            var (bus, waitingTime) = linesArray[1].Split(',')
                .Where(str => str != "x")
                .Select(Bus.Parse)
                .Select(bus => (Bus: bus, WaitingTime: bus.Id - (timestamp % bus.Id)))
                .OrderBy(x => x.WaitingTime)
                .First();

            return bus.Id * waitingTime;
        }

        #endregion

        #region Problem Two

        public static async Task<long> ProblemTwoAsync(IEnumerable<string> lines = null)
        {
            lines ??= await ReadInputAsync();

            var buses = lines
                .ElementAt(1)
                .Split(',')
                .Select((str, i) => int.TryParse(str, out var number)
                    ? new Bus(number, i)
                    : null)
                .Where(x => x != null)
                .ToArray();

            var t = 0L;
            var increaseValue = 1L;
            foreach (var (id, index) in buses)
            {
                while (true)
                {
                    t += increaseValue;
                    if ((t + index) % id == 0)
                    {
                        increaseValue *= id;
                        break;
                    }
                }
            }

            return t;
        }

        #endregion
    }
}
