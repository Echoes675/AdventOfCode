namespace AdventOfCode._2023.Day10;

public class GridBuilder
{
    public Dictionary<(int, int), GridLocation> BuildGrid(List<string> input)
    {
        var result = new Dictionary<(int, int), GridLocation>();
        for(var rowIndex = 0; rowIndex < input.Count; rowIndex++)
        {
            var row = input[rowIndex];
            for(var columnIndex = 0; columnIndex < row.Length; columnIndex++)
            {
                var value = row[columnIndex];
                var coordinates = (rowIndex, columnIndex);
                result.Add(coordinates, new GridLocation(value, coordinates));
            }
        }

        return result;
    }
}