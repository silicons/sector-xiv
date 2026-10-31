using System.Collections.Immutable;

namespace Content.Shared._Citadel.DSA.Jigsaw2D;

/// <summary>
/// A buffer to place jigsaw pieces on.
/// <br />
/// <br />
/// To be intuitive to humans, indices internally are north = ++y, south = --y, east = ++x, west = --x
/// <br />
/// This means the JigsawBuffer - and its contents - are always
/// facing NORTH, regardless of the orientation of the pieces placed on it.
/// </summary>
/// <typeparam name="TPieceData">
/// Data stored on placed pieces.
/// </typeparam>
/// <typeparam name="TTileData">
/// Data stored on tiles.
/// </typeparam>
/// <typeparam name="TEdgeData">Data stored on tile edges</typeparam>
public sealed class JigsawBuffer<TPieceData, TTileData, TEdgeData>
    where TPieceData : struct
    where TTileData : struct
    where TEdgeData : struct
{
    private static JigsawBufferTile<TPieceData, TTileData, TEdgeData>? _nullTile;
    private readonly List<JigsawBufferPlacement<TPieceData, TTileData, TEdgeData>> _placed;
    private JigsawBufferTile<TPieceData, TTileData, TEdgeData>?[] _tiles;

    /// <summary>
    /// Constructs a buffer with a given size.
    /// </summary>
    /// <param name="width"></param>
    /// <param name="height"></param>
    /// <typeparam name="TTileData">
    /// Data stored on tiles.
    /// </typeparam>
    /// <typeparam name="TPieceData">
    /// Data stored on placed pieces.
    /// </typeparam>
    public JigsawBuffer(int width, int height)
    {
        Width = width;
        Height = height;

        _placed = [];
        _tiles = new JigsawBufferTile<TPieceData, TTileData, TEdgeData>?[width * height];
    }

    public int Width { get; }

    public int Height { get; }

    public ImmutableList<JigsawBufferPlacement<TPieceData, TTileData, TEdgeData>> Placed => _placed.ToImmutableList();

    public ref JigsawBufferTile<TPieceData, TTileData, TEdgeData>? GetTile(int x, int y)
    {
        if (!inBounds(x, y))
            return ref _nullTile;

        return ref _tiles[index(x, y)];
    }

    /// <summary>
    /// Enumerates every cell, including empty cells, from bottom to top in the requested orientation.
    /// <br />
    /// <ul>
    /// <li>Starts at (0, 0), scans left to right with increasing X, then advances to Y = 1, and so on.</li>
    /// <li>Non-North orientations scan as if the buffer were already rotated clockwise:
    /// East = 90 degrees, South = 180 degrees, West = 270 degrees.</li>
    /// <li>Returned X/Y coordinates belong to the rotated buffer, with (0, 0) at its bottom-left corner.</li>
    /// <li>East and West swap the buffer's width and height.</li>
    /// <li>Views capture the original tile references and resolve rotated edges on demand.</li>
    /// <li>Stored tiles and edges remain North-facing.</li>
    /// </ul>
    /// <br />
    /// Each row is completed before advancing to the next row above it, regardless of orientation.
    /// </summary>
    /// <exception cref="ArgumentOutOfRangeException">The orientation is not a single cardinal direction.</exception>
    public IEnumerable<(int X, int Y, JigsawBufferTileView<TPieceData, TTileData, TEdgeData> Tile)> EnumerateTiles(
        JigsawOrientation orientation = JigsawOrientation.North)
    {
        // Source coordinates at the first cell, then offsets along each output row and column.
        var (startX, startY, endX, endY, columnX, columnY, rowX, rowY) = orientation switch
        {
            JigsawOrientation.North => (0, 0, Width, Height, 1, 0, 0, 1),
            JigsawOrientation.East => (Width - 1, 0, Height, Width, 0, 1, -1, 0),
            JigsawOrientation.South => (Width - 1, Height - 1, Width, Height, -1, 0, 0, -1),
            JigsawOrientation.West => (0, Height - 1, Height, Width, 0, -1, 1, 0),
            _ => throw new ArgumentOutOfRangeException(),
        };

        for (var y = 0; y < endY; y++, startX += rowX, startY += rowY)
        {
            var sourceX = startX;
            var sourceY = startY;
            for (var x = 0; x < endX; x++, sourceX += columnX, sourceY += columnY)
            {
                yield return (x, y, new JigsawBufferTileView<TPieceData, TTileData, TEdgeData>(_tiles[index(sourceX, sourceY)], orientation));
            }
        }
    }

    private int index(int x, int y)
    {
        return x + y * Width;
    }

    private bool inBounds(int x, int y)
    {
        return x >= 0 && x < Width && y >= 0 && y < Height;
    }
}
