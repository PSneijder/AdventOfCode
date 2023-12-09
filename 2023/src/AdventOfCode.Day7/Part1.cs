using AdventOfCode.Day7.Extensions;

namespace AdventOfCode.Day7;

internal class Part1
{
    public int Calculate(string[] lines)
    {
        return lines.BidsByRanking(Points);
    }

    /// <summary>
    ///     Calculates the points for Part 1 of the Camel Cards game based on a given hand.
    /// </summary>
    /// <param name="hand">A string representing a hand of cards.</param>
    /// <returns>
    ///     A tuple containing two long values representing the pattern value and card value of the hand:
    ///     - Pattern value: Represents the value of the hand based on its pattern (frequency of card occurrences).
    ///     - Card value: Represents the value of the hand based on a specific card order.
    /// </returns>
    /// <remarks>
    ///     The method utilizes the PatternValue and CardValue methods to determine the hand's values.
    ///     The PatternValue method calculates the hand's pattern value, while the CardValue method calculates
    ///     the hand's value based on a specific card order.
    /// </remarks>
    private (long, long) Points(string hand)
    {
        // Calculate the points for Part 1 of the game based on a given hand
        // Calls two methods to determine the hand's pattern value and its card value
        return (hand.PatternValue(), hand.CardValue("123456789TJQKA"));
    }
}