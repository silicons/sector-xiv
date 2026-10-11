using Content.Shared._Citadel.Arcanima.Engine;

namespace Content.Shared._Citadel.Arcanima.Glyph.Arithmetic;

/**
 * A glyph that subtracts the second value from the first, applying the operation componentwise to vectors.
 * <br />
 * <br />
 * <li>Arg 1 (TOP-1) - Number</li>
 * <li>Arg 2 (TOP) - Subtract By</li>
 * <br />
 * On success, all operands are consumed and a single result is pushed onto the stack.
 */
public sealed class ScalarSubtract : Engine.Glyph
{
    public override ExecutionResult Execute(ExecutionContext context)
    {
        return ScalarArithmetic.Execute(context, static (a, b) => a - b);
    }

    public override Engine.Glyph Copy()
    {
        return new ScalarSubtract();
    }
}
