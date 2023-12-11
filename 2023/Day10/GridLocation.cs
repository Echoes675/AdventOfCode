namespace AdventOfCode._2023.Day10;

public class GridLocation
{
    public GridLocation(char value, (int Row, int Column) coordinates)
    {
        Value = value;
        Coordinates = coordinates;
    }

    public char Value { get; }

    public (int Row, int Column) Coordinates { get; }

    public List<(int Row, int Column)> PossibleMoves => GetPossibleMoves().ToList();

    public List<(int Row, int Column)> NotConnected => GetNotConnectedCoordinates().ToList();

    private IEnumerable<(int Row, int Column)> GetNotConnectedCoordinates()
    {
        return Value switch
        {
            '|' => new[]
            {
                (Coordinates.Row, Coordinates.Column - 1), (Coordinates.Row, Coordinates.Column + 1)
            },

            '-' => new[]
            {
                (Coordinates.Row - 1, Coordinates.Column), (Coordinates.Row + 1, Coordinates.Column)
            },

            'L' => new[]
            {
                (Coordinates.Row + 1, Coordinates.Column), (Coordinates.Row, Coordinates.Column - 1)
            },

            'J' => new[]
            {
                (Coordinates.Row + 1, Coordinates.Column), (Coordinates.Row, Coordinates.Column + 1)
            },

            '7' => new[]
            {
                (Coordinates.Row - 1, Coordinates.Column), (Coordinates.Row, Coordinates.Column + 1)
            },

            'F' => new[]
            {
                (Coordinates.Row - 1, Coordinates.Column), (Coordinates.Row, Coordinates.Column - 1)
            },

            'S' => Array.Empty<(int Row, int Column)>(),

            '.' => new[]
            {
                (Coordinates.Row - 1, Coordinates.Column),
                (Coordinates.Row + 1, Coordinates.Column),
                (Coordinates.Row, Coordinates.Column - 1),
                (Coordinates.Row, Coordinates.Column + 1)
            },

            _ => throw new NotSupportedException("Value not supported")
        };
    }

    private IEnumerable<(int Row, int Column)> GetPossibleMoves()
    {
        return Value switch
        {
            '|' => new[]
            {
                (Coordinates.Row - 1, Coordinates.Column), (Coordinates.Row + 1, Coordinates.Column)
            },

            '-' => new[]
            {
                (Coordinates.Row, Coordinates.Column - 1), (Coordinates.Row, Coordinates.Column + 1)
            },

            'L' => new[]
            {
                (Coordinates.Row - 1, Coordinates.Column), (Coordinates.Row, Coordinates.Column + 1)
            },

            'J' => new[]
            {
                (Coordinates.Row - 1, Coordinates.Column), (Coordinates.Row, Coordinates.Column - 1)
            },

            '7' => new[]
            {
                (Coordinates.Row + 1, Coordinates.Column), (Coordinates.Row, Coordinates.Column - 1)
            },

            'F' => new[]
            {
                (Coordinates.Row, Coordinates.Column + 1), (Coordinates.Row + 1, Coordinates.Column)
            },

            '.' => Array.Empty<(int Row, int Column)>(),

            'S' => new[]
            {
                (Coordinates.Row - 1, Coordinates.Column),
                (Coordinates.Row + 1, Coordinates.Column),
                (Coordinates.Row, Coordinates.Column - 1),
                (Coordinates.Row, Coordinates.Column + 1)
            },

            _ => throw new NotSupportedException("Value not supported")
        };
    }
}
