using AdventOfCode.Common;

namespace AdventOfCode.ConsoleWriter;

internal sealed class ConsoleStreamWriter : IStreamWriter
{
    private readonly StreamWriter _writer;
    private bool _disposed;

    public ConsoleStreamWriter()
    {
        _writer = new StreamWriter(Console.OpenStandardOutput())
        {
            AutoFlush = true
        };
    }

    /// <summary>
    ///     Implementation of Dispose method to properly dispose resources
    /// </summary>
    public void Dispose()
    {
        Dispose(true); // Call Dispose method with parameter 'true' to release managed resources
        GC.SuppressFinalize(this); // Suppress finalization to avoid redundant cleanup
    }

    /// <summary>
    ///     Writes a string value to the writer
    /// </summary>
    /// <param name="value">The string value to be written</param>
    public void WriteLine(string value)
    {
        _writer.WriteLine(value);
    }

    ~ConsoleStreamWriter()
    {
        Dispose(false);
    }

    private void Dispose(bool disposing)
    {
        if (_disposed) return;

        if (disposing)
            // Dispose managed resources
            _writer.Dispose();

        // Dispose unmanaged resources (if any)
        _disposed = true;
    }
}