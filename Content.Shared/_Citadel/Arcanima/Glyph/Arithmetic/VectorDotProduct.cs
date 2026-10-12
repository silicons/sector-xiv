using Content.Shared._Citadel.Arcanima.Engine;
using Content.Shared._Citadel.Arcanima.Engine.Errors;
using Content.Shared._Citadel.Arcanima.Engine.Values;

namespace Content.Shared._Citadel.Arcanima.Glyph.Arithmetic;

/**
 * A glyph that computes the dot product of two equal-length vectors.
 * <br />
 * <br />
 * <li>Arg 1 (TOP-1) - First Vector (Vec2, Vec3, or Vec4)</li>
 * <li>Arg 2 (TOP) - Second Vector (Vec2, Vec3, or Vec4)</li>
 * <br />
 * On success, all operands are consumed and a single Number result is pushed onto the stack.
 */
public sealed class VectorDotProduct : Engine.Glyph
{
    public override ExecutionResult Execute(ExecutionContext context)
    {
        if (!context.Stack.TryPeekFromTop(1, out var firstOperand)
            || !context.Stack.TryPeekFromTop(0, out var secondOperand))
            return new ExecutionResult { Error = new InsufficientArgumentsError(2, context.Stack.Size) };

        var first = firstOperand.GetRef<ValueBase>();
        var second = secondOperand.GetRef<ValueBase>();
        var result = (first, second) switch
        {
            (Vec2 a, Vec2 b) => new Number(a.X * b.X + a.Y * b.Y),
            (Vec3 a, Vec3 b) => new Number(a.X * b.X + a.Y * b.Y + a.Z * b.Z),
            (Vec4 a, Vec4 b) => new Number(a.X * b.X + a.Y * b.Y + a.Z * b.Z + a.W * b.W),
            _ => null,
        };

        if (result == null)
        {
            return new ExecutionResult
            {
                Error = first is Vec2 or Vec3 or Vec4
                    ? new BadInputTypeError(second.GetType(), [first.GetType()], 0)
                    : new BadInputTypeError(first.GetType(), [typeof(Vec2), typeof(Vec3), typeof(Vec4)], 1),
            };
        }

        context.Stack.Pop(2);
        context.Stack.Push(new ValueRef(result));
        return new ExecutionResult();
    }

    public override Engine.Glyph Copy()
    {
        return new VectorDotProduct();
    }
}
