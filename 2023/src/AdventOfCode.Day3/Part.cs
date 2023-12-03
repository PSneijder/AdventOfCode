namespace AdventOfCode.Day3;

internal record Part(string Text, int Row, int Col)
{
    public int Int => int.Parse(Text);
}