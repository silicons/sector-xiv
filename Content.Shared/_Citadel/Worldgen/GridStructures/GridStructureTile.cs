namespace Content.Shared._Citadel.Worldgen.GridStructures;

[DataDefinition]
public sealed partial class GridStructureTile
{
    /// <summary>
    /// Weight of the tile. Higher weight tiles will be matched for first.
    /// </summary>
    [DataField("weight")]
    public int Weight { get; internal set; }

    [DataField("north")]
    public GridStructureEdge North { get; internal set; } = new();

    [DataField("south")]
    public GridStructureEdge South { get; internal set; } = new();

    [DataField("east")]
    public GridStructureEdge East { get; internal set; } = new();

    [DataField("west")]
    public GridStructureEdge West { get; internal set; } = new();
}
