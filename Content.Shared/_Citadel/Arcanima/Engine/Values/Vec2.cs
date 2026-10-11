namespace Content.Shared._Citadel.Arcanima.Engine.Values;

public sealed class Vec2(double x, double y) : ValueBase
{
    public double X { get; set; } = x;
    public double Y { get; set; } = y;

    public override Vec2 Copy()
    {
        return new Vec2(X, Y);
    }

    public override ulong GetMemoryUnits()
    {
        return 2;
    }
}
