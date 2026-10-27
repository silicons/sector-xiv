using Robust.Shared.Serialization;

namespace Content.Shared._Citadel.Signal.Components;

/// <summary>
/// This is used for...
/// </summary>
public abstract partial class SignalBeaconComponent : Component
{
}

/// <summary>
/// Contains network state for SignalBeaconComponent.
/// </summary>
[Serializable] [NetSerializable]
public sealed class SignalBeaconComponentState : ComponentState
{
    public SignalBeaconComponentState(SignalBeaconComponent beaconComponent)
    {
    }
}
