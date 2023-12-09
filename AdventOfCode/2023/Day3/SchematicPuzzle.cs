namespace AdventOfCode._2023.Day3;

public class SchematicPuzzle
{

    private readonly SchematicReader _schematicReader;
    private readonly GearFinder _gearFinder;

    public SchematicPuzzle()
    : this(new SchematicReader(), new GearFinder())
    {
        
    }

    public SchematicPuzzle(SchematicReader schematicReader, GearFinder gearFinder)
    {
        _schematicReader = schematicReader;
        _gearFinder = gearFinder;

    }

    public (int Answer1, int Answer2) CalculateAnswers(string filePath)
    {
        var schematic = _schematicReader.ReadSchematic(filePath);

        if (string.IsNullOrEmpty(filePath))
        {
            throw new ArgumentException("Value cannot be null or empty.", nameof(filePath));
        }

        var result = new Schematic();

        if (!File.Exists(filePath))
        {
            throw new InvalidOperationException($"Input file does not exist. File=\"{filePath}\"");
        }

        // var file = File.ReadAllText(filePath);
        // var ex = new Example();
        // var answer1 = ex.PartOne(file);
        // var answer2 = ex.PartTwo(file);

        var partNumberFinder = new PartFinder();
        var parts = partNumberFinder.RetrieveAllParts(schematic);
        var gears = _gearFinder.RetrieveGears(parts);

        var answer1 = parts.Select(p => p.Int).Sum();
        var answer2 = gears.Select(g => g.Antecedent.Int * g.Consequent.Int).Sum();

        return (answer1, answer2);
    }

}