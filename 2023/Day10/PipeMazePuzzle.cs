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

        var roundTripSteps = CountRoundTripSteps(grid, start.Value.Coordinates, 0);
        var answer1 = roundTripSteps / 2;
        var answer2 = 0;

        return (answer1, answer2);
    }

    private int CountRoundTripSteps(Dictionary<(int, int), GridLocation> grid, (int row, int column) currentCoordinates, int count)
    {
        var values = new List<char>();
        var previous = currentCoordinates;
        while (true)
        {
            if (!grid.TryGetValue(currentCoordinates, out var gridLocation))
            {
                return 0;
            }

            values.Add(gridLocation.Value);
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
}
