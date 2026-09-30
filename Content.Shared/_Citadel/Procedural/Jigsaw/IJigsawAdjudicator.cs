using Content.Shared._Citadel.DSA.Jigsaw2D;

namespace Content.Shared._Citadel.Procedural.Jigsaw;

/// <summary>
/// Decides whether two tiles can be next to each other.
/// This is separate from IJigsawSolver so that placement rules and behaviors
/// may be different from the actual solver strategy.
/// </summary>
/// <typeparam name="TTileData"></typeparam>
/// <typeparam name="TPieceData"></typeparam>
/// <typeparam name="TEdgeData"></typeparam>
public interface IJigsawAdjudicator<TPieceData, TTileData, TEdgeData>
    where TPieceData : struct
    where TTileData : struct
    where TEdgeData : struct
{
    /// <summary>
    /// Checks if two jigsaw edges may join each other naturally.
    /// Join is defined by being directly adjacent to that side.
    /// Implies CanEdgeTouch.
    /// </summary>
    /// <param name="alpha"></param>
    /// <param name="beta"></param>
    /// <returns></returns>
    bool CanEdgeJoin(JigsawEdge<TEdgeData> alpha, JigsawEdge<TEdgeData> beta);

    /// <summary>
    /// Check if two jigsaw edges may touch at all.
    /// </summary>
    /// <param name="alpha"></param>
    /// <param name="beta"></param>
    /// <returns></returns>
    bool CanEdgeTouch(JigsawEdge<TEdgeData> alpha, JigsawEdge<TEdgeData> beta);
}
