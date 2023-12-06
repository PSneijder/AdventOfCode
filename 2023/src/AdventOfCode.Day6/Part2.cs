using AdventOfCode.Day6.Extensions;

namespace AdventOfCode.Day6;

internal sealed class Part2 : Part1
{
    public new long Calculate(string[] lines)
    {
        var raceTimes = lines.GetRaceTime();
        var recordDistances = lines.GetRecordDistance();

        var wayToWin = CalculateWayForSingleRace(raceTimes, recordDistances);

        return wayToWin;
    }
}