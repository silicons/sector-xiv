namespace Content.Shared._Citadel.Sector.Biome;

/// <summary>
/// A map of biomes. These always have a width and a height, and a resolution.
/// </summary>
public sealed class BiomeMap(int width, int height, int resolution)
{
    public static readonly int DefaultResolution = 8;

    private BiomeMapNode[] _biomes = new BiomeMapNode[width * height];

    public int Width { get; } = width;
    public int Height { get; } = height;
    public int Resolution { get; } = resolution;

    public ref BiomeMapNode GetNode(int x, int y)
    {
        if (!InBounds(x, y))
        {
            throw new ArgumentOutOfRangeException(
                $"Coordinates {x}, {y} are out of bounds for biome map of size {Width}x{Height}.");
        }

        return ref _biomes[Index(x, y)];
    }

    private int Index(int x, int y)
    {
        return y * Width + x;
    }

    public bool InBounds(int x, int y)
    {
        return x >= 0 && x < Width && y >= 0 && y < Height;
    }
}
