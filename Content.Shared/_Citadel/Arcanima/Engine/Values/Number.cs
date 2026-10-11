namespace Content.Shared._Citadel.Arcanima.Engine.Values;

public sealed class Number(double value) : ValueBase
{
    public double Value { get; set; } = value;

    public override Number Copy()
    {
        return new Number(Value);
    }

    public override ulong GetMemoryUnits()
    {
        return 1;
    }
}
