namespace Content.Shared._Citadel.Worldgen.Engine;

/// <summary>
/// Builds an immutable request to generate a chunk of a world.
/// </summary>
public sealed class WorldgenRequestBuilder
{
    /// <summary>
    /// The seed to use.
    /// </summary>
    public WorldgenSeed Seed { get; set; }

    /// <summary>
    /// The configuration to use.
    /// </summary>
    public required WorldgenConfig Config { get; set; }

    public int LowerLeftX { get; set; }
    public int LowerLeftY { get; set; }
    public int UpperRightX { get; set; }
    public int UpperRightY { get; set; }

    /// <summary>
    /// Creates a request using the current builder values.
    /// </summary>
    public WorldgenRequest Build()
    {
        return new WorldgenRequest(this);
    }
}
