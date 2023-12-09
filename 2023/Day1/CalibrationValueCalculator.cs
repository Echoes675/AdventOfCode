namespace AdventOfCode._2023.Day1;

public class CalibrationValueCalculator
{
    private readonly ICalibrationValueExtractor _calibrationValueDigitExtractor;
    private readonly ICalibrationValueExtractor _calibrationValueExtractor;

    public CalibrationValueCalculator()
    : this (new SimpleCalibrationValueExtractor(), new ComplexCalibrationValueExtractor())
    {
    }

    public CalibrationValueCalculator(ICalibrationValueExtractor calibrationValueDigitExtractor, ICalibrationValueExtractor calibrationValueExtractor)
    {
        _calibrationValueDigitExtractor = calibrationValueDigitExtractor;
        _calibrationValueExtractor = calibrationValueExtractor;
    }

    public (int answer1, int answer2) Calculate(string filePath)
    {
        if (string.IsNullOrEmpty(filePath))
        {
            throw new ArgumentException("Value cannot be null or empty.", nameof(filePath));
        }

        var result = (0,0);

        if (!File.Exists(filePath))
        {
            throw new InvalidOperationException($"Input file does not exist. File=\"{filePath}\"");
        }

        var file = File.ReadAllLines(filePath).ToList();

        if (file.Any())
        {
            result = (Calculate(_calibrationValueDigitExtractor.ExtractValue, file),
                        Calculate(_calibrationValueExtractor.ExtractValue, file));
        }

        return result;
    }

    private int Calculate(Func<string, int?> func, List<string> file)
    {

        int result;
        var numbers = new List<int>();
        var count = 1;
        foreach (var line in file)
        {
            Console.WriteLine(new string('*', 10));
            Console.WriteLine($"Line{count}: {line}");
            var number = _calibrationValueDigitExtractor.ExtractValue(line);
            if (number.HasValue)
            {
                numbers.Add(number.Value);
            }

            count++;
        }

        result = numbers.Sum();
        return result;
    }
}
