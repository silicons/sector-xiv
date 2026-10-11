namespace Content.Shared._Citadel.Arcanima.Engine.Errors;

/// <summary>
/// Incorrect / invalid identifier.
/// <br />
/// <br />
/// Usually from a bad memory load/store or a bad long jump.
/// </summary>
public sealed class BadIdentifierError(Identifier used) : Error
{
    public readonly Identifier Identifier = used;
}
