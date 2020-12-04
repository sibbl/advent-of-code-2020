using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode2020.Day04
{
    internal class Passport
    {
        private const string BirthYear = "byr";
        private const string IssueYear = "iyr";
        private const string ExpirationYear = "eyr";
        private const string Height = "hgt";
        private const string HairColor = "hcl";
        private const string EyeColor = "ecl";
        private const string PassportId = "pid";
        private const string CountryId = "cid";

        private static readonly string[] NecessaryFieldsOfValidPassport =
        {
            BirthYear,
            IssueYear,
            ExpirationYear,
            Height,
            HairColor,
            EyeColor,
            PassportId
        };

        private static readonly Regex FieldRegex = new(@"(?<Name>\w{3}):(?<Value>\S+)");
        private static readonly Regex ColorRegex = new(@"^#[a-f0-9]{6}$");
        private static readonly Regex PassportIdRegex = new(@"^0*[0-9]{9}$");
        private static readonly string[] ValidEyeColors = { "amb", "blu", "brn", "gry", "grn", "hzl", "oth" };

        private readonly IDictionary<string, string> _fields = new Dictionary<string, string>();

        private void AddField(string name, string value)
        {
            _fields[name] = value;
        }

        public static Passport ParseFromLines(IEnumerable<string> lines)
        {
            var result = new Passport();

            foreach (var line in lines)
            {
                var matches = FieldRegex.Matches(line);
                foreach (Match match in matches)
                {
                    var name = match.Groups["Name"].Value;
                    var value = match.Groups["Value"].Value;
                    result.AddField(name, value);
                }
            }

            return result;
        }

        private bool HasField(string fieldName) => _fields.ContainsKey(fieldName);

        public bool HasNecessaryFields() => NecessaryFieldsOfValidPassport.All(HasField);

        private bool HasValidFieldValue(string fieldName)
            => _fields.TryGetValue(fieldName, out var fieldValue) &&
                fieldValue != null &&
                fieldName switch
                {
                    BirthYear when fieldValue is { Length: 4 }
                        => int.TryParse(fieldValue, out var number) && number >= 1920 && number <= 2002,
                    IssueYear when fieldValue is { Length: 4 }
                        => int.TryParse(fieldValue, out var number) && number >= 2010 && number <= 2020,
                    ExpirationYear when fieldValue is { Length: 4 }
                        => int.TryParse(fieldValue, out var number) && number >= 2020 && number <= 2030,
                    Height when fieldValue.EndsWith("cm")
                        => int.TryParse(fieldValue[..^2], out var number) && number >= 150 && number <= 193,
                    Height when fieldValue.EndsWith("in")
                        => int.TryParse(fieldValue[..^2], out var number) && number >= 48 && number <= 76,
                    HairColor => ColorRegex.Match(fieldValue).Success,
                    EyeColor => ValidEyeColors.Contains(fieldValue),
                    PassportId => PassportIdRegex.Match(fieldValue).Success,
                    CountryId => true,
                    _ => false
                };

        public bool IsValid() => NecessaryFieldsOfValidPassport.All(HasValidFieldValue);
    }
}