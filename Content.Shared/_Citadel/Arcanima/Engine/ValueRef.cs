namespace Content.Shared._Citadel.Arcanima.Engine;

/// <summary>
/// Wraps the VM's values so their class representation can be replaced with a discriminated union later.
/// <br />
/// <br />
/// This is called 'Ref' to make it explicit that copying this won't copy the value.
/// </summary>
public readonly struct ValueRef
{
    private readonly ValueBase _data;

    public ValueRef(ValueBase data)
    {
        _data = data;
    }

    public readonly bool Is<T>() where T : ValueBase
    {
        return _data is T;
    }

    public readonly bool GetIf<T>(out T? value) where T : ValueBase
    {
        if (_data is T t)
        {
            value = t;
            return true;
        }

        value = null;
        return false;
    }

    /// <summary>
    /// Gets a copy of this ValueRef, whatever type it is.
    /// </summary>
    /// <returns></returns>
    public ValueRef Copy()
    {
        return new ValueRef(_data.Copy());
    }

    public ulong GetMemoryUnits()
    {
        return _data.GetMemoryUnits();
    }
}
