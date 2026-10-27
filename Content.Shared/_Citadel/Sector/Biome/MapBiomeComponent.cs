using Robust.Shared.Serialization;

namespace Content.Shared._Citadel.Sector.Biome;

/// <summary>
/// This is used for...
/// </summary>
public abstract partial class MapBiomeComponent : Component
{
    
}

/// <summary>
/// Contains network state for MapBiomeComponent.
/// </summary>
[Serializable, NetSerializable]
public sealed class MapBiomeComponentState : ComponentState
{
    public MapBiomeComponentState(MapBiomeComponent component)
    {

    }
}
