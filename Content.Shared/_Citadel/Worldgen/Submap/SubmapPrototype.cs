using Content.Shared._Citadel.Prototypes;
using Robust.Shared.Prototypes;
using Robust.Shared.Utility;

namespace Content.Shared._Citadel.Worldgen.Submap;

/// <summary>
/// A submap to be spawned.
/// <br />
/// <br />
/// There should be one or more grids aligned to the master grid of the map.
/// The 0, 0 origin point.
/// <br />
/// <br />
/// Everything on it will be aligned as 0, 0 as the center.
/// When things are rotated they're rotated around the origin.
/// <br />
/// <br />
/// The token gets aligned on that.
/// </summary>
[Prototype]
[CitadelPrototype]
public sealed partial class SubmapPrototype : ICitadelPrototype
{
    /// <summary>
    /// The path of the map file with the pieces.
    /// </summary>
    [DataField("path", required: true)]
    public ResPath Path { get; private set; }

    /// <inheritdoc />
    [IdDataField]
    public string ID { get; private set; } = default!;
}
