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
                .Where(number => number.IsAdjacent(gear))
                .Select(number => number.Int)
                .ToArray();

            // If there are exactly 2 adjacent numbers, multiply them and add to the sum
            if (neighbours.Count() == 2)
                sum += neighbours.First() * neighbours.Last();
        }

        return sum;
    }
}