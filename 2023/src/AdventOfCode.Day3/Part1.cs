using System.Text.RegularExpressions;
using AdventOfCode.Day3.Extensions;

namespace AdventOfCode.Day3;

internal sealed class Part1
{
    public int Calculate(string[] lines)
    {
        return CalculatePartSum(lines);
    }

    /// <summary>
    ///     Method to calculate the sum of part numbers
    /// </summary>
    /// <param name="lines">The lines.</param>
    /// <returns></returns>
    private int CalculatePartSum(string[] lines)
    {
        var symbols = lines.ToPart(new Regex(@"[^.0-9]"));
        var numbers = lines.ToPart(new Regex(@"\d+"));

        var sum = 0;

        // Iterate through each number and check if adjacent to any symbol
        foreach (var number in numbers)
            if (symbols.Any(part => Adjacent(part, number)))
                sum += number.Int; // Add the number to sum if adjacent to a symbol

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