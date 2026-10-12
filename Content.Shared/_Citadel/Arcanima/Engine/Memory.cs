namespace Content.Shared._Citadel.Arcanima.Engine;

/**
 * Memory stores values keyed by Identifier references.
 * Reads and writes copy values so stack results cannot overwrite stored data.
 */
public sealed class Memory
{
    private readonly Dictionary<Identifier, ValueRef> _values = new();

    /// <summary>
    /// Returns an independent copy of the value at the identifier.
    /// </summary>
    public bool TryGetValueCopy(Identifier id, out ValueRef value)
    {
        if (_values.TryGetValue(id, out var stored))
        {
            value = stored.Copy();
            return true;
        }

        value = default;
        return false;
    }

    /// <summary>
    /// Stores an independent copy, replacing any value already at the identifier.
    /// </summary>
    public void StoreValueCopy(Identifier id, ValueRef value)
    {
        _values[id] = value.Copy();
    }
}
