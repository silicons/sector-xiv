using Content.Shared._Citadel.Arcanima.Engine.Values;

namespace Values;

public sealed class Text : ValueBase
{
    public string Value { get; set; } = "";

    public override Text Copy()
    {
        return new Text { Value = Value };
    }

    public override ulong GetMemoryUnits()
    {
        return (ulong)Value.Length;
    }
}
