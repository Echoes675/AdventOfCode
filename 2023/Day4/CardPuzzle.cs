using AdventOfCode._2023.Day3;
using System.Collections.Generic;
using System;

namespace AdventOfCode._2023.Day4;

public class CardPuzzle : PuzzleBase
{

    private readonly CardFactory _cardFactory;

    public CardPuzzle()
        : this(new CardFactory())
    {

    }
    public CardPuzzle(CardFactory cardFactory)
    {
        _cardFactory = cardFactory;

    }

    public (int Answer1, int Answer2) CalculateAnswers(string filePath)
    {
        var file = GetFileLines(filePath);
        var cards = _cardFactory.CreateCards(file);

        var answer1 = cards.Sum(c => c.Value.Value);
        var winningCards = cards.Where(c => c.IsWinner).ToDictionary(c => c.CardNumber, c => c.MatchedWinningNumbers.Count);

        var answer2 = PlayCards(cards);

        return (answer1, answer2);
    }

    private int PlayCards(List<Card> allCards)
    {
        var winningCardDictionary = allCards.Where(c => c.IsWinner)
            .ToDictionary(c => c.CardNumber, c => c.MatchedWinningNumbersCount);

        return allCards.Count 
               + winningCardDictionary
                   .Select(kvp => kvp.Key)
                   .Sum(cardNumber => PlayCards(winningCardDictionary, cardNumber));
    }

    private int PlayCards(Dictionary<int, int> winningCards, int cardNumber)
    {
        winningCards.TryGetValue(cardNumber, out var winningCardNumberCount);
        var count = winningCardNumberCount;

        for (var i = cardNumber + 1; i <= cardNumber + winningCardNumberCount; i++)
        {
            count += PlayCards(winningCards, i);
        }

        return count;
    }

    // First (non-working?) slow attempt
    private List<Card> PlayCards(List<Card> allCards, IEnumerable<Card> cards, int depth = 0)
    {
        var winningCards = cards.Where(c => c.IsWinner).ToList();
        if (winningCards.Count == 0)
        {
            Console.WriteLine(new string('-', 15)
            + $"\nDepth: {depth}"
            + $"\nInput Card Nos: {string.Join(',', cards.Select(c => c.CardNumber))}"
            + $"\nWinning Card Nos: NONE");
        }
        var subCards = new List<Card>();
        var cardCount = 1;
        Parallel.ForEach(
            winningCards, card =>
            {
                Console.WriteLine(new string('-', 15)
                + $"\nDepth: {depth}"
                + $"\nCard{cardCount} of {winningCards.Count}"
                + $"\nInput Card Nos: {string.Join(',', cards.Select(c => c.CardNumber))}"
                + $"\nWinning Card Nos: {string.Join(',', winningCards.Select(c => c.CardNumber))}"
                + $"\nProcessing card: #{card.CardNumber}");

                if (card.MatchedWinningNumbersCount > 0)
                {
                    Console.WriteLine(
                        $"Card#{card.CardNumber} winning numbers count: {card.MatchedWinningNumbersCount}");
                    var newSubCards = allCards.Skip(card.CardNumber).Take(card.MatchedWinningNumbersCount)
                        .ToList();
                    Console.WriteLine($"New sub cards: {string.Join(',', newSubCards.Select(c => c.CardNumber))}");
                    subCards.Add(card);
                    subCards.AddRange(PlayCards(allCards, newSubCards, depth + 1));
                }

                cardCount++;
            });

        return subCards;
    }
}
