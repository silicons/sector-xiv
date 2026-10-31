namespace Content.Shared._Citadel.Worldgen.Engine.Tokens;

/// <summary>
/// A large fixture that takes up space.
/// <br />
/// <br />
/// Fixtures will stop each other from overlapping.
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
