using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdventOfCode2020.Extensions;
using MoreLinq;

namespace AdventOfCode2020.Day16
{
    public static class Solution16
    {
        private static Task<IEnumerable<IEnumerable<string>>> ReadInputAsync() => InputReader.ReadBlocksBetweenEmptyLinesAsync("Day16/input.txt");

        private record Constraint(int Min, int Max)
        {
            public static Constraint FromString(string input)
            {
                var parts = input.Split('-').Select(int.Parse).ToArray();
                return new Constraint(parts[0], parts[1]);
            }

            public bool IsValid(int value) => value >= Min && value <= Max;
        }

        private class Tickets
        {
            private readonly IReadOnlyDictionary<string, IEnumerable<Constraint>> _constraints;
            private readonly IEnumerable<int> _myTicket;
            private readonly IEnumerable<IEnumerable<int>> _nearbyTickets;

            public Tickets(IEnumerable<IEnumerable<string>> blocks)
            {
                foreach (var block in blocks)
                {
                    var firstLine = block.First();
                    switch (firstLine)
                    {
                        case "your ticket:":
                            _myTicket = block.ElementAt(1).Split(',').Select(int.Parse);
                            break;
                        case "nearby tickets:":
                            _nearbyTickets = block.Skip(1).Select(line => line.Split(',').Select(int.Parse));
                            break;
                        default:
                            _constraints = ParseConstraints(block);
                            break;
                    }
                }
            }

            private IReadOnlyDictionary<string, IEnumerable<Constraint>> ParseConstraints(IEnumerable<string> block)
                => block.Select(line => line.Split(": "))
                    .ToDictionary(
                        splitResult => splitResult[0],
                        splitResult => splitResult[1]
                            .Split(" or ")
                            .Select(Constraint.FromString)
                    );

            private static IEnumerable<IEnumerable<int>> ParseTickets(IEnumerable<string> lines)
                => lines.Select(line => line.Split(',').Select(int.Parse));

            public long SumOfInvalidTicketValues()
                => _nearbyTickets.Sum(
                    numbers => numbers.Sum(number =>
                    {
                        var isValid = _constraints.Values.Any(constraints =>
                            constraints.Any(constraint => constraint.IsValid(number))
                        );
                        return isValid ? 0 : number;
                    })
                );


            public IEnumerable<string> GetKeys()
            {
                var openConstraints = _constraints.Keys.ToList();

                var validNearbyTickets = _nearbyTickets.Where(numbers =>
                    numbers.All(number => _constraints.Values.Any(constraints =>
                            constraints.Any(constraint => constraint.IsValid(number))
                        )
                    )
                );

                var positions = validNearbyTickets.Transpose()
                    .Select(x => x.ToArray())
                    .ToArray();

                var result = new string[_constraints.Count];
                while (openConstraints.Count > 0)
                {
                    positions.ForEach((position, i) =>
                    {
                        var matchingConstraints = 0;
                        var constraintName = string.Empty;
                        foreach (var key in openConstraints)
                        {
                            var foundConstraints = position.Count(number =>
                                _constraints[key].Any(constraint => constraint.IsValid(number)));
                            if (foundConstraints == position.Length)
                            {
                                constraintName = key;
                                matchingConstraints++;
                                if (matchingConstraints > 1) break;
                            }
                        }

                        if (matchingConstraints == 1)
                        {
                            result[i] = constraintName;
                            openConstraints.Remove(constraintName);
                        }
                    });
                }

                return result;
            }

            public long GetMyTicketElementAt(int index) => _myTicket.ElementAt(index);
        }

        #region Problem One

        public static async Task<long> ProblemOneAsync(IEnumerable<IEnumerable<string>> input = null)
        {
            input ??= await ReadInputAsync();
            return new Tickets(input).SumOfInvalidTicketValues();
        }

        #endregion

        #region Problem Two

        public static async Task<long> ProblemTwoAsync(IEnumerable<IEnumerable<string>> input = null)
        {
            input ??= await ReadInputAsync();
            var tickets = new Tickets(input);
            var keys = tickets.GetKeys();
            return keys
                .Select((key, index) => (Key: key, Index: index))
                .Where(item => item.Key.StartsWith("departure"))
                .Multiply(item => tickets.GetMyTicketElementAt(item.Index));
        }

        #endregion
    }
}
