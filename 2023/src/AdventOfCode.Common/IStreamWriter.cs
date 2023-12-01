namespace AdventOfCode.Common;

/// <summary>
///     Interface representing a stream writer in the Advent of Code challenge
/// </summary>
public interface IStreamWriter
{
    /// <summary>
    ///     Method signature for writing a line
    /// </summary>
    void WriteLine(string value);
}