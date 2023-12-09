namespace AdventOfCode._2022.Day1;

public class ElfCalorieCalculator
{
    public List<ElfCalorie> CalculateElfCalories(string filePath)
    {
        if (string.IsNullOrEmpty(filePath))
        {
            throw new ArgumentException("Value cannot be null or empty.", nameof(filePath));
        }

        var result = new List<ElfCalorie>();

        if (!File.Exists(filePath))
        {
            throw new InvalidOperationException($"Input file does not exist. File=\"{filePath}\"");
        }

        var file = File.ReadAllLines(filePath).ToList();

        if (file.Any())
        {
            result = CalculateElfCalories(file);
        }

        return result;
    }

    private List<ElfCalorie> CalculateElfCalories(List<string> file)
    {
        var result = new List<ElfCalorie>();
        var elfcount = 1;
        var total = 0;

        foreach (var item in file)
        {
            if (!string.IsNullOrEmpty(item))
            {
                total += int.Parse(item);
            }
            else
            {
                result.Add(
                    new ElfCalorie
                    {
                        ElfNumber = elfcount++,
                        Calories = total
                    });

                total = 0;
            }
        }

        return result;
    }
}