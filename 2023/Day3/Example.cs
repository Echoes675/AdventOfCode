using System.Text.RegularExpressions;

namespace AdventOfCode._2023.Day3;

public class Example
{

    // Introduce a Parse function that returns the interesting 'blocks' of texts 
    // and positions using a regex. Then just filter and match these according
    // to the problem spec.

    public int PartOne(string input)
    {
        var rows = input.Split("\n");
        var symbols = Parse(rows, new Regex(@"[^.0-9]"));
        var nums = Parse(rows, new Regex(@"\d+"));

        //return nums.Where(n => symbols.Any(s => Adjacent(s, n))).Select(i => i.Int).Sum();

        return (
            from n in nums
            where symbols.Any(s => Adjacent(s, n))
            select n.Int
        ).Sum();
    }

    public int PartTwo(string input)
    {
        var rows = input.Split("\n");
        var gears = Parse(rows, new Regex(@"\*"));
        var numbers = Parse(rows, new Regex(@"\d+"));

        return (
            from g in gears
            let neighbours = from n in numbers where Adjacent(n, g) select n.Int
            where neighbours.Count() == 2
            select neighbours.First() * neighbours.Last()
        ).Sum();
    }

    // checks that the parts are touching each other, i.e. rows are within 1 
    // step and also the columns (using https://stackoverflow.com/a/3269471).
    private bool Adjacent(Part p1, Part p2) =>
        Math.Abs(p2.Row - p1.Row) <= 1 &&
        p1.Column <= p2.Column + p2.Text.Length &&
        p2.Column <= p1.Column + p1.Text.Length;

    // returns the matches of rx with its coordinates
    private Part[] Parse(string[] rows, Regex rx) => (
        from irow in Enumerable.Range(0, rows.Length)
        from match in rx.Matches(rows[irow])
        select new Part(match.Value, irow, match.Index)
    ).ToArray();

}