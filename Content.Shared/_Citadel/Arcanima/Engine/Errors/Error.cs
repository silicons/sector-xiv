namespace Content.Shared._Citadel.Arcanima.Engine.Errors;

/// <summary>
/// Errors. ExecutionResult does not necessarily have one; that way we only heap-allocate
/// upon getting one.
/// </summary>
public abstract class Error
{
    public abstract string Format();
}
