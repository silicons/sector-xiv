using System.Collections.Immutable;

namespace Content.Shared._Citadel.Worldgen.GridStructures;

/// <summary>
/// Cached analysis of a grid structure pack.
/// </summary>
[DataDefinition]
public sealed partial class GridStructurePackAnalysis
{
    /// <summary>
    /// SHA1 of the analyzed map.
    /// <br />
    /// <br />
    /// This is used to determine if the map has changed since the last analysis.
    /// </summary>
    [DataField("hash")]
    public string Hash { get; internal set; }

    [DataField("pieces")]
    public ImmutableList<GridStructurePieceAnalysis> Pieces { get; internal set; }
}
