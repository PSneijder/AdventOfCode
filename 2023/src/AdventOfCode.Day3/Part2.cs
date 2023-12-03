using System.Text.RegularExpressions;
using AdventOfCode.Day3.Extensions;

namespace AdventOfCode.Day3;

internal sealed class Part2
{
    public int Calculate(string[] lines)
    {
        return CalculatePartSum(lines);
    }

    /// <summary>
    ///     Method to calculate the sum of part numbers based on adjacent gears
    /// </summary>
    /// <param name="lines">The lines.</param>
    /// <returns></returns>
    private int CalculatePartSum(string[] lines)
    {
        var gears = lines.ToPart(new Regex(@"\*"));
        var numbers = lines.ToPart(new Regex(@"\d+"));

        var sum = 0;

        // Iterate through each gear to find adjacent numbers and calculate the sum accordingly
        foreach (var gear in gears)
        {
            // Find adjacent numbers to the current gear
            var neighbours = numbers
                .Where(n => Adjacent(n, gear))
                .Select(n => n.Int)
                .ToArray();

            // If there are exactly 2 adjacent numbers, multiply them and add to the sum
            if (neighbours.Count() == 2)
                sum += neighbours.First() * neighbours.Last();
        }

        return sum;
    }

    /// <summary>
    ///     Method to check if two parts are adjacent
    /// </summary>
    /// <param name="p1">The p1.</param>
    /// <param name="p2">The p2.</param>
    /// <returns></returns>
    private bool Adjacent(Part p1, Part p2)
    {
        var isAdjacent = Math.Abs(p2.Row - p1.Row) <= 1
                         && p1.Col <= p2.Col + p2.Text.Length
                         && p2.Col <= p1.Col + p1.Text.Length;

        return isAdjacent; // Return whether two parts are adjacent
    }
}