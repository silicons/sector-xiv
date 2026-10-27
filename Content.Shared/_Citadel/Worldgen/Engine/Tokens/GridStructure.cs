namespace Content.Shared._Citadel.Worldgen.Engine.Tokens;

public sealed class GridStructureTokenBuilder
{
    {
#warning impl
    }
}

/// <summary>
/// A grid structure to be placed on the map.
/// <br />
/// <br />
/// It will be placed centered on the token.
/// </summary>
public sealed class GridStructureToken(GridStructureTokenBuilder builder) : WorldgenToken
{
    /// <summary>
    /// Fuse the token to the global map grid.
    /// </summary>
    public bool FuseToMapGrid { get; }
}
