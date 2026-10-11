namespace Content.Shared._Citadel.Arcanima.Engine.Interfaces;

/// <summary>
/// Interface for objects that can be copied when an Arcanima engine memory
/// reference is copied instead of referenced again.
/// <br />
/// <br />
/// Usually used for objects being held by an Opaque value.
/// </summary>
public interface IMemoryCopyable
{
    /// <summary>
    /// Returns the number of memory units this object occupies.
    /// </summary>
    object Copy();
}
