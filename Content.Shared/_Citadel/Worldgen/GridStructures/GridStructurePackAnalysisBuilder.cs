using System.Collections.Immutable;

namespace Content.Shared._Citadel.Worldgen.GridStructures;

public sealed class GridStructurePackAnalysisBuilder
{
    private string _hash = string.Empty;

    public List<GridStructurePieceAnalysis> Pieces { get; } = new();

    public GridStructurePackAnalysisBuilder WithHash(string hash)
    {
        _hash = hash;
        return this;
    }

    public GridStructurePackAnalysisBuilder WithPieces(ImmutableList<GridStructurePieceAnalysis> pieces)
    {
        Pieces.Clear();
        Pieces.AddRange(pieces);
        return this;
    }

    public GridStructurePackAnalysisBuilder AddPiece(GridStructurePieceAnalysis piece)
    {
        Pieces.Add(piece);
        return this;
    }

    public GridStructurePackAnalysis Build()
    {
        return new GridStructurePackAnalysis
        {
            Hash = _hash,
            Pieces = [.. Pieces],
        };
    }
}
