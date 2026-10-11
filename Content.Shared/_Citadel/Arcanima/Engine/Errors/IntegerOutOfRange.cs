namespace Content.Shared._Citadel.Arcanima.Engine.Errors;

public sealed class IntegerOutOfRange(int value, int low, int high, int argIdx) : Error
{
    public readonly int ArgIdx = argIdx;
    public readonly int High = high;
    public readonly int Low = low;
    public readonly int Value = value;

    public override string Format()
    {
        return $"Argument {ArgIdx} value {Value} is out of bounds ('{Low}' <-> '{High}').";
    }
}
