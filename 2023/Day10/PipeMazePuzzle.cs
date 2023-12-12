using System.Text;

namespace AdventOfCode._2023.Day10;

public class PipeMazePuzzle : PuzzleBase
{

    private readonly GridBuilder _gridBuilder;

    public PipeMazePuzzle()
    : this(new GridBuilder())
    {
    }

    public PipeMazePuzzle(GridBuilder gridBuilder)
    {
        _gridBuilder = gridBuilder;

    }

    public (long Answer1, long Answer2) CalculateAnswers(string filePath)
    {
        var file = GetFileLines(filePath);
        var grid = _gridBuilder.BuildGrid(file);

        var start = grid.Single(l => l.Value.Value == 'S');

        var roundTripSteps = CountRoundTripSteps(grid, start.Value.Coordinates, 0, out var loopPath);
        var answer1 = roundTripSteps / 2;

        var maxRow = grid.Select(r => r.Key.Row).Max();
        var maxColumn = grid.Select(r => r.Key.Column).Max();
        var rebuiltMap = ReBuildMap(loopPath, ++maxRow, ++maxColumn, out var mapString);
        var answer2 = mapString.Count(c => c == 'I');

        return (answer1, answer2);
    }

    private int CountRoundTripSteps(Dictionary<(int, int), GridLocation> grid, (int row, int column) currentCoordinates, int count, out List<GridLocation> loopPath)
    {
        loopPath = new List<GridLocation>();
        var previous = currentCoordinates;
        while (true)
        {
            if (!grid.TryGetValue(currentCoordinates, out var gridLocation))
            {
                return 0;
            }

            loopPath.Add(gridLocation);
            if (gridLocation.Value == 'S' && count > 0)
            {
                return count;
            }

            var possibleMoves = CheckNeighbours(grid, gridLocation);
            var newCoordinates = possibleMoves
                .First(x => x.Coordinates.Row != previous.row || x.Coordinates.Column != previous.column)
                .Coordinates;
            count++;
            previous = currentCoordinates;
            currentCoordinates = newCoordinates;
        }
    }

    private IEnumerable<GridLocation> CheckNeighbours(Dictionary<(int, int), GridLocation> grid, GridLocation currentGridLocation)
    {
        var neighbours = GetNeighbours(currentGridLocation.Coordinates);
        var possibleMoves = new List<GridLocation>();

        foreach (var neighbour in neighbours)
        {
            grid.TryGetValue(neighbour, out var neighbourGridLocation);
            if (neighbourGridLocation != null
                && currentGridLocation.PossibleMoves.Any(x => neighbourGridLocation.Coordinates == x)
                && neighbourGridLocation.PossibleMoves.Any(x => currentGridLocation.Coordinates == x))
            {
                possibleMoves.Add(neighbourGridLocation);
            }
        }

        return possibleMoves;
    }

    private List<(int Row, int Column)> GetNeighbours((int row, int column) coordinates)
    {
        var neighbours = new List<(int Row, int Column)>
        {
            (coordinates.row - 1, coordinates.column),
            (coordinates.row + 1, coordinates.column),
            (coordinates.row, coordinates.column - 1),
            (coordinates.row, coordinates.column + 1)
        };

        return neighbours;
    }

    private Dictionary<(int Row, int Column), GridLocation> ReBuildMap(List<GridLocation> loopPath, int maxRow, int maxColumn, out string mapString)
    {
        var mapSb = new StringBuilder();
        var updatedMap = new Dictionary<(int Row, int Column), GridLocation>();
        for (var i = 0; i < maxRow; i++)
        {
            var outsideLoop = true;
            var sb = new StringBuilder();
            var cornerCharCount = 0;
            for (var j = 0; j < maxColumn; j++)
            {
                var item = loopPath.FirstOrDefault(x => x.Coordinates == (i, j))
                           ?? new GridLocation(outsideLoop ? 'O' : 'I', (i, j));

                if (item.Value is '|' or 'J' or 'L' or 'S')
                {
                    cornerCharCount++;
                    outsideLoop = cornerCharCount % 2 == 0;
                }

                updatedMap.Add(item.Coordinates, item);
                sb.Append(item.Value);
            }

            Console.WriteLine(sb.ToString());
            mapSb.AppendLine(sb.ToString());
        }
        mapString = mapSb.ToString();
        return updatedMap;
    }
}
