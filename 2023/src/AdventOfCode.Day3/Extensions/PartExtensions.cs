namespace AdventOfCode.Day3.Extensions
{
    internal static class PartExtensions
    {

        /// <summary>
        ///     Method to check if two parts are adjacent
        /// </summary>
        /// <param name="p1">The p1.</param>
        /// <param name="p2">The p2.</param>
        /// <returns></returns>
        public static bool IsAdjacent(this Part p1, Part p2)
        {
            var isAdjacent = Math.Abs(p2.Row - p1.Row) <= 1
                             && p1.Col <= p2.Col + p2.Text.Length
                             && p2.Col <= p1.Col + p1.Text.Length;

            return isAdjacent; // Return whether two parts are adjacent
        }
    }
}
