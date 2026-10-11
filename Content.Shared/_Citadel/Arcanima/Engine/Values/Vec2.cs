using Content.Shared._Citadel.Arcanima.Engine;

namespace Values;

public sealed class Vec2 : ValueBase
{
    public double X { get; set; }
    public double Y { get; set; }

    public override Vec2 Copy()
    {
        return new Vec2 { X = X, Y = Y };
    }

    public override ulong GetMemoryUnits()
    {
        return 2;
    }
}
