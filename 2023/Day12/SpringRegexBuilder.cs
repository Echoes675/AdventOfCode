using HandlebarsDotNet.Extensions;
using System.Text;
using System.Text.RegularExpressions;

namespace AdventOfCode._2023.Day12;

public static class SpringRegexBuilder
{
    public static Regex Build(int patternLength, List<int> numbers)
    {
        if (numbers == null || !numbers.Any())
        {
            throw new ArgumentNullException(nameof(numbers));
        }

        var countOfNumbers = numbers.Count;

        var sb = new StringBuilder();

        sb.Append($"^(?=.{{{patternLength}}}$)");

        sb.Append(@"(\.)*");

        for (var i = 0; i < countOfNumbers; i++)
        {
            var number = numbers[i];
            sb.Append($"(#{{{number}}})");

            var symbol = i < countOfNumbers - 1 ? '+' : '*';

            sb.Append($"(\\.){symbol}");
        }

        sb.Append("$");

        return new Regex(sb.ToString());
    }
}
