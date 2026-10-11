using Content.Shared._Citadel.Arcanima.Engine;

namespace Content.Shared._Citadel.Arcanima.Glyph.Stack;

/**
 * A glyph that pushes a constant value onto the stack.
 */
public sealed class Push(ValueRef value) : Engine.Glyph
{
    private ValueRef _value = value.Copy();

    public ValueRef GetValueCopy()
    {
        return _value.Copy();
    }

    public override void Execute(Engine.Carrier carrier)
    {
#warning Push.Execute is not implemented.
        throw new NotImplementedException();
    }
}
