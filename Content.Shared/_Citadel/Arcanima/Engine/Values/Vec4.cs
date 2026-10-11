namespace Content.Shared._Citadel.Arcanima.Engine.Values;

public sealed class Vec4(double x, double y, double z, double w) : ValueBase
{
    public double X { get; set; } = x;
    public double Y { get; set; } = y;
    public double Z { get; set; } = z;
    public double W { get; set; } = w;

    public override Vec4 Copy()
    {
        return new Vec4(X, Y, Z, W);
    }

    public override ulong GetMemoryUnits()
    {
        return 4;
    }
}
