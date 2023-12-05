namespace AdventOfCode.Day5.Extensions;

internal static class StringExtensions
{
    /// <summary>
    ///     Extracts seed numbers from a string line.
    /// </summary>
    /// <param name="line">The line.</param>
    /// <returns></returns>
    public static HashSet<double> GetSeeds(this string line)
    {
        // Skip the first element and parse the remaining elements as double values
        return new HashSet<double>(line.Split(' ').Skip(1).Select(double.Parse));
    }

    /// <summary>
    ///     Processes lines to extract mappings in the format of dictionary.
    /// </summary>
    /// <param name="lines">The lines.</param>
    /// <returns></returns>
    public static Dictionary<string, List<(double from, double to, double adjustment)>> GetMaps(
        this IEnumerable<string> lines)
    {
        // Dictionary to store mappings with map types as keys
        Dictionary<string, List<(double from, double to, double adjustment)>> maps = new();
        List<(double from, double to, double adjustment)> currentMap = new();

        foreach (var line in lines)
        {
            // Skip empty or whitespace lines
            if (string.IsNullOrWhiteSpace(line)) continue;

            if (line.Contains("map"))
            {
                // If line contains "map", create a new list for current map type
                currentMap = new List<(double, double, double)>();
                maps[line] = currentMap;
            }
            else if (currentMap != null)
            {
                // Parse the values in the line to create a tuple representing a mapping range and adjustment
                var values = line.Split(' ').Select(double.Parse).ToArray();
                currentMap!.Add((values[1], values[1] + values[2] - 1, values[0] - values[1]));
            }
        }

        return maps;
    }
}