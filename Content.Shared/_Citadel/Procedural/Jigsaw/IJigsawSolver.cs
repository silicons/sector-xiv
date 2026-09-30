using Content.Shared._Citadel.DSA.Jigsaw2D;

namespace Content.Shared._Citadel.Procedural.Jigsaw;

/// <summary>
/// Interface for solvers.
/// Solvers are less restrained than adjudicators, and may be stateful.
/// </summary>
public interface IJigsawSolver<TSolverParams, TPieceData, TTileData, TEdgeData>
    where TPieceData : struct
    where TTileData : struct
    where TEdgeData : struct
{
    /// <summary>
    /// Attempts to place a single piece.
    /// This is often far less optimized than placing multiple pieces.
    /// </summary>
    /// <param name="jigsawBuffer"></param>
    /// <param name="jigsawPiece"></param>
    /// <param name="solverParams"></param>
    /// <returns></returns>
    JigsawBufferPlacement<TPieceData, TTileData, TEdgeData> PlaceStandalonePiece(
        JigsawBuffer<TPieceData, TTileData, TEdgeData> jigsawBuffer,
        JigsawPiece<TPieceData, TTileData, TEdgeData> jigsawPiece,
        TSolverParams solverParams);
}
