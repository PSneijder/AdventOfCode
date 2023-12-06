using System.Text.RegularExpressions;

namespace AdventOfCode.Day6.Extensions;

internal static class StringExtensions
{
    public static int[] GetRaceTimes(this string[] lines, bool replaceWhitespacesWithEmptyString = false)
    {
        return Regex.Matches(lines[0], @"\d+").Select(m => int.Parse(m.Value)).ToArray();
    }

    public static int[] GetRecordDistances(this string[] lines, bool replaceWhitespacesWithEmptyString = false)
    {
        return Regex.Matches(lines[1], @"\d+").Select(m => int.Parse(m.Value)).ToArray();
    }

    public static long GetRaceTime(this string[] lines, bool replaceWhitespacesWithEmptyString = false)
    {
        return long.Parse(Regex.Match(lines[0].Replace(" ", string.Empty), @"\d+").Value);
    }

    public static long GetRecordDistance(this string[] lines, bool replaceWhitespacesWithEmptyString = false)
    {
        return long.Parse(Regex.Match(lines[1].Replace(" ", string.Empty), @"\d+").Value);
    }
}