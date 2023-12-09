namespace AdventOfCode._2023.Day3;

public class SchematicReader
{
    public Schematic ReadSchematic(string filePath)
    {
        if (string.IsNullOrEmpty(filePath))
        {
            throw new ArgumentException("Value cannot be null or empty.", nameof(filePath));
        }

        var result = new Schematic();

        if (!File.Exists(filePath))
        {
            throw new InvalidOperationException($"Input file does not exist. File=\"{filePath}\"");
        }

        var file = File.ReadAllLines(filePath).ToList();

        if (file.Any())
        {
            result = ReadSchematic(file);
        }

        return result;
    }

    private Schematic ReadSchematic(List<string> file)
    {
        var result = new Schematic();
        var rowCount = 1;

        foreach (var row in file)
        {
            var columnCount = 1;

            while (row.Length >= columnCount)
            {
                var item = row[columnCount-1].ToString();
                var coordinates = (rowCount, columnCount);

                result.Grid.Add(coordinates, item);
                columnCount++;
            }

            rowCount++;
        }

        return result;
    }
}
