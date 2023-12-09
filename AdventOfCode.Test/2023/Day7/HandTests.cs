namespace AdventOfCode.Test._2023.Day7;

using AdventOfCode._2023.Day7;

[TestFixture]
public class HandTests
{
    [Test]
    public void CompareTo_LeftStrongerFiveOfAKindThanRight_Returns1()
    {
        var left = new Hand("AAAAA");
        var right = new Hand("KKKKK");

        var result = left.CompareTo(right);

        Assert.That(result, Is.EqualTo(1));
    }

    [Test]
    public void CompareTo_LeftWeakerFiveOfAKindThanRight_Returns1()
    {
        var left = new Hand("KKKKK");
        var right = new Hand("AAAAA");

        var result = left.CompareTo(right);

        Assert.That(result, Is.EqualTo(-1));
    }

    [Test]
    public void CompareTo_LeftStrongerThreeOfAKindThanRight_Returns1()
    {
        var left = new Hand("KKKKA");
        var right = new Hand("QQQQA");

        var result = left.CompareTo(right);

        Assert.That(result, Is.EqualTo(1));
    }

    [Test]
    public void CompareTo_RightStronger_ReturnsNeg1()
    {
        var left = new Hand("32T3K");
        var right = new Hand("QQQJA");

        var result = left.CompareTo(right);

        Assert.That(result, Is.EqualTo(-1));
    }

    [Test]
    public void Sort_UnorderedList_ReturnsOrderedList()
    {
        var hands = new List<Hand>
        {
             new Hand("32T3K"),
             new Hand("QQQJA"),
             new Hand("T55J5"),
             new Hand("KTJJT"),
             new Hand("KK677"),
        };

        hands.Sort();

        Assert.That(hands[0].Cards, Is.EqualTo("32T3K"));
        Assert.That(hands[1].Cards, Is.EqualTo("KTJJT"));
        Assert.That(hands[2].Cards, Is.EqualTo("KK677"));
        Assert.That(hands[3].Cards, Is.EqualTo("T55J5"));
        Assert.That(hands[4].Cards, Is.EqualTo("QQQJA"));
    }
}
