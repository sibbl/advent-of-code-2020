using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AdventOfCode2020.Day02
{
    public static class Solution02
    {
        private static readonly Regex PasswordEntryRegex =
            new(@"^(?<Param1>\d+)\-(?<Param2>\d+)\s*(?<Character>\w):\s*(?<Password>.*)$", RegexOptions.Multiline);
        private const string RegexParam1GroupName = "Param1";
        private const string RegexParam2GroupName = "Param2";
        private const string RegexCharacterGroupName = "Character";
        private const string RegexPasswordGroupName = "Password";

        private static Task<string> ReadInputAsync() => InputReader.ReadFileContent("Day02/input.txt");

        private abstract record PasswordPolicy(char Character) {
            public abstract bool IsValid(string password);
        }

        private record PasswordEntry<T>(string Password, T Policy)
            where T : PasswordPolicy {

            public bool IsValid() => Policy.IsValid(Password);
        }

        #region Problem One

        private record PasswordPolicyOne(char Character, int MinCharOccurrences, int MaxCharOccurrences) : PasswordPolicy(Character) {
            public PasswordPolicyOne(Match match) : this(
                Convert.ToChar(match.Groups[RegexCharacterGroupName].Value),
                Convert.ToInt32(match.Groups[RegexParam1GroupName].Value),
                Convert.ToInt32(match.Groups[RegexParam2GroupName].Value)
            )
            {}

            public override bool IsValid(string password)
            {
                var charOccurences = password.Count(c => c == Character);
                return charOccurences >= MinCharOccurrences && charOccurences <= MaxCharOccurrences;
            }
        }

        public static async Task<int> ProblemOneAsync(string input = null) {
            input ??= await ReadInputAsync();
            var entries = PasswordEntryRegex.Matches(input).Select(match =>
                new PasswordEntry<PasswordPolicyOne>(
                    match.Groups[RegexPasswordGroupName].Value,
                    new PasswordPolicyOne(match)
                ));

            return entries.Count(entry => entry.IsValid());
        }

        #endregion

        #region Problem Two

        private record PasswordPolicyTwo(char Character, int PositionOne, int PositionTwo) : PasswordPolicy(Character) {
            public PasswordPolicyTwo(Match match) : this(
                Convert.ToChar(match.Groups[RegexCharacterGroupName].Value),
                Convert.ToInt32(match.Groups[RegexParam1GroupName].Value),
                Convert.ToInt32(match.Groups[RegexParam2GroupName].Value)
            )
            {}

            public override bool IsValid(string password)
            {
                var positionOneCharacter = password[PositionOne - 1];
                var positionTwoCharacter = password[PositionTwo - 1];
                return positionOneCharacter != positionTwoCharacter &&
                    (positionOneCharacter == Character || positionTwoCharacter == Character);
            }
        }

        public static async Task<int> ProblemTwoAsync(string input = null) {
            input ??= await ReadInputAsync();
            var entries = PasswordEntryRegex.Matches(input).Select(match =>
                new PasswordEntry<PasswordPolicyTwo>(
                    match.Groups[RegexPasswordGroupName].Value,
                    new PasswordPolicyTwo(match)
                ));

            return entries.Count(entry => entry.IsValid());
        }

        #endregion
    }
}
