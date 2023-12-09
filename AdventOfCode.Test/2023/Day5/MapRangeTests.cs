namespace AdventOfCode.Test._2023.Day5;

using AdventOfCode._2023.Day5;

[TestFixture]
public class MapRangeTests
{

    [Test]
    public void LeftJoin_LeftAndRightRangeMatch_ReturnsRightTarget()
    {
        var left = new MapRange(0L, 10L, 15L);
        var rightRanges = new List<MapRange>
        {
            new MapRange(0L, 10L, 15L)
        };

        var result = left.LeftJoin(rightRanges);

        Assert.That(result.Count, Is.EqualTo(1));
        var firstResult = result[0];
        Assert.That(firstResult.Start, Is.EqualTo(10));
        Assert.That(firstResult.End, Is.EqualTo(24));
        Assert.That(firstResult.Length, Is.EqualTo(15));
        Assert.That(firstResult.Target, Is.Null);
    }

    [Test]
    public void LeftJoin_LeftStartLessThanRightStartAndLeftEndEqualToRightEnd_CreatesNewRanges()
    {
        var left = new MapRange(0L, 15L);
        var rightRanges = new List<MapRange>
        {
            new MapRange(5L, 15L, 10L)
        };

        var result = left.LeftJoin(rightRanges);

        Assert.That(result.Count, Is.EqualTo(2));

        var firstResult = result[0];
        Assert.That(firstResult.Start, Is.EqualTo(0));
        Assert.That(firstResult.End, Is.EqualTo(4));
        Assert.That(firstResult.Length, Is.EqualTo(5));
        Assert.That(firstResult.Target, Is.Null);

        var secondResult = result[1];
        Assert.That(secondResult.Start, Is.EqualTo(15));
        Assert.That(secondResult.End, Is.EqualTo(24));
        Assert.That(secondResult.Length, Is.EqualTo(10));
        Assert.That(secondResult.Target, Is.Null);
    }

    [Test]
    public void LeftJoin_LeftStartLessThanRightStartAndLeftEndGreaterThanRightEnd_CreatesNewRanges()
    {
        var left = new MapRange(0L, 15L);
        var rightRanges = new List<MapRange>
        {
            new MapRange(5L, 15L, 5L)
        };

        var result = left.LeftJoin(rightRanges);

        Assert.That(result.Count, Is.EqualTo(3));

        var firstResult = result[0];
        Assert.That(firstResult.Start, Is.EqualTo(0));
        Assert.That(firstResult.End, Is.EqualTo(4));
        Assert.That(firstResult.Length, Is.EqualTo(5));
        Assert.That(firstResult.Target, Is.Null);

        var secondResult = result[1];
        Assert.That(secondResult.Start, Is.EqualTo(15));
        Assert.That(secondResult.End, Is.EqualTo(19));
        Assert.That(secondResult.Length, Is.EqualTo(5));
        Assert.That(secondResult.Target, Is.Null);

        var thirdResult = result[2];
        Assert.That(thirdResult.Start, Is.EqualTo(10));
        Assert.That(thirdResult.End, Is.EqualTo(14));
        Assert.That(thirdResult.Length, Is.EqualTo(5));
        Assert.That(thirdResult.Target, Is.Null);
    }

    [Test]
    public void LeftJoin_LeftStartGreaterThanRightStartAndLeftEndLessThanRightEnd_CreatesNewRanges()
    {
        var left = new MapRange(5L, 10L);
        var rightRanges = new List<MapRange>
        {
            new MapRange(0L, 10L, 20L)
        };

        var result = left.LeftJoin(rightRanges);

        Assert.That(result.Count, Is.EqualTo(1));

        var firstResult = result[0];
        Assert.That(firstResult.Start, Is.EqualTo(15));
        Assert.That(firstResult.End, Is.EqualTo(24));
        Assert.That(firstResult.Length, Is.EqualTo(10));
        Assert.That(firstResult.Target, Is.Null);
    }

    [Test]
    public void LeftJoin_LeftStartLessThanRightStartAndLeftEndLessThanRightEnd_CreatesNewRanges()
    {
        var left = new MapRange(0L, 10L);
        var rightRanges = new List<MapRange>
        {
            new MapRange(5L, 15L, 10L)
        };

        var result = left.LeftJoin(rightRanges);

        Assert.That(result.Count, Is.EqualTo(2));

        var firstResult = result[0];
        Assert.That(firstResult.Start, Is.EqualTo(0));
        Assert.That(firstResult.End, Is.EqualTo(4));
        Assert.That(firstResult.Length, Is.EqualTo(5));
        Assert.That(firstResult.Target, Is.Null);

        var secondResult = result[1];
        Assert.That(secondResult.Start, Is.EqualTo(15));
        Assert.That(secondResult.End, Is.EqualTo(19));
        Assert.That(secondResult.Length, Is.EqualTo(5));
        Assert.That(secondResult.Target, Is.Null);
    }

