using AdventOfCode.Day7.Extensions;

namespace AdventOfCode.Day7;

internal sealed class Part2
{
    public int Calculate(string[] lines)
    {
        return lines.BidsByRanking(Points);
    }

    /// <summary>
    ///     Calculates the points for Part 2 of the Camel Cards game based on a given hand with the new Joker rule.
    /// </summary>
    /// <param name="hand">A string representing a hand of cards.</param>
    /// <returns>
    ///     A tuple containing two long values representing the pattern value and card value of the hand with the Joker rule:
    ///     - Pattern value: Represents the value of the hand based on its pattern (frequency of card occurrences) with Jokers.
    ///     - Card value: Represents the value of the hand based on a specific card order, considering Jokers as the weakest
    ///     cards.
    /// </returns>
    /// <remarks>
    ///     In this updated game rule, J cards act as wildcards (Jokers) that can substitute for the best card to form the
    ///     strongest hand type.
    ///     J cards are treated as the weakest individual cards, weaker even than 2. They can represent any other card for hand
    ///     strength evaluation.
    ///     The method uses the cards "J123456789TQKA" to determine the potential value of Jokers in the hand.
    ///     The patternValue is calculated by replacing Jokers with other cards and finding the hand's maximum pattern value.
    ///     The cardValue is determined based on a specific card order while treating Jokers as the weakest cards.
    /// </remarks>
    private (long, long) Points(string hand)
    {
        var cards = "J123456789TQKA"; // Define the sequence of cards considering Jokers as weakest
        var patternValue = cards.Select(card => hand.Replace('J', card).PatternValue()).Max();

        return (patternValue, hand.CardValue(cards)); // Return patternValue and cardValue as a tuple
    }
}