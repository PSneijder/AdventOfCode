using AdventOfCode.Common;
using AdventOfCode.Common.InputReader;

namespace AdventOfCode.Day4;

internal sealed class Puzzle : IPuzzle
{
    private readonly Part1 _part1;
    private readonly Part2 _part2;
    private readonly IInputReader _reader;
    private readonly IStreamWriter _writer;

    public Puzzle(Part1 part1, Part2 part2, IInputReader reader, IStreamWriter writer)
    {
        _part1 = part1;
        _part2 = part2;
        _reader = reader;
        _writer = writer;
    }

    public void Solve()
    {
        var lines = _reader.GetInputFrom(Days.Day4);

        var sum1 = _part1.Calculate(lines);
        var sum2 = _part2.Calculate(lines);

        _writer.WriteLine($"{sum1}"); // 26426
        _writer.WriteLine($"{sum2}"); // 6227972
    }
}