using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2020.Extensions
{
    public static class StringExtensions
    {
        /// <summary>
        /// Converts input like binary '1010' to 10
        /// </summary>
        /// <param name="input">Binary representation of input</param>
        /// <returns>Integer representation of binary input</returns>
        public static int ToIntegerFromBinary(this string input)
            => Convert.ToInt32(input, 2);

        /// <summary>
        /// Replace characters by specified map, where key will be replaced by value
        /// </summary>
        /// <param name="input">String to replace characters in</param>
        /// <param name="replacementDict"></param>
        /// <returns>String with replaced characters</returns>
        public static string ReplaceCharactersInString(this string input, IEnumerable<KeyValuePair<char, char>> replacementDict)
            => replacementDict.Aggregate(input, (current, value) => current.Replace(value.Key, value.Value));

        public static long ToLongFromBinary(this string input) => Convert.ToInt64(input, 2);
        public static long ToLongFromBinary(this char[] input) => ToLongFromBinary(new string(input));
    }
}
