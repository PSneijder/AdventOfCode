using System.Text.RegularExpressions;

namespace AdventOfCode.Day4.Extensions;

internal static class StringExtensions
{
    /// <summary>
    ///     Extension method to convert a string into a 'Card' object.
    /// </summary>
    /// <param name="line">The line.</param>
    /// <returns></returns>
    public static Card ToCard(this string line)
    {
        // Splitting the input string into parts using ':' and '|', and storing them in an array.
        var parts = line.Split(':', '|');

        // Extracting numbers from the second and third parts using Regex pattern matching.
        var left = Regex.Matches(parts[1], @"\d+").Select(m => m.Value);
        var right = Regex.Matches(parts[2], @"\d+").Select(m => m.Value);

        // Creating a new 'Card' object by counting the intersection of numbers between 'left' and 'right'.
        return new Card(left.Intersect(right).Count()); // Counting the common numbers and creating a 'Card'.
    }
}