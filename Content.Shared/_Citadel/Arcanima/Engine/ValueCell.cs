namespace Content.Shared._Citadel.Arcanima.Engine;

/// <summary>
/// Managed storage backend for ValueRef. Each owned value has one cell; aliases reuse it.
/// Only ValueRef accesses this type, keeping glyphs independent of the storage backend.
/// A future native or unsafe backend can replace the handle implementation in ValueRef.
/// </summary>
internal sealed class ValueCell(ValueBase data)
{
    internal ValueBase Data = data;
}
