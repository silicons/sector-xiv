using Content.Shared._Citadel.Arcanima.Engine;

namespace Values;

public sealed class Vector2 : ValueBase
{
    public double X { get; set; }
    public double Y { get; set; }

    public override Vector2 Copy()
    {
        return new Vector2 { X = X, Y = Y };
    }

    public override ulong GetMemoryUnits()
    {
        return 2;
    }
}
