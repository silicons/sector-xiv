namespace Content.Shared._Citadel.Arcanima.Engine.Values;

public sealed class Option<T>(T? value) : ValueBase where T : ValueBase
{
    public T? Value { get; set; } = value;

    public override Option<T> Copy()
    {
        return new Option<T>(Value == null ? null : (T)Value.Copy());
    }

    public override ulong GetMemoryUnits()
    {
        return (Value?.GetMemoryUnits() ?? 0) + 1;
    }
}
