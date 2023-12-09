using AdventOfCode.Day8.Extensions;

namespace AdventOfCode.Day8;

internal class Part1
{
    public long Calculate(string[] lines)
    {
        return lines.CalculateStepsToTarget("AAA", "ZZZ");
    }
}