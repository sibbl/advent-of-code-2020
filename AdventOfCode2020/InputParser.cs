using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode2020
{
    public static class InputParser
    {
        /// <summary>
        /// Parses content by applying a regular expression and returns the value from the given conversion function
        /// </summary>
        /// <remarks>
        /// If the regular expression has the multiline flag, it's applied on the whole file content.
        /// Otherwise the lines are split, empty lines are ignored, and the expression is then applied on each line.
        /// </remarks>
        /// <typeparam name="T">Result type</typeparam>
        /// <param name="input">String content to parse</param>
        /// <param name="regex">Regular expression to apply on each line</param>
        /// <param name="conversionFunc">Function applied onto each regex match</param>
        /// <returns>Enumerable of result types</returns>
        public static IEnumerable<T> ParseLinesUsingRegex<T>(string input, Regex regex, Func<Match, T> conversionFunc)
        {
            return regex.Options.HasFlag(RegexOptions.Multiline)
                ? regex.Matches(input).Select(conversionFunc)
                : input.Split('\r', StringSplitOptions.RemoveEmptyEntries)
                    .Select(line => regex.Match(line))
                    .Select(conversionFunc);
        }
    }
}