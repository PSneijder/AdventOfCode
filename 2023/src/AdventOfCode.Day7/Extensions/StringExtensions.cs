namespace AdventOfCode.Day7.Extensions;

internal static class StringExtensions
{
    public static int BidsByRanking(this string[] input, Func<string, (long, long)> getPoints)
    {
        // Use LINQ to process each string in the input array
        var bidsByRanking = from line in input
            // Split each line into hand and bid parts
            let hand = line.Split(" ")[0]
            let bid = int.Parse(line.Split(" ")[1])
            // Order the hands based on their ranking given by the getPoints function
            orderby getPoints(hand)
            select bid;

        // Calculate the total winnings based on hand rankings and bids
        return bidsByRanking
            // For each bid in the sorted sequence, calculate the rank and multiply it by the bid
            .Select((bid, rank) => (rank + 1) * bid)
            // Sum up all the calculated bids to get the total winnings
            .Sum();
    }

    public static long CardValue(this string hand, string cardOrder)
    {
        // Calculate the value of a hand based on a specific card order
        // Each card in the hand is mapped to its index in the given card order
        return Pack(hand.Select(card => cardOrder.IndexOf(card)));
    }

    public static long PatternValue(this string hand)
    {
        // Calculate the value of a hand based on its pattern
        // Each card in the hand is mapped to the count of occurrences of that card in the hand
        // The resulting sequence is then ordered in descending order and packed into a single value
        return Pack(hand.Select(card => hand.Count(x => x == card)).OrderDescending());
    }

    private static long Pack(IEnumerable<int> numbers)
    {
        // Pack a sequence of integers into a single long value
        // Combines the numbers using a base-256 representation to create a single value
        return numbers.Aggregate(1L, (a, v) => a * 256 + v);
    }
}