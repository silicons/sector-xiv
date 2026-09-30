namespace Content.Shared._Citadel.DSA.Jigsaw2D;

/// <summary>
/// A tile that's in a buffer.
/// Edge orientation will be automatically fitted to the buffer & the current orientation.
/// </summary>
public sealed class JigsawBufferTile<TPieceData, TTileData, TEdgeData> where TPieceData : struct
    where TTileData : struct
    where TEdgeData : struct
{
    public TTileData Data;

    public JigsawBufferPlacement<TPieceData, TTileData, TEdgeData>? Placement;

    /**
     * The weight of this tile as a hint to solvers.
     *
     * The higher it is, the more prioritized it is to be joined first.
     *
     * Tiles that are more picky generally be more weighty, because
     * otherwise, less picky tiles (and their edges) may get 'first pick' and choke them out.
     */
    public int Weight = 0;

    /// <summary>
    /// Constructs a buffer tile.
    /// </summary>
    /// <param name="placement">The piece being placed.</param>
    /// <param name="jigsawTile">The tile on the piece</param>
    /// <param name="jigsawOrientation">Orientation. This will automatically handle rotation of edge data.</param>
    /// <param name="x">X on the buffer this is being placed on</param>
    /// <param name="y">Y on the buffer this is being placed on</param>
    internal JigsawBufferTile(JigsawBufferPlacement<TPieceData, TTileData, TEdgeData> placement,
        JigsawTile<TTileData, TEdgeData> jigsawTile,
        JigsawOrientation jigsawOrientation,
        int x,
        int y)
    {
        X = x;
        Y = y;
        Placement = placement;
#warning impl
    }

    /// <summary>
    /// Placed X
    /// </summary>
    public int X { get; }

    /// <summary>
    /// Placed Y
    /// </summary>
    public int Y { get; }

    // @formatter:off
    public JigsawEdge<TEdgeData> North;
    public JigsawEdge<TEdgeData> East;
    public JigsawEdge<TEdgeData> South;
    public JigsawEdge<TEdgeData> West;
    // @formatter:on
}
