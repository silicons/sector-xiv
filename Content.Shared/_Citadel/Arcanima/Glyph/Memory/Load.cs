using Content.Shared._Citadel.Arcanima.Engine;
using Content.Shared._Citadel.Arcanima.Engine.Errors;
using Content.Shared._Citadel.Arcanima.Engine.Values;

namespace Content.Shared._Citadel.Arcanima.Glyph.Memory;

/**
 * A glyph that loads an independent copy of a memory value.
 * <br />
 * <br />
 * <li>Arg 1 (TOP) - Memory Identifier (Ident)</li>
 * <br />
 * On success, the identifier is consumed and replaced by the copied value.
 */
public sealed class Load : Engine.Glyph
{
    public override ExecutionResult Execute(ExecutionContext context)
    {
        if (!context.Stack.TryPeekFromTop(0, out var operand))
            return new ExecutionResult { Error = new InsufficientArgumentsError(1, context.Stack.Size) };

        var id = operand.GetMaybeRef<Ident>();
        if (id == null)
        {
            return new ExecutionResult
            {
                Error = new BadInputTypeError(operand.GetRef<ValueBase>().GetType(), [typeof(Ident)], 0),
            };
        }

        if (!context.Memory.TryGetValueCopy(id.Value, out var value))
            return new ExecutionResult { Error = new BadIdentifierError(id.Value) };

        context.Stack.Pop();
        context.Stack.Push(value);
        return new ExecutionResult();
    }

    public override Engine.Glyph Copy()
    {
        return new Load();
    }
}
