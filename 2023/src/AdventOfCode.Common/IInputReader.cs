using AdventOfCode.Common.InputReader;

namespace AdventOfCode.Common;

public interface IInputReader
{
    string[] GetInputFrom(Days day);
}