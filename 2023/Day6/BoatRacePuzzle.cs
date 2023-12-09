namespace AdventOfCode._2023.Day6;

public class BoatRacePuzzle
{
    public (long Answer1, long Answer2) CalculateAnswers()
    {
        var races = new List<RaceInfo>
        {
            new (51, 377),
            new (69, 1171),
            new (98, 1224),
            new (78, 1505)
        };

        var testRaces = new List<RaceInfo>
        {
            new (7, 9),
            new (15, 40),
            new (30, 200)
        };


        var answer1 = CalculateProductOfCountOfRecordBreakingRuns(races);
        var answer2 = CalculateRecordBreakingRuns(new RaceInfo(51699878, 377117112241505));

        return (answer1, answer2);
    }

    private int CalculateProductOfCountOfRecordBreakingRuns(List<RaceInfo> races)
    {
        var result = 1;

        foreach (var race in races)
        {
            result *= CalculateRecordBreakingRuns(race);
        }

        return result;
    }

    private int CalculateRecordBreakingRuns(RaceInfo race)
    {
        var count = 0;
        for (var i = 1; i <= race.RaceDuration; i++)
        {
            var distance = (race.RaceDuration - i) * i;
            if (distance > race.RaceDistanceRecord)
            {
                count++;
            }
        }

        return count;
    }
}