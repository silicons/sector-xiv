namespace Content.Shared._Citadel.Arcanima.Engine;

/// <summary>
/// Wraps the VM's values so their class representation can be replaced with a discriminated union later.
/// <br />
/// <br />
/// This is called 'Ref' to make it explicit that copying this won't copy the value.
/// </summary>
public readonly struct ValueRef(ValueBase data)
{
    public readonly bool Is<T>() where T : ValueBase
    {
        return data is T;
    }

    public readonly bool GetIf<T>(out T? value) where T : ValueBase
    {
        if (data is T t)
        {
            value = t;
            return true;
        }

        value = null;
        return false;
    }

    public T GetRef<T>() where T : ValueBase
    {
        if (data is T casted)
            return casted;
        throw new InvalidOperationException($"ValueRef is not of type {typeof(T).Name}");
    }

    public T? GetMaybeRef<T>() where T : ValueBase
    {
        return data as T;
    }

    /// <summary>
    /// Gets a copy of this ValueRef, whatever type it is.
    /// </summary>
    /// <returns></returns>
    public ValueRef Copy()
    {
        return new ValueRef(data.Copy());
    }

    public ulong GetMemoryUnits()
    {
        return data.GetMemoryUnits();
    }
}
