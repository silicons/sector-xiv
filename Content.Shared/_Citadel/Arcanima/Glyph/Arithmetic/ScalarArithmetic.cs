using Content.Shared._Citadel.Arcanima.Engine;
using Content.Shared._Citadel.Arcanima.Engine.Errors;
using Content.Shared._Citadel.Arcanima.Engine.Values;

namespace Content.Shared._Citadel.Arcanima.Glyph.Arithmetic;

internal static class ScalarArithmetic
{
    public static ExecutionResult Execute(ExecutionContext context, Func<double, double, double> operation)
    {
        if (context.Stack.Size < 2)
            return new ExecutionResult { Error = new InsufficientArgumentsError(2, context.Stack.Size) };

        var first = context.Stack.PeekFromTop(1).GetRef<ValueBase>();
        var second = context.Stack.PeekFromTop(0).GetRef<ValueBase>();
        ValueBase? result = (first, second) switch
        {
            (Number a, Number b) => new Number(operation(a.Value, b.Value)),
            (Vec2 a, Number b) => new Vec2(operation(a.X, b.Value), operation(a.Y, b.Value)),
            (Vec2 a, Vec2 b) => new Vec2(operation(a.X, b.X), operation(a.Y, b.Y)),
            (Vec3 a, Number b) => new Vec3(operation(a.X, b.Value), operation(a.Y, b.Value), operation(a.Z, b.Value)),
            (Vec3 a, Vec3 b) => new Vec3(operation(a.X, b.X), operation(a.Y, b.Y), operation(a.Z, b.Z)),
            (Vec4 a, Number b) => new Vec4(operation(a.X, b.Value), operation(a.Y, b.Value), operation(a.Z, b.Value), operation(a.W, b.Value)),
            (Vec4 a, Vec4 b) => new Vec4(operation(a.X, b.X), operation(a.Y, b.Y), operation(a.Z, b.Z), operation(a.W, b.W)),
            _ => null,
        };

        if (result == null)
        {
            Type[]? expected = first switch
            {
                Number => [typeof(Number)],
                Vec2 => [typeof(Number), typeof(Vec2)],
                Vec3 => [typeof(Number), typeof(Vec3)],
                Vec4 => [typeof(Number), typeof(Vec4)],
                _ => null,
            };
            return new ExecutionResult
            {
                Error = expected != null
                    ? new BadInputTypeError(second.GetType(), expected, 0)
                    : new BadInputTypeError(first.GetType(), [typeof(Number), typeof(Vec2), typeof(Vec3), typeof(Vec4)], 1),
            };
        }

        context.Stack.Pop(2);
        context.Stack.Push(new ValueRef(result));
        return new ExecutionResult();
    }
}
