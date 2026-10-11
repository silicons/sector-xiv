using Content.Shared._Citadel.Arcanima.Engine;

namespace Content.Shared._Citadel.Arcanima.Glyph.Memory;

/**
 * A glyph that loads a value from memory.
 */
public sealed class Load(Identifier id) : Engine.Glyph
{
    public override void Execute(CarrierThread thread)
    {
#warning Load.Execute is not implemented.
        throw new NotImplementedException();
    }
}
