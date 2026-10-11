using Content.Shared._Citadel.Arcanima.Engine;

namespace Values;

public sealed class Option<T> : ValueBase where T : ValueBase
{
    public T? Value { get; set; }

    public override Option<T> Copy()
    {
        return new Option<T> { Value = Value == null ? null : (T)Value.Copy() };
    }

    public override ulong GetMemoryUnits()
    {
        return (Value?.GetMemoryUnits() ?? 0) + 1;
    }
}
