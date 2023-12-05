using AdventOfCode.Common;
using Microsoft.Extensions.DependencyInjection;

namespace AdventOfCode.Day5.Extensions;

public static class ServiceCollectionExtensions
{
    public static void UsePuzzleFromDay5(this ServiceCollection services)
    {
        services.AddTransient<IPuzzle, Puzzle>();
        services.AddTransient<Part1>();
        services.AddTransient<Part2>();
    }
}