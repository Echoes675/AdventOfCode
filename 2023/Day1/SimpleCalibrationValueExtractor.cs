namespace AdventOfCode._2023.Day1;

using System.Text.RegularExpressions;

public class SimpleCalibrationValueExtractor : CalibrationValueExtractorBase
{

    private static Regex _calibrationValuesRegex = new(@"\d");

    public SimpleCalibrationValueExtractor()
        : base(_calibrationValuesRegex)
    {
    }

    protected override int RetrieveMultipleDigitNumber(string first, string last)
    {
        var firstNumber = int.Parse(first);
        var lastNumber = int.Parse(last);

        return firstNumber * 10 + lastNumber;
    }
}
