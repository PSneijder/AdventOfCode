using AdventOfCode.Day9.Extensions;

namespace AdventOfCode.Day9;

internal sealed class Part2
{
    public long Calculate(string[] lines)
    {
        return lines.SumExtrapolatedSequences(numbers => numbers.ExtrapolateLeft());
    }
}