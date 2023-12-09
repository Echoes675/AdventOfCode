using System.Text.RegularExpressions;

namespace AdventOfCode._2023.Day5;

public class SeedRangeReader
{
    private static Regex _seedRanges = new Regex(@"(\d+\s\d+)");

    public List<MapRange> ReadSeedRange(string input)
    {
        var matches = _seedRanges.Matches(input);

        var mapRanges = GetSeedRanges(matches).ToList();
        //var seedRanges = mapRanges.Select(
        //    r =>
        //    {
        //        var mergedRanges = r;
        //        mapRanges.Where(r.OverlappingRanges).ToList().ForEach(o => mergedRanges = r.Merge(o));
        //        return mergedRanges;
        //    })
        //    .OrderBy(r => r.Start)
        //    .ToList();

        return mapRanges;
    }

    private IEnumerable<MapRange> GetSeedRanges(MatchCollection matches)
    {
        foreach (Match match in matches)
        {
            var numbers = match.Value.Split(' ');
            yield return new MapRange(long.Parse(numbers[0]), (long.Parse(numbers[1])));
        }
    }
}
