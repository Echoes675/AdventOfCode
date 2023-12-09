namespace AdventOfCode._2023.Day2;

public class Game
{
    public int GameNumber { get; set; }
    public int BlueCubesCount { get; set; }
    public int GreenCubesCount { get; set; }
    public int RedCubesCount { get; set; }

    public override string ToString()
    {
        return
            $"GameNumber:{GameNumber};BlueCubesCount:{BlueCubesCount};GreenCubesCount:{GreenCubesCount};RedCubesCount:{RedCubesCount}";
    }
}