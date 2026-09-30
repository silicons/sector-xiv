using System.Collections.Immutable;

namespace Content.Shared._Citadel.DSA.Jigsaw2D;

public sealed class JigsawBufferPlacement<TPieceData, TTileData, TEdgeData>
    where TPieceData : struct
    where TTileData : struct
    where TEdgeData : struct
{
    internal JigsawBufferPlacement(JigsawPiece<TPieceData, TTileData, TEdgeData> jigsawPiece,
        IEnumerable<JigsawBufferTile<TPieceData, TTileData, TEdgeData>> tiles,
        JigsawOrientation direction,
        int lowerLeftX,
        int lowerLeftY)
    {
        JigsawPiece = jigsawPiece;
        Tiles = tiles.ToImmutableList();
        Direction = direction;
        LowerLeftX = lowerLeftX;
        LowerLeftY = lowerLeftY;
    }

    public JigsawPiece<TPieceData, TTileData, TEdgeData> JigsawPiece { get; }
    public ImmutableList<JigsawBufferTile<TPieceData, TTileData, TEdgeData>> Tiles { get; }
    public JigsawOrientation Direction { get; }

    public int LowerLeftX { get; }
    public int LowerLeftY { get; }
}
