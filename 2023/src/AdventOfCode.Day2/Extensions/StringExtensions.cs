using System.Text.RegularExpressions;

namespace AdventOfCode.Day2.Extensions;

internal static class StringExtensions
{
    /// <summary>
    ///     Extension method to convert a string line into a Game object
    /// </summary>
    /// <param name="line">The line.</param>
    /// <returns></returns>
    public static Game ToGame(this string line)
    {
        var id = ParseIntegers(line, @"Game (\d+)").First();
        var red = ParseIntegers(line, @"(\d+) red").Max();
        var green = ParseIntegers(line, @"(\d+) green").Max();
        var blue = ParseIntegers(line, @"(\d+) blue").Max();

        return new Game(id, red, green, blue);
    }

    /// <summary>
    ///     Helper method to parse integers using regular expressions from a given input and pattern
    /// </summary>
    /// <param name="input">The input.</param>
    /// <param name="pattern">The pattern.</param>
    /// <returns></returns>
    private static IEnumerable<int> ParseIntegers(string input, string pattern)
    {
        foreach (Match match in Regex.Matches(input, pattern))
            yield return int.Parse(match.Groups[1].Value);
    }
}