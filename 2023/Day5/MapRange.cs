namespace AdventOfCode._2023.Day5;

public class MapRange
{
    private MapRange()
    {
    }

    public MapRange(long start, long rangeLength)
    {
        Start = start;
        Length = rangeLength;
        End = start + rangeLength - 1;
    }

    public MapRange(long start, long targetStart, long rangeLength)
    {
        Start = start;
        Length = rangeLength;
        End = start + rangeLength - 1;
        var sourceEnd = targetStart + rangeLength - 1;

        Target = new MapRange
        {
            Start = targetStart,
            End = sourceEnd,
            Length = rangeLength
        };
    }

    public long Start { get; set; }

    public long End { get; set; }

    public long Length { get; set; }

    public MapRange Target { get; init; }

    public bool IsNumberInRange(long number)
    {
        return number >= Start && number <= End;
    }

    public bool TryGetTargetNumber(long number, out long targetNumber)
    {
        if (number >= Start && number <= End)
        {
            var difference = Target.Start - Start;
            targetNumber = number + difference;
            return true;
        }

        throw new InvalidOperationException($"Number not in range. Number=\"{number}\";Start=\"{Start}\";End=\"{End}\";");
    }

    public List<MapRange> LeftJoin(List<MapRange> rightRanges)
    {
        rightRanges = rightRanges.OrderBy(x => x.Start).ToList();

        var result = new List<MapRange>();
        var overallIndex = 0L;

        foreach (var right in rightRanges)
        {
            if (Start == right.Start && End == right.End)
            {
                result.Add(right.Target);
                return result;
            }

            var leftIndex = 0L;
            var rangeLength = 0L;
            var difference = 0L;

            if (Start < right.Start)
            {
                difference = right.Start - Start - overallIndex;
                rangeLength = difference;
                var start = overallIndex + Start;
                result.Add(new MapRange(start, rangeLength));

                leftIndex += rangeLength;
            }

            if (Start < right.Start && End >= right.End)
            {
                rangeLength = right.Length;
                result.Add(new MapRange(right.Target.Start, rangeLength));

                leftIndex += rangeLength;
            }
            else if (Start < right.Start && right.Start < End && End < right.End)
            {
                difference = right.End - End;
                rangeLength = right.Length - difference;
                result.Add(new MapRange(right.Target.Start, rangeLength));

                leftIndex += rangeLength;
            }
            else if (Start > right.Start && right.End > Start && right.End <= End)
            {
                difference = Start - right.Start;
                rangeLength = right.Length - difference;
                var start = right.Target.Start + difference;
                result.Add(new MapRange(start, rangeLength));

                leftIndex += rangeLength;
            }
            else if (Start > right.Start && End < right.End)
            {
                var startDiff = Start - right.Start;
                difference = right.End - End + startDiff;
                rangeLength = right.Length - difference;
                var start = right.Target.Start + startDiff;
                result.Add(new MapRange(start, rangeLength));

                leftIndex += rangeLength;
            }
            else if (Start == right.Start)
            {
                if (End > right.End)
                {
                    rangeLength = right.Length;
                    result.Add(new MapRange(right.Target.Start, rangeLength));
                    leftIndex += rangeLength;
                }

                if (End < right.End)
                {
                    difference = right.End - End;
                    rangeLength = right.Length - difference;
                    result.Add(new MapRange(right.Target.Start, rangeLength));
                    leftIndex += rangeLength;
                }
            }

            overallIndex += leftIndex;
        }

        if (overallIndex < Length)
        {
            var difference = Length - overallIndex;
            var start = overallIndex + Start;
            result.Add(new MapRange(start, difference));
        }

        return result;
    }

    public bool OverlappingRanges(MapRange right)
    {
        return Start == right.Start && End == right.End
               || Start > right.Start && End < right.End
               || Start < right.Start && End >= right.End
               || Start < right.Start && right.Start < End && End < right.End
               || Start > right.Start && right.End > Start && right.End <= End
               || Start == right.Start && End > right.End
               || Start == right.Start && End < right.End
               || Start > right.Start && End < right.End;
    }
}
