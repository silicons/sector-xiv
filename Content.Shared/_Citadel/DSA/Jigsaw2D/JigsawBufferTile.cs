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
    /// <param name="tile">The tile on the piece</param>
    /// <param name="orientation">Orientation. This will automatically handle rotation of edge data.</param>
    /// <param name="x">X on the buffer this is being placed on</param>
    /// <param name="y">Y on the buffer this is being placed on</param>
    internal JigsawBufferTile(JigsawBufferPlacement<TPieceData, TTileData, TEdgeData> placement,
        JigsawTile<TTileData, TEdgeData> tile,
        JigsawOrientation orientation,
        int x,
        int y)
    {
        X = x;
        Y = y;
        Placement = placement;
        Data = tile.Data;
        North = tile.GetRelativeEdge(JigsawOrientation.North, orientation).Clone();
        East = tile.GetRelativeEdge(JigsawOrientation.East, orientation).Clone();
        South = tile.GetRelativeEdge(JigsawOrientation.South, orientation).Clone();
        West = tile.GetRelativeEdge(JigsawOrientation.West, orientation).Clone();
    }

    /// <summary>
    /// Placed X
    /// </summary>
    public int X { get; }

    /// <summary>
    /// Placed Y
    /// </summary>
    public int Y { get; }

    /// <summary>
    /// Gets an edge in the buffer's stored North-facing orientation.
    /// </summary>
    public JigsawEdge<TEdgeData> GetAbsoluteEdge(JigsawOrientation orientation)
    {
        switch (orientation)
        {
            case JigsawOrientation.North:
                return North;
            case JigsawOrientation.East:
                return East;
            case JigsawOrientation.South:
                return South;
            case JigsawOrientation.West:
                return West;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }

    /// <summary>
    /// Gets the edge facing the requested direction after viewing the North-facing buffer clockwise at 'rotated'.
    /// </summary>
    public JigsawEdge<TEdgeData> GetRelativeEdge(
        JigsawOrientation orientation,
        JigsawOrientation rotated)
    {
        // Convert directions to clockwise quarter turns; enum flags are not in rotation order.
        var direction = QuarterTurns(orientation);
        var rotation = QuarterTurns(rotated);
        switch ((direction - rotation + 4) % 4)
        {
            case 0:
                return North;
            case 1:
                return East;
            case 2:
                return South;
            default:
                return West;
        }
    }

    private static int QuarterTurns(JigsawOrientation orientation)
    {
        return orientation switch
        {
            JigsawOrientation.North => 0,
            JigsawOrientation.East => 1,
            JigsawOrientation.South => 2,
            JigsawOrientation.West => 3,
            _ => throw new ArgumentOutOfRangeException(),
        };
    }

    // @formatter:off
    public JigsawEdge<TEdgeData> North;
    public JigsawEdge<TEdgeData> East;
    public JigsawEdge<TEdgeData> South;
    public JigsawEdge<TEdgeData> West;
    // @formatter:on
}
