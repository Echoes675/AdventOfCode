using System.Text.RegularExpressions;

namespace AdventOfCode._2023.Day11;

using System.Linq;

public class CosmicExpansionPuzzle : PuzzleBase
{

    private readonly CosmicExpansionCalculator _cosmicExpansionCalculator;

    public CosmicExpansionPuzzle()
    : this(new CosmicExpansionCalculator())
    {
    }

    public CosmicExpansionPuzzle(CosmicExpansionCalculator cosmicExpansionCalculator)
    {
        _cosmicExpansionCalculator = cosmicExpansionCalculator;
    }

    public (long Answer1, long Answer2) CalculateAnswers(string filePath)
    {
        var file = GetFileLines(filePath);

        var celestialMap = BuildMap(file);

        //var expandedMap = _cosmicExpansionCalculator.CalculateExpansion(file);

        var maxRow = celestialMap.Last().Coordinates.Row;
        var maxColumn = celestialMap.Last().Coordinates.Column;

        var galaxyRows = celestialMap.Where(x => x.IsGalaxy).Select(x => x.Coordinates.Row).ToList();
        var galaxyColumns = celestialMap.Where(x => x.IsGalaxy).Select(x => x.Coordinates.Column).ToList();

        var nonGalaxyRowIndexes = Enumerable.Range(0, maxRow + 1).Except(galaxyRows).Distinct().ToList();
        var nonGalaxyColumnIndexes = Enumerable.Range(0, maxColumn + 1).Except(galaxyColumns).Distinct().ToList();

        var distancesBetweenGalaxies = GetDistancesBetweenGalaxies(celestialMap, nonGalaxyRowIndexes, nonGalaxyColumnIndexes);

        var answer1 = distancesBetweenGalaxies.SelectMany(x => x.Values.Select(y => y)).Sum();

        var answer2 = 0;

        return (answer1,  answer2);
    }

    private List<Dictionary<(int FirstGalaxy, int SecondGalaxy), int>> GetDistancesBetweenGalaxies(List<CelestialLocation> celestialMap, List<int> nonGalaxyRowIndexes, List<int> nonGalaxyColumnIndexes)
    {
        var galaxyLocations = celestialMap.Where(x => x.IsGalaxy).ToList();
        var allGalaxyPairDistances = new List<Dictionary<(int FirstGalaxy, int SecondGalaxy), int>>();
        for(var i = 0; i < galaxyLocations.Count - 1; i++)
        {
            var galaxy = galaxyLocations[i];
            var galaxyDistances = new Dictionary<(int FirstGalaxy,int SecondGalaxy),int>();

            for(var j = (i + 1); j < galaxyLocations.Count; j++ )
            {
                var otherGalaxy = galaxyLocations[j];
                var expandedRowCount = nonGalaxyRowIndexes.Count(r => r > galaxy.Coordinates.Row && r < otherGalaxy.Coordinates.Row);
                var expandedColumnCount = nonGalaxyColumnIndexes.Count(r => (r > galaxy.Coordinates.Column && r < otherGalaxy.Coordinates.Column)
                                                                                    ||(r > otherGalaxy.Coordinates.Column && r < galaxy.Coordinates.Column));

                var rowDiff = otherGalaxy.Coordinates.Row > galaxy.Coordinates.Row
                    ? otherGalaxy.Coordinates.Row - galaxy.Coordinates.Row
                    : galaxy.Coordinates.Row - otherGalaxy.Coordinates.Row;

                var columnDiff = otherGalaxy.Coordinates.Column > galaxy.Coordinates.Column
                    ? otherGalaxy.Coordinates.Column - galaxy.Coordinates.Column
                    : galaxy.Coordinates.Column - otherGalaxy.Coordinates.Column;

                var distance = rowDiff + columnDiff + expandedRowCount + expandedColumnCount;

                galaxyDistances.Add((i + 1, j + 1),distance);
                // Console.WriteLine($"Galaxy:{i+1}; Coordinates:{galaxy.Coordinates}; Galaxy:{j+1}; Coordinates:{otherGalaxy.Coordinates}; RowExpansion:{expandedRowCount}; ColumnExpansion:{expandedColumnCount}; Distance:{distance}");
            }
            // Console.WriteLine(new string('-',15));
            allGalaxyPairDistances.Add(galaxyDistances);
        }

        return allGalaxyPairDistances;
    }

    private List<CelestialLocation> BuildMap(List<string> file)
    {
        var map = new List<CelestialLocation>();
        for (var rowIndex = 0; rowIndex < file.Count; rowIndex++)
        {
            var line = file[rowIndex];
            for (var columnIndex = 0; columnIndex < line.Length; columnIndex++)
            {
                var c = line[columnIndex];
                map.Add(new CelestialLocation(c, (rowIndex, columnIndex)));
            }
        }

        return map;

        //return file.SelectMany(
        //    (x, r) => x.Select((v, c) => new CelestialLocation(v, (r, c))))
        //    .ToList();
    }
}

public class CosmicExpansionCalculator
{
    private Regex _galaxiesRegex = new Regex(@"(#)");
    public List<CelestialLocation> CalculateExpansion(List<string> celestialMap)
    {
        var galaxyCoordinates = FindGalaxies(celestialMap).ToList();

        var maxRow = celestialMap.Count;
        var maxColumn = celestialMap[0].Length;

        var galaxyRows = galaxyCoordinates.Select(x => x.Row).ToList();
        var galaxyColumns = galaxyCoordinates.Select(x => x.Column).ToList();

        var nonGalaxyRowIndexes = Enumerable.Range(0, maxRow + 1).Except(galaxyRows).ToList();
        var nonGalaxyColumnIndexes = Enumerable.Range(0, maxColumn + 1).Except(galaxyColumns).ToList();

        var expandedMap = ExpandMap(celestialMap, nonGalaxyRowIndexes, nonGalaxyColumnIndexes);
        throw new NotImplementedException();
    }

    private List<string> ExpandMap(List<string> celestialMap, List<int> nonGalaxyRowIndexes, List<int> nonGalaxyColumnIndexes)
    {
        var expandedRowsMap = ExpandRows(celestialMap, nonGalaxyRowIndexes);
        throw new NotImplementedException();
    }

    private List<string> ExpandRows(List<string> celestialMap, List<int> nonGalaxyRowIndexes)
    {
        var result = celestialMap.SelectMany(
            (r , i) => nonGalaxyRowIndexes.Contains(i)
                ? Enumerable.Repeat(r, 2)
                : Enumerable.Repeat(r, 1))
            .ToList();

        return result;
    }

    private List<string> ExpandColumns(List<string> celestialMap, List<int> nonGalaxyRowIndexes)
    {
        throw new NotImplementedException();
    }

    private List<(int Row,int Column)> FindGalaxies(List<string> celestialMap)
    {
        var result = new List<(int Row,int Column)> ();
        for (var i = 0; i < celestialMap.Count; i++)
        {
            var row = celestialMap[i];
            var galaxyMatches = _galaxiesRegex.Matches(row);
            var galaxiesCoordinates = galaxyMatches.Select(x => (Row: i, Column: x.Index));
            result.AddRange(galaxiesCoordinates);
        }

        return result;
    }

}