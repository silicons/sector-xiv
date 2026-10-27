namespace Content.Shared._Citadel.Worldgen.Engine;

/// <summary>
/// A request to generate a chunk of a world.
/// </summary>
public sealed class WorldgenRequest
{
    public WorldgenRequest(WorldgenRequestBuilder builder)
    {
        ArgumentNullException.ThrowIfNull(builder);
        ArgumentNullException.ThrowIfNull(builder.Config);

        Seed = builder.Seed;
        Config = builder.Config;
        LowerLeftX = builder.LowerLeftX;
        LowerLeftY = builder.LowerLeftY;
        UpperRightX = builder.UpperRightX;
        UpperRightY = builder.UpperRightY;
    }

    /// <summary>
    /// The seed to use.
    /// </summary>
    public WorldgenSeed Seed { get; }

    /// <summary>
    /// The configuration to use.
    /// </summary>
    public WorldgenConfig Config { get; }

    public int LowerLeftX { get; }
    public int LowerLeftY { get; }
    public int UpperRightX { get; }
    public int UpperRightY { get; }

    public int Width => UpperRightX - LowerLeftX;
    public int Height => UpperRightY - LowerLeftY;
}
