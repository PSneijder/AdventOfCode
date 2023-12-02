using AdventOfCode.Day2.Extensions;

namespace AdventOfCode.Day2;

internal sealed class Part2
{
    /// <summary>
    ///     Calculate method takes an array of strings (lines) and returns the product of cube counts
    /// </summary>
    /// <param name="lines">The lines.</param>
    /// <returns></returns>
    public int Calculate(string[] lines)
    {
        return FindSumOfPossibleGames(lines);
    }

    /// <summary>
    ///     Method to find the product of cube counts in each game
    /// </summary>
    /// <param name="lines">The lines.</param>
    /// <returns></returns>
    private int FindSumOfPossibleGames(string[] lines)
    {
        // Calculates the product of cube counts in each game and sums them up
        var sum = lines.Sum(line =>
        {
            var game = line.ToGame();

            // Returns the product of red, green, and blue cube counts in each game
            return game.Red * game.Green * game.Blue;
        });

        // Returns the sum of products of cube counts in all games
        return sum;
    }
}