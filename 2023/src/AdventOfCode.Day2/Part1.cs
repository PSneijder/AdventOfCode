using AdventOfCode.Day2.Extensions;

namespace AdventOfCode.Day2;

internal sealed class Part1
{
    /// <summary>
    ///     Calculate method takes an array of strings (lines) and returns the sum of possible games' IDs
    /// </summary>
    /// <param name="lines">The lines.</param>
    /// <returns></returns>
    public int Calculate(string[] lines)
    {
        return FindSumOfPossibleGames(lines);
    }

    /// <summary>
    ///     Method to find the sum of possible games' IDs
    /// </summary>
    /// <param name="lines">The lines.</param>
    /// <returns></returns>
    private int FindSumOfPossibleGames(string[] lines)
    {
        // Sums up the IDs of possible games by checking each line of input
        var sum = lines.Sum(line =>
        {
            var game = line.ToGame();
            var isPossible = IsGamePossible(game);

            // Returns the game ID if it's possible, otherwise returns 0
            return isPossible
                ? game.Id
                : 0;
        });

        return sum;
    }

    /// <summary>
    ///     Method to check if a game is possible based on cube counts
    /// </summary>
    /// <param name="game">The game.</param>
    private bool IsGamePossible(Game game)
    {
        return game.Red <= 12 && game.Green <= 13 && game.Blue <= 14;
    }
}