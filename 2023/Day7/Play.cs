namespace AdventOfCode._2023.Day7;

public class Play : IComparable<Play>
{
    public Play(Hand hand, int bid)
    {
        Hand = hand;
        Bid = bid;
    }

    public Hand Hand { get; }
    public int Bid { get; }

    public int CompareTo(Play? other)
    {
        if (other == null)
        {
            throw new ArgumentNullException(nameof(other));
        }

        return Hand.CompareTo(other.Hand);
    }

    // Define the is greater than operator.
    public static bool operator >(Play operand1, Play operand2)
    {
        return operand1.CompareTo(operand2) > 0;
    }

    // Define the is less than operator.
    public static bool operator <(Play operand1, Play operand2)
    {
        return operand1.CompareTo(operand2) < 0;
    }

    // Define the is greater than or equal to operator.
    public static bool operator >=(Play operand1, Play operand2)
    {
        return operand1.CompareTo(operand2) >= 0;
    }

    // Define the is less than or equal to operator.
    public static bool operator <=(Play operand1, Play operand2)
    {
        return operand1.CompareTo(operand2) <= 0;
    }
}