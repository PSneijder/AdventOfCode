namespace AdventOfCode.Day1;

internal sealed class Part1
{
    /// <summary>
    ///     Method to calculate the calibration values sum based on provided lines of text.
    /// </summary>
    /// <param name="lines">The lines.</param>
    public int Calculate(string[] lines)
    {
        // Calculate the sum of calibration values
        return CalculateCalibrationValuesSum(lines);
    }

    /// <summary>
    ///     Method to calculate the sum of calibration values based on provided array of strings
    /// </summary>
    /// <param name="lines">The lines.</param>
    /// <returns></returns>
    private int CalculateCalibrationValuesSum(string[] lines)
    {
        // Initialize the sum variable to hold the total sum of calibration values
        var sum = lines.Sum(line =>
        {
            // Retrieve the first and last digits in the current line
            var (firstDigit, lastDigit) = FindDigit(line);

            // Check if both first and last digits are found in the line
            if (firstDigit != default && lastDigit != default)
            {
                // Concatenate the first and last digits and parse them into an integer
                var calibrationValue = int.Parse($"{firstDigit}{lastDigit}");

                // Return the calculated calibration value
                return calibrationValue;
            }

            return 0;
        });

        return sum;
    }

    /// <summary>
    ///     Method to find the first and last digits in a given line of text
    /// </summary>
    /// <param name="line">The line.</param>
    /// <returns></returns>
    private (char?, char?) FindDigit(string line)
    {
        // Find all possible digits in the line based on words or direct digits
        var foundDigits = line
            .SelectMany((_, i) => GetDigitsAtIndex(line, i))
            .ToArray();

        // Retrieve the first and last digits found in the line
        char? first = foundDigits.FirstOrDefault();
        char? last = foundDigits.LastOrDefault();

        // Return a tuple containing the first and last digits found in the line
        return (first, last);
    }

    /// <summary>
    ///     Method to get digits at a specific index in the line, considering direct digits
    /// </summary>
    /// <param name="line">The line.</param>
    /// <param name="index">The index.</param>
    /// <returns></returns>
    private IEnumerable<char> GetDigitsAtIndex(string line, int index)
    {
        // If the character at the index is a digit, yield the digit itself
        if (char.IsDigit(line[index])) yield return line[index];
    }
}