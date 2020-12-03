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
        /// Reads file and converts each line into an integer
        /// </summary>
        /// <param name="filename">Path to file to read</param>
        /// <returns>Enumerable of integers</returns>
        public static async Task<IEnumerable<int>> ReadLinesAsIntegersAsync(string filename)
        {
            var lines = await ReadLinesAsync(filename);
            return lines.Select(line => Convert.ToInt32(line));
        }

        /// <summary>
        /// Reads file and returns the lines as a string array
        /// </summary>
        /// <param name="filename">Path to file to read</param>
        /// <returns>File content</returns>
        public static async Task<IEnumerable<IEnumerable<char>>> ReadMapAsync(string filename)
        {
            var lines =await File.ReadAllLinesAsync(filename);
            return lines.Select(x => x.ToCharArray());
        }
    }
}