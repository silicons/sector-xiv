using Content.Shared._Citadel.Arcanima.Engine;

namespace Content.Shared._Citadel.Arcanima.Glyph.Flow;

/**
 * A glyph that performs a short jump.
 */
public sealed class ShortJump(int AbsoluteIdx) : Engine.Glyph
{
    public override ExecutionResult Execute(CarrierThread thread, ExecutionState state)
    {
#warning ShortJump.Execute is not implemented.
        throw new NotImplementedException();
    }
}
