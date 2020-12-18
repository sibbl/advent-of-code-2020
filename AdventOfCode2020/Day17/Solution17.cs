using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdventOfCode2020.Extensions;
using MoreLinq;

namespace AdventOfCode2020.Day17
{
    public static class Solution17
    {
        private static Task<IEnumerable<IEnumerable<char>>> ReadInputAsync() => InputReader.ReadMapAsync("Day17/input.txt");

        private class ConwayCubes
        {
            private Array _array;

            public ConwayCubes(IEnumerable<IEnumerable<char>> map, int dimensions)
            {
                var mapArray = map.ToArray();
                var initialYSize = mapArray[0].Count();
                var initialXSize = mapArray.Length;

                // calculate sizes of dimensions
                var lengths = Enumerable.Range(0, dimensions)
                    .Select(i => i switch
                    {
                        0 => initialXSize,
                        1 => initialYSize,
                        _ => 1
                    })
                    .ToArray();

                _array = Array.CreateInstance(typeof(bool), lengths);

                // fill map with values
                Enumerable.Range(0, initialXSize).ForEach(x =>
                {
                    Enumerable.Range(0, initialYSize).ForEach(y =>
                    {
                        var indices = Enumerable.Range(0, dimensions)
                            .Select(idx => idx switch
                            {
                                0 => x,
                                1 => y,
                                _ => 0
                            })
                            .ToArray();
                        _array.SetValue(mapArray[x].ElementAt(y) == '#', indices);
                    });
                });
            }

            private static int CountActiveNeighbors(Array source, int[] itemIndices, int[] neighborIndices = null, int dimension = 0)
            {
                neighborIndices ??= itemIndices;
                var baseIndex = neighborIndices[dimension];
                var minIndex = source.GetLowerBound(dimension);
                var maxIndex = source.GetUpperBound(dimension);

                var activeNeighborsCount = 0;
                for (var i = -1; i <= 1; i++)
                {
                    var indexToCheck = baseIndex + i;
                    if (indexToCheck < minIndex || indexToCheck > maxIndex) continue;

                    var newNeighborIndices = (int[])neighborIndices.Clone();
                    newNeighborIndices[dimension] = indexToCheck;

                    var newDimension = dimension + 1;
                    if (newDimension == source.Rank)
                    {
                        var isNeighbor = itemIndices.SequenceEqual(newNeighborIndices) == false;
                        if (isNeighbor && (bool)source.GetValue(newNeighborIndices))
                        {
                            activeNeighborsCount++;
                        }
                    }
                    else
                    {
                        activeNeighborsCount +=
                            CountActiveNeighbors(source, itemIndices, newNeighborIndices, newDimension);
                    }
                }

                return activeNeighborsCount;
            }

            private void PerformCycle()
            {
                // increase size to each side and build a new array
                var newArrayDimensions = Enumerable.Range(0, _array.Rank).Select(dimension => _array.GetLength(dimension) + 2).ToArray();
                var newArray = Array.CreateInstance(typeof(bool), newArrayDimensions);

                // fill each field based on old array
                newArray.SelectForEach((_, indices) =>
                {
                    var oldArrayIndices = indices.Select(x => x - 1).ToArray();
                    var currentCubeIsActive = _array.TryGetValue(out var currentIsActiveObj, oldArrayIndices) && (bool)currentIsActiveObj;
                    var activeNeighborsCount = CountActiveNeighbors(_array, oldArrayIndices);

                    return (currentCubeIsActive && (activeNeighborsCount == 2 || activeNeighborsCount == 3))
                           || (currentCubeIsActive == false && activeNeighborsCount == 3);
                });

                _array = newArray;
            }

            public int GetActiveCubesCountAfterCycles(int cycles)
            {
                Enumerable.Range(0, cycles).ForEach(_ => PerformCycle());
                return _array.Cast<bool>().Count(x => x);
            }
        }

        #region Problem One

        public static async Task<long> ProblemOneAsync(IEnumerable<IEnumerable<char>> map = null)
        {
            map ??= await ReadInputAsync();
            return new ConwayCubes(map, 3).GetActiveCubesCountAfterCycles(6);
        }

        #endregion

        #region Problem Two

        public static async Task<long> ProblemTwoAsync(IEnumerable<IEnumerable<char>> map = null)
        {
            map ??= await ReadInputAsync();
            return new ConwayCubes(map, 4).GetActiveCubesCountAfterCycles(6);
        }

        #endregion
    }
}
