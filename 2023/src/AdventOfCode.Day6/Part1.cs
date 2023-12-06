using AdventOfCode.Day6.Extensions;

namespace AdventOfCode.Day6;

internal class Part1
{
    public long Calculate(string[] lines)
    {
        var raceTimes = lines.GetRaceTimes();
        var recordDistances = lines.GetRecordDistances();

        // Calculate total ways to beat records across all races
        var totalWaysToWin = CalculateTotalWaysToWin(raceTimes, recordDistances);

        return totalWaysToWin;
    }

    /// <summary>
    ///     Method to calculate ways to beat records in each race
    /// </summary>
    /// <param name="raceTimes">The race times.</param>
    /// <param name="recordDistances">The record distances.</param>
    /// <returns></returns>
    private long CalculateTotalWaysToWin(int[] raceTimes, int[] recordDistances)
    {
        var result = 1L;

        // Iterate through each race
        for (var i = 0; i < raceTimes.Length; i++)
            // Calculate ways to beat record distance for each race
            result *= CalculateWayForSingleRace(raceTimes[i], recordDistances[i]);

        return result;
    }

    /// <summary>
    ///     Method to calculate way to beat record distance in a single race
    /// </summary>
    /// <param name="raceTime">The race time.</param>
    /// <param name="recordDistance">The record distance.</param>
    /// <returns></returns>
    protected long CalculateWayForSingleRace(long raceTime, long recordDistance)
    {
        var result = 0L;

        // Calculate different button press durations to beat the record distance
        for (var i = 1; i < raceTime - 1; i++)
            // Check if the boat can surpass the record distance for the given button press duration
            if ((raceTime - i) * i > recordDistance)
                result++;

        return result;
    }
}