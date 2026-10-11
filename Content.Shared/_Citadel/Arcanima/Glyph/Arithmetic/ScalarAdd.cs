using Content.Shared._Citadel.Arcanima.Engine;

namespace Content.Shared._Citadel.Arcanima.Glyph.Arithmetic;

/// <summary>
/// A glyph that adds two stack values, applying the operation componentwise to vectors.
/// The top of the stack is the second operand.
/// </summary>
public sealed class ScalarAdd : Engine.Glyph
{
    public override ExecutionResult Execute(ExecutionContext context)
    {
        return ScalarArithmetic.Execute(context, static (a, b) => a + b);
    }

    public override Engine.Glyph Copy()
    {
        return new ScalarAdd();
    }
}
