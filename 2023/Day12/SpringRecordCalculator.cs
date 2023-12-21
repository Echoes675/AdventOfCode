using System.ComponentModel;

namespace AdventOfCode._2023.Day12;

public class SpringRecordCalculator
{
    private Dictionary<string, long> _arrangements = new Dictionary<string, long>();

    public long CalculateNumberOfPossibleValidArrangements(List<string> input)
    {
        var total = 0L;

        foreach (var line in input)
        {
            var pair = line.Split(" ");
            string pattern = pair[0];
            var damagedSprings = pair[1].Split(',').Select(int.Parse).ToArray();
            total += Calculate(pattern, damagedSprings);
        }

        return total;
    }

    private long Calculate(string pattern, int[] groups)
    {
        var key = pattern + ':' + string.Join(",", groups);

        if (_arrangements.TryGetValue(key, out var result))
        {
            return result;
        }

        result =  Count(pattern, groups);

        _arrangements[key] = result;
        return result;
    }

    private long Count(string pattern, int[] groups)
    {
        while (true)
        {
            if (!groups.Any())
            {
                return pattern.Contains('#') ? 0 : 1;
            }

            if (string.IsNullOrEmpty(pattern))
            {
                return 0;
            }

            if (pattern.StartsWith('.'))
            {
                pattern = pattern.Trim('.');
                continue;
            }

            if (pattern.StartsWith('?'))
            {
                return Calculate('.' + pattern[1..], groups)
                    + Calculate('#' + pattern[1..], groups);
            }

            if (pattern.StartsWith('#'))
            {
                if (groups.Length == 0)
                {
                    return 0;
                }

                if (pattern.Length < groups[0])
                {
                    return 0;
                }

                if (groups.Length > 1)
                {
                    if (pattern.Length < groups[0] + 1 || pattern[groups[0]] == '#')
                    {
                        return 0;
                    }

                    pattern = pattern[(groups[0] + 1)..];
                    groups = groups[1..];
                    continue;
                }

                // pattern = pattern[groups[0]..];

                pattern = pattern.All(c => c is '#' or '?')
                    ? pattern[groups[0]..]
                    : pattern[pattern.IndexOf('.')..];
                groups = groups[1..];
                continue;
            }

            throw new Exception("Invalid input");
        }
    }
}
