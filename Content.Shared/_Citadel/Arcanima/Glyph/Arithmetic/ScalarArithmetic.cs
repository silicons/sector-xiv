using Content.Shared._Citadel.Arcanima.Engine;
using Content.Shared._Citadel.Arcanima.Engine.Errors;
using Content.Shared._Citadel.Arcanima.Engine.Values;

namespace Content.Shared._Citadel.Arcanima.Glyph.Arithmetic;

internal static class ScalarArithmetic
{
    public static ExecutionResult Execute<TOperation>(ExecutionContext context)
        where TOperation : struct, IOperation
    {
        if (!context.Stack.TryPeekFromTop(1, out var firstOperand)
            || !context.Stack.TryPeekFromTop(0, out var secondOperand))
            return new ExecutionResult { Error = new InsufficientArgumentsError(2, context.Stack.Size) };

        var first = firstOperand.GetRef<ValueBase>();
        var second = secondOperand.GetRef<ValueBase>();
        ValueBase? result = (first, second) switch
        {
            (Number a, Number b) => new Number(TOperation.Apply(a.Value, b.Value)),
            (Vec2 a, Number b) => new Vec2(TOperation.Apply(a.X, b.Value), TOperation.Apply(a.Y, b.Value)),
            (Vec2 a, Vec2 b) => new Vec2(TOperation.Apply(a.X, b.X), TOperation.Apply(a.Y, b.Y)),
            (Vec3 a, Number b) => new Vec3(TOperation.Apply(a.X, b.Value),
                TOperation.Apply(a.Y, b.Value),
                TOperation.Apply(a.Z, b.Value)),
            (Vec3 a, Vec3 b) => new Vec3(TOperation.Apply(a.X, b.X),
                TOperation.Apply(a.Y, b.Y),
                TOperation.Apply(a.Z, b.Z)),
            (Vec4 a, Number b) => new Vec4(TOperation.Apply(a.X, b.Value),
                TOperation.Apply(a.Y, b.Value),
                TOperation.Apply(a.Z, b.Value),
                TOperation.Apply(a.W, b.Value)),
            (Vec4 a, Vec4 b) => new Vec4(TOperation.Apply(a.X, b.X),
                TOperation.Apply(a.Y, b.Y),
                TOperation.Apply(a.Z, b.Z),
                TOperation.Apply(a.W, b.W)),
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
                    : new BadInputTypeError(first.GetType(),
                        [typeof(Number), typeof(Vec2), typeof(Vec3), typeof(Vec4)],
                        1),
            };
        }

        context.Stack.Pop(2);
        context.Stack.Push(new ValueRef(result));
        return new ExecutionResult();
    }

    // Value-type specialization lets the JIT inline arithmetic without delegate dispatch.
    public interface IOperation
    {
        abstract static double Apply(double a, double b);
    }

    public readonly struct Add : IOperation
    {
        public static double Apply(double a, double b)
        {
            return a + b;
        }
    }

    public readonly struct Subtract : IOperation
    {
        public static double Apply(double a, double b)
        {
            return a - b;
        }
    }

    public readonly struct Multiply : IOperation
    {
        public static double Apply(double a, double b)
        {
            return a * b;
        }
    }

    public readonly struct Divide : IOperation
    {
        public static double Apply(double a, double b)
        {
            return a / b;
        }
    }
}
