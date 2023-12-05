using AdventOfCode.Day5.Extensions;

namespace AdventOfCode.Day5;

internal sealed class Part2
{
    public long Calculate(string[] lines)
    {
        var seeds = lines[0].GetSeeds();
        var maps = lines.Skip(1).GetMapsWithRanges();

        return GetLowestLocationForSeeds(seeds, maps);
    }

    private long GetLowestLocationForSeeds(HashSet<long> seeds, List<List<MapWithRange>> maps)
    {
        var ranges = CreateRanges(seeds.ToArray());
        var locations = CalculateSeedLocation(ranges, maps);

        return locations.Min(range => range.Start);
    }

    /// <summary>
    ///     Creates ranges based on seed values.
    /// </summary>
    /// <param name="seeds">The seeds.</param>
    /// <returns></returns>
    private List<Range> CreateRanges(long[] seeds)
    {
        var ranges = new List<Range>();

        // Create a Range object using the current seed as the start and length as the end.
        // Subtract 1 from the length to create the correct range.
        for (var i = 0; i < seeds.Length; i += 2) ranges.Add(new Range(seeds[i], seeds[i] + seeds[i + 1] - 1));

        return ranges;
    }

    /// <summary>
    ///     Function to get the lowest location for a collection of seeds with maps containing ranges
    /// </summary>
    /// <param name="ranges">The ranges.</param>
    /// <param name="maps">The garden map groups.</param>
    /// <returns></returns>
    private List<Range> CalculateSeedLocation(List<Range> ranges, List<List<MapWithRange>> maps)
    {
        foreach (var map in maps)
        {
            // Reset transformed flag for ranges
            ResetTransformed(ranges);

            // Apply transformations to the ranges based on map rules
            ranges = CalculateMapTransform(ranges, map);
        }

        return ranges;
    }

    /// <summary>
    ///     Function to reset the IsTransformed flag for ranges
    /// </summary>
    /// <param name="ranges">The ranges.</param>
    private void ResetTransformed(List<Range> ranges)
    {
        foreach (var range in ranges) range.IsTransformed = false;
    }

    /// <summary>
    ///     Function to apply transformations to the ranges based on map rules
    /// </summary>
    /// <param name="ranges">The ranges.</param>
    /// <param name="maps">The garden map group.</param>
    /// <returns></returns>
    private List<Range> CalculateMapTransform(List<Range> ranges, List<MapWithRange> maps)
    {
        foreach (var map in maps)
            // Apply map transformations to the ranges
            ranges = ranges.SelectMany(map.TransformRange).ToList();

        return ranges;
    }
}