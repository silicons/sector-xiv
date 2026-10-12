using Content.Shared._Citadel.Arcanima.Engine;

namespace Content.Shared._Citadel.Arcanima.Glyph.Stack;

/**
 * A glyph that pushes a constant value onto the stack.
 */
public sealed class Push(ValueRef value) : Engine.Glyph
{
    private readonly ValueRef _value = value.Copy();

    public ValueRef GetValueCopy()
    {
        return _value.Copy();
    }

    public override ExecutionResult Execute(ExecutionContext context)
    {
        context.Stack.Push(GetValueCopy());
        return new ExecutionResult();
    }

    public override Engine.Glyph Copy()
    {
        return new Push(_value);
    }
}
