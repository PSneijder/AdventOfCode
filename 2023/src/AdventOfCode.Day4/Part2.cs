using AdventOfCode.Day4.Extensions;

namespace AdventOfCode.Day4;

internal sealed class Part2
{
    public double Calculate(string[] lines)
    {
        return CalculatePoints(lines);
    }

    /// <summary>
    ///     Method to calculate points based on the array of strings.
    /// </summary>
    /// <param name="lines">The lines.</param>
    /// <returns></returns>
    private double CalculatePoints(string[] lines)
    {
        // Converting each line into a 'Card' object and storing them in an array.
        var cards = lines.Select(l => l.ToCard()).ToArray();
        // Initializing an array 'counts' with each element as 1.
        var counts = cards.Select(_ => 1).ToArray();

        // Looping through each 'Card' and its associated count to calculate points.
        for (var i = 0; i < cards.Length; i++)
        {
            var (card, count) = (cards[i], counts[i]);

            // Incrementing counts for subsequent cards based on the number of matches.
            for (var j = 0; j < card.Matches; j++)
                counts[i + j + 1] += count; // Adding the current count to future indices.
        }

        return counts.Sum(); // Returning the sum of all counts as the total points.
    }
}