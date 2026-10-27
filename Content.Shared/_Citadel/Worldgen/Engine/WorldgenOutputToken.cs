namespace Content.Shared._Citadel.Worldgen.Engine;

public struct WorldgenOutputToken
{
    /// <summary>
    /// The X coordinate of the token.
    /// <br />
    /// <br />
    /// This is generally considered as centered.
    /// </summary>
    public float X;

    /// <summary>
    /// The Y coordinate of the token.
    /// <br />
    /// <br />
    /// This is generally considered as centered.
    /// </summary>
    public float Y;

    /// <summary>
    /// The token itself.
    /// </summary>
    public WorldgenToken Token;
}
