namespace Content.Shared._Citadel.DSA.Jigsaw2D;

/// <summary>
/// A single piece of a jigsaw puzzle.
/// <br />
/// Pieces may be arbitrarily rotated while placed.
/// <br />
/// Pieces will be rotated clockwise if non-NORTH.
/// </summary>
/// <param name="jigsawPattern"></param>
/// <typeparam name="TPieceData"></typeparam>
/// <typeparam name="TTileData"></typeparam>
/// <typeparam name="TEdgeData"></typeparam>
public sealed class JigsawPiece<TPieceData, TTileData, TEdgeData>(JigsawPattern<TTileData, TEdgeData> jigsawPattern)
    : ICloneable
    where TPieceData : struct
    where TTileData : struct
    where TEdgeData : struct
{
    public readonly JigsawPattern<TTileData, TEdgeData> JigsawPattern =
        jigsawPattern.Clone() as JigsawPattern<TTileData, TEdgeData> ??
        throw new InvalidOperationException("Null pattern in JigsawPiece constructor.");

    public TPieceData Data;

    public object Clone()
    {
#warning impl
        throw new NotImplementedException();
    }
}
