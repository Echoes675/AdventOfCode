namespace AdventOfCode._2023.Day4;

using System.Text.RegularExpressions;

public class CardFactory
{
    private static Regex _cardRegex = new Regex(@"Card\s*(\d+):\s{1,2}((\d+)\s{1,2})*\|\s{1,2}((\d+)\s{0,2})*");

    public List<Card> CreateCards(List<string> input)
    {
        return input.Where(l => !string.IsNullOrEmpty(l))
            .Select(
                l =>
                {
                    var cardMatches = _cardRegex.Matches(l);
                    var cardNumber = int.Parse(cardMatches.Single().Groups[1].Value);
                    var winningNumbers = cardMatches.Single().Groups[3].Captures.Select(n => int.Parse(n.Value)).ToList();
                    var gameNumbers = cardMatches.Single().Groups[5].Captures.Select(n => int.Parse(n.Value)).ToList();

                    return new Card(cardNumber, winningNumbers, gameNumbers);
                }).ToList();
    }
}
