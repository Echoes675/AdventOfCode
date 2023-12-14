using AdventOfCode._2023.Day3;

namespace AdventOfCode._2023;

using AdventOfCode._2023.Day10;
using AdventOfCode._2023.Day11;
using AdventOfCode._2023.Day4;
using AdventOfCode._2023.Day5;
using AdventOfCode._2023.Day6;
using AdventOfCode._2023.Day7;
using AdventOfCode._2023.Day8;
using AdventOfCode._2023.Day9;

public class QuizRunner2023 : IQuizRunner
{
    public void Run(int day)
    {
        (long Answer1, long Answer2) result = (0,0);
        switch (day)
        {
            case 1:
                result = Day1();
                break;
            case 2:
                result = Day2();
                break;
            case 3:
                result = Day3();
                break;
            case 4:
                result = Day4();
                break;
            case 5:
                result = Day5();
                break;
            case 6:
                result = Day6();
                break;
            case 7:
                result = Day7();
                break;
            case 8:
                result = Day8();
                break;
            case 9:
                result = Day9();
                break;
            case 10:
                result = Day10();
                break;
            case 11:
                result = Day11();
                break;
        }
        Console.WriteLine($"Q1: {result.Answer1}");
        Console.WriteLine($"Q2: {result.Answer2}");
        Console.ReadLine();
    }

    private static (long Answer1, long Answer2) Day11()
    {
        var puzzle = new CosmicExpansionPuzzle();
        var result = puzzle.CalculateAnswers("C:\\Development\\Personal\\AdventOfCode\\2023\\Day11\\input.txt");

        return result;
    }

    private static (long Answer1, long Answer2) Day10()
    {
        var puzzle = new PipeMazePuzzle();
        var result = puzzle.CalculateAnswers("C:\\Development\\Personal\\AdventOfCode\\2023\\Day10\\input.txt");

        return result;
    }

    private static (long Answer1, long Answer2) Day9()
    {
        var puzzle = new MirageMaintenancePuzzle();
        var result = puzzle.CalculateAnswers("C:\\Development\\Personal\\AdventOfCode\\2023\\Day9\\input.txt");

        return result;
    }

    private static (long Answer1, long Answer2) Day8()
    {
        var puzzle = new MapPuzzle();
        var result = puzzle.CalculateAnswers("C:\\Development\\Personal\\AdventOfCode\\2023\\Day8\\input.txt");

        return result;
    }

    private static (long Answer1, long Answer2) Day7()
    {
        var puzzle = new CamelCardsPuzzle();
        var result = puzzle.CalculateAnswers("C:\\Development\\Personal\\AdventOfCode\\2023\\Day7\\input.txt");

        return result;
    }

    private static (long Answer1, long Answer2) Day6()
    {
        var puzzle = new BoatRacePuzzle();
        var result = puzzle.CalculateAnswers();

        return result;
    }

    private static (long Answer1, long Answer2) Day5()
    {
        var puzzle = new SeedsPuzzle();
        var result = puzzle.CalculateAnswers("C:\\Development\\Personal\\AdventOfCode\\AdventOfCode\\2023\\Day5\\input.txt");

        return result;
    }

    private static (long Answer1, long Answer2) Day4()
    {
        var puzzle = new CardPuzzle();
        var result = puzzle.CalculateAnswers("C:\\Development\\Personal\\AdventOfCode\\AdventOfCode\\2023\\Day4\\input.txt");

        return result;
    }

    private static (long Answer1, long Answer2) Day3()
    {
        var puzzle = new SchematicPuzzle();
        var result = puzzle.CalculateAnswers("C:\\Development\\Personal\\AdventOfCode\\AdventOfCode\\2023\\Day3\\input.txt");
        //var result = puzzle.CalculateAnswers("C:\\Development\\Personal\\AdventOfCode\\AdventOfCode\\2023\\Day3\\test.txt");

        return result;
    }

    private static (long Answer1, long Answer2) Day2()
    {
        var idCalculator = new Day2.GamesIdCalculator();
        var result =
            idCalculator.RetrieveAnswers("C:\\Development\\Personal\\AdventOfCode\\AdventOfCode\\2023\\Day2\\CubeGame.txt");

        return result;
    }

    private static (long Answer1, long Answer2) Day1()
    {
        var calibrationValueCalculator = new Day1.CalibrationValueCalculator();
        var result =
            calibrationValueCalculator.Calculate("C:\\Development\\Personal\\AdventOfCode\\AdventOfCode\\2023\\Day1\\input.txt");

        return result;
    }
}