namespace AdventOfCode._2023.Day2;

using System.Text.RegularExpressions;

public class GameFactory
{
    private static Regex _gameNumberRegex = new (@"(Game )(\d*)");
    private static Regex _blueRegex = new (@"(\d*)( blue)");
    private static Regex _greenRegex = new (@"(\d*)( green)");
    private static Regex _redRegex = new (@"(\d*)( red)");

    public Game CreateGame(string gameDetails)
    {
        Console.WriteLine($"Creating Game. Input=\"{gameDetails}\"");
        var gameNumber = ExtractGameNumber(gameDetails);

        var maxBlue = ExtractMaxOfColour(gameDetails, _blueRegex);
        var maxGreen = ExtractMaxOfColour(gameDetails, _greenRegex);
        var maxRed = ExtractMaxOfColour(gameDetails, _redRegex);

        var game = new Game
        {
            GameNumber = gameNumber,
            BlueCubesCount = maxBlue,
            GreenCubesCount = maxGreen,
            RedCubesCount = maxRed
        };

        Console.WriteLine($"New Game: {game}\n");

        return game;
    }

    private static int ExtractMaxOfColour(string gameDetails, Regex regex)
    {
        var matches = regex.Matches(gameDetails);
        if (matches.Count == 0)
        {
            Console.WriteLine($"No matches found. Regex=\"{regex}\"; Input=\"{gameDetails}\"");
            return 0;
        }

        var numbers = matches.Select(x => int.Parse(x.Groups[1].Value)).ToList();
        Console.WriteLine($"Found. Regex=\"{regex}\"; Numbers=\"{string.Join(',', numbers)}\"");

        return numbers.Max();
    }

    private static int ExtractGameNumber(string gameDetails)
    {
        var matches = _gameNumberRegex.Matches(gameDetails);
        if (matches.Count == 0)
        {
            throw new InvalidOperationException($"Input string does not contain the game number in the expected format. ExpectedFormat=\"Game n:\"; Input=\"{gameDetails}\"");
        }

        if (matches.Count > 1)
        {
            throw new InvalidOperationException($"Input string can not contain more than one game number. Input=\"{gameDetails}\"");
        }

        var gameNumberString = matches.First().Groups[2].Value;

        return int.Parse(gameNumberString);
    }

}