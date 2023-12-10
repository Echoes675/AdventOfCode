namespace AdventOfCode._2023;

public class PuzzleBase
{
    protected List<string> GetFileLines(string filePath)
    {
        if (string.IsNullOrEmpty(filePath))
        {
            throw new ArgumentException("Value cannot be null or empty.", nameof(filePath));
        }

        if (!File.Exists(filePath))
        {
            throw new InvalidOperationException($"Input file does not exist. File=\"{filePath}\"");
        }

        return File.ReadAllLines(filePath).ToList();
    }

}