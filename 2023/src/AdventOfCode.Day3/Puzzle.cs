using AdventOfCode.Common;
using AdventOfCode.Common.InputReader;

namespace AdventOfCode.Day3;

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
        var lines = _reader.GetInputFrom(Days.Day3);

        var sum1 = _part1.Calculate(lines);
        var sum2 = _part2.Calculate(lines);

        _writer.WriteLine($"Sum of part numbers in the engine schematic: {sum1}"); // 514969
        _writer.WriteLine($"Sum of gear ratios in the engine schematic: {sum2}"); // 78915902
    }
}