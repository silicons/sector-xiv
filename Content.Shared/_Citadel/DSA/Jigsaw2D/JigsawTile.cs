namespace Content.Shared._Citadel.DSA.Jigsaw2D;

/// <summary>
/// A single tile of a jigsaw puzzle. Stores data on whether it can
/// join to other tiles.
/// <br />
/// <br />
/// Tiles are internally assuming they are facing NORTH.
/// <br />
/// Edges are laid out that way.
/// </summary>
public sealed class JigsawTile<TTileData, TEdgeData> : ICloneable
    where TTileData : struct
    where TEdgeData : struct
{
    public TTileData Data;

    public JigsawEdge<TEdgeData> North = new();
    public JigsawEdge<TEdgeData> East = new();
    public JigsawEdge<TEdgeData> South = new();
    public JigsawEdge<TEdgeData> West = new();

    /// <summary>
    /// Clones the tile and each edge, copying their data by value.
    /// Reference fields inside data structs remain shared.
    /// </summary>
    public JigsawTile<TTileData, TEdgeData> Clone()
    {
        return new JigsawTile<TTileData, TEdgeData>
        {
            Data = Data,
            North = North.Clone(),
            East = East.Clone(),
            South = South.Clone(),
            West = West.Clone(),
        };
    }

    object ICloneable.Clone() => Clone();

    /// <summary>
    /// Gets an edge in the tile's natural (North-facing) orientation.
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
    /// Gets the edge facing the requested direction after rotating the tile clockwise to tileOrientation.
    /// </summary>
    public JigsawEdge<TEdgeData> GetRelativeEdge(
        JigsawOrientation orientation,
        JigsawOrientation tileOrientation)
    {
        // Convert directions to clockwise quarter turns; enum flags are not in rotation order.
        var direction = QuarterTurns(orientation);
        var rotation = QuarterTurns(tileOrientation);
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
}
