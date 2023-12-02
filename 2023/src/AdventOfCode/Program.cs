using AdventOfCode.Common;
using AdventOfCode.Common.Extensions;
using AdventOfCode.Day2.Extensions;
using AdventOfCode.Extensions;
using Microsoft.Extensions.DependencyInjection;

namespace AdventOfCode;

internal class Program
{
    private static void Main(string[] args)
    {
        // Build the service provider
        using var serviceProvider = CreateServiceProvider();

        // Resolve and use the puzzle service
        using var writer = serviceProvider.GetRequiredService<IStreamWriter>();

        // Resolve and use the puzzle service
        var puzzle = serviceProvider.GetRequiredService<IPuzzle>();

        try
        {
            puzzle.Solve();
        }
        catch (Exception e)
        {
            writer.WriteLine(e.Message);
            throw;
        }
    }

    private static ServiceProvider CreateServiceProvider()
    {
        // Create a service collection
        var services = new ServiceCollection();

        // Register services
        services.UsePuzzleInputReader();
        services.UseConsoleWriter();
        // services.UsePuzzleFromDay1();
        services.UsePuzzleFromDay2();

        var serviceProvider = services.BuildServiceProvider();

        return serviceProvider;
    }
}