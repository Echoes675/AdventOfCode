namespace AdventOfCode._2023.Day1;

using System.Text.RegularExpressions;

public abstract class CalibrationValueExtractorBase : ICalibrationValueExtractor
{
    private readonly Regex _regex;

    protected CalibrationValueExtractorBase(Regex regex)
    {
        _regex = regex;
    }

    public int? ExtractValue(string input)
    {
        int result;

        var matches = _regex.Matches(input);

        if (matches == null || matches.Count == 0)
        {
            Console.WriteLine($"There are no numbers in the input string. Value={input}");
            return null;
        }

        var values = matches.Select(x => x.Value).ToList();

        Console.WriteLine("Matches:" + string.Join(";", values));

        if (values.Count == 1)
        {
            result = int.TryParse(values.First(), out var i) ?
                (i * 10) + i :
                throw new Exception($"Unable to parse string to integer. Input={i}");
        }
        else
        {
            result = RetrieveMultipleDigitNumber(values.First(), values.Last());
        }

        Console.WriteLine($"Number: {result}");

        return result;
    }

    protected abstract int RetrieveMultipleDigitNumber(string first, string last);
}