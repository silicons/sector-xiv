namespace Content.Shared._Citadel.DSA.Jigsaw2D;

/// <summary>
/// A holder pattern for tiles in a jigsaw piece.
/// <br />
/// To be intuitive to humans, indices internally are north = ++y, south = --y, east = ++x, west = --x
/// </summary>
/// <typeparam name="TTileData"></typeparam>
/// <typeparam name="TEdgeData"></typeparam>
public sealed class JigsawPattern<TTileData, TEdgeData> : ICloneable
    where TTileData : struct
    where TEdgeData : struct
{
    /// <summary>
    /// A null-ref that may be returned.
    /// </summary>
    private static JigsawTile<TTileData, TEdgeData>? _nullTile;

    /// <summary>
    /// Tiles list. Created and sized at init.
    /// <br />
    /// Row-major, index = (y * width) + x.
    /// Indices start from 0.
    /// </summary>
    private readonly JigsawTile<TTileData, TEdgeData>?[] _tiles;

    /// <summary>
    /// Creates a pattern with a given size.
    /// </summary>
    /// <param name="width"></param>
    /// <param name="height"></param>
    public JigsawPattern(int width, int height)
    {
        Width = width;
        Height = height;

        _tiles = new JigsawTile<TTileData, TEdgeData>?[width * height];
    }

    /// <summary>
    /// Copy constructor.
    /// </summary>
    /// <param name="clone"></param>
    private JigsawPattern(JigsawPattern<TTileData, TEdgeData> clone)
        : this(clone.Width, clone.Height)
    {
        for (var i = 0; i < clone._tiles.Length; i++)
        {
            _tiles[i] = clone._tiles[i];
        }
    }

    public int Width { get; }
    public int Height { get; }

    public object Clone()
    {
        return new JigsawPattern<TTileData, TEdgeData>(this);
    }

    public bool PlaceTile(JigsawTile<TTileData, TEdgeData> jigsawTile,
        int x,
        int y,
        out JigsawTile<TTileData, TEdgeData>? replaced)
    {
        if (!InBounds(x, y))
        {
            replaced = null;
            return false;
        }

        var index = IndexOf(x, y);
        replaced = _tiles[index];
        _tiles[index] = jigsawTile;
        return true;
    }

    public ref JigsawTile<TTileData, TEdgeData>? GetTile(int x, int y)
    {
        if (!InBounds(x, y))
            return ref _nullTile;
        return ref _tiles[IndexOf(x, y)];
    }

    /// <summary>
    /// Gets the index of a tile.
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    /// <returns></returns>
    private int IndexOf(int x, int y)
    {
        return y * Width + x;
    }

    private bool InBounds(int x, int y)
    {
        var index = IndexOf(x, y);
        return index >= 0 && index < _tiles.Length;
    }
}
