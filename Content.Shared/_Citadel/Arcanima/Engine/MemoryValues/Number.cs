namespace Content.Shared._Citadel.Arcanima.Engine.MemoryValues;

public sealed class Number : MemoryValue
{
    public double Value { get; set; } = 0.0;

    public override object Clone()
    {
        return new Number { Value = Value };
    }
}
