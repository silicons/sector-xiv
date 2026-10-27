namespace Content.Shared._Citadel.Worldgen.GridStructures;

[DataDefinition]
public sealed partial class GridStructureEdge
{
    /// <summary>
    /// Weight of the edge. Higher weight edges will be matched for first.
    /// </summary>
    [DataField("weight")]
    public int Weight { get; private set; }

    /// <summary>
    /// Bitmask this edge counts as.
    /// </summary>
    [DataField("match")]
    public ulong Match { get; private set; }

    /// <summary>
    /// Bitmask this edge requires to be present on the other side.
    /// </summary>
    [DataField("require")]
    public ulong Require { get; private set; }

    /// <summary>
    /// Bitmask this edge forbids to be present on the other side.
    /// </summary>
    [DataField("forbid")]
    public ulong Forbid { get; private set; }
}
