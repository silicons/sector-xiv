using Content.Shared._Citadel.Arcanima.Engine;
using Content.Shared._Citadel.Arcanima.Engine.Errors;
using Content.Shared._Citadel.Arcanima.Engine.Values;

namespace Content.Shared._Citadel.Arcanima.Glyph.Memory;

/**
 * A glyph that stores a value in memory. The existing memory cell
 * will be overwritten with a copy and any references to it will see the new value.
 * <br />
 * <br />
 * <li>Arg 1 (TOP-1) - Memory Identifier (Ident)</li>
 * <li>Arg 2 (TOP) - Value</li>
 * <br />
 * On success, both operands are consumed and no result is pushed onto the stack.
 */
public sealed class Store : Engine.Glyph
{
    public override ExecutionResult Execute(ExecutionContext context)
    {
        if (!context.Stack.TryPeekFromTop(1, out var operand)
            || !context.Stack.TryPeekFromTop(0, out var value))
            return new ExecutionResult { Error = new InsufficientArgumentsError(2, context.Stack.Size) };

        var id = operand.GetMaybeRef<Ident>();
        if (id == null)
        {
            return new ExecutionResult
            {
                Error = new BadInputTypeError(operand.GetRef<ValueBase>().GetType(), [typeof(Ident)], 1),
            };
        }

        context.Memory.StoreValueCopy(id.Value, value);
        context.Stack.Pop(2);
        return new ExecutionResult();
    }

    public override Engine.Glyph Copy()
    {
        return new Store();
    }
}
