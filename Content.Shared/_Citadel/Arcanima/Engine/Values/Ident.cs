namespace Content.Shared._Citadel.Arcanima.Engine.Values;

/// <summary>
/// Represents a program Identifier.
/// </summary>
public sealed class Ident(Identifier value) : ValueBase
{
    public Identifier Value { get; set; } = value;

    public override Ident Copy()
    {
        return new Ident(Value);
    }

    public override ulong GetMemoryUnits()
    {
        return 1;
    }
}
