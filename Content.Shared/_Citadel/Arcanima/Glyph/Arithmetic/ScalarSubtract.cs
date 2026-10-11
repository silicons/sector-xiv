using Content.Shared._Citadel.Arcanima.Engine;

namespace Content.Shared._Citadel.Arcanima.Glyph.Arithmetic;

/**
 * A glyph that subtracts the second value from the first, applying the operation componentwise to vectors.
 * <br />
 * <br />
 * <li>Arg 1 (TOP-1) - Number</li>
 * <li>Arg 2 (TOP) - Subtract By</li>
 * <br />
 * If the first operand is a vector and the second is a Number, the Number is coerced
 * to a vector of the same size with that value in every component.
 * If both operands are vectors, they must be the same size.
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
