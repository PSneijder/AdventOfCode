using AdventOfCode.Day9.Extensions;

namespace AdventOfCode.Day9;

internal class Part1
{
    public long Calculate(string[] lines)
    {
        return lines.SumExtrapolatedSequences(numbers => numbers.ExtrapolateRight());
    }
}