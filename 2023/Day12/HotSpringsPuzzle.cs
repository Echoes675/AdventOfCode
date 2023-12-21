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

        var answer2 = 0;

        return (answer1, answer2);
    }
}
