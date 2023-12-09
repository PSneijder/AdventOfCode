using System.Text.RegularExpressions;
using Map = System.Collections.Generic.Dictionary<string, (string Left, string Right)>;

namespace AdventOfCode.Day8.Extensions;

internal static class StringExtensions
{
    public static long CalculateStepsToTarget(this string[] lines, string startMarker, string endMarker)
    {
        var directions = lines[0];
        var map = ParseMap(lines.Skip(2).ToArray());

        var startNodes = map.Keys.Where(node => node.EndsWith(startMarker));

        // Calculate the total steps by finding the least common multiple of steps from different start nodes
        var totalSteps = startNodes
            .Select(startNode => StepsToTarget(startNode, endMarker, directions, map))
            .Aggregate(1L, LeastCommonMultiple);

        return totalSteps;
    }

    /// <summary>
    ///     https://en.wikipedia.org/wiki/Least_common_multiple
    /// </summary>
    /// <param name="a">a.</param>
    /// <param name="b">The b.</param>
    /// <returns></returns>
    private static long LeastCommonMultiple(long a, long b)
    {
        return a * b / GreatestCommonDivisor(a, b);
    }

    /// <summary>
    ///     https://en.wikipedia.org/wiki/Greatest_common_divisor
    /// </summary>
    /// <param name="a">a.</param>
    /// <param name="b">The b.</param>
    /// <returns></returns>
    private static long GreatestCommonDivisor(long a, long b)
    {
        return b == 0 ? a : GreatestCommonDivisor(b, a % b);
    }

    /// <summary>
    ///     Determines the number of steps required to reach the target node from the current node
    /// </summary>
    /// <param name="current">The current.</param>
    /// <param name="endMarker">The end marker.</param>
    /// <param name="directions">The directions.</param>
    /// <param name="map">The map.</param>
    /// <returns></returns>
    private static long StepsToTarget(string current, string endMarker, string directions, Map map)
    {
        var stepCount = 0;

        while (!current.EndsWith(endMarker))
        {
            var direction = directions[stepCount % directions.Length];
            current = direction == 'L' ? map[current].Left : map[current].Right;
            stepCount++;
        }

        return stepCount;
    }

    /// <summary>
    ///     Parses the input instructions to create a map of nodes and their connections
    /// </summary>
    /// <param name="lines">The lines.</param>
    /// <returns></returns>
    private static Map ParseMap(string[] lines)
    {
        var map = new Map();

        foreach (var line in lines)
        {
            var matches = Regex.Matches(line, "[A-Z]+");
            var currentNode = matches[0].Value;
            var leftNode = matches[1].Value;
            var rightNode = matches[2].Value;

            map[currentNode] = (leftNode, rightNode);
        }

        return map;
    }
}