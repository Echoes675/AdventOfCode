namespace AdventOfCode._2023.Day3;

public class GearFinder
{
    public List<Gear> RetrieveGears(List<Part> parts)
    {
        var gears =
            parts.Where(p => p.GearPosition != null)
                .Select(g => g.GearPosition)
                .Distinct()
                .ToDictionary(
                    g => g ?? throw new InvalidOperationException("Gear co-ordinates cannot be null"),
                    g => parts.Where(p => p.GearPosition == g).ToList())
                .Where(kvp => kvp.Value.Count() == 2)
                .Select(g => new Gear(g.Value[0], g.Value[1]))
                .ToList();

        return gears;
    }
}
