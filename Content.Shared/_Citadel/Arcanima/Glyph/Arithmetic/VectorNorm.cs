using Content.Shared._Citadel.Arcanima.Engine;
using Content.Shared._Citadel.Arcanima.Engine.Errors;
using Content.Shared._Citadel.Arcanima.Engine.Values;

namespace Content.Shared._Citadel.Arcanima.Glyph.Arithmetic;

/**
 * A glyph that scales a vector to a target length. Zero vectors remain zero.
 * <br />
 * <br />
 * <li>Arg 1 (TOP-1) - Vector (Vec2)</li>
 * <li>Arg 2 (TOP) - Target Length (Number)</li>
 * <br />
 * On success, all operands are consumed and a single result is pushed onto the stack.
 */
public sealed class VectorNorm : Engine.Glyph
{
    public override ExecutionResult Execute(ExecutionContext context)
    {
        if (!context.Stack.TryPeekFromTop(1, out var vector)
            || !context.Stack.TryPeekFromTop(0, out var norm))
            return new ExecutionResult { Error = new InsufficientArgumentsError(2, context.Stack.Size) };

        if (!vector.Is<Vec2>())
        {
            return new ExecutionResult
            {
                Error = new BadInputTypeError(vector.GetRef<ValueBase>().GetType(), [typeof(Vec2)], 1),
            };
        }

        if (!norm.Is<Number>())
        {
            return new ExecutionResult
            {
                Error = new BadInputTypeError(norm.GetRef<ValueBase>().GetType(), [typeof(Number)], 0),
            };
        }

        var value = vector.GetRef<Vec2>();
        var targetLength = norm.GetRef<Number>().Value;
        var length = double.Hypot(value.X, value.Y);
        var result = length == 0
            ? new Vec2(0, 0)
            : new Vec2(value.X / length * targetLength, value.Y / length * targetLength);
        context.Stack.Pop(2);
        context.Stack.Push(new ValueRef(result));
        return new ExecutionResult();
    }

    public override Engine.Glyph Copy()
    {
        return new VectorNorm();
    }
}
