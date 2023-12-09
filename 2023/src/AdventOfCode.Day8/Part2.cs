using AdventOfCode.Day8.Extensions;

namespace AdventOfCode.Day8;

internal sealed class Part2
{
    public long Calculate(string[] lines)
    {
        return lines.CalculateStepsToTarget("A", "Z");
    }
}