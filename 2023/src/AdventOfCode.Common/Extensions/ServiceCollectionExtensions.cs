using AdventOfCode.Common.InputReader;
using Microsoft.Extensions.DependencyInjection;

namespace AdventOfCode.Common.Extensions;

public static class ServiceCollectionExtensions
{
    public static void UsePuzzleInputReader(this ServiceCollection services)
    {
        services.AddTransient<IInputReader, PuzzleInputReader>();
    }
}