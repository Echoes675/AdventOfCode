namespace AdventOfCode._2022.Day2;

public class RockPaperScissorsPuzzle
{

    private readonly RockPaperScissorsCalculator _rockPaperScissorsCalculator;

    public RockPaperScissorsPuzzle() 
        : this(new RockPaperScissorsCalculator())
    {
        
    }

    public RockPaperScissorsPuzzle(RockPaperScissorsCalculator rockPaperScissorsCalculator)
    {
        _rockPaperScissorsCalculator = rockPaperScissorsCalculator;

    }

    public (int Answer1, int Answer2) CalculateAnswers(string filePath)
    {
        if (string.IsNullOrEmpty(filePath))
        {
            throw new ArgumentException("Value cannot be null or empty.", nameof(filePath));
        }

        if (!File.Exists(filePath))
        {
            throw new InvalidOperationException($"Input file does not exist. File=\"{filePath}\"");
        }

        var file = File.ReadAllLines(filePath).ToList();

        var answer1Scores = new List<int>();
        var answer2Scores = new List<int>();

        if (file.Any())
        {
            answer1Scores.AddRange(CalculateScores(file, _rockPaperScissorsCalculator.CalculateInvalidScore));
            answer2Scores.AddRange(CalculateScores(file, _rockPaperScissorsCalculator.CalculateValidScore));
        }

        return (answer1Scores.Sum(), answer2Scores.Sum());
    }

    private List<int> CalculateScores(List<string> file, Func<string, int> func)
    {
        var result = new List<int>();

        foreach (var item in file.Where(x => !string.IsNullOrEmpty(x)))
        {
            result.Add(func(item));
        }

        return result;
        
    }
}
