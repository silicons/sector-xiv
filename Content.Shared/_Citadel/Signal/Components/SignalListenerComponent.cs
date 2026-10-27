using Robust.Shared.Serialization;

namespace Content.Shared._Citadel.Signal.Components;

/// <summary>
/// This is used for...
/// </summary>
public abstract partial class SignalListenerComponent : Component
{
    
}

/// <summary>
/// Contains network state for SignalListenerComponent.
/// </summary>
[Serializable, NetSerializable]
public sealed class SignalListenerComponentState : ComponentState
{
    public SignalListenerComponentState(SignalListenerComponent component)
    {

    }
}
