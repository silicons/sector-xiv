namespace Content.Shared._Citadel.Arcanima.Engine.MemoryValues;

public sealed class Optional<T> : MemoryValue where T : MemoryValue
{
    public T? Value { get; set; } = null;
}
