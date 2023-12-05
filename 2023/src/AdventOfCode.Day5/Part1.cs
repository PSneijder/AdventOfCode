using AdventOfCode.Day5.Extensions;

namespace AdventOfCode.Day5;

internal sealed class Part1
{
    public double Calculate(string[] lines)
    {
        var seeds = lines[0].GetSeeds();
        var maps = lines.Skip(1).GetMaps();

        return GetLowestLocationForSeeds(seeds, maps);
    }

    /// <summary>
    ///     Finds the lowest location number for given seeds using provided mappings.
    /// </summary>
    /// <param name="seeds">The seeds.</param>
    /// <param name="maps">The maps.</param>
    /// <returns></returns>
    private double GetLowestLocationForSeeds(HashSet<double> seeds,
        Dictionary<string, List<(double from, double to, double adjustment)>> maps)
    {
        // Initialize the result with maximum value
        var result = double.MaxValue;

        // Loop through each seed number
        foreach (var seed in seeds)
        {
            // Initialize the value with the current seed
            var value = seed;

            // Loop through each mapping
            foreach (var map in maps)
                // Loop through each range in the mapping
            foreach (var item in map.Value)
                // If the value falls within the range, adjust the value and break
                if (value >= item.from && value <= item.to)
                {
                    value += item.adjustment;
                    break;
                }

            // Update the result with the minimum value found
            result = Math.Min(result, value);
        }

        // Return the lowest location number found for the seeds
        return result;
    }
}