namespace AdventOfCode.Day5;

/// <summary>
///     Class representing a range with start and end points.
/// </summary>
internal sealed class Range
{
    public Range(long start, long end, bool isTransformed = false)
    {
        Start = start;
        End = end;
        IsTransformed = isTransformed;
    }

    public long Start { get; }
    public long End { get; }
    public bool IsTransformed { get; set; }

    /// <summary>
    ///     Method to find the intersection between two ranges.
    /// </summary>
    /// <param name="other">The other.</param>
    /// <returns>Returns a new Range representing the intersection, or null if no intersection exists.</returns>
    public Range? GetIntersection(Range other)
    {
        // Check if there is no overlap between the ranges.
        if (End <= other.Start || Start >= other.End)
            // No intersection found.
            return null;

        // Calculate and return the intersection range.
        return new Range(Math.Max(Start, other.Start), Math.Min(End, other.End));
    }

    /// <summary>
    ///     Method to subtract the intersection of two ranges and return resulting ranges.
    /// </summary>
    /// <param name="intersection">The intersection.</param>
    /// <returns></returns>
    public List<Range> SubtractIntersection(Range intersection)
    {
        var result = new List<Range>();

        // Check if there's a range before the intersection.
        if (Start < intersection.Start)
            // Add the range before the intersection to the result.
            result.Add(new Range(Start, intersection.Start));

        // Check if there's a range after the intersection.
        if (End > intersection.End)
            // Add the range after the intersection to the result.
            result.Add(new Range(intersection.End, End));

        // Return the resulting ranges after subtraction.
        return result;
    }
}