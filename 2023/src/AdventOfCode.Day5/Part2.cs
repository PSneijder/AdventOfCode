using AdventOfCode.Day5.Extensions;

namespace AdventOfCode.Day5;

internal sealed class Part2
{
    public double Calculate(string[] lines)
    {
        var seeds = lines[0].GetSeeds();
        var maps = lines.Skip(1).GetMaps();

        return GetLowestLocationForSeedsWithRanges(seeds.ToArray(), maps);
    }

    /// <summary>
    ///     Creates ranges based on provided seed numbers.
    /// </summary>
    /// <param name="seeds">The seeds.</param>
    /// <returns></returns>
    private List<(double from, double to)> CreateRanges(double[] seeds)
    {
        var ranges = new List<(double from, double to)>();

        // Create tuple ranges based on seed numbers
        for (var i = 0; i < seeds.Length; i += 2) ranges.Add((from: seeds[i], to: seeds[i] + seeds[i + 1] - 1));

        // Return the list of tuple ranges
        return ranges;
    }

    /// <summary>
    ///     Finds the lowest location number for given seeds with ranges using provided mappings.
    /// </summary>
    /// <param name="seeds">The seeds.</param>
    /// <param name="maps">The maps.</param>
    /// <returns></returns>
    private double GetLowestLocationForSeedsWithRanges(double[] seeds,
        Dictionary<string, List<(double from, double to, double adjustment)>> maps)
    {
        // Create ranges based on seed numbers
        var ranges = CreateRanges(seeds);

        // Loop through each mapping
        foreach (var map in maps)
        {
            var orderedMap = map.Value.OrderBy(x => x.from).ToArray();
            var newRanges = new List<(double from, double to)>();

            // Loop through each seed range
            foreach (var range in ranges)
            {
                var modifiedRange = range;

                // Loop through each mapping in order
                foreach (var mapping in orderedMap)
                {
                    // Modify the seed range based on the mapping adjustments
                    if (modifiedRange.from < mapping.from)
                    {
                        newRanges.Add((modifiedRange.from,
                            Math.Min(modifiedRange.to, mapping.from - 1)));

                        modifiedRange.from = mapping.from;

                        if (modifiedRange.from > modifiedRange.to)
                            break;
                    }

                    if (modifiedRange.from <= mapping.to)
                    {
                        newRanges.Add((modifiedRange.from + mapping.adjustment,
                            Math.Min(modifiedRange.to, mapping.to) + mapping.adjustment));

                        modifiedRange.from = mapping.to + 1;

                        if (modifiedRange.from > modifiedRange.to)
                            break;
                    }
                }

                if (modifiedRange.from <= modifiedRange.to) newRanges.Add(modifiedRange);
            }

            // Update the seed ranges with the modified ranges
            ranges = newRanges;
        }

        // Return the lowest location number found in modified ranges
        return ranges.Min(r => r.from);
    }
}