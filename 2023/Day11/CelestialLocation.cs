namespace AdventOfCode._2023.Day11;

public record CelestialLocation(char Value, (int Row, int Column) Coordinates)
{
    public bool IsGalaxy => Value == '#';
}
