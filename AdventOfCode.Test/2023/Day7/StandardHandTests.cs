namespace AdventOfCode.Test._2023.Day7;

using AdventOfCode._2023.Day7;

[TestFixture]
public class StandardHandTests
{
    [Test]
    public void CompareTo_LeftStrongerFiveOfAKindThanRight_Returns1()
    {
        var left = new StandardHand("AAAAA");
        var right = new StandardHand("KKKKK");

        var result = left.CompareTo(right);

        Assert.That(result, Is.EqualTo(1));
    }

    [Test]
    public void CompareTo_LeftWeakerFiveOfAKindThanRight_Returns1()
    {
        var left = new StandardHand("KKKKK");
        var right = new StandardHand("AAAAA");

        var result = left.CompareTo(right);

        Assert.That(result, Is.EqualTo(-1));
    }

    [Test]
    public void CompareTo_LeftStrongerThreeOfAKindThanRight_Returns1()
    {
        var left = new StandardHand("KKKKA");
        var right = new StandardHand("QQQQA");

        var result = left.CompareTo(right);

        Assert.That(result, Is.EqualTo(1));
    }

    [Test]
    public void CompareTo_RightStronger_ReturnsNeg1()
    {
        var left = new StandardHand("32T3K");
        var right = new StandardHand("QQQJA");

        var result = left.CompareTo(right);

        Assert.That(result, Is.EqualTo(-1));
    }

    [Test]
    public void Sort_UnorderedList_ReturnsOrderedList()
    {
        var hands = new List<StandardHand>
        {
             new StandardHand("32T3K"),
             new StandardHand("QQQJA"),
             new StandardHand("T55J5"),
             new StandardHand("KTJJT"),
             new StandardHand("KK677"),
        };

        hands.Sort();

        Assert.That(hands[0].Cards, Is.EqualTo("32T3K"));
        Assert.That(hands[1].Cards, Is.EqualTo("KTJJT"));
        Assert.That(hands[2].Cards, Is.EqualTo("KK677"));
        Assert.That(hands[3].Cards, Is.EqualTo("T55J5"));
        Assert.That(hands[4].Cards, Is.EqualTo("QQQJA"));
    }
}
