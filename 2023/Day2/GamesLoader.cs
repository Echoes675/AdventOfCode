namespace AdventOfCode._2023.Day2;

public class GamesLoader
{
    private readonly GameFactory _gameFactory;

    public GamesLoader()
        : this(new GameFactory())
    {
    }

    public GamesLoader(GameFactory gameFactory)
    {
        _gameFactory = gameFactory ?? throw new ArgumentNullException(nameof(gameFactory));
    }

    public List<Game> LoadGames(string filePath)
    {
        var result = new List<Game>();
        if (string.IsNullOrEmpty(filePath))
        {
            throw new ArgumentException("Value cannot be null or empty.", nameof(filePath));
        }

        if (!File.Exists(filePath))
        {
            throw new InvalidOperationException($"Input file does not exist. File=\"{filePath}\"");
        }

        var file = File.ReadAllLines(filePath).ToList();

        if (file.Any())
        {
            result = file.Where(x => !string.IsNullOrEmpty(x)).Select(_gameFactory.CreateGame).ToList();
        }

        return result;
    }
}