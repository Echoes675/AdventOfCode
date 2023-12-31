﻿namespace AdventOfCode._2023.Day7;

public class CamelCardsPuzzle : PuzzleBase
{
    public (long Answer1, long Answer2) CalculateAnswers(string filePath)
    {
        var file = GetFileLines(filePath);

        var plays = file.Select(
            x =>
            {
                var values = x.Split(" ");
                var bid = int.Parse(values[1]);
                return new Play(new StandardHand(values[0]), bid);
            }).ToList();

        var answer1 = CalculateAnswer(plays);

        var jokerPlays = file.Select(
            x =>
            {
                var values = x.Split(" ");
                var bid = int.Parse(values[1]);
                return new Play(new JokerHand(values[0]), bid);
            }).ToList();
        var answer2 = CalculateAnswer(jokerPlays);

        return (answer1, answer2);
    }

    private int CalculateAnswer(List<Play> plays)
    {
        var total = 0;
        var rank = 1;
        plays.Sort();
        var hands = plays.Select(p => p.Hand).ToList();
        foreach (var play in plays)
        {
            total += play.Bid * rank;
            rank++;
        }

        return total;
    }

}