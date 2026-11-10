namespace Content.Shared._Citadel.Worldgen.Engine.Tokens;

/// <summary>
/// A small spot placement.
/// <br />
/// <br />
/// Generally used for small things like trees and whatnot.
/// </summary>
public abstract class Spot : WorldgenToken
{
    /// <summary>
    /// Approximate radius. Spots are always represented as circles.
    /// </summary>
    public readonly float Radius = 0;
}
