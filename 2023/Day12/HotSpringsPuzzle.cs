namespace AdventOfCode._2023.Day12;

using Fare;
using System.Collections.Immutable;

public class HotSpringsPuzzle : PuzzleBase
{

    private readonly SpringRecordCalculator _calculator;

    public HotSpringsPuzzle()
        : this(new SpringRecordCalculator())
    {
    }

    public HotSpringsPuzzle(SpringRecordCalculator calculator)
    {
        _calculator = calculator;
    }

    public (long Answer1, long Answer2) CalculateAnswers(string filePath)
    {
        var damagedRecords = GetFileLines(filePath);
        var answer1 = _calculator.CalculateNumberOfPossibleValidArrangements(damagedRecords);

        var unfoldedDamagedRecords = UnfoldSprings(damagedRecords);

        var answer2 = _calculator.CalculateNumberOfPossibleValidArrangements(unfoldedDamagedRecords);

        return (answer1, answer2);
    }

    private List<string> UnfoldSprings(List<string> springs)
    {
        var result = new List<string>();
        foreach (var record in springs)
        {
            var springRecord = record.Split(' ');

            var newPattern = string.Join('?', Enumerable.Repeat(springRecord[0], 5));
            var newGroups = string.Join(',', Enumerable.Repeat(springRecord[1], 5));

            result.Add(newPattern + " " + newGroups);
        }

        return result;
    }
}
