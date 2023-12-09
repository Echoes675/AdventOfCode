using System.Text.RegularExpressions;

namespace AdventOfCode._2023.Day7;

public class Hand : IComparable<Hand>
{
    private static Regex _validCard = new Regex(@"([2-9TJQKA])\1+");
    private static Regex _invalidCard = new Regex(@"[^2-9TJQKA\s]+");
    private static Dictionary<char, int> _cardStrength = new ()
    {
        {'2', 2},
        {'3', 3},
        {'4', 4},
        {'5', 5},
        {'6', 6},
        {'7', 7},
        {'8', 8},
        {'9', 9},
        {'T', 10},
        {'J', 11},
        {'Q', 12},
        {'K', 13},
        {'A', 14}
    };

    public Hand(string cards)
    {
        if (string.IsNullOrEmpty(cards))
        {
            throw new ArgumentNullException("Value cannot be null or empty.", nameof(cards));
        }

        if (cards.Length != 5)
        {
            throw new ArgumentException("Value cannot be less than or greater than 5 characters in length.", nameof(cards));
        }

        Cards = !_invalidCard.Matches(cards).Any()
            ? cards.ToUpper()
            : throw new ArgumentException($"Cards contain invalid characters. Cards={cards}");

    }

    public string Cards { get; }

    public int CompareTo(Hand? other)
    {
        if (other == null)
        {
            throw new ArgumentNullException(nameof(other));
        }

        var sortedCardsLeft = new string(Cards.OrderBy(x => x).ToArray());
        var sortedCardsRight = new string(other.Cards.OrderBy(x => x).ToArray());

        var leftMatches = _validCard.Matches(sortedCardsLeft);
        var rightMatches = _validCard.Matches(sortedCardsRight);

        if (leftMatches.Any() || rightMatches.Any())
        {
            var leftValue = GetHandValue(leftMatches);
            var rightValue = GetHandValue(rightMatches);

            // Winning hand
            if (leftValue != rightValue)
            {
                return leftValue > rightValue ? 1 : -1;
            } 
        }

        // It's a draw - who won
        return CalculateDraw(Cards, other.Cards);
    }

    // Define the is greater than operator.
    public static bool operator >(Hand operand1, Hand operand2)
    {
        return operand1.CompareTo(operand2) > 0;
    }

    // Define the is less than operator.
    public static bool operator <(Hand operand1, Hand operand2)
    {
        return operand1.CompareTo(operand2) < 0;
    }

    // Define the is greater than or equal to operator.
    public static bool operator >=(Hand operand1, Hand operand2)
    {
        return operand1.CompareTo(operand2) >= 0;
    }

    // Define the is less than or equal to operator.
    public static bool operator <=(Hand operand1, Hand operand2)
    {
        return operand1.CompareTo(operand2) <= 0;
    }

    private int GetHandValue(MatchCollection? matches)
    {
        if (matches == null || !matches.Any())
        {
            return 0;
        }

        switch (matches.Count)
        {
            case 1 when matches.First().Value.Length == 5:
                // Five of a kind
                return 6;
            case 1 when matches.First().Value.Length == 4:
                // Four of a kind
                return 5;
            case 2 when matches.Any(m => m.Value.Length == 3):
                // Full House
                return 4;
            case 1 when matches.First().Value.Length == 3:
                // Three of a kind
                return 3;
            case 2 when matches.All(m => m.Value.Length == 2):
                // Two pair
                return 2;
            case 1 when matches.First().Value.Length == 2:
                // Two pair
                return 1;
            default:
                return 0;
        }
    }

    private int CalculateDraw(string left, string right)
    {
        for (var i = 0; i < left.Length; i++)
        {
            if (left[i] == right[i])
            {
                continue;

            }
            _cardStrength.TryGetValue(left[i], out var leftValue);
            _cardStrength.TryGetValue(right[i], out var rightValue);
            return leftValue > rightValue ? 1 : -1;
        }

        return 0;
    }
}
