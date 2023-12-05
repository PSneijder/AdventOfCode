namespace AdventOfCode.Day5;

/// <summary>
///     Represents a mapping between a source range and a destination in a Map.
/// </summary>
internal sealed class Map
{
    public Map(string mapStr)
    {
        // Split the input string by spaces, remove empty entries, convert to long, and store in an array.
        var values = mapStr.Split(' ').Where(str => !string.IsNullOrEmpty(str)).Select(long.Parse).ToArray();

        // Assign the parsed values to the corresponding properties.
        Destination = values[0];
        Source = values[1];
        Range = values[2];
    }

    public long Destination { get; }
    public long Source { get; }
    public long Range { get; }

    /// <summary>
    ///     Checks if the input value falls within the range defined by the source and its range.
    /// </summary>
    /// <param name="input">The input.</param>
    /// <returns></returns>
    public bool IsInRange(long input)
    {
        return input >= Source && input < Source + Range;
    }

    /// <summary>
    ///     Calculates the output value based on the input, source, and destination values.
    /// </summary>
    /// <param name="input">The input.</param>
    /// <returns></returns>
    public long Output(long input)
    {
        return input + Destination - Source;
    }
}