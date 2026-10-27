namespace Content.Shared._Citadel.Worldgen.Engine;

/// <summary>
/// An output for a worldgen request.
/// </summary>
public sealed class WorldgenOutput
{
    public List<WorldgenOutputToken> Tokens = new();
}
