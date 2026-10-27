using Content.Shared._Citadel.Signal.Prototypes;

namespace Content.Shared._Citadel.Signal.Simulation;

/// <summary>
/// An active, registered signal.
/// </summary>
public sealed class SignalBeacon
{
    private SignalMap? _map;
    private SignalBeaconParams? _params;
    private SignalTypePrototype? _type;
}
