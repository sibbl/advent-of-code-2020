using System;

namespace AdventOfCode2020.Extensions
{
    public static class NumberExtensions
    {
        public static string ToBinaryString(this long number) => Convert.ToString(number, 2);

        public static string ToBinaryString(this long number, int paddedLength) =>
            ToBinaryString(number).PadLeft(paddedLength, '0');
        public static string ToBinaryString(this int number) => Convert.ToString(number, 2);

        public static string ToBinaryString(this int number, int paddedLength) =>
            ToBinaryString(number).PadLeft(paddedLength, '0');
    }
}
