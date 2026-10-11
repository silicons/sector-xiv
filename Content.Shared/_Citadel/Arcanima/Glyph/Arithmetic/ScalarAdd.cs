using Content.Shared._Citadel.Arcanima.Engine;

namespace Content.Shared._Citadel.Arcanima.Glyph.Arithmetic;

/**
 * A glyph that adds two values, applying the operation componentwise to vectors.
 * <br />
 * <br />
 * <li>Arg 1 (TOP-1) - Arg 1</li>
 * <li>Arg 2 (TOP) - Arg 2</li>
 * <br />
 * On success, all operands are consumed and a single result is pushed onto the stack.
 */
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
