using System.Text.RegularExpressions;

namespace AdventOfCode._2023.Day7;

public interface IHand
{

    string Cards { get; }

    int Value { get; }

    int CompareTo<T>(T? other) where T : IHand;

}

public class JokerHand : IHand, IComparable<JokerHand>
{
    private static Dictionary<char, int> _cardStrength = new()
    {
        {'T', 10},
        {'2', 2},
        {'3', 3},
        {'4', 4},
        {'5', 5},
        {'6', 6},
        {'7', 7},
        {'8', 8},
        {'9', 9},
        {'J', 1},
        {'Q', 12},
        {'K', 13},
        {'A', 14}
    };

    private static Regex _jokerCard = new Regex(@"(J)");
    private static Regex _validCard = new Regex(@"([2-9TJQKA])\1+");
    private static Regex _invalidCard = new Regex(@"[^2-9TJQKA\s]+");
    private int _value = -1;
    private int _value1;

    public JokerHand(string cards)
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

        Init();
    }

    public string Cards { get; }

    public int Value
    {
        get => _value;
        set => _value = value;
    }

    public int CompareTo<T>(T? other) where T : IHand
    {
        if (other is not JokerHand otherJokerHand)
        {
            throw new ArgumentException($"Parameter must be type of {typeof(JokerHand)}. Type=\"{typeof(T)}\"");
        }

        return CompareTo(otherJokerHand);
    }

    public int CompareTo(JokerHand? other)
    {
        if (other == null)
        {
            throw new ArgumentNullException(nameof(other));
        }

        var otherValue = other.Value;

        if (otherValue < 0)
        {
            var sortedCardsRight = new string(other.Cards.OrderBy(x => x).ToArray());

            if (other.Cards.Contains('J', StringComparison.InvariantCultureIgnoreCase))
            {
                sortedCardsRight = TransformJoker(sortedCardsRight);
            }

            var rightMatches = _validCard.Matches(sortedCardsRight);

            otherValue = GetHandValue(rightMatches);
            other.Value = otherValue;
        }

        // Winning hand
        if (_value != other.Value)
        {
            return _value > other.Value ? 1 : -1;
        }

        // It's a draw - who won
        return CalculateDraw(Cards, other.Cards);
    }

    private void Init()
    {
        var sortedCardsLeft = new string(Cards.OrderBy(x => x).ToArray());

        if (Cards.Contains('J', StringComparison.InvariantCultureIgnoreCase))
        {
            sortedCardsLeft = TransformJoker(sortedCardsLeft);
        }

        var leftMatches = _validCard.Matches(sortedCardsLeft);

        _value = GetHandValue(leftMatches);
    }

    private string TransformJoker(string cards)
    {
        var jokerCount = _jokerCard.Count(cards);
        var jokerRemovedCards = cards.Replace("J", string.Empty);
        var matches = _validCard.Matches(jokerRemovedCards);
        string newCards;
        if (!matches.Any())
        {
            if (jokerCount == 5)
            {
                newCards = new string('A', 5);
            }
            else
            {
                var highCardValue = 0;
                var highCard = 'J';
                foreach (var character in jokerRemovedCards)
                {
                    _cardStrength.TryGetValue(character, out var cardValue);
                    if (cardValue > highCardValue)
                    {
                        highCardValue = cardValue;
                        highCard = character;
                    }
                }

                newCards = jokerRemovedCards + new string(highCard, jokerCount);
            }

            return new string(newCards.OrderBy(x => x).ToArray());
        }

        char card;
        switch (matches.Count)
        {
            case 1 when matches.First().Value.Length == 4: // Four of a kind
            case 1 when matches.First().Value.Length == 3: // Three of a kind
            case 1 when matches.First().Value.Length == 2: // Two Pair
                card = matches.First().Value[0];
                newCards = jokerRemovedCards + new string(card, jokerCount);
                return new string(newCards.OrderBy(x => x).ToArray());

            case 2 when matches.All(m => m.Value.Length == 2):
                // Two pair
                _cardStrength.TryGetValue(matches[0].Value[0], out var firstPairValue);
                _cardStrength.TryGetValue(matches[1].Value[0], out var secondPairValue);

                card = firstPairValue > secondPairValue ? matches[0].Value[0] : matches[1].Value[1];
                newCards = jokerRemovedCards + new string(card, jokerCount);
                return new string(newCards.OrderBy(x => x).ToArray());

            default:
                return cards;
        }
    }

    // Define the is greater than operator.
    public static bool operator >(JokerHand operand1, JokerHand operand2)
    {
        return operand1.CompareTo(operand2) > 0;
    }

    // Define the is less than operator.
    public static bool operator <(JokerHand operand1, JokerHand operand2)
    {
        return operand1.CompareTo(operand2) < 0;
    }

    // Define the is greater than or equal to operator.
    public static bool operator >=(JokerHand operand1, JokerHand operand2)
    {
        return operand1.CompareTo(operand2) >= 0;
    }

    // Define the is less than or equal to operator.
    public static bool operator <=(JokerHand operand1, JokerHand operand2)
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
                // One pair
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