    [Test]
    public void LeftJoin_LeftStartGreaterThanRightStartAndLeftEndGreaterThanRightEnd_CreatesNewRanges()
    {
        var left = new MapRange(5L, 15L, 10L);
        var rightRanges = new List<MapRange>
        {
            new MapRange(0L, 10L, 10L)
        };

        var result = left.LeftJoin(rightRanges);

        Assert.That(result.Count, Is.EqualTo(2));

        var firstResult = result[0];
        Assert.That(firstResult.Start, Is.EqualTo(15));
        Assert.That(firstResult.End, Is.EqualTo(19));
        Assert.That(firstResult.Length, Is.EqualTo(5));
        Assert.That(firstResult.Target, Is.Null);

        var secondResult = result[1];
        Assert.That(secondResult.Start, Is.EqualTo(10));
        Assert.That(secondResult.End, Is.EqualTo(14));
        Assert.That(secondResult.Length, Is.EqualTo(5));
        Assert.That(secondResult.Target, Is.Null);
    }

    [Test]
    public void LeftJoin_LeftStartGreaterThanRightStartAndLeftEndEqualToRightEnd_CreatesNewRange()
    {
        var left = new MapRange(5L, 15L, 10L);
        var rightRanges = new List<MapRange>
        {
            new MapRange(0L, 10L, 15L)
        };

        var result = left.LeftJoin(rightRanges);

        Assert.That(result.Count, Is.EqualTo(1));

        var firstResult = result[0];
        Assert.That(firstResult.Start, Is.EqualTo(15));
        Assert.That(firstResult.End, Is.EqualTo(24));
        Assert.That(firstResult.Length, Is.EqualTo(10));
        Assert.That(firstResult.Target, Is.Null);
    }

    [Test]
    public void LeftJoin_LeftStartEqualToRightStartAndLeftEndGreaterThanRightEnd_CreatesNewRanges()
    {
        var left = new MapRange(0L, 10L, 15L);
        var rightRanges = new List<MapRange>
        {
            new MapRange(0L, 10L, 10L)
        };

        var result = left.LeftJoin(rightRanges);

        Assert.That(result.Count, Is.EqualTo(2));

        var firstResult = result[0];
        Assert.That(firstResult.Start, Is.EqualTo(10));
        Assert.That(firstResult.End, Is.EqualTo(19));
        Assert.That(firstResult.Length, Is.EqualTo(10));
        Assert.That(firstResult.Target, Is.Null);

        var secondResult = result[1];
        Assert.That(secondResult.Start, Is.EqualTo(10));
        Assert.That(secondResult.End, Is.EqualTo(14));
        Assert.That(secondResult.Length, Is.EqualTo(5));
        Assert.That(secondResult.Target, Is.Null);
    }

    [Test]
    public void LeftJoin_LeftStartEqualToRightStartAndLeftEndLessThanRightEnd_CreatesNewRange()
    {
        var left = new MapRange(0L, 10L, 10L);
        var rightRanges = new List<MapRange>
        {
            new MapRange(0L, 10L, 15L)
        };

        var result = left.LeftJoin(rightRanges);

        Assert.That(result.Count, Is.EqualTo(1));

        var firstResult = result[0];
        Assert.That(firstResult.Start, Is.EqualTo(10));
        Assert.That(firstResult.End, Is.EqualTo(19));
        Assert.That(firstResult.Length, Is.EqualTo(10));
        Assert.That(firstResult.Target, Is.Null);
    }

    [Test]
    public void LeftJoin_MultipleRightWithGaps_CreatesNewRanges()
    {
        var left = new MapRange(0L, 15L);
        var rightRanges = new List<MapRange>
        {
            new MapRange(3L, 23L, 3L),
            new MapRange(8L, 28L, 3L),
        };

        var result = left.LeftJoin(rightRanges);

        Assert.That(result.Count, Is.EqualTo(5));

        var firstResult = result[0];
        Assert.That(firstResult.Start, Is.EqualTo(0));
        Assert.That(firstResult.End, Is.EqualTo(2));
        Assert.That(firstResult.Length, Is.EqualTo(3));
        Assert.That(firstResult.Target, Is.Null);

        var secondResult = result[1];
        Assert.That(secondResult.Start, Is.EqualTo(23));
        Assert.That(secondResult.End, Is.EqualTo(25));
        Assert.That(secondResult.Length, Is.EqualTo(3));
        Assert.That(secondResult.Target, Is.Null);

        var thirdResult = result[2];
        Assert.That(thirdResult.Start, Is.EqualTo(6));
        Assert.That(thirdResult.End, Is.EqualTo(7));
        Assert.That(thirdResult.Length, Is.EqualTo(2));
        Assert.That(thirdResult.Target, Is.Null);

        var fourthResult = result[3];
        Assert.That(fourthResult.Start, Is.EqualTo(28));
        Assert.That(fourthResult.End, Is.EqualTo(30));
        Assert.That(fourthResult.Length, Is.EqualTo(3));
        Assert.That(fourthResult.Target, Is.Null);

        var fifthResult = result[4];
        Assert.That(fifthResult.Start, Is.EqualTo(11));
        Assert.That(fifthResult.End, Is.EqualTo(14));
        Assert.That(fifthResult.Length, Is.EqualTo(4));
        Assert.That(fifthResult.Target, Is.Null);
    }
}
