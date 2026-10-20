using Content.Shared._Citadel.Arcanima.Engine;

namespace Content.Shared._Citadel.Arcanima.Glyph.Kinematic;

/**
 * A glyph that gets the carrier's velocity.
 */
public sealed class GetCarrierRelativeVelocity : Engine.Glyph
{
    public override ExecutionResult Execute(ExecutionContext context)
    {
#warning GetCarrierRelativeVelocity.Execute is not implemented.
        throw new NotImplementedException();
    }

    public override Engine.Glyph Copy()
    {
        return new GetCarrierRelativeVelocity();
    }
}
