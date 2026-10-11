namespace Content.Shared._Citadel.Arcanima.Engine;

/**
 * A program builder to compile a program.
 * <br />
 * <br />
 * Arcanima programs are immutable once compiled.
 */
public sealed class ProgramBuilder
{
    public Dictionary<Identifier, GlyphChain> GlyphChains { get; } = new();
}
