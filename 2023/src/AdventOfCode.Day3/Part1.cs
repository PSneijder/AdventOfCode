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
            if (symbols.Any(part => part.IsAdjacent(number)))
                sum += number.Int; // Add the number to sum if adjacent to a symbol

        return sum;
    }
}