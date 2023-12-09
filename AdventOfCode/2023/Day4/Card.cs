using System.Reflection.Metadata.Ecma335;

namespace AdventOfCode._2023.Day4;

public class Card
{
    private readonly List<int> _winningNumbers;
    private readonly List<int> _gameNumbers;
    private List<int>? _matchedWinningNumbers;
    private int? _matchedWinningNumbersCount;

    public Card(int cardNumber, List<int> winningNumbers, List<int> gameNumbers)
    {
        CardNumber = cardNumber;
        _winningNumbers = winningNumbers;
        _gameNumbers = gameNumbers;
    }

    public int CardNumber { get; }

    public bool IsWinner => MatchedWinningNumbers.Count > 0;
    public List<int> MatchedWinningNumbers => _matchedWinningNumbers ??= _winningNumbers.Intersect(_gameNumbers).ToList();
    public int MatchedWinningNumbersCount => _matchedWinningNumbersCount ??= MatchedWinningNumbers.Count;

    public Lazy<int> Value => new (() =>
    {
        var intersectedLists = MatchedWinningNumbers;
        var noOfMatches = intersectedLists.Count;
        var total = GetValue(noOfMatches, 1);
        return total;
    });

    private int GetValue(int count, int total)
    {
        if (count is 0 or 1)
        {
            return count == 1 ? total : count;
        }

        return GetValue(--count, total * 2);
    }
}