using System.Text.RegularExpressions;

namespace AdventOfCode._2023.Day8;

public class MapPuzzle : PuzzleBase
{

    private static Regex _coordinatesRegex = new Regex(@"(\w+)\s=\s\((\w+),\s(\w+)");
    private static Regex _directionsRegex = new Regex(@"(\w+)\s\s");

    public (long Answer1, long Answer2) CalculateAnswers(string filePath)
    {
        var file = ReadFile(filePath);

        var directionsMatches = _directionsRegex.Matches(file);
        var coordinatesMatches = _coordinatesRegex.Matches(file);

        var map = new Dictionary<string, (string Left, string Right)>(StringComparer.OrdinalIgnoreCase);

        foreach (Match match in coordinatesMatches)
        {
            map.Add(match.Groups[1].Value, (match.Groups[2].Value, match.Groups[3].Value));
        }

        var answer1 = CalculatePart1(map, directionsMatches.First().Value.Trim());

        var answer2 = 0;

        return (answer1, answer2);
    }

    private long CalculatePart1(Dictionary<string, (string Left, string Right)> map, string directions)
    {
        var currentLocation = "AAA";
        (string Left, string Right) currentPair;
        var count = 0;
        var index = 0;
        var found = false;
        while (!found)
        {
            var direction = directions[index];
            currentPair = map[currentLocation];
            currentLocation = direction == 'L' ? currentPair.Left : currentPair.Right;

            count++;
            index = index < directions.Length - 1 ? index + 1 : 0;

            if (currentLocation == "ZZZ")
            {
                found = true;
            }
        }

        return count;
    }
}
