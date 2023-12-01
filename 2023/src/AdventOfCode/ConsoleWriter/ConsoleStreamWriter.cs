using AdventOfCode.Common;

namespace AdventOfCode.ConsoleWriter;

internal sealed class ConsoleStreamWriter : IStreamWriter, IDisposable
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

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    /// <summary>
    ///     Writes the line.
    /// </summary>
    /// <param name="value">The value.</param>
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