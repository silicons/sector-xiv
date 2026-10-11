using Content.Shared._Citadel.Arcanima.Engine;

namespace Content.Shared._Citadel.Arcanima.Glyph.Arithmetic;

/**
 * A glyph that adds 2 values from the stack.
 */
public sealed class Add : Engine.Glyph
{
    public override ExecutionResult Execute(CarrierThread thread, ExecutionState state)
    {
#warning Add.Execute is not implemented.
        throw new NotImplementedException();
    }


    public override Engine.Glyph Copy()
    {
        return new Add();
    }
}
