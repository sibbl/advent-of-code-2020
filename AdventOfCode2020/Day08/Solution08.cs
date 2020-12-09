using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AdventOfCode2020.Day08
{
    public static class Solution08
    {
        private static Task<IEnumerable<string>> ReadInputAsync() => InputReader.ReadLinesAsync("Day08/input.txt");

        private static readonly Regex InstructionRegex = new(@"^(?<Operation>\w{3})\s+(?<Parameter>[^\s]+)$");

        private record Instruction(string Operation, int Parameter);

        private static Instruction ParseLine(string line)
        {
            var match = InstructionRegex.Match(line);
            var operation = match.Groups["Operation"].Value;
            var parameterString = match.Groups["Parameter"].Value;
            var parameter = int.Parse(parameterString);
            return new(operation, parameter);
        }

        private class LoopDetectedException : Exception { }

        private class Algorithm
        {
            private readonly ICollection<Instruction> _instructions;

            public int Pointer { get; private set; }
            public int Accumulator { get; private set; }

            public Algorithm(ICollection<Instruction> instructions) => _instructions = instructions;

            private int GetNextPointer()
            {
                var (operation, parameter) = _instructions.ElementAt(Pointer);
                return operation switch
                {
                    "jmp" => Pointer + parameter,
                    _ => Pointer + 1
                };
            }

            private void Step()
            {
                var (operation, parameter) = _instructions.ElementAt(Pointer);
                Pointer = GetNextPointer();
                switch (operation)
                {
                    case "acc":
                        Accumulator += parameter;
                        break;
                }
            }

            public void Run()
            {
                var calledInstructions = new HashSet<int>();

                while (true)
                {
                    var nextPointer = GetNextPointer();
                    if (nextPointer > _instructions.Count)
                    {
                        throw new IndexOutOfRangeException();
                    }
                    if (calledInstructions.Contains(nextPointer))
                    {
                        throw new LoopDetectedException();
                    }

                    calledInstructions.Add(Pointer);
                    Step();

                    if (Pointer == _instructions.Count)
                    {
                        return;
                    }
                }
            }
        }


        #region Problem One

        public static async Task<long> ProblemOneAsync(IEnumerable<string> lines = null)
        {
            lines ??= await ReadInputAsync();

            var algorithm = new Algorithm(lines.Select(ParseLine).ToList());

            try
            {
                algorithm.Run();
            }
            catch (LoopDetectedException)
            {
            }

            return algorithm.Accumulator;
        }

        #endregion


        #region Problem Two

        public static async Task<long> ProblemTwoAsync(IEnumerable<string> lines = null)
        {
            lines ??= await ReadInputAsync();

            var initialAlgorithmInstructions = lines.Select(ParseLine).ToArray();

            for (var i = 0; i < initialAlgorithmInstructions.Length; i++)
            {
                var instruction = initialAlgorithmInstructions[i];

                var newInstruction = instruction with
                {
                    Operation = instruction.Operation switch
                    {
                        "jmp" => "nop",
                        "nop" => "jmp",
                        _ => instruction.Operation
                    }
                };


                if (instruction != newInstruction)
                {
                    initialAlgorithmInstructions[i] = newInstruction;

                    var algorithm = new Algorithm(initialAlgorithmInstructions);
                    try
                    {
                        algorithm.Run();
                        return algorithm.Accumulator;
                    }
                    catch (Exception ex) when (ex is IndexOutOfRangeException || ex is LoopDetectedException)
                    {
                    }

                    initialAlgorithmInstructions[i] = instruction;
                }
            }

            return -1;
        }

        #endregion
    }
}
