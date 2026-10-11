namespace Content.Shared._Citadel.Arcanima.Engine.Interfaces;

/// <summary>
/// Interface for objects that can report their memory usage in terms of memory units.
/// </summary>
public interface IMemoryMeasurable
{
    /// <summary>
    /// Returns the number of memory units this object occupies.
    /// </summary>
    ulong GetMemoryUnits();
}
