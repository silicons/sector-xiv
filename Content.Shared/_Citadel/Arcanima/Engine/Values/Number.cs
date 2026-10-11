using Content.Shared._Citadel.Arcanima.Engine;

namespace Values;

public sealed class Number : ValueBase
{
    public double Value { get; set; }

    public override Number Copy()
    {
        return new Number { Value = Value };
    }

    public override ulong GetMemoryUnits()
    {
        return 1;
    }
}
