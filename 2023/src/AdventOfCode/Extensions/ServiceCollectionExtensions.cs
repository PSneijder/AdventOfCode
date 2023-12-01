using AdventOfCode.Common;
using AdventOfCode.ConsoleWriter;
using Microsoft.Extensions.DependencyInjection;

namespace AdventOfCode.Extensions;

internal static class ServiceCollectionExtensions
{
    public static void UseConsoleWriter(this ServiceCollection services)
    {
        services.AddTransient<IStreamWriter, ConsoleStreamWriter>();
    }
}