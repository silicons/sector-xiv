namespace Content.Shared._Citadel.Worldgen.GridStructures;

/// <summary>
/// A tile of a grid structure.
/// <br />
/// These are placed on Grids to allow them to partake in grid structure matching.
/// <br />
/// Please do not manually place these; these are meant to be placed on the preset components.
/// </summary>
[RegisterComponent]
public sealed partial class GridStructureTileComponent : Component
{
    /// <summary>
    /// Grid alignment of the component.
    /// </summary>
    [DataField("alignment")]
    public int Alignment { get; private set; }

    /// <summary>
    /// Weight of the tile. Higher weight tiles will be matched for first.
    /// </summary>
    [DataField("weight")]
    public int Weight { get; private set; }

    [DataField("north")]
    public GridStructureEdge North { get; private set; }

    [DataField("south")]
    public GridStructureEdge South { get; private set; }

    [DataField("east")]
    public GridStructureEdge East { get; private set; }

    [DataField("west")]
    public GridStructureEdge West { get; private set; }
}
