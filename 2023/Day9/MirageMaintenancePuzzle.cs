namespace AdventOfCode._2023.Day9;

public class MirageMaintenancePuzzle : PuzzleBase
{
    public (long Answer1, long Answer2) CalculateAnswers(string filePath)
    {
        var report = GetFileLines(filePath);

        var answer1 = report
            .Select(x => CalculateNextNumber(x.Split(" ").Select(long.Parse).ToList()))
            .Sum();

        var answer2 = report
            .Select(x => CalculatePreviousNumber(x.Split(" ").Select(long.Parse).ToList()))
            .Sum();

        return (answer1, answer2);
    }

    private long CalculateNextNumber(string numbers)
    {
        return CalculateNextNumber(numbers.Split(" ").Select(long.Parse).ToList());
    }

    private long CalculatePreviousNumber(string numbers)
    {
        return CalculatePreviousNumber(numbers.Split(" ").Select(long.Parse).ToList());
    }

    private long CalculatePreviousNumber(List<long> numbers)
    {
        var diffs = CalculateDiffs(numbers);
        var previousNumber = diffs.First();
        if (diffs.GroupBy(x => x).Count() > 1)
        {
            previousNumber = CalculatePreviousNumber(diffs);
        }

        return numbers.First() - previousNumber;
    }

    private long CalculateNextNumber(List<long> numbers)
    {
        var diffs = CalculateDiffs(numbers);
        var nextNumber = diffs.Last();
        if (diffs.GroupBy(x => x).Count() > 1)
        {
            nextNumber = CalculateNextNumber(diffs);
        }

        return numbers.Last() + nextNumber;
    }

    private List<long> CalculateDiffs(List<long> numbers)
    {
        var result = new List<long>();
        for (var i = 0; i < numbers.Count - 1; i++)
        {
            result.Add(numbers[i + 1] - numbers[i]);
        }

        return result;
    }
}