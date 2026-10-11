namespace Content.Shared._Citadel.Arcanima.Engine;

/**
 * A set of instructions for a program to execute.
 */
public sealed class GlyphChain
{
    public GlyphChain(Identifier id, Glyph[] glyphs)
    {
        Id = id;
        Glyphs = glyphs;
    }

    /**
     * Array of glyphs that make up the chain.
     * <br />
     * <br />
     * At runtime, glyphs are executed in order, starting from the first glyph and moving to the last.
     * <br />
     * Glyphs may also jump to one another.
     */
    public Glyph[] Glyphs { get; }

    public Identifier Id { get; }
}
