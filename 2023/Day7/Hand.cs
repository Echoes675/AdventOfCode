using AdventOfCode._2023.Day4;
using System.Text.RegularExpressions;

namespace AdventOfCode._2023.Day7;

public class Hand : IComparable<Hand>
{

    private static Regex _validCard = new Regex(@"([2-9TJQKA])\1+");
    private static Regex _invalidCard = new Regex(@"[^2-9TJQKA\s]+");
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
            ? cards
            : throw new ArgumentException($"Cards contain invalid characters. Cards={cards}");

    }

    public string Cards { get; }

    public int CompareTo(Hand? other)
    {
        if (other == null)
        {
            throw new ArgumentNullException(nameof(other));
        }

        var firstCardLeft = Cards.First();
        var firstCardRight = other.Cards.First();

        var sortedCardsLeft = new string(Cards.OrderBy(x => x).ToArray());
        var sortedCardsRight = new string(other.Cards.OrderBy(x => x).ToArray());

        var leftMatches = _validCard.Matches(sortedCardsLeft);
        var rightMatches = _validCard.Matches(sortedCardsRight);

       

        //var isNumber = int.TryParse(Id.ToString(), out var value);

        if (ReferenceEquals(this, other))
            return 0;
        if (ReferenceEquals(null, other))
            return 1;
        return string.Compare(Cards, other.Cards, StringComparison.Ordinal);
    }

    private int GetHandValue(MatchCollection matches)
    {
        if (matches.First().Value.Length == 5)
        {
            // Five of a kind
            return 6;
        }

        switch (matches.Count)
        {
            case 1 when matches.First().Value.Length == 4:
                // Four of a kind
                return 5;
            case 2 when matches.Any(m => m.Value.Length == 3):
                // Full House
                return 4;
            case 1 when matches.First().Length == 3:
                // Three of a kind
                return 3;
        }

    }
}
