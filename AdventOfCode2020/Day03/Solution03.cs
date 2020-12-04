using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2020.Day03
{
    public static class Solution03
    {
        private enum AreaValue
        {
            Open,
            Tree
        }

        private record Coordinate(int X = 0, int Y = 0);

        private record StepVector(int MoveRight, int MoveDown);

        private record Area
        {
            private readonly AreaValue[][] _map;

            public Area(IEnumerable<IEnumerable<char>> map)
            {
                _map = map.Select(y =>
                    y.Select(x => x switch
                    {
                        '#' => AreaValue.Tree,
                        _ => AreaValue.Open
                    }).ToArray()
                ).ToArray();
            }

            public bool HasValueAt(Coordinate position)
                => _map.Length > position.Y;

            public bool TryGetValueAt(Coordinate position, out AreaValue value)
            {
                if (_map.Length <= position.Y)
                {
                    value = default;
                    return false;
                }

                var row = _map[position.Y];
                value = row[position.X % row.Length];
                return true;
            }
        }

        private class TravelJourney
        {
            private readonly Area _area;

            private Coordinate _position = new();

            public TravelJourney(Area area)
                => _area = area;

            private Coordinate GetNextPosition(StepVector vector)
                => _position with
                {
                    X = _position.X + vector.MoveRight,
                    Y = _position.Y + vector.MoveDown
                };

            public bool TryWalk(StepVector vector, out AreaValue value)
            {
                var nextPosition = GetNextPosition(vector);
                var success = _area.TryGetValueAt(nextPosition, out value);
                if (success)
                {
                    _position = nextPosition;
                }

                return success;
            }

            public int CountTreesOnJourney(StepVector stepVector)
            {
                _position = new();
                var treeSum = 0;

                while (TryWalk(stepVector, out var newPositionValue))
                {
                    if (newPositionValue == AreaValue.Tree)
                    {
                        treeSum++;
                    }
                }

                return treeSum;
            }
        }

        private static Task<IEnumerable<IEnumerable<char>>> ReadInputAsync() => InputReader.ReadMapAsync("Day03/input.txt");

        #region Problem One

        public static async Task<int> ProblemOneAsync(IEnumerable<IEnumerable<char>> map = null)
        {
            map ??= await ReadInputAsync();
            var journey = new TravelJourney(new Area(map));
            return journey.CountTreesOnJourney(new StepVector(3, 1));
        }

        #endregion

        #region Problem Two

        public static async Task<int> ProblemTwoAsync(IEnumerable<IEnumerable<char>> map = null)
        {
            map ??= await ReadInputAsync();
            var journey = new TravelJourney(new Area(map));
            var vectors = new[]
            {
                new StepVector(1, 1),
                new StepVector(3, 1),
                new StepVector(5, 1),
                new StepVector(7, 1),
                new StepVector(1, 2),
            };
            return vectors
                .Select(vector => journey.CountTreesOnJourney(vector))
                .Aggregate(1, (x, y) => x * y);
        }

        #endregion
    }
}
