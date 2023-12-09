using System.Text;
using System.Text.RegularExpressions;

namespace AdventOfCode._2023.Day3;

public class PartFinder
{

    private static readonly Regex _numberRegex = new (@"\d");
    private static readonly Regex _symbol = new (@"[^.\d\n]");

    public List<Part> RetrieveAllParts(Schematic schematic)
    {
        var parts = new List<Part>();
        for(var i = 0; i < schematic.Grid.Count; i++)
        {
            var item = schematic.Grid.ElementAt(i);
            if (item.Value.Equals(".") || _symbol.IsMatch(item.Value))
            {
                continue;
            }

            var numberStringBuilder = new StringBuilder();
            var isPartNumber = false;
            var (row, column) = item.Key;
            (int, int)? gearSymbolPosition = null;

            while (_numberRegex.IsMatch(item.Value) && i < schematic.Grid.Count)
            {
                numberStringBuilder.Append(item.Value);
                isPartNumber = (isPartNumber || CheckNeighbours(schematic.Grid, item.Key.Item1, item.Key.Item2, out gearSymbolPosition));
                i++;
                item = i < schematic.Grid.Count ? schematic.Grid.ElementAt(i) : item;
            }

            if (isPartNumber)
            {
                parts.Add(new Part(numberStringBuilder.ToString(), row, column, gearSymbolPosition));
            }
        }

        return parts;
    }

    private bool CheckNeighbours(Dictionary<(int, int), string> grid, int row, int column, out (int, int)? gearSymbolPosition) =>
        CheckNeighbour(grid, row - 1, column, out gearSymbolPosition) // Check N character
        || CheckNeighbour(grid, row - 1, column - 1, out gearSymbolPosition) // Check NW character
        || CheckNeighbour(grid, row, column - 1, out gearSymbolPosition) // Check W character
        || CheckNeighbour(grid, row + 1, column - 1, out gearSymbolPosition) // Check SW character
        || CheckNeighbour(grid, row + 1, column, out gearSymbolPosition) // Check S character
        || CheckNeighbour(grid, row + 1, column + 1, out gearSymbolPosition) // Check SE character
        || CheckNeighbour(grid, row, column + 1, out gearSymbolPosition) // Check E character
        || CheckNeighbour(grid, row - 1, column + 1, out gearSymbolPosition); // Check NE character

    private bool CheckNeighbour(Dictionary<(int, int), string> grid, int row, int column, out (int, int)? gearSymbolPosition)
    {
        gearSymbolPosition = null;
        var neighbourExists = grid.TryGetValue((row, column), out var neighbour);

        if (neighbourExists && !string.IsNullOrEmpty(neighbour))
        {
            gearSymbolPosition = neighbour == "*" ? (row, column) : null;
            return _symbol.IsMatch(neighbour);
        }

        return false;
    }
}

//public class Position
//{
//    private readonly int _x;
//    private readonly int _y;

//    public Position(int x, int y)
//    {
//        _x = x;
//        _y = y;

//    }

//    public int X { get; private set; } = _x;
//    public int Y { get; private set; } = _y;

//    public Position[] GetAdjacentPosition()
//    {
//        return [
//            new Position(X - 1, Y - 1),
//        new Position(X - 1, Y),
//        new Position(X - 1, Y + 1),
//        new Position(X, Y - 1),
//        new Position(X, Y + 1),
//        new Position(X + 1, Y - 1),
//        new Position(X + 1, Y),
//        new Position(X + 1, Y + 1)];
//    }
//}