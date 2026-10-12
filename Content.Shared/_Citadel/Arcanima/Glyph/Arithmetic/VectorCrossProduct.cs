using Content.Shared._Citadel.Arcanima.Engine;
using Content.Shared._Citadel.Arcanima.Engine.Errors;
using Content.Shared._Citadel.Arcanima.Engine.Values;

namespace Content.Shared._Citadel.Arcanima.Glyph.Arithmetic;

/**
 * A glyph that computes the cross product of two Vec3 vectors.
 * <br />
 * <br />
 * <li>Arg 1 (TOP-1) - First Vector (Vec3)</li>
 * <li>Arg 2 (TOP) - Second Vector (Vec3)</li>
 * <br />
 * On success, all operands are consumed and a single Vec3 result is pushed onto the stack.
 */
public sealed class VectorCrossProduct : Engine.Glyph
{
    public override ExecutionResult Execute(ExecutionContext context)
    {
        if (!context.Stack.TryPeekFromTop(1, out var first)
            || !context.Stack.TryPeekFromTop(0, out var second))
            return new ExecutionResult { Error = new InsufficientArgumentsError(2, context.Stack.Size) };

        if (!first.Is<Vec3>())
        {
            return new ExecutionResult
            {
                Error = new BadInputTypeError(first.GetRef<ValueBase>().GetType(), [typeof(Vec3)], 1),
            };
        }

        if (!second.Is<Vec3>())
        {
            return new ExecutionResult
            {
                Error = new BadInputTypeError(second.GetRef<ValueBase>().GetType(), [typeof(Vec3)], 0),
            };
        }

        var a = first.GetRef<Vec3>();
        var b = second.GetRef<Vec3>();
        var result = new Vec3(
            a.Y * b.Z - a.Z * b.Y,
            a.Z * b.X - a.X * b.Z,
            a.X * b.Y - a.Y * b.X);
        context.Stack.Pop(2);
        context.Stack.Push(new ValueRef(result));
        return new ExecutionResult();
    }

    public override Engine.Glyph Copy()
    {
        return new VectorCrossProduct();
    }
}
