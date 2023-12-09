namespace AdventOfCode._2022.Day1;

public class ElfCaloriePuzzle
{
    private readonly ElfCalorieCalculator _elfCalorieCalculator;

    public ElfCaloriePuzzle()
     : this(new ElfCalorieCalculator())
    {
        
    }

    public ElfCaloriePuzzle(ElfCalorieCalculator elfCalorieCalculator)
    {
        _elfCalorieCalculator = elfCalorieCalculator;

    }

    public (int Answer1, int Answer2) CalculateAnswers(string filePath)
    {
        var elfCalories = _elfCalorieCalculator.CalculateElfCalories(filePath).OrderByDescending(x => x.Calories).ToList();
        var answer1 = elfCalories.Max(x => x.Calories);
        var answer2 = elfCalories.Take(3).Sum(x => x.Calories);

        return (answer1, answer2);
    }

}