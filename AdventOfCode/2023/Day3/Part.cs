namespace AdventOfCode._2023.Day3;

public record Part(string Text, int Row, int Column, (int, int)? GearPosition = null)
{
    public int Int => int.Parse(Text);

}