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

        var answer1 = CalculateNumberOfSteps(map, directionsMatches.First().Value.Trim(), "AAA", x => x != "ZZZ");

        var answer2 = CalculatePart2(map, directionsMatches.First().Value.Trim());

        return (answer1, answer2);
    }

    private long CalculatePart2(Dictionary<string, (string Left, string Right)> map, string directions)
    {
        var startNodes = map.Where(x => x.Key[2] == 'A').Select(s => s.Key).ToList();
        var stepsCounts = new List<int>();
        Parallel.ForEach(
            startNodes, node =>
            {
                stepsCounts.Add(CalculateNumberOfSteps(map, directions, node, x => x[2] != 'Z'));
            });

        return LeastCommonMultiple.LCM(stepsCounts.ToArray());
    }

    private int CalculateNumberOfSteps(Dictionary<string, (string Left, string Right)> map, string directions, string startNode, Func<string,bool> predicate)
    {
        var currentLocation = startNode;
        var count = 0;
        var index = 0;
        while (predicate.Invoke(currentLocation))
        {
            var direction = directions[index];
            (string Left, string Right) currentPair = map[currentLocation];
            currentLocation = direction == 'L' ? currentPair.Left : currentPair.Right;

            count++;
            index = index < directions.Length - 1 ? index + 1 : 0;
        }

        return count;
    }
}
