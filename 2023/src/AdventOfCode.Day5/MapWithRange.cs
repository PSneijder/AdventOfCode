namespace AdventOfCode.Day5;

/// <summary>
///     Represents a map between source and destination ranges, allowing transformations.
/// </summary>
internal sealed class MapWithRange
{
    public MapWithRange(string mapStr)
    {
        // Split the input string by spaces, remove empty entries, convert to long, and store in a list.
        var values = mapStr.Split(' ').Where(str => !string.IsNullOrEmpty(str)).Select(long.Parse).ToList();

        // Extract the values for destination start, source start, and length from the list.
        var destinationStart = values[0];
        var sourceStart = values[1];
        var length = values[2];

        // Create Range objects for the destination and source based on extracted values.
        Destination = new Range(destinationStart, destinationStart + length);
        Source = new Range(sourceStart, sourceStart + length);
    }

    public Range Destination { get; }
    public Range Source { get; }

    // Calculates the offset between the destination and source start points.
    public long Offset => Destination.Start - Source.Start;

    /// <summary>
    ///     Transforms the input range based on the map's source and destination ranges.
    /// </summary>
    /// <param name="inputRange">The input range.</param>
    /// <returns></returns>
    public List<Range> TransformRange(Range inputRange)
    {
        if (inputRange.IsTransformed)
            // Return the input range if it's already transformed.
            return new List<Range> { inputRange };

        // Find the intersection between the map's source and the input range.
        var intersection = Source.GetIntersection(inputRange);

        if (intersection == null)
            // No intersection found, return the input range.
            return new List<Range> { inputRange };

        // Calculate the transformed range based on the intersection and offset.
        var transformed = new Range(intersection.Start + Offset, intersection.End + Offset, true);

        // Subtract the intersection from the input range and return the transformed range and remaining ranges.
        return new List<Range> { transformed }.Concat(inputRange.SubtractIntersection(intersection)).ToList();
    }
}