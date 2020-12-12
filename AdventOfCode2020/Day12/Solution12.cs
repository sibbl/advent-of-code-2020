using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdventOfCode2020.Day12
{
    public static class Solution12
    {
        private static Task<IEnumerable<string>> ReadInputAsync() => InputReader.ReadLinesAsync("Day12/input.txt");

        private record Instruction(char Action, int Value)
        {
            public static Instruction FromString(string line) => new(line[0], int.Parse(line[1..]));
        }

        private enum DirectionsMovementBehavior
        {
            DirectionsMoveShip,
            DirectionsMoveWayPoint
        };

        private class Vector
        {
            public long X { get; set; }
            public long Y { get; set; }

            public Vector(long x, long y) => (X, Y) = (x, y);

            public static Vector operator +(Vector v1, Vector v2) => new(v1.X + v2.X, v1.Y + v2.Y);
            public static Vector operator *(Vector v1, Vector v2) => new(v1.X * v2.X, v1.Y * v2.Y);
            public static Vector operator *(Vector v, long value) => new(v.X * value, v.Y * value);
        }

        private class Route
        {
            private readonly IEnumerable<Instruction> _instructions;
            private readonly DirectionsMovementBehavior _directionsMovementBehavior;
            private Vector _position = new(0, 0);
            private Vector _movementVector;

            public Route(IEnumerable<string> instructionInput) : this(instructionInput, new Vector(1, 0), DirectionsMovementBehavior.DirectionsMoveShip)
            {
            }

            public Route(IEnumerable<string> instructionInput, Vector movementVector, DirectionsMovementBehavior directionsMovementBehavior)
            {
                _instructions = instructionInput.Select(Instruction.FromString);
                _movementVector = movementVector;
                _directionsMovementBehavior = directionsMovementBehavior;
            }

            private void MoveIntoDirection(char direction, int value)
            {
                var vector = direction switch
                {
                    'E' => new Vector(1, 0),
                    'W' => new Vector(-1, 0),
                    'N' => new Vector(0, 1),
                    'S' => new Vector(0, -1),
                    _ => throw new Exception("Invalid direction " + direction)
                };
                switch (_directionsMovementBehavior)
                {
                    case DirectionsMovementBehavior.DirectionsMoveShip:
                        _position += vector * value;
                        break;
                    case DirectionsMovementBehavior.DirectionsMoveWayPoint:
                        _movementVector += vector * value;
                        break;
                    default:
                        throw new NotImplementedException("Behavior not implemented: " + _directionsMovementBehavior);
                }
            }

            private void Turn(char turnAction, int degrees)
            {
                if (turnAction == 'L')
                {
                    degrees *= -1;
                }

                while (degrees < 0)
                {
                    degrees += 360;
                }

                _movementVector = (degrees % 360) switch
                {
                    0 => _movementVector,
                    90 => new Vector(_movementVector.Y, _movementVector.X * -1),
                    180 => new Vector(_movementVector.X * -1, _movementVector.Y * -1),
                    270 => new Vector(_movementVector.Y * -1, _movementVector.X),
                    _ => throw new ArgumentException("Unsupported degrees: " + degrees)
                };
            }

            public Vector MoveToEndPosition()
            {
                foreach (var (action, value) in _instructions)
                {
                    switch (action)
                    {
                        case 'E':
                        case 'S':
                        case 'W':
                        case 'N':
                            MoveIntoDirection(action, value);
                            break;
                        case 'L':
                        case 'R':
                            Turn(action, value);
                            break;
                        case 'F':
                            _position += (_movementVector * value);
                            break;
                        default:
                            throw new NotImplementedException("Action not implemented: " + action);
                    }
                }

                return _position;
            }

        }

        #region Problem One

        public static async Task<long> ProblemOneAsync(IEnumerable<string> lines = null)
        {
            lines ??= await ReadInputAsync();
            var endPosition = new Route(lines).MoveToEndPosition();
            return Math.Abs(endPosition.X) + Math.Abs(endPosition.Y);
        }

        #endregion

        #region Problem Two

        public static async Task<long> ProblemTwoAsync(IEnumerable<string> lines = null)
        {
            lines ??= await ReadInputAsync();
            var endPosition = new Route(lines, new Vector(10, 1), DirectionsMovementBehavior.DirectionsMoveWayPoint)
                .MoveToEndPosition();
            return Math.Abs(endPosition.X) + Math.Abs(endPosition.Y);
        }

        #endregion
    }
}
