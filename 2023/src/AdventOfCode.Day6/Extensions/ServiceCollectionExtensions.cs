using AdventOfCode.Common;
using Microsoft.Extensions.DependencyInjection;

namespace AdventOfCode.Day6.Extensions;

public static class ServiceCollectionExtensions
{
    public static void UsePuzzleFromDay6(this ServiceCollection services)
    {
        services.AddTransient<IPuzzle, Puzzle>();
        services.AddTransient<Part1>();
        services.AddTransient<Part2>();
    }
}