namespace Content.Shared._Citadel.Arcanima.Engine.Values;

public sealed class Text(string value) : ValueBase
{
    public string Value { get; set; } = value;

    public override Text Copy()
    {
        return new Text(Value);
    }

    public override ulong GetMemoryUnits()
    {
        return (ulong)Value.Length;
    }
}
