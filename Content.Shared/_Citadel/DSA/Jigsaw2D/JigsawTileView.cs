namespace Content.Shared._Citadel.DSA.Jigsaw2D;

/// <summary>
/// An oriented view of a tile.
/// Captures the tile reference at enumeration time;
/// replacing the pattern cell does not change an existing view.
/// </summary>
public readonly struct JigsawTileView<TTileData, TEdgeData>(
    JigsawTile<TTileData, TEdgeData>? tile,
    JigsawOrientation orientation)
    where TTileData : struct
    where TEdgeData : struct
{
    /// <summary>
    /// The raw tile.
    /// <br />
    /// <br />
    /// It's recommended to not use this and use GetData and GetEdge instead.
    /// </summary>
    public JigsawTile<TTileData, TEdgeData>? RawTile { get; } = tile;

    /// <summary>
    /// The orientation the tile has been rotated to
    /// (same orientation as the enumeration)
    /// </summary>
    public JigsawOrientation Orientation { get; } = orientation;

    public bool HasTile => Tile != null;

    /// <summary>
    /// Gets a reference to the tile's struct data without copying it.
    /// </summary>
    /// <exception cref="InvalidOperationException">The view is empty.</exception>
    public ref TTileData GetData()
    {
        if (Tile == null)
            throw new InvalidOperationException("Cannot get data from an empty view.");

        return ref Tile.Data;
    }

    /// <summary>
    /// Gets the edge facing the requested direction, or null for an empty view.
    /// Edge data can be accessed by reference through the returned object's Data field.
    /// </summary>
    public JigsawEdge<TEdgeData>? GetEdge(JigsawOrientation orientation)
    {
        return Tile?.GetRelativeEdge(orientation, Orientation);
    }
}
