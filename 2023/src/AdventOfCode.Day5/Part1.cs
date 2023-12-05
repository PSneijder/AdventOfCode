using AdventOfCode.Day5.Extensions;

namespace AdventOfCode.Day5;

internal sealed class Part1
{
    public long Calculate(string[] lines)
    {
        var seeds = lines[0].GetSeeds();
        var maps = lines.Skip(1).GetMaps();

        return GetLowestLocationForSeeds(seeds, maps);
    }

    /// <summary>
    ///     Function to find the lowest location for a collection of seeds
    /// </summary>
    /// <param name="seeds">The seeds.</param>
    /// <param name="maps">The maps.</param>
    /// <returns></returns>
    private long GetLowestLocationForSeeds(HashSet<long> seeds, List<List<Map>> maps)
    {
        var locations = new HashSet<long>();

        // Loop through each seed number
        foreach (var seed in seeds)
        {
            // Calculate location for each seed and add it to locations set
            var location = CalculateSeedLocation(seed, maps);

            locations.Add(location);
        }

        // Return the lowest location number found for the seeds
        return locations.Min();
    }

    /// <summary>
    ///     Function to calculate the final location of a seed based on maps
    /// </summary>
    /// <param name="input">The input.</param>
    /// <param name="maps">The maps.</param>
    /// <returns></returns>
    private long CalculateSeedLocation(long input, List<List<Map>> maps)
    {
        var output = input;

        // Apply each map to the input seed
        foreach (var map in maps)
            // Calculate the output location based on the map rules
            output = CalculateOutput(output, map);

        return output;
    }

    /// <summary>
    ///     Function to calculate the output based on the map rules
    /// </summary>
    /// <param name="input">The input.</param>
    /// <param name="maps">The maps.</param>
    /// <returns></returns>
    private long CalculateOutput(long input, List<Map> maps)
    {
        var output = input;

        // Apply each map rule to the input output
        foreach (var map in maps)
            // Check if the output is within the map range
            if (map.IsInRange(output))
            {
                // Apply map transformation to the output
                output = map.Output(output);

                // If output changes, break the loop
                if (input != output)
                    break;
            }

        return output;
    }
}