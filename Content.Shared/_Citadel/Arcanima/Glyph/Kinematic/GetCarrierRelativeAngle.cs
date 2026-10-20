using Content.Shared._Citadel.Arcanima.Engine;

namespace Content.Shared._Citadel.Arcanima.Glyph.Kinematic;

/**
 * A glyph that gets the carrier's facing direction.
 */
public sealed class GetCarrierRelativeAngle : Engine.Glyph
{
    public override ExecutionResult Execute(ExecutionContext context)
    {
#warning GetCarrierRelativeAngle.Execute is not implemented.
        throw new NotImplementedException();
    }

    public override Engine.Glyph Copy()
    {
        return new GetCarrierRelativeAngle();
    }
}
