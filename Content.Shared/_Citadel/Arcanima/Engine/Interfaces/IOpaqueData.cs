namespace Content.Shared._Citadel.Arcanima.Engine.Interfaces;

/// <summary>
/// Opaque payloads must support copying and reporting their memory usage.
/// </summary>
public interface IOpaqueData : IMemoryCopyable, IMemoryMeasurable
{
}
