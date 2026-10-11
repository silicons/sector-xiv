using Content.Shared._Citadel.Arcanima.Engine;

namespace Content.Shared._Citadel.Arcanima.Glyph.Arithmetic;

/**
 * A glyph that divides the first value by the second, applying the operation componentwise to vectors.
 * <br />
 * <br />
 * <li>Arg 1 (TOP-1) - Dividend</li>
 * <li>Arg 2 (TOP) - Divisor</li>
 * <br />
 * On success, all operands are consumed and a single result is pushed onto the stack.
 */
public sealed class ScalarDivide : Engine.Glyph
{
    public override ExecutionResult Execute(ExecutionContext context)
    {
        return ScalarArithmetic.Execute(context, static (a, b) => a / b);
    }

    public override Engine.Glyph Copy()
    {
        return new ScalarDivide();
    }
}
