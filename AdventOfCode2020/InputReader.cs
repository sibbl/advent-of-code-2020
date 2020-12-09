using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace AdventOfCode2020
{
    public static class InputReader
    {
        /// <summary>
        /// Reads file and returns the content
        /// </summary>
        /// <param name="filename">Path to file to read</param>
        /// <returns>File content</returns>
        public static Task<string> ReadFileContent(string filename)
        {
            return File.ReadAllTextAsync(filename);
        }

        /// <summary>
        /// Reads file and returns the lines as a string array
        /// </summary>
        /// <param name="filename">Path to file to read</param>
        /// <returns>File content</returns>
        public static async Task<IEnumerable<string>> ReadLinesAsync(string filename)
        {
            var lines = await File.ReadAllLinesAsync(filename);
            return lines;
        }

        /// <summary>
        /// Reads file and converts each line into a long
        /// </summary>
        /// <param name="filename">Path to file to read</param>
        /// <returns>Enumerable of longs</returns>
        public static async Task<IEnumerable<long>> ReadLinesAsLongsAsync(string filename)
        {
            var lines = await ReadLinesAsync(filename);
            return lines.Select(line => Convert.ToInt64(line));
        }

        /// <summary>
        /// Reads file and returns the lines as character map
        /// </summary>
        /// <param name="filename">Path to file to read</param>
        /// <returns>Character map</returns>
        public static async Task<IEnumerable<IEnumerable<char>>> ReadMapAsync(string filename)
        {
            var lines = await File.ReadAllLinesAsync(filename);
            return lines.Select(x => x.ToCharArray());
        }

        /// <summary>
        /// Reads file and returns the lines as a string array, grouped into blocks separated by empty lines
        /// </summary>
        /// <param name="filename">Path to file to read</param>
        /// <returns>Blocks of lines of strings</returns>
        public static async Task<IEnumerable<IEnumerable<string>>> ReadBlocksBetweenEmptyLinesAsync(string filename)
        {
            var lines = await File.ReadAllLinesAsync(filename);
            var result = new List<IEnumerable<string>>();
            var currentBlock = new List<string>();
            foreach (var line in lines)
            {
                if (string.IsNullOrWhiteSpace(line))
                {
                    if (currentBlock.Count > 0)
                    {
                        result.Add(currentBlock);
                        currentBlock = new();
                    }
                }
                else
                {
                    currentBlock.Add(line);
                }
            }

            if (currentBlock.Count > 0)
            {
                result.Add(currentBlock);
            }

            return result;
        }
    }
}