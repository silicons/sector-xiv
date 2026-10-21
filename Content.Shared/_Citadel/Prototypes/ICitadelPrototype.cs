using Robust.Shared.Prototypes;

namespace Content.Shared._Citadel.Prototypes;

/// <summary>
/// Marker interface for all Citadel prototypes.
/// </summary>
public interface ICitadelPrototype : IPrototype
{
    CitadelPrototypeSync Sync { get; }
}
