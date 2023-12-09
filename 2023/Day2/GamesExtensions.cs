namespace AdventOfCode._2023.Day2;

public static class GamesExtensions
{
    public static List<Game> FindPossibleGames(this List<Game> games, int redCount, int greenCount, int blueCount)
    {
        return games.Where(x =>
            x.RedCubesCount <= redCount &&
            x.GreenCubesCount <= greenCount &&
            x.BlueCubesCount <= blueCount)
            .ToList();
    }
}