namespace AdventOfCode._2022.Day2;

public class RockPaperScissorsCalculator
{
    private static Dictionary<string, int> _combinationsScores = new()
    {
        {"A X", 3}, // Rock Rock - Draw
        {"A Y", 6}, // Rock Paper - Win
        {"A Z", 0}, // Rock Scissors - Loss
        {"B X", 0}, // Paper Rock - Loss
        {"B Y", 3}, // Paper Paper - Draw
        {"B Z", 6}, // Paper Scissors - Win
        {"C X", 6}, // Scissors Rock - Win
        {"C Y", 0}, // Scissors Paper - Loss
        {"C Z", 3}  // Scissors Scissors - Draw
    };

    private static Dictionary<string, int> _moveValue = new()
    {
        {"A", 1},
        {"B", 2},
        {"C", 3},
        {"X", 1},
        {"Y", 2},
        {"Z", 3},
    };

    private static Dictionary<string, int> _resultValue = new()
    {
        {"X", 0},
        {"Y", 3},
        {"Z", 6},
    };

    public int CalculateInvalidScore(string input)
    {
        var combinationScore = _combinationsScores[input];
        var moveValue = _moveValue[input[2].ToString()];

        return combinationScore + moveValue;
    }

    public int CalculateValidScore(string input)
    {


        return _moveValue[input[0].ToString()] + _resultValue[input[2].ToString()];
    }
}