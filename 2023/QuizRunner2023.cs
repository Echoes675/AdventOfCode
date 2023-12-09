using AdventOfCode._2023.Day3;

namespace AdventOfCode._2023;

using AdventOfCode._2023.Day4;
using AdventOfCode._2023.Day5;
using AdventOfCode._2023.Day6;

public class QuizRunner2023 : IQuizRunner
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
            case 3:
                Day3();
                break;
            case 4:
                Day4();
                break;
            case 5:
                Day5();
                break;
            case 6:
                Day6();
                break;
        }

        Console.ReadLine();
    }

    private static void Day6()
    {
        var puzzle = new BoatRacePuzzle();
        var result = puzzle.CalculateAnswers();

        Console.WriteLine($"Q1: {result.Answer1}");
        Console.WriteLine($"Q2: {result.Answer2}");
    }

    private static void Day5()
    {
        var puzzle = new SeedsPuzzle();
        var result = puzzle.CalculateAnswers("C:\\Development\\Personal\\AdventOfCode\\AdventOfCode\\2023\\Day5\\input.txt");

        Console.WriteLine($"Q1: {result.Answer1}");
        Console.WriteLine($"Q2: {result.Answer2}");
    }

    private static void Day4()
    {
        var puzzle = new CardPuzzle();
        var result = puzzle.CalculateAnswers("C:\\Development\\Personal\\AdventOfCode\\AdventOfCode\\2023\\Day4\\input.txt");

        Console.WriteLine($"Q1: {result.Answer1}");
        Console.WriteLine($"Q2: {result.Answer2}");
    }

    private static void Day3()
    {
        var puzzle = new SchematicPuzzle();
        var result = puzzle.CalculateAnswers("C:\\Development\\Personal\\AdventOfCode\\AdventOfCode\\2023\\Day3\\input.txt");
        //var result = puzzle.CalculateAnswers("C:\\Development\\Personal\\AdventOfCode\\AdventOfCode\\2023\\Day3\\test.txt");

        Console.WriteLine($"Q1: {result.Answer1}");
        Console.WriteLine($"Q2: {result.Answer2}");
    }

    private static void Day2()
    {
        var idCalculator = new Day2.GamesIdCalculator();
        var result =
            idCalculator.RetrieveAnswers("C:\\Development\\Personal\\AdventOfCode\\AdventOfCode\\2023\\Day2\\CubeGame.txt");

        Console.WriteLine($"Q1: {result.Answer1}");
        Console.WriteLine($"Q2: {result.Answer2}");
    }

    private static void Day1()
    {
        var calibrationValueCalculator = new Day1.CalibrationValueCalculator();
        var result =
            calibrationValueCalculator.Calculate("C:\\Development\\Personal\\AdventOfCode\\AdventOfCode\\2023\\Day1\\input.txt");

        Console.WriteLine($"Q1: {result.answer1}");
        Console.WriteLine($"Q2: {result.answer2}");
    }
}