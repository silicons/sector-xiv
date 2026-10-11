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
    /// <br />
    /// <br />
    /// If set, the program may or may not be in a valid state.
    /// Glyphs generally should not modify the stack until after they've validated arguments, so
    /// it's likely that the program is still in a valid state, but this is not guaranteed.
    /// </summary>
    public Error? Error = null;
}
