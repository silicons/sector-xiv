namespace Content.Shared._Citadel.Arcanima.Engine;

/// <summary>
/// A reference / handle to a mutable value cell.
/// <br />
/// <br />
/// Normal copies of this struct will alias; Copy() will make a new ValueRef
/// with a separate cell.
/// <br />
/// <br />
/// This unfortunately adds overhead, but confining storage access here
/// allows for us to replace the backend of Arcanima's memory system later without much fuss.
/// </summary>
public readonly struct ValueRef
{
    private readonly ValueCell _cell;

    /// <summary>
    /// Creates an owned value cell. Obtaining or copying a handle to it does not allocate.
    /// </summary>
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
    /// Replaces the cell's value. All aliases, including stack and memory handles, see the change.
    /// </summary>
    public void Store<T>(T value) where T : ValueBase
    {
        _cell.Data = value;
    }

    /// <summary>
    /// Creates an independent ValueRef and cell containing a copy of the current value.
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
