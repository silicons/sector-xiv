using Content.Shared._Citadel.Arcanima.Engine;
using Content.Shared._Citadel.Arcanima.Engine.Errors;

namespace Content.Shared._Citadel.Arcanima.Glyph.Stack;

/**
 * A glyph that removes a value from the stack.
 */
public sealed class Pop : Engine.Glyph
{
    public override ExecutionResult Execute(ExecutionContext context)
    {
        if (context.Stack.Size < 1)
            return new ExecutionResult { Error = new InsufficientArgumentsError(1, context.Stack.Size) };

        context.Stack.Pop();
        return new ExecutionResult();
    }

    public override Engine.Glyph Copy()
    {
        return new Pop();
    }
}
