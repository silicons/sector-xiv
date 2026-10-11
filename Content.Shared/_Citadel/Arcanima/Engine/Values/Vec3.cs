namespace Content.Shared._Citadel.Arcanima.Engine.Values;

public sealed class Vec3(double x, double y, double z) : ValueBase
{
    public double X { get; set; } = x;
    public double Y { get; set; } = y;
    public double Z { get; set; } = z;

    public override Vec3 Copy()
    {
        return new Vec3(X, Y, Z);
    }

    public override ulong GetMemoryUnits()
    {
        return 3;
    }
}
