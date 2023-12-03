using System.Text.RegularExpressions;

namespace AdventOfCode.Day3.Extensions;

internal static class StringExtensions
{
    /// <summary>
    ///     Extension method to convert string lines to an array of Part objects based on a regex pattern
    /// </summary>
    /// <param name="lines">The lines.</param>
    /// <param name="regex">The regex.</param>
    /// <returns></returns>
    public static Part[] ToPart(this string[] lines, Regex regex)
    {
        var list = new List<Part>();

        // Loop through each row (line) in the input array
        foreach (var row in Enumerable.Range(0, lines.Length))
            // For each match found in the current row using the provided regex pattern
        foreach (Match match in regex.Matches(lines[row]))
            // Create a new Part object and add it to the list
            list.Add(new Part(match.Value, row, match.Index));

        return list.ToArray(); // Return the array of Part objects
    }
}