using Content.Shared._Citadel.Arcanima.Engine;

namespace Content.Shared._Citadel.Arcanima.Glyph.Arithmetic;

/**
 * A glyph that adds two values, applying the operation componentwise to vectors.
 * <br />
 * <br />
 * <li>Arg 1 (TOP-1) - Arg 1</li>
 * <li>Arg 2 (TOP) - Arg 2</li>
 * <br />
 * If the first operand is a vector and the second is a Number, the Number is coerced
 * to a vector of the same size with that value in every component.
 * If both operands are vectors, they must be the same size.
 * <br />
 * On success, a single result replaces the first operand and the second operand is consumed.
 * If the first operand is indirect, its memory slot is updated and the reference remains on the stack.
 */
public sealed class ScalarAdd : Engine.Glyph
{
    public override ExecutionResult Execute(ExecutionContext context)
    {
        return ScalarArithmetic.Execute<ScalarArithmetic.Add>(context);
    }

    public override Engine.Glyph Copy()
    {
        return new ScalarAdd();
    }
}
