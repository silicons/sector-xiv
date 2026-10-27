using Robust.Shared.Prototypes;
using Robust.Shared.Utility;

namespace Content.Shared._Citadel.Worldgen.GridStructures;

/// <summary>
/// This is a prototype for...
/// </summary>
[Prototype]
public sealed partial class GridStructurePackPrototype : IPrototype
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
