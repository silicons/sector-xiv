namespace Content.Shared._Citadel.Arcanima.Engine;

/**
 * A stack of memory values.
 * <br />
 * <br />
 * This is the core execution context for a Carrier.
 * <br />
 * Internally, this supports indexed access.
 */
public sealed class Stack : ICloneable
{
    private readonly List<MemoryValue> _values = new();

    public int Size => _values.Count;

    public object Clone()
    {
        var clone = new Stack();
        foreach (var value in _values)
        {
            clone.Push((MemoryValue)value.Clone());
        }

        return clone;
    }

    public void Push(MemoryValue value)
    {
        _values.Add(value);
    }

    public MemoryValue Pop()
    {
        var value = Peek();
        _values.RemoveAt(_values.Count - 1);
        return value;
    }

    public MemoryValue Peek()
    {
        if (_values.Count == 0)
            throw new InvalidOperationException("The stack is empty.");

        return _values[^1];
    }

    /// <summary>Returns the value at a zero-based index from the top.</summary>
    public MemoryValue PeekFromTop(int index)
    {
        if (index < 0 || index >= _values.Count)
            throw new ArgumentOutOfRangeException(nameof(index));

        return _values[_values.Count - 1 - index];
    }

    /// <summary>Returns the value at a zero-based index from the bottom.</summary>
    public MemoryValue PeekFromBottom(int index)
    {
        if (index < 0 || index >= _values.Count)
            throw new ArgumentOutOfRangeException(nameof(index));

        return _values[index];
    }

    public void Clear()
    {
        _values.Clear();
    }
}
