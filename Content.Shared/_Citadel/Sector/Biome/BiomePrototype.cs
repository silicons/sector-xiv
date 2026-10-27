using Content.Shared._Citadel.Prototypes;
using Robust.Shared.Prototypes;

namespace Content.Shared._Citadel.Sector.Biome;

/// <summary>
/// A biome of a world.
/// <br />
/// <br />
/// Despite being called a biome, this is not necessarily planet-only.
/// </summary>
[Prototype]
[CitadelPrototype]
public sealed class BiomePrototype : ICitadelPrototype
{
    /// <inheritdoc />
    [IdDataField]
    public string ID { get; } = default!;
}
