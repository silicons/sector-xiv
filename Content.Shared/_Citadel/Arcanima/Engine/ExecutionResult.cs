using Content.Shared._Citadel.Arcanima.Engine.Errors;

namespace Content.Shared._Citadel.Arcanima.Engine;

/// <summary>
/// Execution result from a glyph.
/// </summary>
public ref struct ExecutionResult()
{
    /// <summary>
    /// If set, jump to target instead of continuing to the next glyph in the chain.
    /// <br />
    /// <br />
    /// This is in ExecutionResult instead of as a Glyph side effect with the thread / state because
    /// glyphs should generally not mess with thread/state.
    /// <br />
    /// <br />
    /// I know C# has no such thing as 'undefined behavior', but undefined behavior may occur if you
    /// return a jump to a target that is not in the Program.
    /// </summary>
    public JumpTarget? JumpTo = null;

    /// <summary>
    /// The error that occurred during execution, if any.
    /// </summary>
    public Error? Error = null;
}
