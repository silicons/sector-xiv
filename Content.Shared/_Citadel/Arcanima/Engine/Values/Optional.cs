using Content.Shared._Citadel.Arcanima.Engine;

namespace Values;

public sealed class Optional<T> : ValueBase where T : ValueBase
{
    public T? Value { get; set; }

    public override Optional<T> Copy()
    {
        return new Optional<T> { Value = Value == null ? null : (T)Value.Copy() };
    }

    public override ulong GetMemoryUnits()
    {
        return (Value?.GetMemoryUnits() ?? 0) + 1;
    }
}
