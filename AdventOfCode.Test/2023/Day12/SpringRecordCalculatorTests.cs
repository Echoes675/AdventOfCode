namespace AdventOfCode.Test._2023.Day12;

using AdventOfCode._2023.Day12;

public class SpringRecordCalculatorTests
{
    [TestCase("???.### 1,1,3", 1)]
    [TestCase(".??..??...?##. 1,1,3", 4)]
    [TestCase("?#?#?#?#?#?#?#? 1,3,1,6", 1)]
    [TestCase("????.#...#... 4,1,1", 1)]
    [TestCase("????.######..#####. 1,6,5", 4)]
    [TestCase("?###???????? 3,2,1", 10)]
    [TestCase("#.#? 4", 0)]
    [TestCase("#.#?## 1,4", 1)]
    public void CalculateNumberOfPossibleValidArrangements_InputSupplied_ReturnsNumberOfPossibleValidArrangements(string input, int numberOfValidArrangements)
    {
        var calculator = new SpringRecordCalculator();

        var inputList = new List<string>
        {
            input
        };

        var result = calculator.CalculateNumberOfPossibleValidArrangements(inputList);

        Assert.That(result, Is.EqualTo(numberOfValidArrangements));
    }
}
