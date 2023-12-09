namespace AdventOfCode.Day9.Extensions;

internal static class LongArrayOperations
{
    /// <summary>
    ///     Extrapolates the sequence of numbers to the right and sums up the result
    /// </summary>
    /// <param name="numbers">The numbers.</param>
    /// <returns></returns>
    public static long ExtrapolateRight(this long[] numbers)
    {
        // If the input array is empty, return 0
        if (!numbers.Any())
            return 0;

        // Calculate the extrapolation to the right recursively using differences and addition
        return ExtrapolateRight(CalculateDifferences(numbers)) + numbers.Last();
    }

    /// <summary>
    ///     Extrapolates the sequence of numbers to the left and sums up the result
    /// </summary>
    /// <param name="numbers">The numbers.</param>
    /// <returns></returns>
    public static long ExtrapolateLeft(this long[] numbers)
    {
        // Extrapolate to the left by reversing the sequence and applying right extrapolation
        return ExtrapolateRight(numbers.Reverse().ToArray());
    }

    /// <summary>
    ///     Calculates the differences between consecutive numbers in the sequence
    /// </summary>
    /// <param name="numbers">The numbers.</param>
    /// <returns></returns>
    private static long[] CalculateDifferences(long[] numbers)
    {
        // Zip the sequence with its skipped version and calculate differences
        return numbers.Zip(numbers.Skip(1)).Select(pair => pair.Second - pair.First).ToArray();
    }
}