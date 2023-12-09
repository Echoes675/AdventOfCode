namespace AdventOfCode._2023.Day2;

public class GamesIdCalculator
{
    private readonly GamesLoader _gamesLoader;

    public GamesIdCalculator()
    : this(new GamesLoader())
    {
    }

    public GamesIdCalculator(GamesLoader gamesLoader)
    {
        _gamesLoader = gamesLoader;
    }

    public (int Answer1, int Answer2) RetrieveAnswers(string filePath)
    {
        var games = _gamesLoader.LoadGames(filePath);

        var answer1 = RetrieveTotal(games, 12, 13, 14);
        var answer2 = RetrievePowerOfFewestPossibleCubes(games);

        return (answer1, answer2);
    }

    private int RetrievePowerOfFewestPossibleCubes(List<Game> games)
    {
        return games.Select(x => x.RedCubesCount * x.GreenCubesCount * x.BlueCubesCount).Sum();
    }

    private int RetrieveTotal(List<Game> games, int redCount, int greenCount, int blueCount)
    {
        var possibleGames = games.FindPossibleGames(redCount, greenCount, blueCount)
            .Select(x => x.GameNumber)
            .ToList();

        Console.WriteLine($"PossibleGames:\n{string.Join(',', possibleGames)}");

        return possibleGames.Sum();
    }
}