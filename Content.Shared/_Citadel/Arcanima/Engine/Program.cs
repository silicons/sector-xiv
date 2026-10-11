using System.Collections.Immutable;

namespace Content.Shared._Citadel.Arcanima.Engine;

/**
 * A compiled program.
 * <br />
 * <br />
 * Compiled programs are immutable.
 */
public sealed class Program
{
    public Program(ProgramBuilder builder)
    {
    }

    /**
     * Glyph chains by ID.
     */
    public ImmutableDictionary<Identifier, GlyphChain> GlyphChains { get; }
}
