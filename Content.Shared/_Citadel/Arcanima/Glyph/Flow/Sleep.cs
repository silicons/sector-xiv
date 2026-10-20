using Content.Shared._Citadel.Arcanima.Engine;

namespace Content.Shared._Citadel.Arcanima.Glyph.Flow;

/**
 * A glyph that causes the carrier to pause its evaluation loop.
 *
 * The carrier will still be able to react while sleeping.
 */
public sealed class Sleep : Engine.Glyph
{
    public override ExecutionResult Execute(ExecutionContext context)
    {
#warning Sleep.Execute is not implemented.
        throw new NotImplementedException();
    }

    public override Engine.Glyph Copy()
    {
        return new Sleep();
    }
}
