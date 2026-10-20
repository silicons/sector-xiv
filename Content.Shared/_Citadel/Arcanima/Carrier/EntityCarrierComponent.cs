using Robust.Shared.Serialization;

namespace Content.Shared._Citadel.Arcanima.Carrier;

/// <summary>
/// This is used for...
/// </summary>
public abstract partial class EntityCarrierComponent : Component
{
}

/// <summary>
/// Contains network state for EntityCarrier.
/// </summary>
[Serializable] [NetSerializable]
public sealed class EntityCarrierState : ComponentState
{
    public EntityCarrierState(EntityCarrierComponent component)
    {
#warning EntityCarrierState population is not implemented.
    }
}
