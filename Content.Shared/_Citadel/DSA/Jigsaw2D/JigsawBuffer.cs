using System.Collections.Immutable;

namespace Content.Shared._Citadel.DSA.Jigsaw2D;

/// <summary>
/// A buffer to place jigsaw pieces on.
/// <br />
/// To be intuitive to humans, indices internally are north = ++y, south = --y, east = ++x, west = --x
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

    private int index(int x, int y)
    {
        return x + y * Width;
    }

    private bool inBounds(int x, int y)
    {
        return x >= 0 && x < Width && y >= 0 && y < Height;
    }
}
