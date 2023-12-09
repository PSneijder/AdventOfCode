using AdventOfCode.Common;
using AdventOfCode.Common.Extensions;
using AdventOfCode.Day9.Extensions;
using AdventOfCode.Extensions;
using Microsoft.Extensions.DependencyInjection;

namespace AdventOfCode;

internal class Program
{
    private static void Main()
    {
        // Build the service provider
        using var serviceProvider = CreateServiceProvider();

        // Resolve and use the writer service
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
        services.UseConsoleWriter();
        services.UsePuzzleInputReader();
        // services.UsePuzzleFromDay1();
        // services.UsePuzzleFromDay2();
        // services.UsePuzzleFromDay3();
        // services.UsePuzzleFromDay4();
        // services.UsePuzzleFromDay5();
        // services.UsePuzzleFromDay6();
        // services.UsePuzzleFromDay7();
        // services.UsePuzzleFromDay8();
        services.UsePuzzleFromDay9();

        var serviceProvider = services.BuildServiceProvider();

        return serviceProvider;
    }
}