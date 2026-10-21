namespace Content.Shared._Citadel.DSA.Jigsaw2D;

/// <summary>
/// A single piece of a jigsaw puzzle.
/// <br />
/// <br />
/// Pieces may be arbitrarily rotated while placed.
/// <br />
/// Pieces will be rotated clockwise if non-NORTH.
/// <br />
/// <br />
/// Pieces are immutable once created. You may breach this
/// immutability by having TPieceData, TTileData, TEdgeData hold
/// reference types, but this is at your own peril.
/// <br />
/// <br />
/// The Jigsaw2D system will automatically value-wise-clone
/// all data when placing pieces.
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
#warning JigsawPiece.Clone is not implemented.
        throw new NotImplementedException();
    }
}
