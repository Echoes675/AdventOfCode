namespace AdventOfCode._2023.Day7;

public class CamelCardsPuzzle
{
    public (long Answer1, long Answer2) CalculateAnswers(string filePath)
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

        var plays = file.Select(
            x =>
            {
                var values = x.Split(" ");
                var bid = int.Parse(values[1]);
                return new Play(new Hand(values[0]), bid);
            }).ToList();

        var answer1 = CalculateAnswer1(plays);
        var answer2 = 0;

        return (answer1, answer2);
    }

    private int CalculateAnswer1(List<Play> plays)
    {
        var total = 0;
        var rank = 1;
        plays.Sort();
        foreach (var play in plays)
        {
            total += play.Bid * rank;
            rank++;
        }

        return total;
    }

}