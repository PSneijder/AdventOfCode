namespace AdventOfCode.Common.InputReader;

/// <summary>
///     Class responsible for reading puzzle input for Advent of Code challenges
/// </summary>
/// <seealso cref="AdventOfCode.Common.IInputReader" />
internal sealed class PuzzleInputReader : IInputReader
{
    /// <summary>
    ///     Method to retrieve input data for a specific day's puzzle
    /// </summary>
    /// <param name="day">The day.</param>
    /// <returns></returns>
    public string[] GetInputFrom(Days day)
    {
        var basePath = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\..\..\"));
        var filePath = Path.Combine(basePath, $@"res\{day}\{day}.txt");

        var lines = File.ReadAllLines(filePath);

        return lines;
    }
}