using AdventOfCode.Common;
using AdventOfCode.Common.InputReader;

namespace AdventOfCode.Day6;

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
        var lines = _reader.GetInputFrom(Days.Day6);

        var sum1 = _part1.Calculate(lines);
        var sum2 = _part2.Calculate(lines);

        _writer.WriteLine($"Total ways to win: {sum1}"); // 1710720
        _writer.WriteLine($"Total ways to win: {sum2}"); // 35349468
    }
}