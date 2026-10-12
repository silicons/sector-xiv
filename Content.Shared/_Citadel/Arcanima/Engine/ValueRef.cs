namespace Content.Shared._Citadel.Arcanima.Engine;

/// <summary>
/// Wraps a VM value in a storage cell. Struct copies refer to the same cell;
/// Copy() creates an independent cell and value snapshot.
/// </summary>
public readonly struct ValueRef
{
    private readonly ValueCell _cell;

    public ValueRef(ValueBase data)
    {
        _cell = new ValueCell(data);
    }

    private ValueBase Data => _cell.Data;

    public bool Is<T>() where T : ValueBase
    {
        return Data is T;
    }

    public bool GetIf<T>(out T? value) where T : ValueBase
    {
        if (Data is T t)
        {
            value = t;
            return true;
        }

        value = null;
        return false;
    }

    public void Get<T>(out T value) where T : ValueBase
    {
        // May throw InvalidCastException.
        value = (T)Data;
    }

    public T GetRef<T>() where T : ValueBase
    {
        if (Data is T casted)
            return casted;
        throw new InvalidOperationException($"ValueRef is not of type {typeof(T).Name}");
    }

    public T? GetMaybeRef<T>() where T : ValueBase
    {
        return Data as T;
    }

    /// <summary>
    /// Creates an independent ValueRef containing a copy of the current value.
    /// </summary>
    public ValueRef Copy()
    {
        return new ValueRef(Data.Copy());
    }

    public ulong GetMemoryUnits()
    {
        return Data.GetMemoryUnits();
    }
}
