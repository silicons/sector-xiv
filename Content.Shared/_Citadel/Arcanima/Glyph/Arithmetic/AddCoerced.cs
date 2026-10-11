using Content.Shared._Citadel.Arcanima.Engine;
using Content.Shared._Citadel.Arcanima.Engine.Errors;
using Content.Shared._Citadel.Arcanima.Engine.Values;

namespace Content.Shared._Citadel.Arcanima.Glyph.Arithmetic;

/**
 * A glyph that adds 2 values from the stack.
 * <br />
 * This will coerce the second value to the type of the first value if possible.
 * If the coercion is not possible, an error will be returned.
 * <br />
 * The result will be pushed onto the stack, with the operands consumed.
 */
public sealed class AddCoerced : Engine.Glyph
{
    public override ExecutionResult Execute(ExecutionContext context)
    {
        if (context.Stack.Size < 2)
            return new ExecutionResult { Error = new InsufficientArgumentsError(2, context.Stack.Size) };

        var a = context.Stack.PeekFromTop(1);
        var b = context.Stack.PeekFromTop(0);

        // Coerce b to the type of a if possible
        // this is mildly miserable in terms of speed, but,
        // discriminated unions are coming in .NET11 and will save this
        //
        // (at time of writing, it is october 2026)
        // (i wouldn't be surprised if this system isn't done in 2027.)
        if (a.Is<Number>())
        {
            if (b.Is<Number>())
            {
                var result = a.GetRef<Number>().Value + b.GetRef<Number>().Value;
                context.Stack.Pop(2);
                context.Stack.Push(new ValueRef(new Number(result)));
            }
            else
            {
                return new ExecutionResult
                {
                    Error = new BadInputTypeError(b.GetType(), [typeof(Number)], 0),
                };
            }
        }
        else if (a.Is<Text>())
        {
            if (b.Is<Text>())
            {
                var result = a.GetRef<Text>().Value + b.GetRef<Text>().Value;
                context.Stack.Pop(2);
                context.Stack.Push(new ValueRef(new Text(result)));
            }
            else
            {
                return new ExecutionResult
                {
                    Error = new BadInputTypeError(b.GetType(), [typeof(Text)], 0),
                };
            }
        }
        else if (a.Is<Vec2>())
        {
            var casted = a.GetRef<Vec2>();
            if (b.Is<Number>())
            {
                var adding = b.GetRef<Number>().Value;
                context.Stack.Pop(2);
                context.Stack.Push(new ValueRef(new Vec2(casted.X + adding, casted.Y + adding)));
            }
            else if (b.Is<Vec2>())
            {
                var adding = b.GetRef<Vec2>();
                context.Stack.Pop(2);
                context.Stack.Push(new ValueRef(new Vec2(casted.X + adding.X, casted.Y + adding.Y)));
            }
            else
            {
                return new ExecutionResult
                {
                    Error = new BadInputTypeError(b.GetType(), [typeof(Number), typeof(Vec2)], 0),
                };
            }
        }

        return new ExecutionResult();
    }


    public override Engine.Glyph Copy()
    {
        return new AddCoerced();
    }
}
