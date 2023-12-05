namespace AdventOfCode.Day5.Extensions;

internal static class StringExtensions
{
    /// <summary>
    ///     Extracts seed numbers from a string line.
    /// </summary>
    /// <param name="line">The line.</param>
    /// <returns></returns>
    public static HashSet<long> GetSeeds(this string line)
    {
        // Skip the first element and parse the remaining elements as double values
        return new HashSet<long>(line.Split(' ').Skip(1).Select(long.Parse));
    }

    /// <summary>
    ///     Processes lines to extract mappings.
    /// </summary>
    /// <param name="lines">The lines.</param>
    /// <returns></returns>
    public static List<List<Map>> GetMaps(this IEnumerable<string> lines)
    {
        List<List<Map>> maps = new();
        List<Map> currentMaps = new();

        foreach (var line in lines)
        {
            if (string.IsNullOrEmpty(line))
            {
                maps.Add(currentMaps);
                currentMaps = new List<Map>();
                continue;
            }

            if (line.EndsWith(':')) continue;

            currentMaps.Add(new Map(line));
        }

        if (currentMaps.Any()) maps.Add(currentMaps);

        return maps;
    }

    /// <summary>
    ///     Processes lines to extract mappings.
    /// </summary>
    /// <param name="lines">The lines.</param>
    /// <returns></returns>
    public static List<List<MapWithRange>> GetMapsWithRanges(this IEnumerable<string> lines)
    {
        List<List<MapWithRange>> maps = new();
        List<MapWithRange> currentMaps = new();

        foreach (var line in lines)
        {
            if (string.IsNullOrEmpty(line))
            {
                maps.Add(currentMaps);
                currentMaps = new List<MapWithRange>();
                continue;
            }

            if (line.EndsWith(':')) continue;

            currentMaps.Add(new MapWithRange(line));
        }

        if (currentMaps.Any()) maps.Add(currentMaps);

        return maps;
    }
}