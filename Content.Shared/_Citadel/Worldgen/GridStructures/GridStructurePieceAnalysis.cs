using System.Collections.Immutable;

namespace Content.Shared._Citadel.Worldgen.GridStructures;

/**
 * A single analyzed piece of a grid structure pack.
 *
 * These are what's actually fed to the generator.
 */
[DataDefinition]
public sealed partial class GridStructurePieceAnalysis
{
    public ImmutableList<GridStructurePiece> Pieces;
}
