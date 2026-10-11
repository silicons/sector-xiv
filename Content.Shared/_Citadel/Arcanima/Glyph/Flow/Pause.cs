using Content.Shared._Citadel.Arcanima.Engine;

namespace Content.Shared._Citadel.Arcanima.Glyph.Flow;

/**
 * A glyph that causes the carrier to fully pause its evaluation loop.
 *
 * The carrier will still be able to react while paused.
 */
public sealed class Pause : Engine.Glyph
{
    public override ExecutionResult Execute(CarrierThread thread, ExecutionState state)
    {
#warning Pause.Execute is not implemented.
        throw new NotImplementedException();
    }
}
