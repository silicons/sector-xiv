namespace Content.Shared._Citadel.Arcanima.Engine.Errors;

/// <summary>
/// Incorrect identifier.
/// <br />
/// <br />
/// Usually from a bad memory load/store.
/// </summary>
public sealed class BadIdentifierError(Identifier used) : Error
{
    public readonly Identifier Identifier = used;
}
