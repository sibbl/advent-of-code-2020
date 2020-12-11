using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdventOfCode2020.Day11
{
    public static class Solution11
    {
        private static Task<IEnumerable<IEnumerable<char>>> ReadInputAsync() => InputReader.ReadMapAsync("Day11/input.txt");

        private class WaitingArea
        {
            private const char Floor = '.';
            private const char EmptySeat = 'L';
            private const char OccupiedSeat = '#';

            private char[,] _map;
            private readonly int _cols;
            private readonly int _rows;
            private readonly int _occupiedSeatCountThreshold;
            private readonly bool _onlyDirectNeighbors;

            public WaitingArea(IEnumerable<IEnumerable<char>> map, bool onlyDirectNeighbors = true, int occupiedSeatCountThreshold = 4)
            {
                var mapArray = map.ToArray();
                _cols = mapArray[0].Count();
                _rows = mapArray.Length;

                _map = new char[_rows, _cols];
                for (var i = 0; i < _rows; i++)
                {
                    for (var j = 0; j < _cols; j++)
                    {
                        _map[i, j] = mapArray[i].ElementAt(j);
                    }
                }
                _onlyDirectNeighbors = onlyDirectNeighbors;
                _occupiedSeatCountThreshold = occupiedSeatCountThreshold;
            }

            private bool IsInBounds(int x, int y) => x >= 0 && x < _rows && y >= 0 && y < _cols;

            private IEnumerable<char> GetNeighbors(int i, int j)
            {
                var neighbors = new List<char>();
                for (var x = -1; x <= 1; x++)
                {
                    for (var y = -1; y <= 1; y++)
                    {
                        if (x == 0 && y == 0) continue;
                        var checkX = i + x;
                        var checkY = j + y;
                        var continueSearching = true;
                        while (continueSearching && IsInBounds(checkX, checkY))
                        {
                            var currentSeat = _map[checkX, checkY];
                            if (currentSeat != Floor)
                            {
                                neighbors.Add(currentSeat);
                                continueSearching = false;
                            }
                            else if (_onlyDirectNeighbors)
                            {
                                continueSearching = false;
                            }
                            checkX += x;
                            checkY += y;
                        }
                    }
                }

                return neighbors;
            }

            public int Fill()
            {
                var changes = 0;
                var newMap = (char[,])_map.Clone();

                for (var i = 0; i < _rows; i++)
                {
                    for (var j = 0; j < _cols; j++)
                    {
                        var current = _map[i, j];

                        switch (current)
                        {
                            case Floor:
                                continue;
                            case EmptySeat:
                                if (GetNeighbors(i, j).Any(x => x == OccupiedSeat) == false)
                                {
                                    newMap[i, j] = OccupiedSeat;
                                    changes++;
                                }
                                break;
                            case OccupiedSeat:
                                if (GetNeighbors(i, j).Count(x => x == OccupiedSeat) >= _occupiedSeatCountThreshold)
                                {
                                    newMap[i, j] = EmptySeat;
                                    changes++;
                                }
                                break;
                        }
                    }
                }

                _map = newMap;

                return changes;
            }

            public int GetOccupiedSeatsCount() => _map.Cast<char>().Count(x => x == OccupiedSeat);

            public int FillAndGetOccupiedSeatsCountAfterEverythingSettled()
            {
                int changes;
                do
                {
                    changes = Fill();
                } while (changes > 0);
                return GetOccupiedSeatsCount();
            }
        }

        #region Problem One

        public static async Task<long> ProblemOneAsync(IEnumerable<IEnumerable<char>> map = null)
        {
            map ??= await ReadInputAsync();
            return new WaitingArea(map).FillAndGetOccupiedSeatsCountAfterEverythingSettled();
        }

        #endregion

        #region Problem Two

        public static async Task<long> ProblemTwoAsync(IEnumerable<IEnumerable<char>> map = null)
        {
            map ??= await ReadInputAsync();
            return new WaitingArea(map, false, 5).FillAndGetOccupiedSeatsCountAfterEverythingSettled();
        }

        #endregion
    }
}
