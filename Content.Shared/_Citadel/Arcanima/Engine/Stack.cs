namespace Content.Shared._Citadel.Arcanima.Engine;

/**
 * A stack of VM values with indexed access.
 */
public sealed class Stack : ICloneable
{
    private ValueRef[] _values = Array.Empty<ValueRef>();

    public int Size { get; private set; }

    public object Clone()
    {
        var clone = new Stack();
        for (var i = 0; i < Size; i++)
        {
            clone.Push(_values[i].Copy());
        }

        return clone;
    }

    /// <summary>
    /// Pushes a ValueRef without copying its underlying value.
    /// Use Copy() when an independent value is required.
    /// </summary>
    /// <param name="value"></param>
    public void Push(ValueRef value)
    {
        if (Size == _values.Length)
            Array.Resize(ref _values, _values.Length == 0 ? 4 : _values.Length * 2);

        _values[Size++] = value;
    }

    public ValueRef Pop()
    {
        var value = Peek();
        _values[--Size] = default;
        return value;
    }

    public void Pop(int count)
    {
        if (count < 0 || count > Size)
            throw new ArgumentOutOfRangeException(nameof(count));

        var first = Size - count;
        Array.Clear(_values, first, count);
        Size = first;
    }

    public ValueRef Peek()
    {
        if (Size == 0)
            throw new InvalidOperationException("The stack is empty.");

        return _values[Size - 1];
    }

    /// <summary>Tries to return a value at a zero-based index from the top.</summary>
    public bool TryPeekFromTop(int index, out ValueRef value)
    {
        if (index < 0 || index >= Size)
        {
            value = default;
            return false;
        }

        value = _values[Size - 1 - index];
        return true;
    }

    /// <summary>Tries to return a value at a zero-based index from the bottom.</summary>
    public bool TryPeek(int index, out ValueRef value)
    {
        if (index < 0 || index >= Size)
        {
            value = default;
            return false;
        }

        value = _values[index];
        return true;
    }

    public void Clear()
    {
        Array.Clear(_values, 0, Size);
        Size = 0;
    }
}
