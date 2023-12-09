namespace AdventOfCode._2023.Day1;

using System.Text.RegularExpressions;

public class ComplexCalibrationValueExtractor : CalibrationValueExtractorBase
{
    private static Regex _calibrationValuesRegex = new (@"(?=(one|two|three|four|five|six|seven|eight|nine))|\d");

    public ComplexCalibrationValueExtractor()
        : base(_calibrationValuesRegex)
    {
    }

    protected override int RetrieveMultipleDigitNumber(string first, string last)
    {
        var firstNumber = int.TryParse(first, out var i) ? i : WordToNumber(first);

        var lastNumber = int.TryParse(last, out var j) ? j : WordToNumber(last);

        return firstNumber * 10 + lastNumber;
    }

    private int WordToNumber(string value)
    {
        return value.ToLower() switch
        {
            "one" => 1,
            "two" => 2,
            "three" => 3,
            "four" => 4,
            "five" => 5,
            "six" => 6,
            "seven" => 7,
            "eight" => 8,
            "nine" => 9,
            "zero" => 0,
            _ => throw new InvalidOperationException($"Value is not a number. Value=\"{value}\"")
        };
    }
}
