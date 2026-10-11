using Content.Shared._Citadel.Arcanima.Engine;
using Content.Shared._Citadel.Arcanima.Engine.Errors;
using Content.Shared._Citadel.Arcanima.Engine.Values;

namespace Content.Shared._Citadel.Arcanima.Glyph.Arithmetic;

/// <summary>
/// A glyph that scales a vector to the length given by the number on top of the stack.
/// Zero vectors remain zero. Both arguments are consumed.
/// </summary>
public sealed class VectorNorm : Engine.Glyph
{
    public override ExecutionResult Execute(ExecutionContext context)
    {
        if (context.Stack.Size < 2)
            return new ExecutionResult { Error = new InsufficientArgumentsError(2, context.Stack.Size) };

        var vector = context.Stack.PeekFromTop(1);
        var norm = context.Stack.PeekFromTop(0);
        if (!vector.Is<Vec2>())
            return new ExecutionResult
            {
                Error = new BadInputTypeError(vector.GetRef<ValueBase>().GetType(), [typeof(Vec2)], 1),
            };

        if (!norm.Is<Number>())
            return new ExecutionResult
            {
                Error = new BadInputTypeError(norm.GetRef<ValueBase>().GetType(), [typeof(Number)], 0),
            };

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
