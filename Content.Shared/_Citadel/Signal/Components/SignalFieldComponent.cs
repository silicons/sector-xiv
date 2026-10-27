using Robust.Shared.Serialization;

namespace Content.Shared._Citadel.Signal.Components;

/// <summary>
/// This is used for...
/// </summary>
public abstract partial class SignalFieldComponent : Component
{
}

/// <summary>
/// Contains network state for SignalFieldComponent.
/// </summary>
[Serializable] [NetSerializable]
public sealed class SignalFieldComponentState : ComponentState
{
    public SignalFieldComponentState(SignalFieldComponent component)
    {
    }
}
