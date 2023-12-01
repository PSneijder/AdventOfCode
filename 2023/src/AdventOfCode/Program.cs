using AdventOfCode.Common;
using AdventOfCode.Day1.Extensions;
using AdventOfCode.Extensions;
using Microsoft.Extensions.DependencyInjection;

namespace AdventOfCode;

internal class Program
{
    private static void Main(string[] args)
    {
        try
        {
            // Create a service collection
            var services = new ServiceCollection();

            // Register services
            services.UseConsoleWriter();
            services.UsePuzzleFromDay1();

            // Build the service provider
            using var serviceProvider = services.BuildServiceProvider();

            // Resolve and use the service
            var puzzle = serviceProvider.GetRequiredService<IPuzzle>();
            puzzle.Solve();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}