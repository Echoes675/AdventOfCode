using AdventOfCode._2022.Day1;
using AdventOfCode._2022.Day2;

namespace AdventOfCode._2022;

public class QuizRunner2022 : IQuizRunner
{
    public void Run(int day)
    {
        switch (day)
        {
            case 1:
                Day1();
                break;
            case 2:
                Day2();
                break;
        }

        Console.ReadLine();
    }

    private static void Day2()
    {
        var rockPaperScissorsPuzzle = new RockPaperScissorsPuzzle();

        var result = rockPaperScissorsPuzzle.CalculateAnswers(
            "C:\\Development\\Personal\\AdventOfCode\\AdventOfCode\\2022\\Day2\\input.txt");

        Console.WriteLine($"Q1: {result.Answer1}");
        Console.WriteLine($"Q2: {result.Answer2}");
    }

    private static void Day1()
    {
        var elfCaloriePuzzle = new ElfCaloriePuzzle();

        var result = elfCaloriePuzzle.CalculateAnswers(
            "C:\\Development\\Personal\\AdventOfCode\\AdventOfCode\\2022\\Day1\\input.txt");

        Console.WriteLine($"Q1: {result.Answer1}");
        Console.WriteLine($"Q2: {result.Answer2}");
    }
}