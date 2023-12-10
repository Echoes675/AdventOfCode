using AdventOfCode._2023.Day7;

namespace AdventOfCode.Test._2023.Day7;

[TestFixture]
public class JokerHandTests
{
    [TestCase("T55J5")]
    [TestCase("KTJJT")]
    [TestCase("QQQJA")]
    public void CompareTo_LeftLessThanRight_ReturnsNeg1(string rightCards)
    {
        var left = new JokerHand("AAAKK");
        var right = new JokerHand(rightCards);

        var result = left.CompareTo(right);

        Assert.That(result, Is.EqualTo(-1));
    }

    [TestCase("AATTJ", "TQQAA")]
    [TestCase("5J2JA", "TQQAA")]
    [TestCase("2345J", "J345A")]
    public void CompareTo_LeftGreaterThanRight_Returns1(string leftCards, string rightCards)
    {
        var left = new JokerHand(leftCards);
        var right = new JokerHand(rightCards);

        var result = left.CompareTo(right);

        Assert.That(result, Is.EqualTo(1));
    }

    [Test]
    public void Sort_UnorderedList_ReturnsOrderedList()
    {
        var hands = new List<JokerHand>
        {
            new JokerHand("32T3K"),
            new JokerHand("QQQJA"),
            new JokerHand("T55J5"),
            new JokerHand("KTJJT"),
            new JokerHand("KK677"),
        };

        hands.Sort();

        Assert.That(hands[0].Cards, Is.EqualTo("32T3K"));
        Assert.That(hands[1].Cards, Is.EqualTo("KK677"));
        Assert.That(hands[2].Cards, Is.EqualTo("T55J5"));
        Assert.That(hands[3].Cards, Is.EqualTo("QQQJA"));
        Assert.That(hands[4].Cards, Is.EqualTo("KTJJT"));
    }
}
