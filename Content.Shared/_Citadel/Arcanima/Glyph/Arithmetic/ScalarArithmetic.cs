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

        var a = context.Stack.PeekFromTop(1);
        var b = context.Stack.PeekFromTop(0);
        ValueBase result;

        if (a.Is<Number>())
        {
            if (!b.Is<Number>())
            {
                return new ExecutionResult
                {
                    Error = new BadInputTypeError(b.GetRef<ValueBase>().GetType(), [typeof(Number)], 0),
                };
            }

            result = new Number(operation(a.GetRef<Number>().Value, b.GetRef<Number>().Value));
        }
        else if (a.Is<Vec2>())
        {
            var vector = a.GetRef<Vec2>();
            if (b.Is<Number>())
            {
                var scalar = b.GetRef<Number>().Value;
                result = new Vec2(operation(vector.X, scalar), operation(vector.Y, scalar));
            }
            else if (b.Is<Vec2>())
            {
                var other = b.GetRef<Vec2>();
                result = new Vec2(operation(vector.X, other.X), operation(vector.Y, other.Y));
            }
            else
            {
                return new ExecutionResult
                {
                    Error = new BadInputTypeError(b.GetRef<ValueBase>().GetType(), [typeof(Number), typeof(Vec2)], 0),
                };
            }
        }
        else
        {
            return new ExecutionResult
            {
                Error = new BadInputTypeError(a.GetRef<ValueBase>().GetType(), [typeof(Number), typeof(Vec2)], 1),
            };
        }

        context.Stack.Pop(2);
        context.Stack.Push(new ValueRef(result));
        return new ExecutionResult();
    }
}
