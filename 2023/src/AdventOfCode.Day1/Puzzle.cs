using AdventOfCode.Common;

namespace AdventOfCode.Day1;

internal sealed class Puzzle : IPuzzle
{
    private readonly Part1 _part1;
    private readonly Part2 _part2;
    private readonly IStreamWriter _writer;

    public Puzzle(Part1 part1, Part2 part2, IStreamWriter writer)
    {
        _part1 = part1;
        _part2 = part2;
        _writer = writer;
    }

    public void Solve()
    {
        var basePath = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\..\..\"));
        var filePath = Path.Combine(basePath, @"res\day1\day1.txt");

        var lines = File.ReadAllLines(filePath);

        var sum1 = _part1.Calculate(lines); // 55208
        var sum2 = _part2.Calculate(lines); // 54578

        // Display the sum of calibration values from part 1 to the console
        _writer.WriteLine($"Sum of calibration values: {sum1}");
        // Display the sum of calibration values from part 2 to the console
        _writer.WriteLine($"Sum of calibration values: {sum2}");
    }
}