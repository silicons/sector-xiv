namespace Content.Shared._Citadel.Worldgen.Engine.Tokens;

/// <summary>
/// A large fixture that takes up space.
/// <br />
/// <br />
/// Fixtures generally shouldn't overlap each other.
/// </summary>
public abstract class Fixture : WorldgenToken
{
    /// <summary>
    /// As physics units.
    /// </summary>
    public readonly float Height = 0;

    /// <summary>
    /// As degrees clockwise of north.
    /// </summary>
    public readonly float Rotation = 0;

    /// <summary>
    /// As physics units.
    /// </summary>
    public readonly float Width = 0;
}
