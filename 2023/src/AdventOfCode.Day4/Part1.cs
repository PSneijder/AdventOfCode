using AdventOfCode.Day4.Extensions;

namespace AdventOfCode.Day4;

internal sealed class Part1
{
    public double Calculate(string[] lines)
    {
        return CalculatePoints(lines);
    }

    /// <summary>
    ///     Method to calculate the sum based on the array of strings.
    /// </summary>
    /// <param name="lines">The lines.</param>
    /// <returns></returns>
    private double CalculatePoints(string[] lines)
    {
        // Using LINQ's Sum method to iterate through each line and calculate a sum.
        var sum = lines.Sum(line =>
        {
            var card = line.ToCard();

            // Returning a value based on the number of 'Matches' in the 'Card' object.
            return card.Matches > 0
                ? Math.Pow(2, card.Matches - 1)
                : 0;
        });

        return sum;
    }
}