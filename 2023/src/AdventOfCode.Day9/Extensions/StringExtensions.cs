namespace AdventOfCode.Day9.Extensions;

internal static class StringExtensions
{
    /// <summary>
    ///     Solves the problem by performing extrapolation on parsed numbers
    /// </summary>
    /// <param name="input">The input.</param>
    /// <param name="extrapolate">The extrapolate.</param>
    /// <returns></returns>
    public static long SumExtrapolatedSequences(this string[] input, Func<long[], long> extrapolate)
    {
        // Parse each line of input into arrays of long numbers and then perform extrapolation
        var parsedNumbers = input.Select(ParseNumbers).Select(extrapolate);

        // Sum up the results of the extrapolation for all input lines
        var totalSum = parsedNumbers.Sum();

        return totalSum;
    }

    /// <summary>
    ///     Parses a line of space-separated numbers into an array of long numbers
    /// </summary>
    /// <param name="line">The line.</param>
    /// <returns></returns>
    private static long[] ParseNumbers(string line)
    {
        var numbers = line.Split(" ").Select(long.Parse).ToArray();

        return numbers;
    }
}